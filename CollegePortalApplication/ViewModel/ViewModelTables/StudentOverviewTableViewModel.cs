using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class StudentOverviewTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public StudentOverviewTableViewModel()
        {
        }

        public StudentOverviewTableViewModel(StudentOverview studentOverview)
        {
            Id = studentOverview.id;
            StudentID = studentOverview.studentID;
            ModuleID = studentOverview.moduleID;
            Semester = studentOverview.semester;
            Year = studentOverview.year;
            Attendance = studentOverview.attendance;
            Grade = studentOverview.grade;
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

        private string _semester;
        public string Semester
        {
            get { return _semester; }
            set
            {
                SetValue(ref _semester, value);
            }
        }
        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                SetValue(ref _year, value);
            }
        }

        private double _attendance;
        public double Attendance
        {
            get { return _attendance; }
            set
            {
                SetValue(ref _attendance, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private double _grade;
        public double Grade
        {
            get { return _grade; }
            set
            {
                SetValue(ref _grade, value);
                OnPropertyChanged(nameof(Display));
            }
        }
        public string Display
        {
            get { return $"{StudentID} | {ModuleID} | {Attendance}"; }
        }
    }
}
