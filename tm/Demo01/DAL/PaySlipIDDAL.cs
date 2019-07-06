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
    public class PaySlipIDDAL:IPaySlipIDDAL
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
        public List<PaySlipID> GetList()
        {
            string sql = "select * from PaySlipID";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PaySlipID> GetList = new List<PaySlipID>();
            foreach (DataRow item in dt.Rows)
            {
                PaySlipID entity = new PaySlipID();
                entity.id = int.Parse(item["id"].ToString());
                entity.UserID =  int.Parse(item["UserID"].ToString());
                entity.BasicSalary =decimal.Parse( item["BasicSalary"].ToString());
                entity.AttendanceBonus =decimal.Parse( item["AttendanceBonus"].ToString());
                entity.Fine =decimal.Parse( item["Fine"].ToString());
                entity.SalaryTime =DateTime.Parse( item["SalaryTime"].ToString());
                entity.SalarySum = decimal.Parse(item["SalarySum"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaySlipID GetListyi(int id)
        {
            string sql = "select * from PaySlipID where id="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PaySlipID entity = new PaySlipID();
            foreach (DataRow item in dt.Rows)
            {    
                entity.id = int.Parse(item["id"].ToString());
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.BasicSalary = decimal.Parse(item["BasicSalary"].ToString());
                entity.AttendanceBonus = decimal.Parse(item["AttendanceBonus"].ToString());
                entity.Fine = decimal.Parse(item["Fine"].ToString());
                entity.SalaryTime = DateTime.Parse(item["SalaryTime"].ToString());
                entity.SalarySum = decimal.Parse(item["SalarySum"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(PaySlipID entity)
        {
            string sql = "insert into PaySlipID(UserID,BasicSalary,AttendanceBonus,Fine,SalaryTime,SalarySum) values(@UserID,@BasicSalary,@AttendanceBonus,@Fine,@SalaryTime,@SalarySum)";
            db.PrepareSql(sql);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("BasicSalary", entity.BasicSalary);
            db.SetParameter("AttendanceBonus", entity.AttendanceBonus);
            db.SetParameter("Fine", entity.Fine);
            db.SetParameter("SalaryTime", entity.SalaryTime);
            db.SetParameter("SalarySum", entity.SalarySum);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from PaySlipID where id=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(PaySlipID entity)
        {
            string sql = "update PaySlipID set UserID=@UserID,BasicSalary=@BasicSalary,AttendanceBonus=@AttendanceBonus,Fine=@Fine,SalaryTime=@SalaryTime,SalarySum=@SalarySum where id=@id";
            db.PrepareSql(sql);
            db.SetParameter("id", entity.id);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("BasicSalary", entity.BasicSalary);
            db.SetParameter("AttendanceBonus", entity.AttendanceBonus);
            db.SetParameter("Fine", entity.Fine);
            db.SetParameter("SalaryTime", entity.SalaryTime);
            db.SetParameter("SalarySum", entity.SalarySum);
            return db.ExecNonQuery();
        }
    }
}
