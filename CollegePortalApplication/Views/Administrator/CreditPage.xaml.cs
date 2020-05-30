using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;


namespace CollegePortalApplication.Views.Administrator
{
    public partial class CreditPage : ContentPage
    {
        public CreditPage()
        {
            var creditStore = new SQLiteCreditStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new CreditViewModel(creditStore, pageService);

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
            ViewModel.SelectCredit.Execute(e.SelectedItem);
        }

        public CreditViewModel ViewModel
        {
            get { return BindingContext as CreditViewModel; }
            set { BindingContext = value; }
        }
    }
}
