using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class StudentDetailViewModel
    {
        private readonly IStudent _studentStore;
        private readonly IPageService _pageService;

        public event EventHandler<Student> StudentAdded;
        public event EventHandler<Student> StudentUpdated;

        public Student Student { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public StudentDetailViewModel(StudentTableViewModel viewModel, IStudent studentStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _studentStore = studentStore;

            SaveCommand = new Command(async () => await Save());

            Student = new Student
            {
                id = viewModel.Id,
                studentID = viewModel.StudentID,
                firstName = viewModel.FirstName,
                lastName = viewModel.LastName,
                email = viewModel.Email,
                city = viewModel.City,
                postCode = viewModel.PostCode,
                accountType = viewModel.AccountType,
                status = viewModel.Status,
                courseID = viewModel.CourseID,
                dayOfBirth = viewModel.DayOfBirth,
                gender = viewModel.Gender,
                idNumber = viewModel.IdNumber,
                password = viewModel.Password,
                phoneNumber = viewModel.PhoneNumber,
                street = viewModel.Street
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Student.studentID)
                && String.IsNullOrWhiteSpace(Student.firstName)
                && String.IsNullOrWhiteSpace(Student.courseID)
                && String.IsNullOrWhiteSpace(Student.idNumber)
                && String.IsNullOrWhiteSpace(Student.password))
            {
                await _pageService.DisplayAlert("Error", "Please enter All the Fields", "OK");
                return;
            }
            if (Student.id == 0)
            {
                await _studentStore.AddStudent(Student);

                StudentAdded?.Invoke(this, Student);
            }
            else
            {
                await _studentStore.UpdateStudent(Student);

                StudentUpdated?.Invoke(this, Student);
            }
            await _pageService.PopModalAsync();
        }
    }
}
