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
    public class DepartmentDAL:IDepartmentDAL
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Department> GetList()
        {
            string sql = "select * from Department";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Department> GetList = new List<Department>();
            foreach (DataRow item in dt.Rows)
            {
                Department entity = new Department();
                entity.DepartmentID = int.Parse(item["DepartmentID"].ToString());
                entity.DepartmentName = item["DepartmentName"].ToString();
                entity.DepartmentRemarks = int.Parse(item["DepartmentRemarks"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetListyi(int id)
        {
            string sql = "select * from Department where DepartmentID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Department entity = new Department();
            foreach (DataRow item in dt.Rows)
            {      
                entity.DepartmentID = int.Parse(item["DepartmentID"].ToString());
                entity.DepartmentName = item["DepartmentName"].ToString();
                entity.DepartmentRemarks = int.Parse(item["DepartmentRemarks"].ToString());
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Add(Department entity)
        {
            string sql = "insert into  Department(DepartmentName,DepartmentRemarks) values(@DepartmentName,@DepartmentRemarks)";
            db.PrepareSql(sql);
            db.SetParameter("DepartmentName", entity.DepartmentName);
            db.SetParameter("DepartmentRemarks", entity.DepartmentRemarks);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from Department where DepartmentID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update(Department entity)
        {
            string sql = "update Department set DepartmentName=@DepartmentName,DepartmentRemarks=@DepartmentRemarks where DepartmentID=@DepartmentID";
            db.SetParameter("DepartmentID", entity.DepartmentID);
            db.SetParameter("DepartmentRemarks", entity.DepartmentRemarks);
            db.SetParameter("DepartmentName", entity.DepartmentName);
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
    }
}
