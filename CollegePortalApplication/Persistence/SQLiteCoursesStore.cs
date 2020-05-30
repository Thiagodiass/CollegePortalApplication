using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteCoursesStore : ICourses
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteCoursesStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Courses>();
        }

        public async Task AddCourse(Courses courses)
        {
            await _connection.InsertAsync(courses);
        }

        public async Task DeleteCourse(Courses courses)
        {
            await _connection.DeleteAsync(courses);
        }

        public async Task<Courses> GetCourses(int id)
        {
            return await _connection.FindAsync<Courses>(id);
        }

        public async Task<IEnumerable<Courses>> GetCoursesAsync()
        {
            return await _connection.Table<Courses>().ToListAsync();
        }

        public async Task UpdateCourse(Courses courses)
        {
            await _connection.UpdateAsync(courses);
        }
    }
}
