using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class StudentTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public StudentTableViewModel()
        {
        }

        public StudentTableViewModel(Student student)
        {
            Id = student.id;
            StudentID = student.studentID;
            FirstName = student.firstName;
            LastName = student.lastName;
            PhoneNumber = student.phoneNumber;
            Email = student.email;
            DayOfBirth = student.dayOfBirth;
            Gender = student.gender;
            Street = student.street;
            City = student.city;
            PostCode = student.postCode;
            IdNumber = student.idNumber;
            Password = student.password;
            CourseID = student.courseID;
            AccountType = student.accountType;
            Status = student.status;
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

        private string _courseID;
        public string CourseID
        {
            get { return _courseID; }
            set
            {
                SetValue(ref _courseID, value);
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

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                SetValue(ref _status, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Display
        {
            get { return $"{StudentID} | {CourseID} | {FirstName}"; }
        }

    }
}
