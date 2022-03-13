
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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerName"] == null) // checks if user is authenticated
            {
                Server.Transfer("LogonPage.aspx");
            }

            if (!Page.IsPostBack)
            {
                populateProfile(); 
            }

            
        }

        void populateProfile() // populates the profile of user
        {
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
            DataTable Response = new DataTable();
            Response = client.uodateProfile(Session["customerID"].ToString());

            if (Response.Rows.Count > 0)
            {
                foreach (DataRow item in Response.Rows)
                {
                    TextBoxName.Text = item[1].ToString();
                    TextBoxSurname.Text = item[2].ToString();
                    TextBoxContact.Text = item[3].ToString();
                    TextBoxEmail.Text = item[4].ToString();
                    TextBoxAddress.Text = item[5].ToString();
                    TextBoxPassword.Text = item[6].ToString();
                    TextBoxPasswordQuestion.Text = item[7].ToString();
                    TextBoxPasswordQuestionAnswer.Text = item[8].ToString();
                    TextBoxID.Text = item[9].ToString();

                }
               

            }
        }
        protected void BtnSave_Click(object sender, EventArgs e) // updates the profile
        {
            if (Page.IsValid)
            {
                if(TextBoxPassword.Text != TextBoxConfirmPassword.Text)
                {
                    LabelError.Text = "Password not matching";
                    return;
                }
                ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();


                LabelError.Text = client.UpdateProfile(Session["customerID"].ToString(),TextBoxName.Text,TextBoxSurname.Text, TextBoxContact.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPassword.Text, TextBoxPasswordQuestion.Text, TextBoxPasswordQuestionAnswer.Text, TextBoxID.Text);

                populateProfile();
            }
        }
    }
}