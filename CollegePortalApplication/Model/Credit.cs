using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class Credit
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(3), Unique]
        public string creditID { get; set; }

        public int classesWeekly { get; set; }
    }
}
