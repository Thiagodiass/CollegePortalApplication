using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;

namespace CollegePortalApplication.Persistence
{
    public class SQLiteActivitiesStore : IActivitiesStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteActivitiesStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Activities>();
        }

        public async Task AddActivity(Activities activities)
        {
            await _connection.InsertAsync(activities);
        }

        public async Task DeleteActivity(Activities activities)
        {
            await _connection.DeleteAsync(activities);
        }

        public async Task<Activities> GetActivities(int id)
        {
            return await _connection.FindAsync<Activities>(id);
        }

        public async Task<IEnumerable<Activities>> GetActivitiesAsync()
        {
            return await _connection.Table<Activities>().ToListAsync();
        }

        public async Task UpdateActivity(Activities activities)
        {
            await _connection.UpdateAsync(activities);
        }
    }
}
