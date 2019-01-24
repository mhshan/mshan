using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mshan.Utilities.DbUtilities;
namespace Mshan.DatabaseDocument
{
    public partial class _Default : System.Web.UI.Page
    {
        public Dictionary<string,TableEntity.Table> userTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {  
                userTable=DocumentLoad.AllTable(); 
            }
        }
    }
}
