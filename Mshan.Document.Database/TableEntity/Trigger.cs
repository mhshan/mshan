using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mshan.Document.Database.TableEntity
{
    public class Trigger
    {
        //a.table_name,a.trigger_name,a.table_owner,a.triggering_event,a.trigger_body 
        public string TriggerName
        {
            get;
            set;
        }
        public string ColumnName
        {
            get;
            set;
        }
        public string TriggeringEvent
        {
            get;
            set;
        }

        public string TriggerBody
        {
            get;
            set;
        }
    }
}