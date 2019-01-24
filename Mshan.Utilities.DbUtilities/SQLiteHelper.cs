using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
namespace Mshan.Utilities.DbUtilities
{

        /// <summary>
        /// SQLiteHelper
        /// 有关数据库连接的方法。
        /// 
        /// 修改纪录
        /// 
        /// 
        /// 版本：1.3
        /// 
        /// <author>
        ///		<name>Mshan</name>
        ///		<date>2008.08.26</date>
        /// </author> 
        /// </summary>
        public class SQLiteHelper : BaseDbHelper, IDbHelper
        {
            public override DbProviderFactory GetInstance()
            { 
                return SQLiteFactory.Instance;
            }
            public override CurrentDbType CurrentDbType
            {
                get
                {
                    return CurrentDbType.SQLite;
                }
            }
            #region public SQLiteHelper()
            /// <summary>
            /// 构造方法
            /// </summary>
            public SQLiteHelper()
            {
                FileName = "SQLiteHelper.txt";    // sql查询句日志
            }
            #endregion
            #region public SQLiteHelper(string connectionString)
            /// <summary>
            /// 设定软件名称
            /// </summary>
            /// <param name="connectionString">数据连接</param>
            public SQLiteHelper(string connectionString)
                : this()
            {
                this.ConnectionString = connectionString;
            }
            #endregion

            #region public string GetDbNow()
            /// <summary>
            /// 获得数据库日期时间
            /// </summary>
            /// <returns>日期时间</returns>
            public string GetDbNow()
            {
                return " SYSDATE ";
            }
            #endregion

            #region public string GetDbDateTime()
            /// <summary>
            /// 获得数据库日期时间
            /// </summary>
            /// <returns>日期时间</returns>
            public string GetDbDateTime()
            {
                string commandText = " SELECT " + this.GetDbNow() + " FROM DUAL ";
                this.Open();
                string dateTime = this.ExecuteScalar(commandText, new DbParameter[0], CommandType.Text).ToString();
                this.Close();
                return dateTime;
            }
            #endregion


            #region public string SqlSafe(string value) 检查参数的安全性
            /// <summary>
            /// 检查参数的安全性
            /// </summary>
            /// <param name="value">参数</param>
            /// <returns>安全的参数</returns>
            public string SqlSafe(string value)
            {
                value = value.Replace("'", "''");
                // value = value.Replace("%", "'%");
                return value;
            }
            #endregion

            #region public DbParameter MakeInParam(string targetFiled, object targetValue)
            /// <summary>
            /// 获取参数
            /// </summary>
            /// <param name="targetFiled">目标字段</param>
            /// <param name="targetValue">值</param>
            /// <returns>参数</returns>
            public DbParameter MakeInParam(string targetFiled, object targetValue)
            {
                return new SQLiteParameter(":" + targetFiled, targetValue);
            }
            #endregion

            #region public DbParameter[] MakeParameters(string targetFiled, object targetValue)
            /// <summary>
            /// 获取参数
            /// </summary>
            /// <param name="targetFiled">目标字段</param>
            /// <param name="targetValue">值</param>
            /// <returns>参数集</returns>
            public IDbDataParameter MakeParameter(string targetFiled, object targetValue)
            {
                IDbDataParameter dbParameters = null;
                if (targetFiled != null && targetValue != null)
                {
                    dbParameters = this.MakeInParam(targetFiled, targetValue == null ? DBNull.Value : targetValue);
                }
                return dbParameters;
            }
            #endregion

            #region public IDbDataParameter MakeParameter(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数，包含详细参数设置
            /// <summary>
            /// 获取参数，包含详细参数设置
            /// </summary>
            /// <param name="parameterName">参数名</param>
            /// <param name="parameterValue">值</param>
            /// <param name="dbType">数据类型</param>
            /// <param name="parameterSize">长度</param>
            /// <param name="parameterDirection">参数类型</param>
            /// <returns>参数</returns>
            public IDbDataParameter MakeParameter(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
            {
                SQLiteParameter parameter;

                if (parameterSize > 0)
                {
                    parameter = new SQLiteParameter(parameterName, ConvertToSqlDbType(dbType), parameterSize);
                }
                else
                {
                    parameter = new SQLiteParameter(parameterName, ConvertToSqlDbType(dbType));
                }

                parameter.Direction = parameterDirection;
                if (!(parameterDirection == ParameterDirection.Output && parameterValue == null))
                {
                    parameter.Value = parameterValue;
                }

                return parameter;
            }
            #endregion

            #region  private SQLiteType ConvertToSqlDbType(System.Data.DbType dbType) 类型转换
            /// <summary>
            /// 类型转换
            /// </summary>
            /// <param name="dbType">数据类型</param>
            /// <returns>转换结果</returns>
            private DbType ConvertToSqlDbType(System.Data.DbType dbType)
            {
                SQLiteParameter sqlParameter = new SQLiteParameter();
                sqlParameter.DbType = dbType;
                return sqlParameter.DbType;
            }
            #endregion
            #region public DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
            /// <summary>
            /// 获取参数
            /// </summary>
            /// <param name="targetFiled">目标字段</param>
            /// <param name="targetValue">值</param>
            /// <returns>参数集</returns>
            public IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
            {
                // 这里需要用泛型列表，因为有不合法的数组的时候
                List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
                if (targetFileds != null && targetValues != null)
                {
                    for (int i = 0; i < targetFileds.Length; i++)
                    {
                        if (targetFileds[i] != null && targetValues[i] != null && (!(targetValues[i] is Array)))
                        {
                            dbParameters.Add(this.MakeInParam(targetFileds[i], targetValues[i]));
                        }
                    }
                }
                return dbParameters.ToArray();
            }
            #endregion
            #region public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters) 获取参数泛型列表
            /// <summary>
            /// 获取参数泛型列表
            /// </summary>
            /// <param name="parameters">参数</param>
            /// <returns>参数集</returns>
            public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters)
            {
                // 这里需要用泛型列表，因为有不合法的数组的时候
                List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        if (parameter.Key != null && parameter.Value != null && (!(parameter.Value is Array)))
                        {
                            dbParameters.Add(MakeParameter(parameter.Key, parameter.Value));
                        }
                    }
                }
                return dbParameters.ToArray();
            }
            #endregion
            public DbParameter MakeOutParam(string paramName, DbType DbType, int Size)
            {
                return MakeParam(paramName, DbType, Size, ParameterDirection.Output, null);
            }

            public DbParameter MakeInParam(string paramName, DbType DbType, int Size, object Value)
            {
                return MakeParam(paramName, DbType, Size, ParameterDirection.Input, Value);
            }

            public DbParameter MakeParam(string paramName, DbType DbType, Int32 Size, ParameterDirection Direction, object Value)
            {
                SQLiteParameter param;

                if (Size > 0)
                {
                    param = new SQLiteParameter(paramName, DbType, Size);
                }
                else
                {
                    param = new SQLiteParameter(paramName, DbType);
                }

                param.Direction = Direction;
                if (!(Direction == ParameterDirection.Output && Value == null))
                    param.Value = Value;

                return param;
            }


            #region public string GetParameter(string parameter) 获得参数Sql表达式
            /// <summary>
            /// 获得参数Sql表达式
            /// </summary>
            /// <param name="parameter">参数名称</param>
            /// <returns>字符串</returns>
            public string GetParameter(string parameter)
            {
                return " :" + parameter + " ";
            }
            #endregion

            #region string PlusSign(params string[] values)
            /// <summary>
            ///  获得Sql字符串相加符号
            /// </summary>
            /// <param name="values">参数值</param>
            /// <returns>字符加</returns>
            public string PlusSign(params string[] values)
            {
                string returnValue = string.Empty;
                for (int i = 0; i < values.Length; i++)
                {
                    returnValue += values[i] + " || ";
                }
                if (!String.IsNullOrEmpty(returnValue))
                {
                    returnValue = returnValue.Substring(0, returnValue.Length - 4);
                }
                else
                {
                    returnValue = " || ";
                }
                return returnValue;
            }
            #endregion
        }

}
