using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteStaffStore : IStaff
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteStaffStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Staff>();
        }

        public async Task AddStaff(Staff staff)
        {
            await _connection.InsertAsync(staff);
        }

        public async Task DeleteStaff(Staff staff)
        {
            await _connection.DeleteAsync(staff);
        }

        public async Task<Staff> GetStaffs(int id)
        {
            return await _connection.FindAsync<Staff>(id);
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync()
        {
            return await _connection.Table<Staff>().ToListAsync();
        }

        public async Task UpdateStaff(Staff staff)
        {
            await _connection.UpdateAsync(staff);
        }
    }
}
