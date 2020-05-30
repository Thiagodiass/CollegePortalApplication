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

    public class UsersAccountTypeViewModel : BaseViewModel
    {
        private UserAccountTViewModel _selectedUserAccountType;
        private IUsersAccountTypeStore _usersAccountTypeStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<UserAccountTViewModel> UsersAccount { get; private set; } = new ObservableCollection<UserAccountTViewModel>();

        public UserAccountTViewModel SelectedUserAccountType
        {
            get { return _selectedUserAccountType; }
            set { SetValue(ref _selectedUserAccountType, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddUserAccountType { get; private set; }
        public ICommand SelectUserAccountType { get; private set; }
        public ICommand DeleteUserAccountType { get; private set; }

        public UsersAccountTypeViewModel(IUsersAccountTypeStore usersAccountTypeStore, IPageService pageService)
        {
            _usersAccountTypeStore = usersAccountTypeStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddUserAccountType = new Command(async () => await AddUserAccType());
            SelectUserAccountType = new Command<UserAccountTViewModel>(async c => await SelectUserAccType(c));
            DeleteUserAccountType = new Command<UserAccountTViewModel>(async c => await DeleteUserAccType(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var usersAccount = await _usersAccountTypeStore.GetUsersAccountTypeAsync();

            foreach (var u in usersAccount)
                UsersAccount.Add(new UserAccountTViewModel(u));
        }

        private async Task AddUserAccType()
        {
            var viewModel = new UserAccountTypeDetailViewModel(new UserAccountTViewModel(), _usersAccountTypeStore, _pageService);

            viewModel.UserAccountTypeAdded += (source, usersAccount) =>
            {
                UsersAccount.Add(new UserAccountTViewModel(usersAccount));
            };

            await _pageService.PushModalAsync(new UserAccountTypeDetailPage(viewModel));
        }

        private async Task SelectUserAccType(UserAccountTViewModel userAccount)
        {
            if (userAccount == null)
                return;

            SelectedUserAccountType = null;

            var viewModel = new UserAccountTypeDetailViewModel(userAccount, _usersAccountTypeStore, _pageService);
            viewModel.UserAccountTypeUpdated += (source, updateUserAccount) =>
            {
                userAccount.Id = updateUserAccount.id;
                userAccount.AccountName = updateUserAccount.accountName;
                userAccount.AccountType = updateUserAccount.accountType;
            };

            await _pageService.PushModalAsync(new UserAccountTypeDetailPage(viewModel));
        }

        private async Task DeleteUserAccType(UserAccountTViewModel userAccount)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning",$"Are you sure you want to delete{userAccount.TypeAndName}?", "Yes", "No"))
            {
                UsersAccount.Remove(userAccount);
                var userAccountType = await _usersAccountTypeStore.GetUsersAccountType(userAccount.Id);
                await _usersAccountTypeStore.DeleteUserAccountType(userAccountType);
            }
        }
    }
}

