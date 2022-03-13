
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
    public partial class Forgot_Password_change : System.Web.UI.Page
    {

        string answer = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) // check for email
            {
                Server.Transfer("LogonPage.aspx");
            }

            if (!Page.IsPostBack)
            {
                getDetails();
            }

        }

        void getDetails()
        { // Pass email to web service and once done will return the datatable with details to give us the questions and answers
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
            DataTable Response = new DataTable();
            Response = client.ForgotPassword(Session["Email"].ToString());

            if (Response.Rows.Count > 0)
            {
                foreach (DataRow item in Response.Rows)
                {
                    LblQ.Text = item[7].ToString();
                    Session["answer"] = item[8].ToString();

                    
                }


            }

            else
            {
                LblMessage.Text = "Email does not exist";
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e) // checks for validations
        {
            if (TextBoxAnswer.Text == "")
            {
                LblMessage.Text = "Incorrect";
                return;
            }

            if (TextBoxNewPass.Text == "")
            {
                LblMessage.Text = "Passwords do not match sav";
                return;
            }

            if (Session["answer"].ToString() != TextBoxAnswer.Text)
            {
                LblMessage.Text = "Incorrect answer" + answer;
                return;
            }

            if(TextBoxNewPass.Text != TextBoxConfirmPass.Text)
            {
                LblMessage.Text = "Passwords do not match";
                return;
            }

            try
            {
                ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient(); // if pass , then the password is updated
                LblMessage.Text = client.UpdatePassword(Session["Email"].ToString(), TextBoxConfirmPass.Text);
            }
            catch (Exception ex)
            {

                LblMessage.Text = ex.ToString();
            }
            

        }
    }
}