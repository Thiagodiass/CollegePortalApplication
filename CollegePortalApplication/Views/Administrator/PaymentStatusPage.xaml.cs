using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class PaymentStatusPage : ContentPage
    {
        public PaymentStatusPage()
        {
            var paymentStatusStore = new SQLitePaymentStatusStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new PaymentStatusViewModel(paymentStatusStore, pageService);

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
            ViewModel.SelectPaymentStatus.Execute(e.SelectedItem);
        }

        public PaymentStatusViewModel ViewModel
        {
            get { return BindingContext as PaymentStatusViewModel; }
            set { BindingContext = value; }
        }
    }
}
