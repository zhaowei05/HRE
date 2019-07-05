using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class PaySlipID
    {
        public int id { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<decimal> BasicSalary { get; set; }
        public Nullable<decimal> AttendanceBonus { get; set; }
        public Nullable<decimal> Fine { get; set; }
        public Nullable<System.DateTime> SalaryTime { get; set; }
        public Nullable<decimal> SalarySum { get; set; }
    }
}
