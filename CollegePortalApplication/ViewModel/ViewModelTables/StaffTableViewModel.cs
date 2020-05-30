using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class StaffTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public StaffTableViewModel()
        {
        }

        public StaffTableViewModel(Staff staff)
        {
            Id = staff.id;
            StaffID = staff.staffID;
            FirstName = staff.firstName;
            LastName = staff.lastName;
            PhoneNumber = staff.phoneNumber;
            Email = staff.email;
            DayOfBirth = staff.dayOfBirth;
            Gender = staff.gender;
            Street = staff.street;
            City = staff.city;
            PostCode = staff.postCode;
            IdNumber = staff.idNumber;
            Password = staff.password;
            Active = staff.active;
            AccountType = staff.accountType;
        }

        private string _staffID;
        public string StaffID
        {
            get { return _staffID; }
            set
            {
                SetValue(ref _staffID, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetValue(ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetValue(ref _phoneNumber, value);
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetValue(ref _email, value);
            }
        }

        private DateTime _dayOfBirth;
        public DateTime DayOfBirth
        {
            get { return _dayOfBirth; }
            set
            {
                SetValue(ref _dayOfBirth, value);
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                SetValue(ref _gender, value);
            }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                SetValue(ref _street, value);
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                SetValue(ref _city, value);
            }
        }

        private string _postCode;
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                SetValue(ref _postCode, value);
            }
        }

        private string _idNumber;
        public string IdNumber
        {
            get { return _idNumber; }
            set
            {
                SetValue(ref _idNumber, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetValue(ref _password, value);
            }
        }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set
            {
                SetValue(ref _active, value);
            }
        }

        private string _accountType;
        public string AccountType
        {
            get { return _accountType; }
            set
            {
                SetValue(ref _accountType, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Display
        {
            get { return $"{StaffID} |     {AccountType}     |   {FirstName}"; }
        }
    }
}
