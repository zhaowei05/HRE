using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class Leave
    {
        public int LeaveID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> LeaveState { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public Nullable<System.DateTime> LeaveStartTime { get; set; }
        public Nullable<System.DateTime> LeaveEndTime { get; set; }
        public string LeaveHalfDay { get; set; }
        public Nullable<int> LeaveDays { get; set; }
        public string LeaveReason { get; set; }
        public Nullable<int> ApproverID { get; set; }
        public Nullable<System.DateTime> ApprovalTime { get; set; }
        public string ApproverReason { get; set; }
    }
}
