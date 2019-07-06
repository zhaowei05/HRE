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

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Entity.UserInfo> GetPage(Entity.UserInfo entity, int PageIndex, int PageSize, out int count)
        { 
            string sqlwhere = "";
            if (entity.DepartmentID!=0)
            {
                sqlwhere += " and UserInfo.DepartmentID="+entity.DepartmentID;
            }
            if (entity.UserName!=null && !entity.UserName.Equals(""))
            {
                sqlwhere += " and UserInfo.UserName like '%"+entity.UserName+"%'";
            }
            string sql = "select count(*) from UserInfo where 1=1 " +sqlwhere;
            count = (int)db.ExecScalar();
            sql = @"select * from (
                    select UserInfo.*,ROW_NUMBER() over(order by UserInfo.UserID) rowid,Department.DepartmentName 
                    from UserInfo inner join Department on UserInfo.DepartmentID=Department.DepartmentID
                    where 1=1 " + sqlwhere + ") tamp where rowid between @PageIndex and @PageSize";
            db.PrepareSql(sql);
            db.SetParameter("PageIndex", (PageIndex - 1) * PageSize + 1);
            db.SetParameter("PageSize", PageIndex * PageSize);
            DataTable dt = new DataTable();
            dt = db.ExecQuery();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Entity.UserInfo> GetList = new List<UserInfo>();
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
                entity.department=new Department();
                entity.department.DepartmentName = item["DepartmentName"].ToString(); 
                GetList.Add(entity);
            }
            return GetList;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Entity.UserInfo> GetList()
        {
            string sql = "select * from UserInfo inner join Department on UserInfo.DepartmentID=Department.DepartmentID";
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
                entity.department = new Department();
                entity.department.DepartmentName = item["DepartmentName"].ToString(); 
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
            string sql = "select * from UserInfo inner join Department on UserInfo.DepartmentID=Department.DepartmentID where UserID=" + id;
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
                entity.department = new Department();
                entity.department.DepartmentName = item["DepartmentName"].ToString(); 
            }
            return entity;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(Entity.UserInfo entity)
        {
            string sql = "insert into UserInfo(DepartmentID,RoleID,UserNumber,LoginName,LoginPwd,UserName,UserAge,UserSex,UserTel,UserAddress,UserIphone,UserRemarks,UserStatr,EntryTime,DimissionTime,BasePay) values(@UserID,@DepartmentID,@RoleID,@UserNumber,@LoginName,@LoginPwd,@UserName,@UserAge,@UserSex,@UserTel,@UserAddress,@UserIphone,@UserRemarks,@UserStatr,@EntryTime,@DimissionTime,@BasePay)";
            db.PrepareSql(sql);
            db.SetParameter("DepartmentID", entity.DepartmentID);
            db.SetParameter("RoleID", entity.RoleID);
            db.SetParameter("UserNumber", entity.UserNumber);
            db.SetParameter("LoginName", entity.LoginName);
            db.SetParameter("LoginPwd", entity.LoginPwd);
            db.SetParameter("UserName", entity.UserName);
            db.SetParameter("UserAge", entity.UserAge);
            db.SetParameter("UserSex", entity.UserSex);
            db.SetParameter("UserTel", entity.UserTel);
            db.SetParameter("UserAddress", entity.UserAddress);
            db.SetParameter("UserIphone", entity.UserIphone);
            db.SetParameter("UserRemarks", entity.UserRemarks);
            db.SetParameter("UserStatr", entity.UserStatr);
            db.SetParameter("EntryTime", entity.EntryTime);
            db.SetParameter("DimissionTime", entity.DimissionTime);
            db.SetParameter("BasePay", entity.BasePay);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from UserInfo where UserID=" + id;
            db.PrepareSql(sql);
            return db.ExecNonQuery();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(Entity.UserInfo entity)
        {
            string sql = "update UserInfo set DepartmentID=@DepartmentID,RoleID=@RoleID,UserNumber=@UserNumber,LoginName=@LoginName,LoginPwd=@LoginPwd,UserName=@UserName,UserAge=@UserAge,UserSex=@UserSex,UserTel=@UserTel,UserAddress=@UserAddress,UserIphone=@UserIphone,UserRemarks=@UserRemarks,UserStatr=@UserStatr,EntryTime=@EntryTime,DimissionTime=@DimissionTime,BasePay=@BasePay where UserID=@UserID";
            db.PrepareSql(sql);
            db.SetParameter("UserID", entity.UserID);
            db.SetParameter("DepartmentID", entity.DepartmentID);
            db.SetParameter("RoleID", entity.RoleID);
            db.SetParameter("UserNumber", entity.UserNumber);
            db.SetParameter("LoginName", entity.LoginName);
            db.SetParameter("LoginPwd", entity.LoginPwd);
            db.SetParameter("UserName", entity.UserName);
            db.SetParameter("UserAge", entity.UserAge);
            db.SetParameter("UserSex", entity.UserSex);
            db.SetParameter("UserTel", entity.UserTel);
            db.SetParameter("UserAddress", entity.UserAddress);
            db.SetParameter("UserIphone", entity.UserIphone);
            db.SetParameter("UserRemarks", entity.UserRemarks);
            db.SetParameter("UserStatr", entity.UserStatr);
            db.SetParameter("EntryTime", entity.EntryTime);
            db.SetParameter("DimissionTime", entity.DimissionTime);
            db.SetParameter("BasePay", entity.BasePay);
            return db.ExecNonQuery();
        }
    }
}
