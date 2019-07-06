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
    public class CategoryItemsDAL:ICategoryItemsDAL
    {
        DBHelper db = new DBHelper();
        public List<CategoryItems> GetTable(string TablName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<CategoryItems> GetList()
        {
            string sql = "select * from CategoryItems";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<CategoryItems> GetList = new List<CategoryItems>();
            foreach (DataRow item in dt.Rows)
            {
                CategoryItems entity = new CategoryItems();
                entity.CID = int.Parse(item["CID"].ToString());
                entity.C_Category = item["C_Category"].ToString();
                entity.CI_ID = int.Parse(item["CI_ID"].ToString());
                entity.CI_Name = item["CI_Name"].ToString();
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public CategoryItems GetListyi(int id)
        {
            string sql = "select * from CategoryItems where CID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            CategoryItems entity = new CategoryItems();
            foreach (DataRow item in dt.Rows)
            {            
                entity.CID = int.Parse(item["CID"].ToString());
                entity.C_Category = item["C_Category"].ToString();
                entity.CI_ID = int.Parse(item["CI_ID"].ToString());
                entity.CI_Name = item["CI_Name"].ToString();
            }
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(CategoryItems entity)
        {
            string sql = "insert into CategoryItems(C_Category,CI_ID,CI_Name)values(@C_Category,@CI_ID,@CI_Name)";
            db.PrepareSql(sql);
            db.SetParameter("C_Category", entity.C_Category);
            db.SetParameter("CI_ID", entity.CI_ID);
            db.SetParameter("CI_Name", entity.CI_Name);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from CategoryItems where CID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(CategoryItems entity)
        {
            string sql = "update CategoryItems set C_Category=@C_Category,CI_ID=@CI_ID,CI_Name=@CI_Name where CID=@CID";
            db.PrepareSql(sql);
            db.SetParameter("CID", entity.CID);
            db.SetParameter("C_Category", entity.C_Category);
            db.SetParameter("CI_ID", entity.CI_ID);
            db.SetParameter("CI_Name", entity.CI_Name);
            return db.ExecNonQuery();
        }
    }
}
