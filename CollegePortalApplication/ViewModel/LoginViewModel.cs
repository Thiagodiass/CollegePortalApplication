using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using CollegePortalApplication.Views.Administrator;
using CollegePortalApplication.Views.Administrator.DetailPages;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IPageService _pageService;
        private IStudent _studentStore;
        private IStaff _staffStore;
        private bool _isDataLoaded;

        public ObservableCollection<StudentTableViewModel> Students { get; private set; } = new ObservableCollection<StudentTableViewModel>();
        public ObservableCollection<StaffTableViewModel> Staffs { get; private set; } = new ObservableCollection<StaffTableViewModel>();
        public event EventHandler<Login> LoginCheck;

        public Login Login { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }

        public LoginViewModel(LoginTableViewModel viewModel, IStudent studentStore, IStaff staffStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _studentStore = studentStore;
            _staffStore = staffStore;
            _pageService = pageService;
            LoadDataCommand = new Command(async () => await LoadData());
            LoginCommand = new Command(async () => await CheckLogin());

            Login = new Login
            {
                login = viewModel.Login,
                password = viewModel.Password
            };

        }
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var student = await _studentStore.GetStudentsAsync();
            var staff = await _staffStore.GetStaffsAsync();

            foreach (var sf in staff)
                Staffs.Add(new StaffTableViewModel(sf));

            foreach (var s in student)
                Students.Add(new StudentTableViewModel(s));
        }

        async Task CheckLogin()
        {
            var search = 0;
            if (String.IsNullOrEmpty(Login.login)
                && String.IsNullOrEmpty(Login.password))
            {
                await _pageService.DisplayAlert("Error", "Empty Login Try Again", "OK");
                return;
            }
            if(search == 0)
            {
                foreach (var s in Staffs)
                {
                    if (s.StaffID.Equals(Login.login) && s.Password.Equals(Login.password))
                    {
                        search = 1;
                        var AccountType = s.AccountType;
                        if (AccountType.Equals("UA2"))
                        {
                            await _pageService.PushAsync(new AdministratorOptionPage());
                        }
                        if (AccountType.Equals("UA3"))
                        {
                            await _pageService.PushAsync(new AdministratorOptionPage());
                        }
                    }
                }
            }


            if (search == 0)
            {
                foreach (var st in Students)
                {
                    if (st.StudentID.Equals(Login.login) && st.Password.Equals(Login.password))
                    {
                        search = 1;
                        var AccountType = st.AccountType;
                        if (AccountType.Equals("UA1"))
                        {
                            await _pageService.PushAsync(new AdministratorOptionPage());
                        }
                        if (AccountType.Equals("UA2"))
                        {
                            await _pageService.PushAsync(new AdministratorOptionPage());
                        }
                    }
                }
            }

            if (search == 0)
            {
                await _pageService.DisplayAlert("Error", "Invalid Login Try again", "OK"); 
            }
        }
    } 
}
