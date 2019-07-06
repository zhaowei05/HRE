using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Entity;
using System.Data;

namespace DAL
{
    public class SystemLogDAL:ISystemLogDAL
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<SystemLog> GetList()
        {
            string sql = "select * from SystemLog";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SystemLog> GetList = new List<SystemLog>();
            foreach (DataRow item in dt.Rows)
            {
                SystemLog entity = new SystemLog();
                entity.LogID = int.Parse(item["LogID"].ToString());
                entity.userID = int.Parse(item["userID"].ToString());
                entity.LogTime =DateTime.Parse( item["LogTime"].ToString());
                entity.LogOperation = item["LogOperation"].ToString();
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemLog GetListyi(int id)
        {
            string sql = "select * from SystemLog";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            SystemLog entity = new SystemLog();
            foreach (DataRow item in dt.Rows)
            {
                entity.LogID = int.Parse(item["LogID"].ToString());
                entity.userID = int.Parse(item["userID"].ToString());
                entity.LogTime = DateTime.Parse(item["LogTime"].ToString());
                entity.LogOperation = item["LogOperation"].ToString();
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(SystemLog entity)
        {
            string sql = "insert into  SystemLog(userID,LogTime,LogOperation) values(@userID,@LogTime,@LogOperation)";
            db.PrepareSql(sql);
            db.SetParameter("userID", entity.userID);
            db.SetParameter("LogTime", entity.LogTime);
            db.SetParameter("LogOperation", entity.LogOperation);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "detele from SystemLog where LogID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(SystemLog entity)
        {
            string sql = "update SystemLog set userID=@userID,LogTime=@LogTime,LogOperation=@LogOperation where LogID=@LogID";
            db.PrepareSql(sql);
            db.SetParameter("LogID", entity.LogID);
            db.SetParameter("userID", entity.userID);
            db.SetParameter("LogTime", entity.LogTime);
            db.SetParameter("LogOperation", entity.LogOperation);
            return db.ExecNonQuery();
        }
    }
}
