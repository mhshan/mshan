//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2015 , Mshan, Ltd. 
//-----------------------------------------------------------------

using System.Reflection;

namespace Mshan.Utilities.DbUtilities
{
    /// <summary>
    /// DbHelperFactory
    /// 数据库服务工厂。
    /// 
    /// 修改纪录
    /// 
    /// 
    /// <author>
    ///		<name>Mshan</name>
    ///		<date>2011.10.09</date>
    /// </author> 
    /// </summary>
    public class DbHelperFactory
    {
        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(string connectionString)
        {
            CurrentDbType dbType = CurrentDbType.SqlServer;
            return GetHelper(dbType, connectionString);
        }

        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="dataBaseType">数据库类型</param>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(CurrentDbType dbType = CurrentDbType.SqlServer, string connectionString = null)
        {
            // 这里是每次都获取新的数据库连接,否则会有并发访问的问题存在
            string dbHelperClass = DbHelper.GetDbHelperClass(dbType);
            IDbHelper dbHelper = (IDbHelper)Assembly.Load("Mshan.Utilities.DbUtilities").CreateInstance(dbHelperClass, true);
            if (!string.IsNullOrEmpty(connectionString))
            {
                dbHelper.ConnectionString = connectionString;
            }
            else
            {
                dbHelper.ConnectionString = BaseSystemInfo.UserCenterDbConnection;
            }
            return dbHelper;
        }
    }
}
