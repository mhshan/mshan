//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2015 , Mshan, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Reflection;
namespace Mshan.Utilities.DbUtilities
{
    /// <summary>
    /// BaseDbHelper
    /// 数据库访问层基础类。
    /// 
    /// 修改纪录
    ///     
    /// 
    /// <author>
    ///		<name>Mshan</name>
    ///		<date>2011.02.20</date>
    /// </author> 
    /// </summary>
    public abstract partial class BaseDbHelper : IDisposable // IDbHelper
    {
        #region public virtual CurrentDbType CurrentDbType 获取当前数据库类型
        /// <summary>
        /// 获取当前数据库类型
        /// </summary>
        public virtual CurrentDbType CurrentDbType
        {
            get
            {
                return CurrentDbType.SqlServer;
            }
        }
        #endregion

        #region private DbConnection DbConnection 数据库连接必要条件参数
        // 数据库连接
        private DbConnection dbConnection = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection DbConnection
        {
            get
            {
                if (this.dbConnection == null)
                {
                    // 若没打开，就变成自动打开关闭的
                    this.Open();
                    this.MustCloseConnection = true;
                }
                return this.dbConnection;
            }
            set
            {
                this.dbConnection = value;
            }
        }

        // 命令
        private DbCommand dbCommand = null;
        /// <summary>
        /// 命令
        /// </summary>
        public DbCommand DbCommand
        {
            get
            {
                return this.dbCommand;
            }

            set
            {
                this.dbCommand = value;
            }
        }

        // 数据库适配器
        private DbDataAdapter dbDataAdapter = null;
        /// <summary>
        /// 数据库适配器
        /// </summary>
        public DbDataAdapter DbDataAdapter
        {
            get
            {
                return this.dbDataAdapter;
            }

            set
            {
                this.dbDataAdapter = value;
            }
        }

        // 数据库连接
        private string connectionString = "Data Source=localhost;Initial Catalog=UserCenterV39;Integrated Security=SSPI;";
        /// <summary>
        /// 数据库连接
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        private DbTransaction dbTransaction = null;

        // 是否已在事务之中
        private bool inTransaction = false;
        /// <summary>
        /// 是否已采用事务
        /// </summary>
        public bool InTransaction
        {
            get
            {
                return this.inTransaction;
            }

            set
            {
                this.inTransaction = value;
            }
        }

        public string FileName = "BaseDbHelper.txt";    // sql查询句日志

        //默认打开关闭数据库选项（默认为否）
        private bool mustCloseConnection = false;
        /// <summary>
        /// 默认打开关闭数据库选项（默认为否）
        /// </summary>
        public bool MustCloseConnection
        {
            get
            {
                return mustCloseConnection;
            }
            set
            {
                mustCloseConnection = value;
            }
        }

        private DbProviderFactory _dbProviderFactory = null;
        /// <summary>
        /// DbProviderFactory实例
        /// </summary>
        public virtual DbProviderFactory GetInstance()
        {
            if (_dbProviderFactory == null)
            {
                _dbProviderFactory = DbHelperFactory.GetHelper().GetInstance();
            }

            return _dbProviderFactory;
        }
        #endregion

        #region public virtual string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public virtual string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            return value;
        }
        #endregion

        #region public virtual string PlusSign() 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <returns>字符加</returns>
        public virtual string PlusSign()
        {
            return " + ";
        }
        #endregion

        #region string PlusSign(params string[] values) 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public virtual string PlusSign(params string[] values)
        {
            string result = string.Empty;
            for (int i = 0; i < values.Length; i++)
            {
                result += values[i] + PlusSign();
            }
            if (!String.IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.Length - 3);
            }
            else
            {
                result = PlusSign();
            }
            return result;
        }
        #endregion

        #region public virtual IDbConnection Open() 获取数据库连接的方法
        /// <summary>
        /// 这时主要的获取数据库连接的方法
        /// </summary>
        /// <returns>数据库连接</returns>
        public virtual IDbConnection Open()
        {
            // 这里是获取一个连接的详细方法
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                // 是否静态数据库里已经设置了连接？

                /*
                if (!string.IsNullOrEmpty(DbHelper.ConnectionString))
                {
                    this.ConnectionString = DbHelper.ConnectionString;
                }
                else
                {
                     读取配置文件？
                }
                */

                // 默认打开业务数据库，而不是用户中心的数据库
                if (String.IsNullOrEmpty(BaseSystemInfo.BusinessDbConnection))
                {
                    this.ConnectionString = BaseSystemInfo.UserCenterDbConnection;
                }
                else
                {
                    this.ConnectionString = BaseSystemInfo.BusinessDbConnection;
                }
            }
            this.Open(this.ConnectionString);
            return this.dbConnection;
        }
        #endregion

        #region public virtual IDbConnection Open(string connectionString) 获得新的数据库连接
        /// <summary>
        /// 获得新的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public virtual IDbConnection Open(string connectionString)
        {
            // 这里数据库连接打开的时候，就判断注册属性的有效性
            //if (!SecretUtil.CheckRegister())
            //{
            //    // 若没有进行注册，让程序无法打开数据库比较好。
            //    connectionString = string.Empty;

            //    // 抛出异常信息显示给客户
            //    throw new Exception(BaseSystemInfo.RegisterException);
            //}

            // 若是空的话才打开，不可以，每次应该打开新的数据库连接才对，这样才能保证不是一个数据库连接上执行的
            this.ConnectionString = connectionString;
            this.dbConnection = GetInstance().CreateConnection();
            this.dbConnection.ConnectionString = this.ConnectionString;
            this.dbConnection.Open();
            this.MustCloseConnection = false;
            return this.dbConnection;
        }
        #endregion

        #region public virtual IDbConnection GetDbConnection() 获取数据库连接
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>数据库连接</returns>
        public virtual IDbConnection GetDbConnection()
        {
            return this.dbConnection;
        }
        #endregion

        #region public virtual IDbTransaction GetDbTransaction() 获取数据源上执行的事务
        /// <summary>
        /// 获取数据源上执行的事务
        /// </summary>
        /// <returns>数据源上执行的事务</returns>
        public virtual IDbTransaction GetDbTransaction()
        {
            return this.dbTransaction;
        }
        #endregion

        #region public virtual IDbCommand GetDbCommand() 获取数据源上命令
        /// <summary>
        /// 获取数据源上命令
        /// </summary>
        /// <returns>数据源上命令</returns>
        public virtual IDbCommand GetDbCommand()
        {
            return this.DbConnection.CreateCommand();
        }
        #endregion

        #region public IDbTransaction BeginTransaction() 事务开始
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns>事务</returns>
        public IDbTransaction BeginTransaction()
        {
            // 写入调试信息
            if (!this.InTransaction)
            {
                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                }
                // 这里是不允许自动关闭了
                this.dbTransaction = this.DbConnection.BeginTransaction();
                this.MustCloseConnection = false;
                this.InTransaction = true;
                // this.dbCommand.Transaction = this.dbTransaction;
            }
            return this.dbTransaction;
        }
        #endregion

        #region public void CommitTransaction() 提交事务
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            if (this.InTransaction)
            {
                // 事务已经完成了，一定要更新标志信息
                this.InTransaction = false;
                this.MustCloseConnection = true;
                this.dbTransaction.Commit();
            }
        }
        #endregion

        #region public void RollbackTransaction() 回滚事务
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            if (this.InTransaction)
            {
                this.InTransaction = false;
                this.dbTransaction.Rollback();
            }
        }
        #endregion

        #region public void Close() 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (this.dbConnection != null)
            {
                this.dbConnection.Close();
                // this.dbConnection.Dispose();
            }
            // this.Dispose();
        }
        #endregion

        #region public virtual void WriteLog(string commandText, string fileName = null) 写入sql查询句日志

        /// <summary>
        /// 写入sql查询句日志
        /// </summary>
        /// <param name="commandText"></param>
        public virtual void WriteLog(string commandText)
        {
             
        }

        /// <summary>
        /// 写入sql查询句日志
        /// </summary>
        /// <param name="commandText">异常</param>
        /// <param name="fileName">文件名</param>
        public virtual void WriteLog(string commandText, string fileName = null)
        {
            
        }
        #endregion

        #region public void Dispose() 内存回收
        /// <summary>
        /// 内存回收
        /// </summary>
        public void Dispose()
        {
            if (this.dbCommand != null)
            {
                this.dbCommand.Dispose();
            }
            if (this.dbDataAdapter != null)
            {
                this.dbDataAdapter.Dispose();
            }
            if (this.dbTransaction != null)
            {
                this.dbTransaction.Dispose();
            }
            // 关闭数据库连接
            if (this.dbConnection != null)
            {
                if (this.dbConnection.State != ConnectionState.Closed)
                {
                    this.dbConnection.Close();
                    this.dbConnection.Dispose();
                }
            }
            this.dbConnection = null;
        }
        #endregion
    }
}
