using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface ICourses
    {
        Task<IEnumerable<Courses>> GetCoursesAsync();
        Task<Courses> GetCourses(int id);
        Task AddCourse(Courses courses);
        Task UpdateCourse(Courses courses);
        Task DeleteCourse(Courses courses);
    }
}
