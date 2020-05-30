using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class UserAccountTViewModel : BaseViewModel
    {
        public int Id { get; set; }
        
        public UserAccountTViewModel()
        {
        }

        public UserAccountTViewModel(UsersAccountType userAccountType)
        {
            Id = userAccountType.id;
            _accountName = userAccountType.accountName;
            _accountType = userAccountType.accountType;
        }
        private string _accountType;
        public string AccountType
        {
            get { return _accountType; }
            set {
                SetValue(ref _accountType, value);
                OnPropertyChanged(nameof(TypeAndName));
            }
        }
        private string _accountName;
        public string AccountName
        {
            get { return _accountName; }
            set
            {
                SetValue(ref _accountName, value);
                OnPropertyChanged(nameof(TypeAndName));
            }
        }

        public string TypeAndName
        {
            get { return $"{AccountType}      |      {AccountName}"; }
        }
    }
}