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
    public class PaymentStatusViewModel : BaseViewModel
    {
        private PaymentStatusTableViewModel _selectedPaymentStatus;
        private IPaymentStatus _paymentStatusStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<PaymentStatusTableViewModel> PaymentStatus{ get; private set; } = new ObservableCollection<PaymentStatusTableViewModel>();

        public PaymentStatusTableViewModel SelectedPaymentStatus
        {
            get { return _selectedPaymentStatus; }
            set { SetValue(ref _selectedPaymentStatus, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddPaymentStatus { get; private set; }
        public ICommand SelectPaymentStatus { get; private set; }
        public ICommand DeletePaymentStatus { get; private set; }

        public PaymentStatusViewModel(IPaymentStatus paymentStatusStore, IPageService pageService)
        {
            _paymentStatusStore = paymentStatusStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddPaymentStatus = new Command(async () => await AddPaymentStatuses());
            SelectPaymentStatus = new Command<PaymentStatusTableViewModel>(async c => await SelectPaymentStatuses(c));
            DeletePaymentStatus = new Command<PaymentStatusTableViewModel>(async c => await DeletePaymentStatuses(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var paymentStatus = await _paymentStatusStore.GetPaymentStatusAsync();

            foreach (var p in paymentStatus)
                PaymentStatus.Add(new PaymentStatusTableViewModel(p));
        }

        private async Task AddPaymentStatuses()
        {
            var viewModel = new PaymentStatusDetailViewModel(new PaymentStatusTableViewModel(), _paymentStatusStore, _pageService);

            viewModel.PaymentStatusAdded += (source, module) =>
            {
                PaymentStatus.Add(new PaymentStatusTableViewModel(module));
            };

            await _pageService.PushModalAsync(new PaymentStatusDetailPage(viewModel));
        }

        private async Task SelectPaymentStatuses(PaymentStatusTableViewModel paymentStatus)
        {
            if (paymentStatus == null)
                return;

            SelectedPaymentStatus = null;

            var viewModel = new PaymentStatusDetailViewModel(paymentStatus, _paymentStatusStore, _pageService);
            viewModel.PaymentStatusUpdated += (source, updatePaymentStatus) =>
            {
                paymentStatus.Id = updatePaymentStatus.id;
                paymentStatus.StudentID = updatePaymentStatus.studentID;
                paymentStatus.CourseID = updatePaymentStatus.courseID;
                paymentStatus.AmountPaid = updatePaymentStatus.amountPaid;
                paymentStatus.Fee = updatePaymentStatus.fee;
                paymentStatus.Date = updatePaymentStatus.date;
            };

            await _pageService.PushModalAsync(new PaymentStatusDetailPage(viewModel));
        }

        private async Task DeletePaymentStatuses(PaymentStatusTableViewModel paymentStatus)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{paymentStatus.StudentID}?", "Yes", "No"))
            {
                PaymentStatus.Remove(paymentStatus);
                var userPaymentStatus = await _paymentStatusStore.GetPaymentStatus(paymentStatus.Id);
                await _paymentStatusStore.DeletePaymentStatus(userPaymentStatus);
            }
        }
    }
}
