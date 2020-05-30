using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class ModuleTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public ModuleTableViewModel()
        {
        }

        public ModuleTableViewModel(Module module)
        {
            Id = module.id;
            ModuleID = module.moduleID;
            ModuleName = module.moduleName;
            StaffID = module.staffID;
            CourseID = module.courseID;
            CreditID = module.creditID;
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

        private string _moduleName;
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                SetValue(ref _moduleName, value);
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

        private string _courseID;
        public string CourseID
        {
            get { return _courseID; }
            set
            {
                SetValue(ref _courseID, value);
            }
        }

        private string _creditID;
        public string CreditID
        {
            get { return _creditID; }
            set
            {
                SetValue(ref _creditID, value);
            }
        }

        public string Display
        {
            get { return $"{ModuleID} |              {ModuleName}"; }
        }
    }
}
