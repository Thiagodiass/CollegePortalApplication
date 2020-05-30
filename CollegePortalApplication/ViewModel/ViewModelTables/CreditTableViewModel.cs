using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class CreditTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public CreditTableViewModel()
        {
        }

        public CreditTableViewModel(Credit credit)
        {
            Id = credit.id;
            CreditID = credit.creditID;
            ClassesWeekly = credit.classesWeekly;
        }

        private string _creditID;
        public string CreditID
        {
            get { return _creditID; }
            set
            {
                SetValue(ref _creditID, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private int _classesWeekly;
        public int ClassesWeekly
        {
            get { return _classesWeekly; }
            set
            {
                SetValue(ref _classesWeekly, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Display
        {
            get { return $"{CreditID} |                     {ClassesWeekly.ToString()}"; }
        }
    }
}
