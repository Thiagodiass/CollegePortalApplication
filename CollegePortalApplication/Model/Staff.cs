using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class Staff
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(15)]
        public string staffID { get; set; }
        [MaxLength(50)]
        public string firstName { get; set; }
        [MaxLength(50)]
        public string lastName { get; set; }
        [MaxLength(20)]
        public string phoneNumber { get; set; }
        [MaxLength(155)]
        public string email { get; set; }
        public DateTime dayOfBirth { get; set; }
        [MaxLength(15)]
        public string gender { get; set; }
        [MaxLength(255)]
        public string street { get; set; }
        [MaxLength(60)]
        public string city { get; set; }
        [MaxLength(15)]
        public string postCode { get; set; }
        [MaxLength(15)]
        public string idNumber { get; set; }
        [MaxLength(50)]
        public string password { get; set; }
        public bool active { get; set; }
        [MaxLength(3)]
        public string accountType { get; set; }
    }
}
