using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollegePortalApplication.Model;

namespace CollegePortalApplication.ViewModel.Interfaces
{
    public interface IUsersAccountTypeStore
    {
        Task<IEnumerable<UsersAccountType>> GetUsersAccountTypeAsync();
        Task<UsersAccountType> GetUsersAccountType(int id);
        Task AddUserAccountType(UsersAccountType usersAccountType);
        Task UpdateUserAccountType(UsersAccountType usersAccountType);
        Task DeleteUserAccountType(UsersAccountType usersAccountType);
    }
}
