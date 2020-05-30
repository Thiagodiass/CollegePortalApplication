using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class AttendanceTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public AttendanceTableViewModel()
        {
        }

        public AttendanceTableViewModel(Attendance attendance)
        {
            Id = attendance.id;
            StudentID = attendance.studentID;
            ModuleID = attendance.moduleID;
            Date = attendance.date;
            Present = attendance.present;
            Late = attendance.late;
            Excused = attendance.excused;
            Absent = attendance.absent;
        }
        private string _studentID;
        public string StudentID
        {
            get { return _studentID; }
            set
            {
                SetValue(ref _studentID, value);
                OnPropertyChanged(nameof(Display));
            }
        }
        private string _moduleID;
        public string ModuleID
        {
            get { return _moduleID; }
            set
            {
                SetValue(ref _moduleID, value);
                OnPropertyChanged(nameof(Display));
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                SetValue(ref _date, value);
            }
        }
        private bool _present;
        public bool Present
        {
            get { return _present; }
            set
            {
                SetValue(ref _present, value);
            }
        }
        private bool _late;
        public bool Late
        {
            get { return _late; }
            set
            {
                SetValue(ref _late, value);
            }
        }
        private bool _excused;
        public bool Excused
        {
            get { return _excused; }
            set
            {
                SetValue(ref _excused, value);
            }
        }
        private bool _absent;
        public bool Absent
        {
            get { return _absent; }
            set
            {
                SetValue(ref _absent, value);
            }
        }

        public string Display
        {
            get { return $"{ModuleID} | {StudentID} | {Date.ToString("dd-MM-yyyy")}"; }
        }
    }
}


