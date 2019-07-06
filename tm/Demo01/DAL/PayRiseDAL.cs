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
    public class PayRiseDAL:IPayRiseDAL
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
        public List<PayRise> GetList()
        {
            string sql = "select * from PayRise";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PayRise> GetList = new List<PayRise>();
            foreach (DataRow item in dt.Rows)
            {
                PayRise entity = new PayRise();
                entity.PayRiseID = int.Parse(item["PayRiseID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.PayRiseMoney =decimal.Parse( item["PayRiseMoney"].ToString());
                entity.Reason = item["Reason"].ToString();
                entity.ApplicationTime =DateTime.Parse( item["ApplicationTime"].ToString());
                entity.ApprovalContent = item["ApprovalContent"].ToString();
                entity.ApprovalState = int.Parse(item["ApprovalState"].ToString());
                entity.ApprovalTime = DateTime.Parse(item["ApprovalTime"].ToString());
                GetList.Add(entity); 
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PayRise GetListyi(int id)
        {
            string sql = "select * from PayRise where PayRiseID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PayRise entity = new PayRise();
            foreach (DataRow item in dt.Rows)
            {             
                entity.PayRiseID = int.Parse(item["PayRiseID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.PayRiseMoney = decimal.Parse(item["PayRiseMoney"].ToString());
                entity.Reason = item["Reason"].ToString();
                entity.ApplicationTime = DateTime.Parse(item["ApplicationTime"].ToString());
                entity.ApprovalContent = item["ApprovalContent"].ToString();
                entity.ApprovalState = int.Parse(item["ApprovalState"].ToString());
                entity.ApprovalTime = DateTime.Parse(item["ApprovalTime"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(PayRise entity)
        {
           string sql="insert into  PayRise(UserID,PayRiseMoney,Reason,ApplicationTime,ApprovalContent,ApprovalState,ApprovalTime) values(@UserID,@PayRiseMoney,@Reason,@ApplicationTime,@ApprovalContent,@ApprovalState,@ApprovalTime)";
           db.PrepareSql(sql);
           db.SetParameter("UserID", entity.UserID);
           db.SetParameter("PayRiseMoney", entity.PayRiseMoney);
           db.SetParameter("Reason", entity.Reason);
           db.SetParameter("ApplicationTime", entity.ApplicationTime);
           db.SetParameter("ApprovalContent", entity.ApprovalContent);
           db.SetParameter("ApprovalState", entity.ApprovalState);
           db.SetParameter("ApprovalTime", entity.ApprovalTime);
           return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from PayRise where PayRiseID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(PayRise entity)
        {
            string sql = "update PayRise set UserID=@UserID,PayRiseMoney=@PayRiseMoney,Reason=@Reason,ApplicationTime=@ApplicationTime,ApprovalContent=@ApprovalContent,ApprovalState=@ApprovalState,ApprovalTime=@ApprovalTime where PayRiseID=@PayRiseID";
            db.PrepareSql(sql);
            db.SetParameter("PayRiseID", entity.PayRiseID);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("PayRiseMoney", entity.PayRiseMoney);
            db.SetParameter("Reason", entity.Reason);
            db.SetParameter("ApplicationTime", entity.ApplicationTime);
            db.SetParameter("ApprovalContent", entity.ApprovalContent);
            db.SetParameter("ApprovalState", entity.ApprovalState);
            db.SetParameter("ApprovalTime", entity.ApprovalTime);
            return db.ExecNonQuery();
        }
    }
}
