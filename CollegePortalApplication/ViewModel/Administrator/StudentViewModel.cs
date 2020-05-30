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
    public class StudentViewModel : BaseViewModel
    {
        private StudentTableViewModel _selectedStudent;
        private IStudent _studentStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<StudentTableViewModel> Students { get; private set; } = new ObservableCollection<StudentTableViewModel>();

        public StudentTableViewModel SelectedStudent
        {
            get { return _selectedStudent; }
            set { SetValue(ref _selectedStudent, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddStudent { get; private set; }
        public ICommand SelectStudent { get; private set; }
        public ICommand DeleteStudent { get; private set; }

        public StudentViewModel(IStudent studentStore, IPageService pageService)
        {
            _studentStore = studentStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddStudent = new Command(async () => await AddStudents());
            SelectStudent = new Command<StudentTableViewModel>(async s => await SelectStudents(s));
            DeleteStudent = new Command<StudentTableViewModel>(async s => await DeleteStudents(s));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var student = await _studentStore.GetStudentsAsync();

            foreach (var s in student)
                Students.Add(new StudentTableViewModel(s));
        }

        private async Task AddStudents()
        {
            var viewModel = new StudentDetailViewModel(new StudentTableViewModel(), _studentStore, _pageService);

            viewModel.StudentAdded += (source, student) =>
            {
                Students.Add(new StudentTableViewModel(student));
            };

            await _pageService.PushModalAsync(new StudentDetailPage(viewModel));
        }

        private async Task SelectStudents(StudentTableViewModel student)
        {
            if (student == null)
                return;

            SelectedStudent = null;

            var viewModel = new StudentDetailViewModel(student, _studentStore, _pageService);
            viewModel.StudentUpdated += (source, updateStudent) =>
            {
                student.Id = updateStudent.id;
                student.AccountType = updateStudent.accountType;
                student.City = updateStudent.city;
                student.CourseID = updateStudent.courseID;
                student.DayOfBirth = updateStudent.dayOfBirth;
                student.Email = updateStudent.email;
                student.FirstName = updateStudent.firstName;
                student.Gender = updateStudent.gender;
                student.IdNumber = updateStudent.idNumber;
                student.LastName = updateStudent.lastName;
                student.Password = updateStudent.password;
                student.PhoneNumber = updateStudent.phoneNumber;
                student.PostCode = updateStudent.postCode;
                student.Status = updateStudent.status;
                student.Street = updateStudent.street;
                student.StudentID = updateStudent.studentID;
                
            };

            await _pageService.PushModalAsync(new StudentDetailPage(viewModel));
        }

        private async Task DeleteStudents(StudentTableViewModel student)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{student.StudentID}?", "Yes", "No"))
            {
                Students.Remove(student);
                var userStudent = await _studentStore.GetStudents(student.Id);
                await _studentStore.DeleteStudent(userStudent);
            }
        }
    }
}
