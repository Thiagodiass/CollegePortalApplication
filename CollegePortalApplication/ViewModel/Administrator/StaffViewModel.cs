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
    public class StaffViewModel : BaseViewModel
    {
        private StaffTableViewModel _selectedStaff;
        private IStaff _staffStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<StaffTableViewModel> Staffs { get; private set; } = new ObservableCollection<StaffTableViewModel>();

        public StaffTableViewModel SelectedStaff
        {
            get { return _selectedStaff; }
            set { SetValue(ref _selectedStaff, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddStaff { get; private set; }
        public ICommand SelectStaff { get; private set; }
        public ICommand DeleteStaff { get; private set; }

        public StaffViewModel(IStaff staffStore, IPageService pageService)
        {
            _staffStore = staffStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddStaff = new Command(async () => await AddStaffs());
            SelectStaff = new Command<StaffTableViewModel>(async s => await SelectStaffs(s));
            DeleteStaff = new Command<StaffTableViewModel>(async s => await DeleteStaffs(s));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var staff = await _staffStore.GetStaffsAsync();

            foreach (var s in staff)
                Staffs.Add(new StaffTableViewModel(s));
        }

        private async Task AddStaffs()
        {
            var viewModel = new StaffDetailViewModel(new StaffTableViewModel(), _staffStore, _pageService);

            viewModel.StaffAdded += (source, staff) =>
            {
                Staffs.Add(new StaffTableViewModel(staff));
            };

            await _pageService.PushModalAsync(new StaffDetailPage(viewModel));
        }

        private async Task SelectStaffs(StaffTableViewModel staff)
        {
            if (staff == null)
                return;

            SelectedStaff = null;

            var viewModel = new StaffDetailViewModel(staff, _staffStore, _pageService);
            viewModel.StaffUpdated += (source, updateStaff) =>
            {
                staff.Id = updateStaff.id;
                
            };

            await _pageService.PushModalAsync(new StaffDetailPage(viewModel));
        }

        private async Task DeleteStaffs(StaffTableViewModel staff)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{staff.StaffID}?", "Yes", "No"))
            {
                Staffs.Remove(staff);
                var userStaff = await _staffStore.GetStaffs(staff.Id);
                await _staffStore.DeleteStaff(userStaff);
            }
        }
    }
}
