
using System;
using System.Collections.Generic;
namespace Entity
{

    
    public partial class Assessment
    {
        public int AssessmentID { get; set; }
        public Nullable<System.DateTime> PerformanceTime { get; set; }
        public Nullable<int> UserID { get; set; }
        public string WorkSummary { get; set; }
        public string UpperGoal { get; set; }
        public Nullable<double> CompletionDegree { get; set; }
        public string ExaminationItems { get; set; }
        public string NextStageObjectives { get; set; }
        public Nullable<double> PerformanceScore { get; set; }
        public string comments { get; set; }
        public Nullable<int> perstate { get; set; }
    }
}
