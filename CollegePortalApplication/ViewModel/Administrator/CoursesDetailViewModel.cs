using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class CoursesDetailViewModel
    {
        private readonly ICourses _coursesStore;
        private readonly IPageService _pageService;

        public event EventHandler<Courses> CourseAdded;
        public event EventHandler<Courses> CourseUpdated;

        public Courses Courses { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public CoursesDetailViewModel(CoursesTableViewModel viewModel, ICourses coursesStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _coursesStore = coursesStore;

            SaveCommand = new Command(async () => await Save());

            Courses = new Courses
            {
                id = viewModel.Id,
                courseID = viewModel.CourseID,
                courseName = viewModel.CourseName,
                staffID = viewModel.StaffID,
                fee = viewModel.Fee
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Courses.courseID)
                && String.IsNullOrWhiteSpace(Courses.staffID)
                && String.IsNullOrWhiteSpace(Courses.courseName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the ID and Name.", "OK");
                return;
            }
            if (Courses.id == 0)
            {
                await _coursesStore.AddCourse(Courses);

                CourseAdded?.Invoke(this, Courses);
            }
            else
            {
                await _coursesStore.UpdateCourse(Courses);

                CourseUpdated?.Invoke(this, Courses);
            }
            await _pageService.PopModalAsync();
        }
    }
}
