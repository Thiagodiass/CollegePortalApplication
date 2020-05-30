using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IModule
    {
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<Module> GetModules(int id);
        Task AddModule(Module module);
        Task UpdateModule(Module module);
        Task DeleteModule(Module module);
    }
}
