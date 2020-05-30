using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class StudentOverviewDetailViewModel
    {
        private readonly IStudentOverview _studentOverviewStore;
        private readonly IPageService _pageService;

        public event EventHandler<StudentOverview> StudentOverviewAdded;
        public event EventHandler<StudentOverview> StudentOverviewUpdated;

        public StudentOverview StudentOverview { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public StudentOverviewDetailViewModel(StudentOverviewTableViewModel viewModel, IStudentOverview studentOverviewStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _studentOverviewStore = studentOverviewStore;

            SaveCommand = new Command(async () => await Save());

            StudentOverview = new StudentOverview
            {
                id = viewModel.Id,
                studentID = viewModel.StudentID,
                semester = viewModel.Semester,
                attendance = viewModel.Attendance,
                grade = viewModel.Grade,
                moduleID = viewModel.ModuleID,
                year = viewModel.Year
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(StudentOverview.studentID)
                && String.IsNullOrWhiteSpace(StudentOverview.moduleID))
            {
                await _pageService.DisplayAlert("Error", "Please enter All the Fields", "OK");
                return;
            }
            if (StudentOverview.id == 0)
            {
                await _studentOverviewStore.AddStudentOverview(StudentOverview);

                StudentOverviewAdded?.Invoke(this, StudentOverview);
            }
            else
            {
                await _studentOverviewStore.UpdateStudentOverview(StudentOverview);

                StudentOverviewUpdated?.Invoke(this, StudentOverview);
            }
            await _pageService.PopModalAsync();
        }
    }
}
