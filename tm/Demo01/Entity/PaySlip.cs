using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class PaySlip
    {
        public int PaySlipID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<decimal> Prize { get; set; }
        public Nullable<decimal> LeaveMoney { get; set; }
        public Nullable<decimal> OvertimeMoney { get; set; }
        public Nullable<decimal> LateMoney { get; set; }
        public Nullable<decimal> AdvanceMoney { get; set; }
        public Nullable<decimal> Absence { get; set; }
        public Nullable<decimal> fine { get; set; }
        public Nullable<decimal> Sa_Bonus { get; set; }
        public Nullable<System.DateTime> Sa_Time { get; set; }
        public Nullable<decimal> Sa_TotalSalary { get; set; }
    }
}
