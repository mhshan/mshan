using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mshan.Utilities.DbUtilities;
using System.Data;
namespace Mshan.Document.Database
{
    public class OracleDocument
    {
        /*
   select * from dba_tables WHERE LOWER(OWNER)='ccense'
     /
     select a.index_name,table_owner,table_name,a.uniqueness from user_indexes a where LOWER(table_name)='rec_vicecard_consume' 
     /
     select index_name,table_name,column_name,column_position, descend from user_ind_columns where LOWER(table_name)='rec_vicecard_consume' order by column_position asc
     /
     select index_name,table_name,column_name,column_position, descend from user_ind_columns where LOWER(index_name)='uk_rec_vicecard_consume'
     /
     select owner,table_name,tablespace_name from dba_tables WHERE LOWER(OWNER)='ccense'
     /
     select * from user_ind_columns where LOWER(index_name)='uk_rec_vicecard_consume'
     /
     select * from user_tab_columns where LOWER(Table_Name)='rec_vicecard_consume'
     /
     select * from user_tables where LOWER(Table_Name)='rec_vicecard_consume'
     /
     select * from user_tab_comments where LOWER(Table_Name)='rec_vicecard_consume'
     /
     select * from user_col_comments where LOWER(Table_Name)='rec_vicecard_consume'
     /
     select * from user_triggers where LOWER(Table_Name)='rec_vicecard_consume'
   */
        public OracleDocument()
        {
            BaseSystemInfo.ServerDbType = CurrentDbType.Oracle;
        }
        public static DataTable GetTablesByUser(string user)
        {
            return DbHelper.Fill(string.Format("select * from dba_tables where lower(owner)='{0}'", user.ToLower()));
        }
        public static DataTable GetAllUserTable()
        {
            return DbHelper.Fill("select  a.table_name, a.tablespace_name, a.status,a.num_rows, a.table_lock,b.comments  from user_tables a left join user_tab_comments b on a.table_name=b.table_name  order by a.table_name asc");
        }
        public static DataTable GetUserTableByTableName(string tableName)
        {
            return DbHelper.Fill(string.Format("select  a.table_name, a.tablespace_name, a.status, a.table_lock,b.comments  from user_tables a left join user_tab_comments b on a.table_name=b.table_name where LOWER(a.Table_Name)='{0}' order by a.table_name asc", tableName.ToLower()));
        }
        public static DataTable GetUserAllTable()
        {
            return DbHelper.Fill("select  a.table_name, a.tablespace_name, a.status, a.table_lock,b.comments  from user_tables a left join user_tab_comments b on a.table_name=b.table_name  order by a.table_name asc");
        }
        public static DataTable GetColumnsByTableName(string tableName)
        {
            return DbHelper.Fill(string.Format("select a.table_name,a.column_name,a.data_type,a.data_length,a.NULLABLE,a.column_id,a.data_default,b.comments  from user_tab_columns a left join user_col_comments b on a.table_name=b.table_name and a.COLUMN_NAME=b.column_name  where LOWER(a.Table_Name)='{0}' order by a.column_id asc", tableName.ToLower()));
        }

        public static DataTable GetIndexesByTableName(string tableName)
        {
            return DbHelper.Fill(string.Format("select a.index_name,table_owner,a.table_name,a.uniqueness,a.tablespace_name from user_indexes a where LOWER(a.table_name)='{0}'", tableName.ToLower()));
        }

        public static DataTable GetIndexesColumnsByIndexName(string indexName)
        {
            return DbHelper.Fill(string.Format("select index_name,table_name,column_name,column_position, descend from user_ind_columns where LOWER(index_name)='{0}' order by column_position asc", indexName.ToLower()));
        }

        public static DataTable GetTriggerByTableName(string tableName)
        {
            return DbHelper.Fill(string.Format("select a.table_name,a.trigger_name,a.table_owner,a.triggering_event,a.trigger_body,a.column_name  from user_triggers a where LOWER(a.Table_Name)='{0}'", tableName.ToLower()));
        }

        public static DataTable GetTableSpaceDetail()
        {
            return DbHelper.Fill(@"select dba_data_files.tablespace_name,
                                       round(dba_data_files.maxbytes / (1024 * 1024), 2) max_bytes,
                                       round(dba_data_files.bytes / (1024 * 1024), 2) current_bytes,
                                       nvl(free_space.freespace, 0) freespace,
                                       to_char(round((dba_data_files.bytes / (1024 * 1024) -
                                                     nvl(free_space.freespace, 0)) * 100 /
                                                     (dba_data_files.bytes / (1024 * 1024)),
                                                     2)) || '%' userate,
                                       nvl(free_space.spaceblock, 0) spaceblock,
                                       dba_data_files.file_id,
                                       dba_data_files.file_name
                                  from dba_data_files
                                  left join (select file_id,
                                                    round(sum(a.bytes) / (1024 * 1024), 2) as freespace,
                                                    count(file_id) as spaceblock
                                               from dba_free_space a
                                              group by a.file_id) free_space
                                    on dba_data_files.file_id = free_space.file_id
                                 order by tablespace_name asc");
        }

        public static DataTable GetTableAndUseDetail()
        {
            return DbHelper.Fill(@"select segment_name, sum(bytes) / 1024 / 1024 mbytese
                                      from user_segments /*where lower(segment_type)＝'table'*/
                                     group by segment_name
                                     order by mbytese desc");
        }
        public static DataTable GetTablePartition()
        {
            return DbHelper.Fill(@"select  table_name,partition_name,num_rows,high_value  from USER_TAB_PARTITIONS");
        }
        public static DataTable GetSubPartitionByTableAndPartition(string tableName,string partition)
        {
            return DbHelper.Fill(string.Format("select * from USER_TAB_SUBPARTITIONS where lower(table_name)='{0}' and lower(partition_name)='{1}'",tableName.ToLower(),partition.ToLower()));
        }
        public static DataTable GetAllProcedure()
        {
            return DbHelper.Fill("SELECT DISTINCT name FROM USER_SOURCE where  type='PACKAGE BODY'   order by name asc");
        }

        public static DataTable GetAllTypeBySchema(string type,string schema)
        {
            return DbHelper.Fill(string.Format("SELECT DISTINCT name FROM USER_SOURCE where  lower(type)='{0}'   order by name asc",type.ToLower()));
        }
        public static DataTable GetProcedureByName(string procedureName, string type)
        {
            return DbHelper.Fill(string.Format("SELECT * FROM USER_SOURCE where  name='{0}' and upper(type)='{1}' order by line asc", procedureName, type.ToUpper()));
        }
        public static Int32 UpdateProcedureLine(string procedureName, string type,Int32 line,string text)
        {
            return DbHelper.ExecuteNonQuery(string.Format("update USER_SOURCE set text='{0}' where name='{1}' and type='{2}' and line='{3}'",text,procedureName,type,line));
        }

        public static Int32 LanguageMaxIndex(string pkgName,string language="zh-CN")
        {
            DataTable dt= DbHelper.Fill(string.Format("SELECT max(id) FROM base_languages where name='{0}' and language='{1}'",pkgName,language));
            if (dt.Rows[0][0] == DBNull.Value)
                return 0;
            return Convert.ToInt32(dt.Rows[0][0])+1;
        }

        public static bool InsertLanguageItem(string pkgName,string text,Int32 index,string language="zh-CN")
        {
           return DbHelper.ExecuteNonQuery(string.Format("insert into base_languages(name,id,language,text) values('{0}','{1}','{2}','{3}')", pkgName, index, language, text))>0;
        }

        public static bool ExecSql(string sql)
        {
              IDataReader dataReader=DbHelper.ExecuteReader(sql);
              dataReader.Close();
              return true;
        }

        public static DataTable GetDdlByObject(string objectType, string objectName, string schema)
        {
           return DbHelper.Fill(string.Format("select DBMS_METADATA.GET_DDL('{0}','{1}','{2}') from dual",objectType,objectName,schema));
        }
        public static DataTable GetSequenceBySchema(string schema)
        {
            return DbHelper.Fill(string.Format("select * from dba_sequences where upper(sequence_owner)='{0}'", schema.ToUpper()));
        }
        public static DataTable GetViewBySchema(string schema)
        {
            return DbHelper.Fill(string.Format("select * from dba_views where upper(owner)='{0}'", schema.ToUpper()));
        }

        /*select * from dba_sequences where sequence_owner='CCENSE' 序列*/
    }
}
