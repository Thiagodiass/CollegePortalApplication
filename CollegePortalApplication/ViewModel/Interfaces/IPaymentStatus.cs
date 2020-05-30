using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IPaymentStatus
    {
        Task<IEnumerable<PaymentStatus>> GetPaymentStatusAsync();
        Task<PaymentStatus> GetPaymentStatus(int id);
        Task AddPaymentStatus(PaymentStatus paymentStatus);
        Task UpdatePaymentStatus(PaymentStatus paymentStatus);
        Task DeletePaymentStatus(PaymentStatus paymentStatus);
    }
}
