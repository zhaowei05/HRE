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
    public class PaySlipDAL:IPaySlipDAL
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<PaySlip> GetList()
        {
            string sql = "select * from PaySlip";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PaySlip> GetList = new List<PaySlip>();
            foreach (DataRow item in dt.Rows)
            {
                PaySlip entity = new PaySlip();
                entity.PaySlipID = int.Parse(item["PaySlipID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.Prize =decimal.Parse( item["Prize"].ToString());
                entity.LeaveMoney = decimal.Parse(item["LeaveMoney"].ToString());
                entity.OvertimeMoney = decimal.Parse(item["OvertimeMoney"].ToString());
                entity.LateMoney = decimal.Parse(item["LateMoney"].ToString());
                entity.AdvanceMoney =decimal.Parse( item["AdvanceMoney"].ToString());
                entity.Absence =decimal.Parse( item["Absence"].ToString());
                entity.fine =decimal.Parse( item["fine"].ToString());
                entity.Sa_Bonus = decimal.Parse(item["Sa_Bonus"].ToString());
                entity.Sa_Time =DateTime.Parse( item["Sa_Time"].ToString());
                entity.Sa_TotalSalary = decimal.Parse(item["Sa_TotalSalary"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaySlip GetListyi(int id)
        {
            string sql = "select * from PaySlip where PaySlipID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PaySlip entity = new PaySlip();
            foreach (DataRow item in dt.Rows)
            {
                entity.PaySlipID = int.Parse(item["PaySlipID"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.Prize = decimal.Parse(item["Prize"].ToString());
                entity.LeaveMoney = decimal.Parse(item["LeaveMoney"].ToString());
                entity.OvertimeMoney = decimal.Parse(item["OvertimeMoney"].ToString());
                entity.LateMoney = decimal.Parse(item["LateMoney"].ToString());
                entity.AdvanceMoney = decimal.Parse(item["AdvanceMoney"].ToString());
                entity.Absence = decimal.Parse(item["Absence"].ToString());
                entity.fine = decimal.Parse(item["fine"].ToString());
                entity.Sa_Bonus = decimal.Parse(item["Sa_Bonus"].ToString());
                entity.Sa_Time = DateTime.Parse(item["Sa_Time"].ToString());
                entity.Sa_TotalSalary = decimal.Parse(item["Sa_TotalSalary"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(PaySlip entity)
        {
            string sql = "insert into PaySlip(UserID,Prize,LeaveMoney,OvertimeMoney,LateMoney,AdvanceMoney,Absence,fine,Sa_Bonus,Sa_Time,Sa_TotalSalary) values(@UserID,@Prize,@LeaveMoney,@OvertimeMoney,@LateMoney,@AdvanceMoney,@Absence,@fine,@Sa_Bonus,@Sa_Time,@Sa_TotalSalary)";
            db.PrepareSql(sql);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("Prize", entity.Prize);
            db.SetParameter("LeaveMoney", entity.LeaveMoney);
            db.SetParameter("OvertimeMoney", entity.OvertimeMoney);
            db.SetParameter("LateMoney", entity.LateMoney);
            db.SetParameter("AdvanceMoney", entity.AdvanceMoney);
            db.SetParameter("Absence", entity.Absence);
            db.SetParameter("fine", entity.fine);
            db.SetParameter("Sa_Bonus", entity.Sa_Bonus);
            db.SetParameter("Sa_Time", entity.Sa_Time);
            db.SetParameter("Sa_TotalSalary", entity.Sa_TotalSalary);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from PaySlip where PaySlipID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(PaySlip entity)
        {
            string sql = "update PaySlip set UserID=@UserID,Prize=@Prize,LeaveMoney=@LeaveMoney,OvertimeMoney=@OvertimeMoney,LateMoney=@LateMoney,AdvanceMoney=@AdvanceMoney,Absence=@Absence,fine=@fine,Sa_Bonus=@Sa_Bonus,Sa_Time=@Sa_Time,Sa_TotalSalary=@Sa_TotalSalary where PaySlipID=@PaySlipID";
            db.PrepareSql(sql);
            db.SetParameter("PaySlipID", entity.PaySlipID);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("Prize", entity.Prize);
            db.SetParameter("LeaveMoney", entity.LeaveMoney);
            db.SetParameter("OvertimeMoney", entity.OvertimeMoney);
            db.SetParameter("LateMoney", entity.LateMoney);
            db.SetParameter("AdvanceMoney", entity.AdvanceMoney);
            db.SetParameter("Absence", entity.Absence);
            db.SetParameter("fine", entity.fine);
            db.SetParameter("Sa_Bonus", entity.Sa_Bonus);
            db.SetParameter("Sa_Time", entity.Sa_Time);
            db.SetParameter("Sa_TotalSalary", entity.Sa_TotalSalary);
            return db.ExecNonQuery();
        }
    }
}
