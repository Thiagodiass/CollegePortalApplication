using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class StudentOverview
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(15)]
        public string studentID { get; set; }
        [MaxLength(5)]
        public string moduleID { get; set; }
        [MaxLength(3)]
        public string semester { get; set; }
        [MaxLength(4)]
        public string year { get; set; }
        public double attendance { get; set; }
        public double grade { get; set; }
    }
}
