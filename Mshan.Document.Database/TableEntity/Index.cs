using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mshan.Document.Database.TableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class Index
    {
        //a.index_name,table_owner,table_name,a.uniqueness
        public String IndexName
        {
            get;
            set;
        }

        public string Uniqueness
        {
            get;
            set;
        }

        public string TableSpace
        {
            get;
            set;
        }

        public Dictionary<string, string> Columns
        {
            get;
            set;
        }

    }
}