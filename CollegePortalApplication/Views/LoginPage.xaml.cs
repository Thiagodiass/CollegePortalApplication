using CollegePortalApplication.Model;
using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using CollegePortalApplication.Views.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views
{
    public partial class LoginPage : ContentPage
    {
        //LoginViewModel ViewModel => BindingContext as LoginViewModel;
        public LoginPage(LoginViewModel viewModel)
        {
            
            InitializeComponent();
            BindingContext = viewModel;
            image.Source = ImageSource.FromResource("CollegePortalApplication.Images.logo.jpg");
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
        public LoginViewModel ViewModel
        {
            get { return BindingContext as LoginViewModel; }
            set { BindingContext = value; }
        }
    }
}
