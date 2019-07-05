using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class PayRise
    {
        public int PayRiseID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<decimal> PayRiseMoney { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> ApplicationTime { get; set; }
        public string ApprovalContent { get; set; }
        public Nullable<int> ApprovalState { get; set; }
        public Nullable<System.DateTime> ApprovalTime { get; set; }
    }
}
