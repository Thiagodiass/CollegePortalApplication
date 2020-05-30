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
    public class CreditViewModel : BaseViewModel
    {
        private CreditTableViewModel _selectedCredit;
        private ICredit _creditStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<CreditTableViewModel> Credits { get; private set; } = new ObservableCollection<CreditTableViewModel>();

        public CreditTableViewModel SelectedCredit
        {
            get { return _selectedCredit; }
            set { SetValue(ref _selectedCredit, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddCredit { get; private set; }
        public ICommand SelectCredit { get; private set; }
        public ICommand DeleteCredit { get; private set; }

        public CreditViewModel(ICredit creditStore, IPageService pageService)
        {
            _creditStore = creditStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddCredit = new Command(async () => await AddCredits());
            SelectCredit = new Command<CreditTableViewModel>(async c => await SelectCredits(c));
            DeleteCredit = new Command<CreditTableViewModel>(async c => await DeleteCredits(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var credit = await _creditStore.GetCreditsAsync();

            foreach (var c in credit)
                Credits.Add(new CreditTableViewModel(c));
        }

        private async Task AddCredits()
        {
            var viewModel = new CreditDetailViewModel(new CreditTableViewModel(), _creditStore, _pageService);

            viewModel.CreditAdded += (source, credit) =>
            {
                Credits.Add(new CreditTableViewModel(credit));
            };

            await _pageService.PushModalAsync(new CreditDetailPage(viewModel));
        }

        private async Task SelectCredits(CreditTableViewModel credit)
        {
            if (credit == null)
                return;

            SelectedCredit = null;

            var viewModel = new CreditDetailViewModel(credit, _creditStore, _pageService);
            viewModel.CreditUpdated += (source, updateCredit) =>
            {
                credit.Id = updateCredit.id;
                credit.CreditID = updateCredit.creditID;
                credit.ClassesWeekly = updateCredit.classesWeekly;
            };

            await _pageService.PushModalAsync(new CreditDetailPage(viewModel));
        }

        private async Task DeleteCredits(CreditTableViewModel credit)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{credit.CreditID}?", "Yes", "No"))
            {
                Credits.Remove(credit);
                var userCredit = await _creditStore.GetCredits(credit.Id);
                await _creditStore.DeleteCredit(userCredit);
            }
        }
    }
}
