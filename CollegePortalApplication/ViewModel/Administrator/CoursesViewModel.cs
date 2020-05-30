using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using CollegePortalApplication.Views.Administrator.DetailPages;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class CoursesViewModel : BaseViewModel
    {
        private CoursesTableViewModel _selectedCourse;
        private ICourses _coursesStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<CoursesTableViewModel> Courses { get; private set; } = new ObservableCollection<CoursesTableViewModel>();

        public CoursesTableViewModel SelectedCourse
        {
            get { return _selectedCourse; }
            set { SetValue(ref _selectedCourse, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddCourse { get; private set; }
        public ICommand SelectCourse { get; private set; }
        public ICommand DeleteCourse { get; private set; }

        public CoursesViewModel(ICourses coursesStore, IPageService pageService)
        {
            _coursesStore = coursesStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddCourse = new Command(async () => await AddCourses());
            SelectCourse = new Command<CoursesTableViewModel>(async c => await SelectCourses(c));
            DeleteCourse = new Command<CoursesTableViewModel>(async c => await DeleteCourses(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var course = await _coursesStore.GetCoursesAsync();

            foreach (var c in course)
                Courses.Add(new CoursesTableViewModel(c));
        }

        private async Task AddCourses()
        {
            var viewModel = new CoursesDetailViewModel(new CoursesTableViewModel(), _coursesStore, _pageService);

            viewModel.CourseAdded += (source, course) =>
            {
                Courses.Add(new CoursesTableViewModel(course));
            };

            await _pageService.PushModalAsync(new CoursesDetailPage(viewModel));
        }

        private async Task SelectCourses(CoursesTableViewModel courses)
        {
            if (courses == null)
                return;

            SelectedCourse = null;

            var viewModel = new CoursesDetailViewModel(courses, _coursesStore, _pageService);
            viewModel.CourseUpdated += (source, updateCourse) =>
            {
                courses.Id = updateCourse.id;
                courses.CourseID = updateCourse.courseID;
                courses.CourseName = updateCourse.courseName;
                courses.StaffID = updateCourse.staffID;
                courses.Fee = updateCourse.fee;
            };

            await _pageService.PushModalAsync(new CoursesDetailPage(viewModel));
        }

        private async Task DeleteCourses(CoursesTableViewModel course)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{course.CourseName}?", "Yes", "No"))
            {
                Courses.Remove(course);
                var userCourse = await _coursesStore.GetCourses(course.Id);
                await _coursesStore.DeleteCourse(userCourse);
            }
        }
    }
}
