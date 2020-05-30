using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class CreditDetailViewModel
    {
        private readonly ICredit _creditStore;
        private readonly IPageService _pageService;

        public event EventHandler<Credit> CreditAdded;
        public event EventHandler<Credit> CreditUpdated;

        public Credit Credit { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public CreditDetailViewModel(CreditTableViewModel viewModel, ICredit creditStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _creditStore = creditStore;

            SaveCommand = new Command(async () => await Save());

            Credit = new Credit
            {
                id = viewModel.Id,
                creditID = viewModel.CreditID,
                classesWeekly = viewModel.ClassesWeekly
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Credit.creditID))
            {
                await _pageService.DisplayAlert("Error", "Please enter CreditID", "OK");
                return;
            }
            if (Credit.id == 0)
            {
                await _creditStore.AddCredit(Credit);

                CreditAdded?.Invoke(this, Credit);
            }
            else
            {
                await _creditStore.UpdateCredit(Credit);

                CreditUpdated?.Invoke(this, Credit);
            }
            await _pageService.PopModalAsync();
        }
    }
}
