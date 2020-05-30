using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;


namespace CollegePortalApplication.Views.Administrator
{
    public partial class AttendancePage : ContentPage
    {
        public AttendancePage()
        {
            var attendanceStore = new SQLiteAttendanceStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new AttendanceViewModel(attendanceStore, pageService);

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
            ViewModel.SelectAttendance.Execute(e.SelectedItem);
        }

        public AttendanceViewModel ViewModel
        {
            get { return BindingContext as AttendanceViewModel; }
            set { BindingContext = value; }
        }
    }
}
