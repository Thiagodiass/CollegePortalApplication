using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class Courses
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(5)]
        public string courseID { get; set; }

        [MaxLength(50)]
        public string courseName { get; set; }

        public double fee { get; set; }

        [MaxLength(15)]
        public string staffID { get; set; }
    }
}
