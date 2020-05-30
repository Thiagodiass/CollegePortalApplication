using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class Module
    {
        [MaxLength(3), Unique]
        public int id { get; set; }

        [MaxLength(5)]
        public string moduleID { get; set; }
        [MaxLength(50)]
        public string moduleName { get; set; }
        [MaxLength(15)]
        public string staffID { get; set; }
        [MaxLength(5)]
        public string courseID { get; set; }
        [MaxLength(3)]
        public string creditID { get; set; }
    }
}
