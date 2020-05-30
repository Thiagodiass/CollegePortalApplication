using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using CollegePortalApplication.Model;
using SQLite;

namespace CollegePortalApplication.Services
{
    public class UsersAccountTypeRepository
    {
        SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }


        public UsersAccountTypeRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<UsersAccountType>().Wait();
        }

        public async Task AddNewUserAccountTypeAsync(string type, string name)
        {
            int result = 0;
            try
            {
                if(string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Account Name Required");
                }
                if (string.IsNullOrWhiteSpace(type))
                {
                    throw new Exception("Account Type Required");
                }

                result = await conn.InsertAsync(new UsersAccountType { accountName = name, accountType = type });
                StatusMessage = string.Format("{0} record(s) added [AccountName:{1}][AccountType:{2}",result,name,type);

            }
            catch (Exception ex)
            {
                if (string.IsNullOrWhiteSpace(name))
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);

                StatusMessage = string.Format("Failed to add {0}. Error: {1}", type, ex.Message);
            }
        }

        public async Task<List<UsersAccountType>> GetAllUsersAccountType()
        {
            try
            {
                return await conn.Table<UsersAccountType>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<UsersAccountType>();
        }
    }
}
