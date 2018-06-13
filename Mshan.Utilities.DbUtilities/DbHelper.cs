//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2015 , Mshan, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Mshan.Utilities.DbUtilities
{
    /// <summary>
    /// DbHelper
    /// 有关数据库连接的方法。
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.18 版本：2.0 Mshan 采用默认参数技术,把一些方法进行简化。
    ///		2008.09.03 版本：1.0 Mhshan 创建。
    /// 
    /// <author>
    ///		<name>Mshan</name>
    ///		<date>2011.09.18</date>
    /// </author> 
    /// </summary>
    public partial class DbHelper
    {
        #region public static DbType GetDbType(string dbType) 数据库连接的类型判断
        /// <summary>
        /// 数据库连接的类型判断
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库类型</returns>
        public static CurrentDbType GetDbType(string dbType)
        {
            CurrentDbType result = CurrentDbType.SqlServer;
            foreach (CurrentDbType currentDbType in Enum.GetValues(typeof(CurrentDbType)))
            {
                if (currentDbType.ToString().Equals(dbType))
                {
                    result = currentDbType;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region public static CommandType GetCommandType(string commandType) 数据库连接的类型判断
        /// <summary>
        /// 数据库连接的类型判断
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <returns>命令类型</returns>
        public static CommandType GetCommandType(string commandType)
        {
            CommandType result = CommandType.Text;
            foreach (CommandType currentCommandType in Enum.GetValues(typeof(CommandType)))
            {
                if (currentCommandType.ToString().Equals(commandType))
                {
                    result = currentCommandType;
                    break;
                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 按数据类型获取数据库访问实现类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库访问实现类</returns>
        public static string GetDbHelperClass(CurrentDbType dbType)
        {
            string result = "Mshan.Utilities.DbUtilities.SqlHelper";
            switch (dbType)
            {
                case CurrentDbType.SqlServer:
                    result = "Mshan.Utilities.DbUtilities.SqlHelper";
                    break;
                case CurrentDbType.Oracle:
                    result = "Mshan.Utilities.DbUtilities.OracleHelper";
                    // result = "Mshan.Utilities.DbUtilities.MSOracleHelper";
                    break;
                case CurrentDbType.Access:
                    result = "Mshan.Utilities.DbUtilities.OleDbHelper";
                    break;
                case CurrentDbType.MySql:
                    result = "Mshan.Utilities.DbUtilities.MySqlHelper";
                    break;
                case CurrentDbType.DB2:
                    result = "Mshan.Utilities.DbUtilities.DB2Helper";
                    break;
                case CurrentDbType.SQLite:
                    result = "Mshan.Utilities.DbUtilities.SqLiteHelper";
                    break;
                case CurrentDbType.Ase:
                    result = "Mshan.Utilities.DbUtilities.AseHelper";
                    break;
                case CurrentDbType.PostgreSql:
                    result = "Mshan.Utilities.DbUtilities.PostgreSqlHelper";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 数据库连接串，这里是为了简化思路
        /// </summary>
        public static string DbConnection = BaseSystemInfo.UserCenterDbConnection;

        /// <summary>
        /// 数据库类型，这里也是为了简化思路
        /// </summary>
        public static CurrentDbType DbType = BaseSystemInfo.ServerDbType;
    }
}