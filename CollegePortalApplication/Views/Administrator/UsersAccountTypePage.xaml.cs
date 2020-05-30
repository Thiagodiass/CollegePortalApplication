using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class UsersAccountTypePage : ContentPage
    {
        //UsersAccountTypeViewModel vm;
        public UsersAccountTypePage()
        {
            var userAccountStore = new SQLiteUsersAccountTypeStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new UsersAccountTypeViewModel(userAccountStore, pageService);

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
            ViewModel.SelectUserAccountType.Execute(e.SelectedItem);
        }

        public UsersAccountTypeViewModel ViewModel
        {
            get { return BindingContext as UsersAccountTypeViewModel; }
            set { BindingContext = value; }
        }
    }
}
