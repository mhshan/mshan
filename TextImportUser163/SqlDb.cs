using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace TextImportUser163
{
     /// <summary>
    ///SqlDB用于数据库操作
    /// </summary> 
    public class SqlDB  
    {
       

        public static string SqlConnString
        {
            get;
            set;
        }

        private System.Data.SqlClient.SqlConnection sqlConn;



        public System.Data.SqlClient.SqlConnection CreateConn()
        {
            if (sqlConn == null)
            {
                sqlConn = new System.Data.SqlClient.SqlConnection(SqlConnString);
                return sqlConn;

            }
            else
            {
                return sqlConn;
            }
        }

        public void OpenConn()
        {
            if (sqlConn == null)
                return;
            if (sqlConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    sqlConn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("数据库打开失败！", e.InnerException);
                }
            }
        }

        public void CloseConn()
        {
            if (sqlConn == null)
                return;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                }
                catch (Exception e)
                {
                    throw new Exception("数据库关闭失败！", e.InnerException);
                }
            }
        }

        public System.Data.SqlClient.SqlCommand CreateCmd(string sql, string type)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, CreateConn()))
            {
                cmd.Connection = CreateConn();
                if (type == "proc")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.CommandText = sql; 
                cmd.CommandTimeout = 500;
                return cmd;
            }
        }

        public System.Data.SqlClient.SqlCommand CreateCmd(string sql, string type, IDataParameter[] parameters)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = CreateConn();
                if (type == "proc")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.CommandText = sql; 
                cmd.CommandTimeout = 500;
                foreach (System.Data.SqlClient.SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return cmd;
            }
        }

        public static System.Data.DataSet GetDataSetText(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text"))
            {
                using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "table");
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    da.Dispose();
                    db.CloseConn();
                    return ds;
                }
            }
        }

        public static System.Data.DataSet GetDataSetText(string sql, IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text", parameters))
            {
                using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "table");
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    da.Dispose();
                    db.CloseConn();
                    return ds;
                }
            }
        }

        public static System.Data.DataSet GetDataSetProc(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc"))
            {
                using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "table");
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    da.Dispose();
                    db.CloseConn();
                    return ds;
                }
            }
        }

        public static System.Data.DataSet GetDataSetProc(string sql, IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc", parameters))
            {
                using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "table");
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    da.Dispose();
                    db.CloseConn();
                    return ds;
                }
            }
        }

        public System.Data.SqlClient.SqlDataReader GetDataReaderText(string sql)
        {
            using (System.Data.SqlClient.SqlCommand cmd = CreateCmd(sql, "text"))
            {
                OpenConn();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return reader; 
            }
        }

        public System.Data.SqlClient.SqlDataReader GetDataReaderText(string sql, IDataParameter[] parameters)
        {
            using (System.Data.SqlClient.SqlCommand cmd = CreateCmd(sql, "text", parameters))
            {
                OpenConn();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return reader;

            }
        }

        public System.Data.SqlClient.SqlDataReader GetDataReaderProc(string sql)
        {
            using (System.Data.SqlClient.SqlCommand cmd = CreateCmd(sql, "proc"))
            {
                OpenConn();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return reader;

            }
        }

        public System.Data.SqlClient.SqlDataReader GetDataReaderProc(string sql, IDataParameter[] parameters)
        {
            using (System.Data.SqlClient.SqlCommand cmd = CreateCmd(sql, "proc", parameters))
            {
                OpenConn();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return reader;

            }
        }

        public static bool ExecSql(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text"))
            {
                db.OpenConn();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                   
                    cmd.Dispose();
                    db.CloseConn();
                    return false;
                }
                else
                {
                    cmd.Dispose();
                    db.CloseConn();
                    return true;
                }
            }
        }

        public static bool ExecSql(string sql, IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text", parameters))
            {
                db.OpenConn();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    db.CloseConn();
                    return false;
                }
                else
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    db.CloseConn();
                    return true;
                }
            }
        }

        public static bool ExecProc(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc"))
            {
                db.OpenConn();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    
                    cmd.Dispose();
                    db.CloseConn();
                    return false;
                }
                else
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    db.CloseConn();
                    return true;
                }
            }
        }

        public static bool ExecProc(string sql, IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc", parameters))
            {
                db.OpenConn();
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    db.CloseConn();
                    return false;
                }
                else
                {
                    cmd.Dispose();
                    db.CloseConn();
                    return true;
                }
            }
        }

        public static int ExecScalarSql(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text"))
            {
                db.OpenConn();
                int n=Convert.ToInt32(cmd.ExecuteScalar());  
                cmd.Dispose();
                db.CloseConn();
                return n;
                
            }
        }
        public static int ExecScalarSql(string sql,IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "text",parameters))
            {
                db.OpenConn();
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                cmd.Dispose();
                db.CloseConn();
                return n;
               
            }
        }

        public static int ExecScalarProc(string sql)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc"))
            {
                db.OpenConn();
                int n=Convert.ToInt32(cmd.ExecuteScalar()); 
                cmd.Dispose();
                db.CloseConn();
                return n; 
            } 

        }

        public static int ExecScalarProc(string sql, IDataParameter[] parameters)
        {
            SqlDB db = new SqlDB();
            using (System.Data.SqlClient.SqlCommand cmd = db.CreateCmd(sql, "proc", parameters))
            {
                db.OpenConn();
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                cmd.Dispose();
                db.CloseConn();
                return n;

            }
        }
    }
}
