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
    public partial class LogonPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e) // redirect to register page
        {
            Server.Transfer("Register.aspx");
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e) 
        {
            DataTable Response = new DataTable();
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient(); // declare Web service
            Response = client.Login(TextBoxName.Text, TextBoxPassword.Text); // passs user name and password to web service
            if(Response.Rows.Count > 0)
            {
                foreach (DataRow item in Response.Rows)
                {
                    string ID = item[0].ToString();
                    string Name = item[1].ToString();
                    string surname = item[2].ToString();

                    Session["customerID"] = ID; // populate sessions and redirect to Banking porfolio
                    Session["customerName"] = Name;
                    Session["customerSurname"] = surname;
                }
                Server.Transfer("Banking_Portfolio.aspx");

            }
            else
            {
                LblWrongPassword.Text = "Incorrect details";            }
        }

        protected void BtnForgotPassword_Click(object sender, EventArgs e)
        {

        }
    }
}