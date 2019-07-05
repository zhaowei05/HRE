using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class Notice
    {
        public int NoticeID { get; set; }
        public Nullable<int> NoticeType { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeContent { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> NoticeStateTime { get; set; }
        public Nullable<System.DateTime> NoticeEndTime { get; set; }
        public Nullable<int> NoticeState { get; set; }
    }
}
