using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class UserAccountTypeDetailViewModel
    {
        private readonly IUsersAccountTypeStore _usersAccountTypeStore;
        private readonly IPageService _pageService;

        public event EventHandler<UsersAccountType> UserAccountTypeAdded;
        public event EventHandler<UsersAccountType> UserAccountTypeUpdated;

        public UsersAccountType UsersAccount { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public UserAccountTypeDetailViewModel(UserAccountTViewModel viewModel, IUsersAccountTypeStore usersAccountTypeStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _usersAccountTypeStore = usersAccountTypeStore;

            SaveCommand = new Command(async () => await Save());

            UsersAccount = new UsersAccountType
            {
                id = viewModel.Id,
                accountName = viewModel.AccountName,
                accountType = viewModel.AccountType
            };
        }

        async Task Save()
        {
            if(String.IsNullOrWhiteSpace(UsersAccount.accountName) && String.IsNullOrWhiteSpace(UsersAccount.accountType))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            if(UsersAccount.id==0)
            {
                await _usersAccountTypeStore.AddUserAccountType(UsersAccount);

                UserAccountTypeAdded?.Invoke(this, UsersAccount);
            }
            else
            {
                await _usersAccountTypeStore.UpdateUserAccountType(UsersAccount);

                UserAccountTypeUpdated?.Invoke(this, UsersAccount);
            }
            await _pageService.PopModalAsync();
        }
    }
}
