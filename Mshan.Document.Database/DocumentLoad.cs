using System;
using System.Collections.Generic;
using System.Linq;
namespace Mshan.Document.Database
{
    public class DocumentLoad
    {
        public static Dictionary<string, TableEntity.Table> AllTable()
        {
            Dictionary<string, TableEntity.Table> tablesDictionary = new Dictionary<string, TableEntity.Table>();
            System.Data.DataTable userDataTable = OracleDocument.GetAllUserTable();
            int i = 1;
            foreach (System.Data.DataRow dataRow in userDataTable.Rows)
            {
                TableEntity.Table userTable = GetTableEntityByDataRow(dataRow);
                tablesDictionary.Add(userTable.TableName, userTable);
                if (++i > 20)
                    break;
            }
            return tablesDictionary;
        }
        public static TableEntity.Table GetTableEntityByTableName(string tableName)
        {
            System.Data.DataTable userDataTable = OracleDocument.GetUserTableByTableName(tableName);
            if (userDataTable.Rows.Count > 0)
                return GetTableEntityByDataRow(userDataTable.Rows[0]);
            return null;
        }

        public static TableEntity.Table GetTableEntityByDataRow(System.Data.DataRow dataRow)
        {
            TableEntity.Table userTable = new TableEntity.Table();
            userTable.TableName = dataRow["table_name"].ToString().ToLower();
            userTable.TableSpace = dataRow["tablespace_name"].ToString();
            userTable.Comments = dataRow["comments"].ToString();
            userTable.Columns = GetColumnsByTable(userTable.TableName);
            userTable.Indexes = GetIndexesByTable(userTable.TableName);
            userTable.Triggeres = GetTriggerByTable(userTable.TableName);
            return userTable;
        }

        public static Dictionary<string, TableEntity.Column> GetColumnsByTable(string tableName)
        {
            Dictionary<string, TableEntity.Column> columnsDictionary = new Dictionary<string, TableEntity.Column>();
            System.Data.DataTable columnDataTable = OracleDocument.GetColumnsByTableName(tableName);
            foreach (System.Data.DataRow dataRow in columnDataTable.Rows)
            {
                // a.table_name,a.column_name,a.data_type,a.data_length,a.NULLABLE,a.column_id,b.comments
                TableEntity.Column column = new TableEntity.Column();
                column.ColumnName = dataRow["column_name"].ToString().ToLower();
                column.ColumnType = dataRow["data_type"].ToString();
                column.ColumnLength = dataRow["data_length"].ToString();
                column.NullAble = dataRow["nullable"].ToString();
                column.DefaultValue = dataRow["data_default"].ToString();
                column.Comments = dataRow["comments"].ToString();
                columnsDictionary.Add(column.ColumnName, column);
            }
            return columnsDictionary;
        }

        public static Dictionary<string, TableEntity.Index> GetIndexesByTable(string tableName)
        {//a.index_name,table_owner,table_name,a.uniqueness,a.tablespace_name
            Dictionary<string, TableEntity.Index> indexDictionary = new Dictionary<string, TableEntity.Index>();
            System.Data.DataTable indexDataTable = OracleDocument.GetIndexesByTableName(tableName);
            foreach (System.Data.DataRow dataRow in indexDataTable.Rows)
            {
                TableEntity.Index index = new TableEntity.Index();
                index.IndexName = dataRow["index_name"].ToString().ToLower();
                index.TableSpace = dataRow["tablespace_name"].ToString();
                index.Uniqueness = dataRow["uniqueness"].ToString();
                index.Columns = GetIndexColumnByIndexName(index.IndexName);
                indexDictionary.Add(index.IndexName, index);
            }
            return indexDictionary;
        }

        public static Dictionary<string, string> GetIndexColumnByIndexName(string indexName)
        {
            Dictionary<string, string> columnDictionary = new Dictionary<string, string>();
            System.Data.DataTable columnDataTable = OracleDocument.GetIndexesColumnsByIndexName(indexName);
            foreach (System.Data.DataRow dataRow in columnDataTable.Rows)
            {//index_name,table_name,column_name,column_position, descend
                columnDictionary.Add(dataRow["column_name"].ToString().ToLower(), dataRow["descend"].ToString().ToLower());
            }
            return columnDictionary;
        }

        public static Dictionary<string, TableEntity.Trigger> GetTriggerByTable(string tableName)
        {
            Dictionary<string, TableEntity.Trigger> triggerDictionary = new Dictionary<string, TableEntity.Trigger>();
            System.Data.DataTable triggerDataTable = OracleDocument.GetTriggerByTableName(tableName);
            foreach (System.Data.DataRow dataRow in triggerDataTable.Rows)
            {//a.table_name,a.trigger_name,a.table_owner,a.triggering_event,a.trigger_body
                TableEntity.Trigger trigger = new TableEntity.Trigger();
                trigger.TriggerName = dataRow["trigger_name"].ToString();
                trigger.TriggeringEvent = dataRow["triggering_event"].ToString();
                trigger.TriggerBody = dataRow["trigger_body"].ToString();
                trigger.ColumnName = dataRow["column_name"].ToString();
                triggerDictionary.Add(trigger.TriggerName, trigger);
            }
            return triggerDictionary;
        }
    }
}
