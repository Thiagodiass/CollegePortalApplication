using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class Attendance
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(15)]
        public string studentID { get; set; }

        [MaxLength(5)]
        public string moduleID { get; set; }

        public DateTime date { get; set; }
        public bool present { get; set; }
        public bool late { get; set; }
        public bool excused { get; set; }
        public bool absent { get; set; }
    }
}
