using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class DBHelper
    {
        //SQL连接字符串-SQL身份认证方式登录
        //public static string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456;";

        //SQL连接字符串-Windows身份认证方式登录
        //public static string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";

        //读取配置文件appSettings节点读取字符串(需要添加引用System.Configuration)
        //public static string connStr = ConfigurationManager.AppSettings["DefaultConn"].ToString();
        //对应的配置文件如下：
        //<appSettings>
        //  <add key="DefaultConn" value="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
        //</appSettings>

        //读取配置文件ConnectionStrings节点读取字符串(需要添加引用System.Configuration)
        public string connStr = ConfigurationManager.ConnectionStrings["DefaultConn"].ConnectionString;
        //对应配置文件如下：
        //<connectionStrings>
        //    <add name="DefaultConn" connectionString="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
        //</connectionStrings>

        public SqlConnection conn = null;
        public SqlDataAdapter adp = null;

        #region 连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        public void OpenConn()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
                conn.Open();
            }
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }
        #endregion

        #region 执行SQL语句前准备
        /// <summary>
        /// 准备执行一个SQL语句
        /// </summary>
        /// <param name="sql">需要执行的SQL语句</param>
        public void PrepareSql(string sql)
        {
            OpenConn(); //打开数据库连接
            adp = new SqlDataAdapter(sql, conn);
        }
        /// <summary>
        /// 准备执行一个存储过程
        /// </summary>
        /// <param name="sql">存储过程名字</param>
        public void PrepareProc(string sql)
        {
            OpenConn(); //打开数据库连接
            adp = new SqlDataAdapter(sql, conn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        #endregion

        #region 设置和获取sql语句的参数
        /// <summary>
        /// 设置传入参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="parameterValue">参数值</param>
        public void SetParameter(string parameterName, object parameterValue)
        {
            parameterName = "@" + parameterName.Trim();
            if (parameterValue == null)
                parameterValue = DBNull.Value;
            adp.SelectCommand.Parameters.Add(new SqlParameter(parameterName, parameterValue));
        }
        /// <summary>
        /// 设置输出参数（不指定长度，适合非字符串）
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        public void SetOutParameter(string parameterName, SqlDbType dbType)
        {
            parameterName = "@" + parameterName.Trim();
            SqlParameter parameter = new SqlParameter(parameterName, dbType);
            parameter.Direction = ParameterDirection.Output;
            adp.SelectCommand.Parameters.Add(parameter);
        }
        /// <summary>
        /// 设置输出参数（指定长度，适合字符串）
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数长度</param>
        public void SetOutParameter(string parameterName, SqlDbType dbType, int size)
        {
            parameterName = "@" + parameterName.Trim();
            SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
            parameter.Direction = ParameterDirection.Output;
            adp.SelectCommand.Parameters.Add(parameter);
        }
        /// <summary>
        /// 设置返回值参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        public void SetReturnParameter(string parameterName)
        {
            parameterName = "@" + parameterName.Trim();
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.Direction = ParameterDirection.ReturnValue;
            adp.SelectCommand.Parameters.Add(parameter);
        }
        /// <summary>
        /// 获取参数内容值
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns>参数值</returns>
        public object GetParameter(string parameterName)
        {
            parameterName = "@" + parameterName.Trim();
            return adp.SelectCommand.Parameters[parameterName].Value;
        }
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <returns>受影响行数</returns>
        public int ExecNonQuery()
        {
            int result = adp.SelectCommand.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>DataTable类型查询结果</returns>
        public DataTable ExecQuery()
        {
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>SqlDataReader类型查询结果,SqlDataReader需要手动关闭</returns>
        public SqlDataReader ExecDataReader()
        {
            return adp.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>查询结果第一行第一列</returns>
        public object ExecScalar()
        {
            object obj = adp.SelectCommand.ExecuteScalar();
            conn.Close();
            return obj;
        }
        #endregion

    }
}


