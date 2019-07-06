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
    public class RoleDAL:IRoleDAL
    {
        DBHelper db = new DBHelper();
     /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Role> GetList()
        {
            string sql = "select * from Role";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Role> GetList = new List<Role>();
            foreach (DataRow item in dt.Rows)
            {
                Role entity = new Role();
                entity.RoleID = int.Parse(item["RoleID"].ToString());
                entity.RoleName =item["RoleName"].ToString();
                entity.RoleNumber = item["RoleNumber"].ToString();
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public Role GetListyi(int id)
        {
            string sql = "select * from Role where RoleID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Role entity = new Role();
            foreach (DataRow item in dt.Rows)
            {
              
                entity.RoleID = int.Parse(item["RoleID"].ToString());
                entity.RoleName = item["RoleName"].ToString();
                entity.RoleNumber = item["RoleNumber"].ToString();
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(Role entity)
        {
            string sql = "insert into Role(RoleName,RoleNumber)values(@RoleName,@RoleNumber)";
            db.PrepareSql(sql);
            db.SetParameter("RoleName", entity.RoleName);
            db.SetParameter("RoleNumber", entity.RoleNumber);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from Role where RoleID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(Role entity)
        {
            string sql = "update  Role set RoleName=@RoleName,RoleNumber=@RoleNumber where RoleID=@RoleID  ";
            db.PrepareSql(sql);
            db.SetParameter("RoleName", entity.RoleName);
            db.SetParameter("RoleNumber", entity.RoleNumber);
            db.SetParameter("RoleID", entity.RoleID);
            return db.ExecNonQuery();
        }
    }
}
