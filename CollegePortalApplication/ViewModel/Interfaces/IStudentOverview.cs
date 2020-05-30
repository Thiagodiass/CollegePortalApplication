using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IStudentOverview
    {
        Task<IEnumerable<StudentOverview>> GetStudentOverviewsAsync();
        Task<StudentOverview> GetStudentOverviews(int id);
        Task AddStudentOverview(StudentOverview studentOverview);
        Task UpdateStudentOverview(StudentOverview studentOverview);
        Task DeleteStudentOverview(StudentOverview studentOverview);
    }
}
