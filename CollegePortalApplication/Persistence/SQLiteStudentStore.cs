using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteStudentStore : IStudent
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteStudentStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Student>();
        }

        public async Task AddStudent(Student student)
        {
            await _connection.InsertAsync(student);
        }

        public async Task DeleteStudent(Student student)
        {
            await _connection.DeleteAsync(student);
        }

        public async Task<Student> GetStudents(int id)
        {
            return await _connection.FindAsync<Student>(id);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _connection.Table<Student>().ToListAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            await _connection.UpdateAsync(student);
        }
    }
}
