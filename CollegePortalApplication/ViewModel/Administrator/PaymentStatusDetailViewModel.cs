using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class PaymentStatusDetailViewModel
    {
        private readonly IPaymentStatus _paymentStatusStore;
        private readonly IPageService _pageService;

        public event EventHandler<PaymentStatus> PaymentStatusAdded;
        public event EventHandler<PaymentStatus> PaymentStatusUpdated;

        public PaymentStatus PaymentStatus { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public PaymentStatusDetailViewModel(PaymentStatusTableViewModel viewModel, IPaymentStatus paymentStatusStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _paymentStatusStore = paymentStatusStore;

            SaveCommand = new Command(async () => await Save());

            PaymentStatus = new PaymentStatus
            {
                id = viewModel.Id,
                studentID = viewModel.StudentID,
                courseID = viewModel.CourseID,
                amountPaid = viewModel.AmountPaid,
                fee = viewModel.Fee,
                date = viewModel.Date
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(PaymentStatus.studentID)
                && String.IsNullOrWhiteSpace(PaymentStatus.courseID))
            {
                await _pageService.DisplayAlert("Error", "Please enter All the Fields", "OK");
                return;
            }
            if (PaymentStatus.id == 0)
            {
                await _paymentStatusStore.AddPaymentStatus(PaymentStatus);

                PaymentStatusAdded?.Invoke(this, PaymentStatus);
            }
            else
            {
                await _paymentStatusStore.UpdatePaymentStatus(PaymentStatus);

                PaymentStatusUpdated?.Invoke(this, PaymentStatus);
            }
            await _pageService.PopModalAsync();
        }
    }
}
