
using SQLite;

namespace CollegePortalApplication.Model
{
    public class UsersAccountType
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(3), Unique]
        public string accountType { get; set; }

        [MaxLength(50), Unique]
        public string accountName { get; set; }
    }
}
