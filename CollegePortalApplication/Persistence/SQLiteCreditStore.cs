using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteCreditStore : ICredit
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteCreditStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Credit>();
        }

        public async Task AddCredit(Credit credit)
        {
            await _connection.InsertAsync(credit);
        }

        public async Task DeleteCredit(Credit credit)
        {
            await _connection.DeleteAsync(credit);
        }

        public async Task<Credit> GetCredits(int id)
        {
            return await _connection.FindAsync<Credit>(id);
        }

        public async Task<IEnumerable<Credit>> GetCreditsAsync()
        {
            return await _connection.Table<Credit>().ToListAsync();
        }

        public async Task UpdateCredit(Credit credit)
        {
            await _connection.UpdateAsync(credit);
        }
    }
}
