using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;

namespace CollegePortalApplication.Persistence
{
    public class SQLiteUsersAccountTypeStore : IUsersAccountTypeStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteUsersAccountTypeStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<UsersAccountType>();
        }

        public async Task AddUserAccountType(UsersAccountType usersAccountType)
        {
            await _connection.InsertAsync(usersAccountType);
        }

        public async Task DeleteUserAccountType(UsersAccountType usersAccountType)
        {
            await _connection.DeleteAsync(usersAccountType);
        }

        public async Task<UsersAccountType> GetUsersAccountType(int id)
        {
            return await _connection.FindAsync<UsersAccountType>(id);
        }

        public async Task<IEnumerable<UsersAccountType>> GetUsersAccountTypeAsync()
        {
            return await _connection.Table<UsersAccountType>().ToListAsync();
        }

        public async Task UpdateUserAccountType(UsersAccountType usersAccountType)
        {
            await _connection.UpdateAsync(usersAccountType);
        }
    }
}
