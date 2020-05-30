using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            var studentStore = new SQLiteStudentStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new StudentViewModel(studentStore, pageService);

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
            ViewModel.SelectStudent.Execute(e.SelectedItem);
        }

        public StudentViewModel ViewModel
        {
            get { return BindingContext as StudentViewModel; }
            set { BindingContext = value; }
        }
    }
}
