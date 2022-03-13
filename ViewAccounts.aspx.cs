// FileName: Logon
//Author: Anna Msomi
// Created: 23/02/2022
//Operating system : Visual Studio 2019
// Version: 2019
//Description : Wed form for Billion Bank


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillionBankProject
{
    public partial class ViewAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["accountType"] == null)
                {
                    Server.Transfer("LogonPage.aspx");
                }
                displayTransction();
                LblAccountType.Text = "Account Type:" + Session["accountType"].ToString();
                LblAccountName.Text = "Name:" + Session["accountName"].ToString();
                LblAccountBalance.Text = "Balance:" + Session["accountbalance"].ToString();
                LblAccountNumber.Text = "Account Number:" + Session["accountNumber"].ToString();
                LblAccountDate.Text = "Date Creation:" + Session["date"].ToString();
                
            }
        }

        void displayTransction()
        {
            DataTable Response = new DataTable();
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
            Response = client.DisplayTransaction(Session["id"].ToString());
            GridView1.DataSource = Response;
            GridView1.DataBind();
        }
    }
}