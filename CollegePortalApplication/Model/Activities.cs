using System;
using SQLite;
namespace CollegePortalApplication.Model
{
    public class Activities
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(5)]
        public string moduleID { get; set; }

        [MaxLength(40)]
        public string studentID { get; set; }

        [MaxLength(15)]
        public string type { get; set; }
        public double grade { get; set; }
        public int weight { get; set; }
        public DateTime dueDate { get; set; }
    }
}

