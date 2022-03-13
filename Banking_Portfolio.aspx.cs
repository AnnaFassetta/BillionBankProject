
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
    public partial class Banking_Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["customerName"] == null) // check for user authentication and redirect to logon page
                {
                    Server.Transfer("LogonPage.aspx");
                }
                displayAccount(); 
                LblClientname.Text = "Client Name:" + Session["customerName"].ToString() + " " + Session["customerSurname"].ToString();
                LblDate.Text = "Date:" + DateTime.Today;
            }

        }


        void displayAccount()
        {
            DataTable Response = new DataTable();
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient(); // declare Web service
            Response = client.DisplayAccount(Session["customerID"].ToString()); // pass variables to get account data table
            GridView1.DataSource = Response; // populate grid
            GridView1.DataBind();
        }




        protected void btnView_Click(object sender, EventArgs e) // Pass to next page where accounts/Tranactions are displayed
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Session["id"] = row.Cells[1].Text;
            Session["accountType"] = row.Cells[2].Text;
            Session["accountName"] = row.Cells[3].Text;
            Session["accountbalance"] = row.Cells[4].Text;
            Session["accountNumber"] = row.Cells[5].Text;
            Session["date"] = row.Cells[7].Text;
            Response.Redirect("ViewAccounts.aspx");
        }
    }
}