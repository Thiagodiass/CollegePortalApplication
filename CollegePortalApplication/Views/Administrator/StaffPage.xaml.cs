using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class StaffPage : ContentPage
    {
        public StaffPage()
        {
            var staffStore = new SQLiteStaffStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new StaffViewModel(staffStore, pageService);

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
            ViewModel.SelectStaff.Execute(e.SelectedItem);
        }

        public StaffViewModel ViewModel
        {
            get { return BindingContext as StaffViewModel; }
            set { BindingContext = value; }
        }
    }
}
