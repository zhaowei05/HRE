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
    public class AttendanceSheetDAL:IAttendanceSheetDAL
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public List<AttendanceSheet> GetPage(AttendanceSheet entity, int PageIndex, int PageSiez, out int count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<AttendanceSheet> GetList()
        {
            string sql = "select * from AttendanceSheet";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<AttendanceSheet> GetList = new List<AttendanceSheet>();
            foreach (DataRow item in dt.Rows)
            {
                AttendanceSheet entity = new AttendanceSheet();
                entity.AttendanceID = int.Parse(item["AttendanceID"].ToString());
                entity.AttendanceStartTime =DateTime.Parse( item["AttendanceStartTime"].ToString());
                entity.AttendanceType = int.Parse(item["AttendanceType"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.ClockTime =DateTime.Parse(item["ClockTime"].ToString());
                entity.ClockOutTime = DateTime.Parse(item["ClockOutTime"].ToString());
                entity.Workinghours = int.Parse(item["Workinghours"].ToString());
                entity.remake = item["remake"].ToString();
                entity.Late = int.Parse(item["Late"].ToString());
                entity.Absenteeism = int.Parse(item["Absenteeism"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public AttendanceSheet GetListyi(int id)
        {
            string sql = "select * from AttendanceSheet where AttendanceID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            AttendanceSheet entity = new AttendanceSheet();
            foreach (DataRow item in dt.Rows)
            {  
                entity.AttendanceID = int.Parse(item["AttendanceID"].ToString());
                entity.AttendanceStartTime = DateTime.Parse(item["AttendanceStartTime"].ToString());
                entity.AttendanceType = int.Parse(item["AttendanceType"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.ClockTime = DateTime.Parse(item["ClockTime"].ToString());
                entity.ClockOutTime = DateTime.Parse(item["ClockOutTime"].ToString());
                entity.Workinghours = int.Parse(item["Workinghours"].ToString());
                entity.remake = item["remake"].ToString();
                entity.Late = int.Parse(item["Late"].ToString());
                entity.Absenteeism = int.Parse(item["Absenteeism"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(AttendanceSheet entity)
        {
            string sql = "insert into AttendanceSheet(AttendanceStartTime,AttendanceType,UserID,ClockTime,ClockOutTime,Workinghours,remake,Late,Absenteeism) values(@AttendanceStartTime,@AttendanceType,@UserID,@ClockTime,@ClockOutTime,@Workinghours,@remake,@Late,@Absenteeism)";
            db.PrepareSql(sql);
            db.SetParameter("AttendanceStartTime", entity.AttendanceStartTime);
            db.SetParameter("AttendanceType", entity.AttendanceType);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("ClockTime", entity.ClockTime);
            db.SetParameter("ClockOutTime", entity.ClockOutTime);
            db.SetParameter("Workinghours", entity.Workinghours);
            db.SetParameter("remake", entity.remake);
            db.SetParameter("Late", entity.Late);
            db.SetParameter("Absenteeism", entity.Absenteeism);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from AttendanceSheet where AttendanceID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(AttendanceSheet entity)
        {
            string sql = "update AttendanceSheet set AttendanceStartTime=@AttendanceStartTime,AttendanceType=@AttendanceType,UserID=@UserID,ClockTime=@ClockTime,ClockOutTime=@ClockOutTime,Workinghours=@Workinghours,remake=@remake,Late=@Late,Absenteeism=@Absenteeism where AttendanceID=@AttendanceID";
            db.PrepareSql(sql);
            db.SetParameter("AttendanceStartTime", entity.AttendanceStartTime);
            db.SetParameter("AttendanceType", entity.AttendanceType);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("ClockTime", entity.ClockTime);
            db.SetParameter("ClockOutTime", entity.ClockOutTime);
            db.SetParameter("Workinghours", entity.Workinghours);
            db.SetParameter("remake", entity.remake);
            db.SetParameter("Late", entity.Late);
            db.SetParameter("Absenteeism", entity.Absenteeism);
            db.SetParameter("AttendanceID", entity.AttendanceID);
            return db.ExecNonQuery();
        }
    }
}
