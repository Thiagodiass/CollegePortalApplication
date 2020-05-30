using System;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.ViewModelTables
{
    public class PaymentStatusTableViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public PaymentStatusTableViewModel()
        {
        }

        public PaymentStatusTableViewModel(PaymentStatus paymentStatus)
        {
            Id = paymentStatus.id;
            StudentID = paymentStatus.studentID;
            CourseID = paymentStatus.courseID;
            Fee = paymentStatus.fee;
            AmountPaid = paymentStatus.amountPaid;
            Date = paymentStatus.date;
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

        private string _courseID;
        public string CourseID
        {
            get { return _courseID; }
            set
            {
                SetValue(ref _courseID, value);
                OnPropertyChanged(nameof(Display));
            }
        }

        private double _fee;
        public double Fee
        {
            get { return _fee; }
            set
            {
                SetValue(ref _fee, value);
            }
        }

        private double _amountPaid;
        public double AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                SetValue(ref _amountPaid, value);
                OnPropertyChanged(nameof(Display));

            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                SetValue(ref _date, value);
            }
        }

        public string Display
        {
            get { return $"{StudentID} | {CourseID} | {AmountPaid}"; }
        }
    }
}
