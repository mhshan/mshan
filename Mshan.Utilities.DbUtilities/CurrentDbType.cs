//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2015 , Mshan, Ltd. 
//-----------------------------------------------------------------


namespace Mshan.Utilities.DbUtilities
{
    /// <summary>
    /// CurrentDbType
    /// 有关数据库连接类型定义。
    /// 
    /// 修改纪录
    /// 
    ///		
    /// <author>
    ///		<name>Mhshan</name>
    ///		<date></date>
    /// </author> 
    /// </summary>
    public enum CurrentDbType
    {
        /// <summary>
        /// 数据库类型：Oracle
        /// </summary>
        Oracle,

        /// <summary>
        /// 数据库类型：SqlServer
        /// </summary>
        SqlServer,

        /// <summary>
        /// 数据库类型：Access
        /// </summary>
        Access,
        /// <summary>
        /// 数据库类型：DB2
        /// </summary>

        DB2,
        /// <summary>
        /// 数据库类型：MySql
        /// </summary>
        MySql,

        /// <summary>
        /// 数据库类型：SQLite
        /// </summary>
        SQLite,

        /// <summary>
        /// 数据库类型：Ase
        /// </summary>
        Ase,

        /// <summary>
        /// 数据库类型：PostgreSql
        /// </summary>
        PostgreSql
    }
}
