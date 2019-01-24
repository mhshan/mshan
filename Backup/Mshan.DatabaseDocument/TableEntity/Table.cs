using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mshan.DatabaseDocument.TableEntity
{
    public class Table
    {
        public string TableName
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string TableSpace
        {
            get;
            set;
        }

        public Dictionary<string, Column> Columns
        {
            get;
            set;
        }

        public Dictionary<string, Index> Indexes
        {
            get;
            set;
        }

        public Dictionary<string, Trigger> Triggeres
        {
            get;
            set;
        }
    }
}