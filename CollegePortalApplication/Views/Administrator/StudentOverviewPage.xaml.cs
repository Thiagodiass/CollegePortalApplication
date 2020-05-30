using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class StudentOverviewPage : ContentPage
    {
        public StudentOverviewPage()
        {
            var studentOverviewStore = new SQLiteStudentOverviewStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new StudentOverviewViewModel(studentOverviewStore, pageService);

            InitializeComponent();
        }

        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectStudentOverview.Execute(e.SelectedItem);
        }

        public StudentOverviewViewModel ViewModel
        {
            get { return BindingContext as StudentOverviewViewModel; }
            set { BindingContext = value; }
        }
    }
}
