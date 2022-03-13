using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillionBankProject
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["customerID"] = null;
            Session["customerName"] = null;
            Session["customerSurname"] = null;

            Server.Transfer("LogonPage.aspx");
        }
    }
}