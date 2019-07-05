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
    public class UserInfoDAL:IUserInfoDAL
    {
        DBHelper db = new DBHelper();
        public List<Entity.UserInfo> GetPage(Entity.UserInfo entity, int PageIndex, int PageSize, out int count)
        {
            
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Entity.UserInfo> GetList()
        {
            string sql = "select * from UserInfo";
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            List<Entity.UserInfo> GetList = new List<UserInfo>();
            foreach (DataRow item in dt.Rows)
            {
                UserInfo entity = new UserInfo();
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.DepartmentID = int.Parse(item["DepartmentID"].ToString());
                entity.RoleID = int.Parse(item["RoleID"].ToString());
                entity.UserNumber = item["UserNumber"].ToString();
                entity.LoginName = item["LoginName"].ToString();
                entity.LoginPwd = item["LoginPwd"].ToString();
                entity.UserName = item["UserName"].ToString();
                entity.UserAge = int.Parse(item["UserAge"].ToString());
                entity.UserSex = int.Parse(item["UserSex"].ToString());
                entity.UserTel = item["UserTel"].ToString();
                entity.UserAddress = item["UserAddress"].ToString();
                entity.UserIphone = item["UserIphone"].ToString();
                entity.UserRemarks = item["UserRemarks"].ToString();
                entity.UserStatr = int.Parse(item["UserStatr"].ToString());
                entity.EntryTime =DateTime.Parse(item["EntryTime"].ToString());
                entity.DimissionTime = DateTime.Parse(item["DimissionTime"].ToString());
                entity.BasePay =decimal.Parse(item["BasePay"].ToString());
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.UserInfo GetListyi(int id)
        {
            string sql = "select * from UserInfo where UserID="+id;
            db.PrepareSql(sql);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            UserInfo entity = new UserInfo();
            foreach (DataRow item in dt.Rows)
            {
                entity.UserID = int.Parse(item["UserID"].ToString());
                entity.DepartmentID = int.Parse(item["DepartmentID"].ToString());
                entity.RoleID = int.Parse(item["RoleID"].ToString());
                entity.UserNumber = item["UserNumber"].ToString();
                entity.LoginName = item["LoginName"].ToString();
                entity.LoginPwd = item["LoginPwd"].ToString();
                entity.UserName = item["UserName"].ToString();
                entity.UserAge = int.Parse(item["UserAge"].ToString());
                entity.UserSex = int.Parse(item["UserSex"].ToString());
                entity.UserTel = item["UserTel"].ToString();
                entity.UserAddress = item["UserAddress"].ToString();
                entity.UserIphone = item["UserIphone"].ToString();
                entity.UserRemarks = item["UserRemarks"].ToString();
                entity.UserStatr = int.Parse(item["UserStatr"].ToString());
                entity.EntryTime = DateTime.Parse(item["EntryTime"].ToString());
                entity.DimissionTime = DateTime.Parse(item["DimissionTime"].ToString());
                entity.BasePay = decimal.Parse(item["BasePay"].ToString());
            }
            return entity;
        }

        public int Add(Entity.UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Entity.UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
