using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAL;
using System.Data;

namespace DAL
{
   public  class LeaveDAL:ILeaveDAL
    {

       DBHelper db = new DBHelper();
       /// <summary>
       /// 分页
       /// </summary>
       /// <param name="entity"></param>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="count"></param>
       /// <returns></returns>
        public List<Leave> GetPage(Leave entity, int PageIndex, int PageSize, out int count)
        {
            throw new NotImplementedException();
        }
      /// <summary>
      /// 查询
      /// </summary>
      /// <returns></returns>
        public List<Leave> GetList()
        {
            string sql = " select * from Leave";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Leave> GetList = new List<Leave>();
            foreach (DataRow item in dt.Rows)
            {
                Leave entity = new Leave();
                entity.LeaveID =int.Parse( item["LeaveID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.LeaveState = int.Parse(item["LeaveState"].ToString());
                entity.LeaveTime =DateTime.Parse( item["LeaveTime"].ToString());
                entity.LeaveStartTime = DateTime.Parse(item["LeaveStartTime"].ToString());
                entity.LeaveEndTime = DateTime.Parse(item["LeaveEndTime"].ToString());
                entity.LeaveHalfDay = item["LeaveHalfDay"].ToString();
                entity.LeaveDays = int.Parse(item["LeaveDays"].ToString());
                entity.LeaveReason = item["LeaveReason"].ToString();
                entity.ApproverID = int.Parse(item["ApproverID"].ToString());
                entity.ApprovalTime = DateTime.Parse(item["ApprovalTime"].ToString());
                entity.ApproverReason = item["ApproverReason"].ToString();
                GetList.Add(entity);
            }
            return GetList;
        }
       /// <summary>
       /// 详情
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Leave GetListyi(int id)
        {
            string sql = "select * from Leave where LeaveID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Leave entity = new Leave();
            foreach (DataRow item in dt.Rows)
            {   
                entity.LeaveID = int.Parse(item["LeaveID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.LeaveState = int.Parse(item["LeaveState"].ToString());
                entity.LeaveTime = DateTime.Parse(item["LeaveTime"].ToString());
                entity.LeaveStartTime = DateTime.Parse(item["LeaveStartTime"].ToString());
                entity.LeaveEndTime = DateTime.Parse(item["LeaveEndTime"].ToString());
                entity.LeaveHalfDay = item["LeaveHalfDay"].ToString();
                entity.LeaveDays = int.Parse(item["LeaveDays"].ToString());
                entity.LeaveReason = item["LeaveReason"].ToString();
                entity.ApproverID = int.Parse(item["ApproverID"].ToString());
                entity.ApprovalTime = DateTime.Parse(item["ApprovalTime"].ToString());
                entity.ApproverReason = item["ApproverReason"].ToString();
            }
            return entity;
        }
       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
        public int Add(Leave entity)
        {
            string sql = "insert into Leave(UserID,LeaveState,LeaveTime,LeaveStartTime,LeaveEndTime,LeaveHalfDay,LeaveDays,LeaveReason,ApproverID,ApprovalTime,ApproverReason)values(UserID,LeaveState,LeaveTime,LeaveStartTime,LeaveEndTime,LeaveHalfDay,LeaveDays,LeaveReason,ApproverID,ApprovalTime,ApproverReason)";
            db.PrepareSql(sql);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("LeaveState", entity.LeaveState);
            db.SetParameter("LeaveTime", entity.LeaveTime);
            db.SetParameter("LeaveStartTime", entity.LeaveStartTime);
            db.SetParameter("LeaveEndTime", entity.LeaveEndTime);
            db.SetParameter("LeaveHalfDay", entity.LeaveHalfDay);
            db.SetParameter("LeaveDays", entity.LeaveDays);
            db.SetParameter("LeaveReason", entity.LeaveReason);
            db.SetParameter("ApproverID", entity.ApproverID);
            db.SetParameter("ApprovalTime", entity.ApprovalTime);
            db.SetParameter("ApproverReason", entity.ApproverReason);
            return db.ExecNonQuery();
        }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from Leave where LeaveID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
        public int Update(Leave entity)
        {
            string sql = "update Leave set UserID=@UserID,LeaveState=@LeaveState,LeaveTime=@LeaveTime,LeaveStartTime=@LeaveStartTime,LeaveEndTime=@LeaveEndTime,LeaveHalfDay=@LeaveHalfDay,LeaveDays=@LeaveDays,LeaveReason=@LeaveReason,ApproverID=@ApproverID,ApprovalTime=@ApprovalTime,ApproverReason=@ApproverReason where LeaveID=@LeaveID";
            db.PrepareSql(sql);
            db.SetParameter("LeaveID", entity.LeaveID);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("LeaveState", entity.LeaveState);
            db.SetParameter("LeaveTime", entity.LeaveTime);
            db.SetParameter("LeaveStartTime", entity.LeaveStartTime);
            db.SetParameter("LeaveEndTime", entity.LeaveEndTime);
            db.SetParameter("LeaveHalfDay", entity.LeaveHalfDay);
            db.SetParameter("LeaveDays", entity.LeaveDays);
            db.SetParameter("LeaveReason", entity.LeaveReason);
            db.SetParameter("ApproverID", entity.ApproverID);
            db.SetParameter("ApprovalTime", entity.ApprovalTime);
            db.SetParameter("ApproverReason", entity.ApproverReason);
            return db.ExecNonQuery();
        }
    }
}
