using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteStudentOverviewStore : IStudentOverview
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteStudentOverviewStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<StudentOverview>();
        }

        public async Task AddStudentOverview(StudentOverview studentOverview)
        {
            await _connection.InsertAsync(studentOverview);
        }

        public async Task DeleteStudentOverview(StudentOverview studentOverview)
        {
            await _connection.DeleteAsync(studentOverview);
        }

        public async Task<StudentOverview> GetStudentOverviews(int id)
        {
            return await _connection.FindAsync<StudentOverview>(id);
        }

        public async Task<IEnumerable<StudentOverview>> GetStudentOverviewsAsync()
        {
            return await _connection.Table<StudentOverview>().ToListAsync();
        }

        public async Task UpdateStudentOverview(StudentOverview studentOverview)
        {
            await _connection.UpdateAsync(studentOverview);
        }
    }
}
