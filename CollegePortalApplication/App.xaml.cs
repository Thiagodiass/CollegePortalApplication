using System;
using CollegePortalApplication.Helper;
using CollegePortalApplication.Services;
using CollegePortalApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegePortalApplication
{
    public partial class App : Application
    {
        string dbPathUsersAccountType => FileAccessHelper.GetLocalFilePath("usersAccountType.db3");
        public static UsersAccountTypeRepository UsersAccountTypeRepo{ get; private set; }

        public App()
        {
            InitializeComponent();

            UsersAccountTypeRepo = new UsersAccountTypeRepository(dbPathUsersAccountType);

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
