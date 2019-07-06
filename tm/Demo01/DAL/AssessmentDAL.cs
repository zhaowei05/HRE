﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAL;
using System.Data;

namespace DAL
{
    public class AssessmentDAL:IAssessmentDAL
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Assessment> GetList()
        {
            string sql = "select * from Assessment";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Assessment> GetList = new List<Assessment>();
            foreach (DataRow item in dt.Rows)
            {
                Assessment entity=new Assessment();
                entity.AssessmentID =int.Parse(item["AssessmentID"].ToString());
                entity.PerformanceTime =DateTime.Parse(item["PerformanceTime"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.WorkSummary = item["WorkSummary"].ToString();
                entity.UpperGoal = item["UpperGoal"].ToString();
                entity.CompletionDegree = int.Parse(item["CompletionDegree"].ToString());
                entity.ExaminationItems =item["ExaminationItems"].ToString();
                entity.NextStageObjectives = item["NextStageObjectives"].ToString();
                entity.PerformanceScore = int.Parse(item["PerformanceScore"].ToString());
                entity.comments = item["comments"].ToString();
                entity.perstate = int.Parse(item["perstate"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public Assessment GetListyi(int id)
        {
            string sql = "select * from Assessment where AssessmentID=" + id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Assessment entity = new Assessment();
            foreach (DataRow item in dt.Rows)
            {
                entity.AssessmentID = int.Parse(item["AssessmentID"].ToString());
                entity.PerformanceTime = DateTime.Parse(item["PerformanceTime"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.WorkSummary = item["WorkSummary"].ToString();
                entity.UpperGoal = item["UpperGoal"].ToString();
                entity.CompletionDegree = int.Parse(item["CompletionDegree"].ToString());
                entity.ExaminationItems = item["ExaminationItems"].ToString();
                entity.NextStageObjectives = item["NextStageObjectives"].ToString();
                entity.PerformanceScore = int.Parse(item["PerformanceScore"].ToString());
                entity.comments = item["comments"].ToString();
                entity.perstate = int.Parse(item["perstate"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(Assessment entity)
        {
           string sql="insert into Assessment(PerformanceTime)"
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(Assessment entity)
        {
            throw new NotImplementedException();
        }
    }
}
