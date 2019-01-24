using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mshan.DatabaseDocument.TableEntity
{
    public class Column
    {
        public string ColumnName
        {
            get;
            set;
        }

        public string ColumnType
        {
            get;
            set;
        }

        public string ColumnLength
        {
            get;
            set;
        }

        public string DefaultValue
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string NullAble
        {
            get;
            set;
        }

    }
}