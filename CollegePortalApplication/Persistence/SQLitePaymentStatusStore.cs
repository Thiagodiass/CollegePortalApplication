using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLitePaymentStatusStore : IPaymentStatus
    {
        private SQLiteAsyncConnection _connection;

        public SQLitePaymentStatusStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<PaymentStatus>();
        }

        public async Task AddPaymentStatus(PaymentStatus paymentStatus)
        {
            await _connection.InsertAsync(paymentStatus);
        }

        public async Task DeletePaymentStatus(PaymentStatus paymentStatus)
        {
            await _connection.DeleteAsync(paymentStatus);
        }

        public async Task<PaymentStatus> GetPaymentStatus(int id)
        {
            return await _connection.FindAsync<PaymentStatus>(id);
        }

        public async Task<IEnumerable<PaymentStatus>> GetPaymentStatusAsync()
        {
            return await _connection.Table<PaymentStatus>().ToListAsync();
        }

        public async Task UpdatePaymentStatus(PaymentStatus paymentStatus)
        {
            await _connection.UpdateAsync(paymentStatus);
        }
    }
}
