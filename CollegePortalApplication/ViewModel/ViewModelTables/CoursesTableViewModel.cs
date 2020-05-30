using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class CoursesTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public CoursesTableViewModel()
        {
        }

        public CoursesTableViewModel(Courses courses)
        {
            Id = courses.id;
            CourseID = courses.courseID;
            CourseName = courses.courseName;
            Fee = courses.fee;
            StaffID = courses.staffID;
        }

        private string _courseID;
        public string CourseID
        {
            get { return _courseID; }
            set
            {
                SetValue(ref _courseID, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                SetValue(ref _courseName, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private double _fee;
        public double Fee
        {
            get { return _fee; }
            set
            {
                SetValue(ref _fee, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private string _staffID;
        public string StaffID
        {
            get { return _staffID; }
            set
            {
                SetValue(ref _staffID, value);
            }
        }

        public string Display
        {
            get { return $"{CourseID} | {CourseName} | {Fee.ToString()}"; }
        }
    }
}
