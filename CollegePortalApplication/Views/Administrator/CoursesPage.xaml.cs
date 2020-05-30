using CollegePortalApplication.Persistence;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class CoursesPage : ContentPage
    {
        public CoursesPage()
        {
            var coursesStore = new SQLiteCoursesStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new CoursesViewModel(coursesStore, pageService);

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
            ViewModel.SelectCourse.Execute(e.SelectedItem);
        }

        public CoursesViewModel ViewModel
        {
            get { return BindingContext as CoursesViewModel; }
            set { BindingContext = value; }
        }
    }
}
