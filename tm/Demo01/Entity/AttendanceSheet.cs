using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class AttendanceSheet
    {
        public int AttendanceID { get; set; }
        public Nullable<System.DateTime> AttendanceStartTime { get; set; }
        public Nullable<int> AttendanceType { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> ClockTime { get; set; }
        public Nullable<System.DateTime> ClockOutTime { get; set; }
        public Nullable<int> Workinghours { get; set; }
        public string remake { get; set; }
        public Nullable<int> Late { get; set; }
        public Nullable<int> Absenteeism { get; set; }
    }
}
