using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using CollegePortalApplication.Views.Administrator.DetailPages;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class ActivitiesViewModel : BaseViewModel
    {
        private ActivitiesTableViewModel _selectedActivity;
        private IActivitiesStore _activitiesStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<ActivitiesTableViewModel> Activities { get; private set; } = new ObservableCollection<ActivitiesTableViewModel>();

        public ActivitiesTableViewModel SelectedActivity
        {
            get { return _selectedActivity; }
            set { SetValue(ref _selectedActivity, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddActivity { get; private set; }
        public ICommand SelectActivity { get; private set; }
        public ICommand DeleteActivity { get; private set; }


        public ActivitiesViewModel(IActivitiesStore activitiesStore, IPageService pageService)
        {
            _activitiesStore = activitiesStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddActivity = new Command(async () => await AddActivities());
            SelectActivity = new Command<ActivitiesTableViewModel>(async c => await SelectActivities(c));
            DeleteActivity = new Command<ActivitiesTableViewModel>(async c => await DeleteActivities(c));
        }
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var activities = await _activitiesStore.GetActivitiesAsync();

            foreach (var a in activities)
                Activities.Add(new ActivitiesTableViewModel(a));
        }

        private async Task AddActivities()
        {
            var viewModel = new ActivitiesDetailViewModel(new ActivitiesTableViewModel(), _activitiesStore, _pageService);

            viewModel.ActivityAdded += (source, activity) =>
            {
                Activities.Add(new ActivitiesTableViewModel(activity));
            };

            await _pageService.PushModalAsync(new ActivitiesDetailPage(viewModel));
        }

        private async Task SelectActivities(ActivitiesTableViewModel activities)
        {
            if (activities == null)
                return;

            SelectedActivity = null;

            var viewModel = new ActivitiesDetailViewModel(activities, _activitiesStore, _pageService);
            viewModel.ActivityUpdated += (source, updateActivity) =>
            {
                activities.Id = updateActivity.id;
                activities.StudentID = updateActivity.studentID;
                activities.ModuleID = updateActivity.moduleID;
                activities.Grade = updateActivity.grade;
                activities.DueDate = updateActivity.dueDate;
                activities.Weight = updateActivity.weight;
                activities.Type = updateActivity.type;
            };

            await _pageService.PushModalAsync(new ActivitiesDetailPage(viewModel));
        }

        private async Task DeleteActivities(ActivitiesTableViewModel activities)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {activities.StudentID}?", "Yes", "No"))
            {
                Activities.Remove(activities);
                var userActivity = await _activitiesStore.GetActivities(activities.Id);
                await _activitiesStore.DeleteActivity(userActivity);
            }
        }

    }
}
