using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class Overtime
    {
        public int OvertimeID { get; set; }
        public Nullable<System.DateTime> OvertimeStateTime { get; set; }
        public Nullable<System.DateTime> OvertimeEndTime { get; set; }
        public Nullable<int> OvertimeDuration { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<int> OvertimeState { get; set; }
        public string ApproverReason { get; set; }
    }
}
