using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IStaff
    {
        Task<IEnumerable<Staff>> GetStaffsAsync();
        Task<Staff> GetStaffs(int id);
        Task AddStaff(Staff staff);
        Task UpdateStaff(Staff staff);
        Task DeleteStaff(Staff staff);
    }
}
