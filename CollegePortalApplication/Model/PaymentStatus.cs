using System;
using SQLite;

namespace CollegePortalApplication.Model
{
    public class PaymentStatus
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(15)]
        public string studentID { get; set; }
        [MaxLength(5)]
        public string courseID { get; set; }
        public double fee { get; set; }
        public double amountPaid { get; set; }
        public DateTime date { get; set; }
    }
}
