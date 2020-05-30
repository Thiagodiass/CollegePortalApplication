using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class ActivitiesTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public ActivitiesTableViewModel()
        {
        }
        public ActivitiesTableViewModel(Activities activities)
        {
            Id = activities.id;
            ModuleID = activities.moduleID;
            StudentID = activities.studentID;
            Type = activities.type;
            Grade = activities.grade;
            Weight = activities.weight;
            DueDate = activities.dueDate;


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

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                SetValue(ref _type, value);
            }
        }

        private double _grade;
        public double Grade
        {
            get { return _grade; }
            set
            {
                SetValue(ref _grade, value);
            }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                SetValue(ref _weight, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                SetValue(ref _dueDate, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Display
        {
            get { return $"{ModuleID} | {StudentID} | {Weight} | {DueDate.ToString("dd-MM-yyyy")}"; }
        }
    }
}
