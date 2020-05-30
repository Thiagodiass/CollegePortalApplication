using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using SQLite;
namespace CollegePortalApplication.Persistence
{
    public class SQLiteModuleStore : IModule
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteModuleStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Module>();
        }

        public async Task AddModule(Module module)
        {
            await _connection.InsertAsync(module);
        }

        public async Task DeleteModule(Module module)
        {
            await _connection.DeleteAsync(module);
        }

        public async Task<Module> GetModules(int id)
        {
            return await _connection.FindAsync<Module>(id);
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            return await _connection.Table<Module>().ToListAsync();
        }

        public async Task UpdateModule(Module module)
        {
            await _connection.UpdateAsync(module);
        }
    }
}
