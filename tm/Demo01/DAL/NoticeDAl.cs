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
   public class NoticeDAL:INoticeDAL
    {

       DBHelper db = new DBHelper();
       /// <summary>
       /// 查询
       /// </summary>
       /// <returns></returns>
        public List<Notice> GetList()
        {
            string sql = "select * from Notice";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Notice> GetList = new List<Notice>();
            foreach (DataRow item in dt.Rows)
            {
                Notice entity = new Notice();
                entity.NoticeID = int.Parse(item["NoticeID"].ToString());
                entity.NoticeType = int.Parse(item["NoticeType"].ToString());
                entity.NoticeTitle = item["NoticeTitle"].ToString();
                entity.NoticeContent = item["NoticeContent"].ToString();
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.NoticeStateTime =DateTime.Parse( item["NoticeStateTime"].ToString());
                entity.NoticeEndTime =DateTime.Parse( item["NoticeEndTime"].ToString());
                entity.NoticeState = int.Parse(item["NoticeState"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
       /// <summary>
       /// 详情
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Notice GetListyi(int id)
        {
            string sql = "select * from Notice where NoticeID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Notice entity = new Notice();
            foreach (DataRow item in dt.Rows)
            {
                entity.NoticeID = int.Parse(item["NoticeID"].ToString());
                entity.NoticeType = int.Parse(item["NoticeType"].ToString());
                entity.NoticeTitle = item["NoticeTitle"].ToString();
                entity.NoticeContent = item["NoticeContent"].ToString();
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.NoticeStateTime = DateTime.Parse(item["NoticeStateTime"].ToString());
                entity.NoticeEndTime = DateTime.Parse(item["NoticeEndTime"].ToString());
                entity.NoticeState = int.Parse(item["NoticeState"].ToString());
            }
            return entity;
        }
       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
        public int Add(Notice entity)
        {
            string sql = "insert into Notice(NoticeType,NoticeTitle,NoticeContent,UserID,NoticeStateTime,NoticeEndTime,NoticeState)values(@NoticeType,@NoticeTitle,@NoticeContent,@UserID,@NoticeStateTime,@NoticeEndTime,@NoticeState)";
            db.PrepareSql(sql);
            db.SetParameter("NoticeType", entity.NoticeType);
            db.SetParameter("NoticeTitle", entity.NoticeTitle);
            db.SetParameter("NoticeContent", entity.NoticeContent);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("NoticeStateTime", entity.NoticeStateTime);
            db.SetParameter("NoticeEndTime", entity.NoticeEndTime);
            db.SetParameter("NoticeState", entity.NoticeState);
          return  db.ExecNonQuery();
        }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from  Notice where NoticeID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();

        }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
        public int Update(Notice entity)
        {
            string sql = "update Notice set NoticeType=@NoticeType,NoticeTitle=@NoticeTitle,NoticeContent=@NoticeContent,UserID=@UserID,NoticeStateTime=@NoticeStateTime,NoticeEndTime=@NoticeEndTime,NoticeState=@NoticeState where NoticeID=@NoticeID";
            db.PrepareSql(sql);
            db.SetParameter("NoticeID", entity.NoticeID);
            db.SetParameter("NoticeType", entity.NoticeType);
            db.SetParameter("NoticeTitle", entity.NoticeTitle);
            db.SetParameter("NoticeContent", entity.NoticeContent);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("NoticeStateTime", entity.NoticeStateTime);
            db.SetParameter("NoticeEndTime", entity.NoticeEndTime);
            db.SetParameter("NoticeState", entity.NoticeState);
            return db.ExecNonQuery();
        }
    }
}
