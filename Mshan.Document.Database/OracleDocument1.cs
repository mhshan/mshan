using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Mshan.Utilities.DbUtilities;
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
        public  OracleDocument()
        {
            BaseSystemInfo.ServerDbType = CurrentDbType.Oracle;
        }
        public static DataTable GetTablesByUser(string user)
        {
            return DbHelper.Fill(string.Format("select * from dba_tables where lower(owner)='{0}' ", user.ToLower()));
        }
        public static DataTable GetAllUserTable()
        {
            return DbHelper.Fill("select  a.table_name, a.tablespace_name, a.status, a.table_lock,b.comments  from user_tables a left join user_tab_comments b on a.table_name=b.table_name  order by a.table_name asc");
        }
        public static DataTable GetUserTableByTableName(string tableName)
        {
            return DbHelper.Fill(string.Format("select  a.table_name, a.tablespace_name, a.status, a.table_lock,b.comments  from user_tables a left join user_tab_comments b on a.table_name=b.table_name where LOWER(a.Table_Name)='{0}' order by a.table_name asc", tableName));
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

    }
}