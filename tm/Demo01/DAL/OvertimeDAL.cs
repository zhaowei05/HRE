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
    public class OvertimeDAL:IOvertimeDAL
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
        public List<UserInfo> GetPage(UserInfo entity, int PageIndex, int PageSize, out int count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Overtime> GetList()
        {
            string sql = "select * from Overtime";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Overtime> GetList = new List<Overtime>();
            foreach (DataRow item in dt.Rows)
            {
                Overtime entity = new Overtime();
                entity.OvertimeID = int.Parse(item["OvertimeID"].ToString());
                entity.OvertimeStateTime =DateTime.Parse(item["OvertimeStateTime"].ToString());
                entity.OvertimeEndTime = DateTime.Parse(item["OvertimeEndTime"].ToString());
                entity.OvertimeDuration = int.Parse(item["OvertimeDuration"].ToString());
                entity.UserID =int.Parse( item["UserID"].ToString());
                entity.ApplyTime = DateTime.Parse(item["ApplyTime"].ToString());
                entity.OvertimeState = int.Parse(item["OvertimeState"].ToString());
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
        public Overtime GetListyi(int id)
        {
            string sql = "select * from Overtime where OvertimeID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Overtime entity = new Overtime();
            foreach (DataRow item in dt.Rows)
            {
                entity.OvertimeID = int.Parse(item["OvertimeID"].ToString());
                entity.OvertimeStateTime = DateTime.Parse(item["OvertimeStateTime"].ToString());
                entity.OvertimeEndTime = DateTime.Parse(item["OvertimeEndTime"].ToString());
                entity.OvertimeDuration = int.Parse(item["OvertimeDuration"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.ApplyTime = DateTime.Parse(item["ApplyTime"].ToString());
                entity.OvertimeState = int.Parse(item["OvertimeState"].ToString());
                entity.ApproverReason = item["ApproverReason"].ToString();
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(Overtime entity)
        {
            string sql = "insert into Overtime(OvertimeStateTime,OvertimeEndTime,OvertimeDuration,UserID,ApplyTime,OvertimeState,ApproverReason) values(@OvertimeStateTime,@OvertimeEndTime,@OvertimeDuration,@UserID,@ApplyTime,@OvertimeState,@ApproverReason)";
            db.PrepareSql(sql);
            db.SetParameter("OvertimeStateTime", entity.OvertimeStateTime);
            db.SetParameter("OvertimeEndTime", entity.OvertimeEndTime);
            db.SetParameter("OvertimeDuration", entity.OvertimeDuration);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("ApplyTime", entity.ApplyTime);
            db.SetParameter("OvertimeState", entity.OvertimeState);
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
            string sql = "delete from Overtime where OvertimeID="+id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(Overtime entity)
        {
            string sql = "update Overtime set OvertimeStateTime=@OvertimeStateTime,OvertimeEndTime=@OvertimeEndTime,OvertimeDuration=@OvertimeDuration,UserID=@UserID,ApplyTime=@ApplyTime,OvertimeState=@OvertimeState,ApproverReason=@ApproverReason where OvertimeID=@OvertimeID";
            db.PrepareSql(sql);
            db.SetParameter("OvertimeID", entity.OvertimeID);
            db.SetParameter("OvertimeStateTime", entity.OvertimeStateTime);
            db.SetParameter("OvertimeEndTime", entity.OvertimeEndTime);
            db.SetParameter("OvertimeDuration", entity.OvertimeDuration);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("ApplyTime", entity.ApplyTime);
            db.SetParameter("OvertimeState", entity.OvertimeState);
            db.SetParameter("ApproverReason", entity.ApproverReason);
            return db.ExecNonQuery();
        }
    }
}
