using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteAttendanceStore : IAttendance
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteAttendanceStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Attendance>();
        }

        public async Task AddAttendance(Attendance attendance)
        {
            await _connection.InsertAsync(attendance);
        }

        public async Task DeleteAttendance(Attendance attendance)
        {
            await _connection.DeleteAsync(attendance);
        }

        public async Task<Attendance> GetAttendance(int id)
        {
            return await _connection.FindAsync<Attendance>(id);
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            return await _connection.Table<Attendance>().ToListAsync();
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            await _connection.UpdateAsync(attendance);
        }
    }
}
