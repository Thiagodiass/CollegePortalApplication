using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;


namespace CollegePortalApplication.Views.Administrator
{
    public partial class ActivitiesPage : ContentPage
    {
        public ActivitiesPage()
        {
            var activitiesStore = new SQLiteActivitiesStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ActivitiesViewModel(activitiesStore, pageService);

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
            ViewModel.SelectActivity.Execute(e.SelectedItem);
        }

        public ActivitiesViewModel ViewModel
        {
            get { return BindingContext as ActivitiesViewModel; }
            set { BindingContext = value; }
        }
    }
}
