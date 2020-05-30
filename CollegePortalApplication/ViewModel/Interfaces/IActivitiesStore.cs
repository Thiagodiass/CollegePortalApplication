using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IActivitiesStore
    {
        Task<IEnumerable<Activities>> GetActivitiesAsync();
        Task<Activities> GetActivities(int id);
        Task AddActivity(Activities activities);
        Task UpdateActivity(Activities activities);
        Task DeleteActivity(Activities activities);
    }
}
