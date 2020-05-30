using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IAttendance
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<Attendance> GetAttendance(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(Attendance attendance);
    }
}
