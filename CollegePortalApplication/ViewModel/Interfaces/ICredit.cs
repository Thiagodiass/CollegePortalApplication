using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface ICredit
    {
        Task<IEnumerable<Credit>> GetCreditsAsync();
        Task<Credit> GetCredits(int id);
        Task AddCredit(Credit credit);
        Task UpdateCredit(Credit credit);
        Task DeleteCredit(Credit credit);
    }
}
