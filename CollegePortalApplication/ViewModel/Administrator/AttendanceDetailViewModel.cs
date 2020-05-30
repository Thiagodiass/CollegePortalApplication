using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class AttendanceDetailViewModel
    {
        private readonly IAttendance _attendanceStore;
        private readonly IPageService _pageService;

        public event EventHandler<Attendance> AttendanceAdded;
        public event EventHandler<Attendance> AttendanceUpdated;

        public Attendance Attendance { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public AttendanceDetailViewModel(AttendanceTableViewModel viewModel, IAttendance attendanceStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _attendanceStore = attendanceStore;

            SaveCommand = new Command(async () => await Save());

            Attendance = new Attendance
            {
                id = viewModel.Id,
                studentID = viewModel.StudentID,
                moduleID = viewModel.ModuleID,
                date = viewModel.Date,
                present = viewModel.Present,
                late = viewModel.Late,
                absent = viewModel.Absent,
                excused = viewModel.Excused
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Attendance.studentID)
                && String.IsNullOrWhiteSpace(Attendance.moduleID))
            {
                await _pageService.DisplayAlert("Error", "Please enter the ID.", "OK");
                return;
            }
            if (Attendance.id == 0)
            {
                await _attendanceStore.AddAttendance(Attendance);

                AttendanceAdded?.Invoke(this, Attendance);
            }
            else
            {
                await _attendanceStore.UpdateAttendance(Attendance);

                AttendanceUpdated?.Invoke(this, Attendance);
            }
            await _pageService.PopModalAsync();
        }
    }
}
