using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using CollegePortalApplication.Views;
using CollegePortalApplication.Views.Administrator.DetailPages;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel
{
    public class StartViewModel
    {
        private IPageService _pageService;
        private IStudent _studentStore;
        private IStaff _staffStore;
        private bool _isDataLoaded;

        public ObservableCollection<StudentTableViewModel> Students { get; private set; } = new ObservableCollection<StudentTableViewModel>();
        public ObservableCollection<StaffTableViewModel> Staffs { get; private set; } = new ObservableCollection<StaffTableViewModel>();
        public ICommand LoadDataCommand { get; private set; }
        public ICommand Login { get; private set; }

        public StartViewModel(IStudent studentStore, IStaff staffStore, IPageService pageService)
        {
            _staffStore = staffStore;
            _studentStore = studentStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            Login = new Command(async () => await LoginPage());
            
        }

        private async Task LoginPage()
        {
            var viewModel = new LoginViewModel(new LoginTableViewModel(), _studentStore, _staffStore, _pageService);

            await _pageService.PushAsync(new LoginPage(viewModel));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var student = await _studentStore.GetStudentsAsync();
            var staff = await _staffStore.GetStaffsAsync();

            foreach (var st in staff)
                Staffs.Add(new StaffTableViewModel(st));

            foreach (var s in student)
                Students.Add(new StudentTableViewModel(s));

        }
    }
}
