using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudents(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
    }
}
