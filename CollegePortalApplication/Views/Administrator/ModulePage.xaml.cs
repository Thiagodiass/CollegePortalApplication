using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class ModulePage : ContentPage
    {
        public ModulePage()
        {
            var moduleStore = new SQLiteModuleStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ModuleViewModel(moduleStore, pageService);

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
            ViewModel.SelectModule.Execute(e.SelectedItem);
        }

        public ModuleViewModel ViewModel
        {
            get { return BindingContext as ModuleViewModel; }
            set { BindingContext = value; }
        }
    }
}
