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
    public class AttendanceViewModel : BaseViewModel
    {
        private AttendanceTableViewModel _selectedAttendance;
        private IAttendance _attendanceStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<AttendanceTableViewModel> Attendances { get; private set; } = new ObservableCollection<AttendanceTableViewModel>();

        public AttendanceTableViewModel SelectedAttendance
        {
            get { return _selectedAttendance; }
            set { SetValue(ref _selectedAttendance, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddAttendance { get; private set; }
        public ICommand SelectAttendance { get; private set; }
        public ICommand DeleteAttendance { get; private set; }

        public AttendanceViewModel(IAttendance attendanceStore, IPageService pageService)
        {
            _attendanceStore = attendanceStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddAttendance = new Command(async () => await AddAttendances());
            SelectAttendance = new Command<AttendanceTableViewModel>(async c => await SelectAttendances(c));
            DeleteAttendance = new Command<AttendanceTableViewModel>(async c => await DeleteAttendances(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var attendance = await _attendanceStore.GetAttendanceAsync();

            foreach (var a in attendance)
                Attendances.Add(new AttendanceTableViewModel(a));
        }

        private async Task AddAttendances()
        {
            var viewModel = new AttendanceDetailViewModel(new AttendanceTableViewModel(), _attendanceStore, _pageService);

            viewModel.AttendanceAdded += (source, attendance) =>
            {
                Attendances.Add(new AttendanceTableViewModel(attendance));
            };

            await _pageService.PushModalAsync(new AttendanceDetailPage(viewModel));
        }

        private async Task SelectAttendances(AttendanceTableViewModel attendances)
        {
            if (attendances == null)
                return;

            SelectedAttendance = null;

            var viewModel = new AttendanceDetailViewModel(attendances, _attendanceStore, _pageService);
            viewModel.AttendanceUpdated += (source, updateAttendance) =>
            {
                attendances.Id = updateAttendance.id;
                attendances.StudentID = updateAttendance.studentID;
                attendances.ModuleID = updateAttendance.moduleID;
                attendances.Present = updateAttendance.present;
                attendances.Late = updateAttendance.late;
                attendances.Absent = updateAttendance.absent;
                attendances.Excused = updateAttendance.excused;
                attendances.Date = updateAttendance.date;
                
            };

            await _pageService.PushModalAsync(new AttendanceDetailPage(viewModel));
        }

        private async Task DeleteAttendances(AttendanceTableViewModel attendance)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{attendance.StudentID}?", "Yes", "No"))
            {
                Attendances.Remove(attendance);
                var userAttendance = await _attendanceStore.GetAttendance(attendance.Id);
                await _attendanceStore.DeleteAttendance(userAttendance);
            }
        }
    }
}
