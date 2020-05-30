using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class LoginTableViewModel : BaseViewModel
    {
        public LoginTableViewModel(Login login)
        {
            Login = login.login;
            Password = login.password;
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                SetValue(ref _login, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetValue(ref _password, value);
            }
        }
        public LoginTableViewModel()
        {
        }
    }
}
