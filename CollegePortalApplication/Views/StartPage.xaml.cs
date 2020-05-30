using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            var studentStore = new SQLiteStudentStore(DependencyService.Get<ISQLiteDb>());
            var staffStore = new SQLiteStaffStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new StartViewModel(studentStore, staffStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        public StartViewModel ViewModel
        {
            get { return BindingContext as StartViewModel; }
            set { BindingContext = value; }
        }
    }
}
