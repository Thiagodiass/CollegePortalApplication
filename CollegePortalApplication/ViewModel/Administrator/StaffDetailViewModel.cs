using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class StaffDetailViewModel
    {
        private readonly IStaff _staffStore;
        private readonly IPageService _pageService;

        public event EventHandler<Staff> StaffAdded;
        public event EventHandler<Staff> StaffUpdated;

        public Staff Staff { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public StaffDetailViewModel(StaffTableViewModel viewModel, IStaff staffStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _staffStore = staffStore;

            SaveCommand = new Command(async () => await Save());

            Staff = new Staff
            {
                id = viewModel.Id,
                staffID = viewModel.StaffID,
                firstName = viewModel.FirstName,
                lastName = viewModel.LastName,
                email = viewModel.Email,
                city = viewModel.City,
                postCode = viewModel.PostCode,
                accountType = viewModel.AccountType,
                active = viewModel.Active,
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
            if (String.IsNullOrWhiteSpace(Staff.staffID)
                && String.IsNullOrWhiteSpace(Staff.firstName)
                && String.IsNullOrWhiteSpace(Staff.accountType)
                && String.IsNullOrWhiteSpace(Staff.idNumber)
                && String.IsNullOrWhiteSpace(Staff.password))
            {
                await _pageService.DisplayAlert("Error", "Please enter All the Fields", "OK");
                return;
            }
            if (Staff.id == 0)
            {
                await _staffStore.AddStaff(Staff);

                StaffAdded?.Invoke(this, Staff);
            }
            else
            {
                await _staffStore.UpdateStaff(Staff);

                StaffUpdated?.Invoke(this, Staff);
            }
            await _pageService.PopModalAsync();
        }
    }
}
