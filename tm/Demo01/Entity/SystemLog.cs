using System;
using System.Collections.Generic;
namespace Entity
{

    public partial class SystemLog
    {
        public int LogID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<System.DateTime> LogTime { get; set; }
        public string LogOperation { get; set; }
    }
}
