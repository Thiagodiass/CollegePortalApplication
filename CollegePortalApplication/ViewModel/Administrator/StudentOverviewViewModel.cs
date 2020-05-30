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
    public class StudentOverviewViewModel : BaseViewModel
    {
        private StudentOverviewTableViewModel _selectedStudentOverview;
        private IStudentOverview _studentOverviewStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<StudentOverviewTableViewModel> StudentOverviews { get; private set; } = new ObservableCollection<StudentOverviewTableViewModel>();

        public StudentOverviewTableViewModel SelectedStudentOverview
        {
            get { return _selectedStudentOverview; }
            set { SetValue(ref _selectedStudentOverview, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddStudentOverview { get; private set; }
        public ICommand SelectStudentOverview { get; private set; }
        public ICommand DeleteStudentOverview { get; private set; }

        public StudentOverviewViewModel(IStudentOverview studentOverviewStore, IPageService pageService)
        {
            _studentOverviewStore = studentOverviewStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddStudentOverview = new Command(async () => await AddStudentOverviews());
            SelectStudentOverview = new Command<StudentOverviewTableViewModel>(async s => await SelectStudentOverviews(s));
            DeleteStudentOverview = new Command<StudentOverviewTableViewModel>(async s => await DeleteStudentOverviews(s));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var studentOverview = await _studentOverviewStore.GetStudentOverviewsAsync();

            foreach (var s in studentOverview)
                StudentOverviews.Add(new StudentOverviewTableViewModel(s));
        }

        private async Task AddStudentOverviews()
        {
            var viewModel = new StudentOverviewDetailViewModel(new StudentOverviewTableViewModel(), _studentOverviewStore, _pageService);

            viewModel.StudentOverviewAdded += (source, studentOverview) =>
            {
                StudentOverviews.Add(new StudentOverviewTableViewModel(studentOverview));
            };

            await _pageService.PushModalAsync(new StudentOverviewDetailPage(viewModel));
        }

        private async Task SelectStudentOverviews(StudentOverviewTableViewModel studentOverview)
        {
            if (studentOverview == null)
                return;

            SelectedStudentOverview = null;

            var viewModel = new StudentOverviewDetailViewModel(studentOverview, _studentOverviewStore, _pageService);
            viewModel.StudentOverviewUpdated += (source, updateStudentOverview) =>
            {
                studentOverview.Id = updateStudentOverview.id;
                studentOverview.StudentID = updateStudentOverview.studentID;
                studentOverview.Semester = updateStudentOverview.semester;
                studentOverview.Attendance = updateStudentOverview.attendance;
                studentOverview.Grade = updateStudentOverview.grade;
                studentOverview.ModuleID = updateStudentOverview.moduleID;
                studentOverview.Year = updateStudentOverview.year;

            };

            await _pageService.PushModalAsync(new StudentOverviewDetailPage(viewModel));
        }

        private async Task DeleteStudentOverviews(StudentOverviewTableViewModel studentOverview)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{studentOverview.StudentID}?", "Yes", "No"))
            {
                StudentOverviews.Remove(studentOverview);
                var userStudentOverview = await _studentOverviewStore.GetStudentOverviews(studentOverview.Id);
                await _studentOverviewStore.DeleteStudentOverview(userStudentOverview);
            }
        }
    }
}
