
// FileName: Logon
//Author: Anna Msomi
// Created: 23/02/2022
//Operating system : Visual Studio 2019
// Version: 2019
//Description : Wed form for Billion Bank
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillionBankProject
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // check if password matches and front end has RequiredFieldValidator checks
            {
                if(TextBoxPassword.Text != TextBoxConfirmPassword.Text)
                {
                    LabelError.Text = "Password not matching";
                    return;
                }
                ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();


                LabelError.Text = client.InsertRegister(TextBoxName.Text,TextBoxSurname.Text, TextBoxContact.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPassword.Text, TextBoxPasswordQuestion.Text, TextBoxPasswordQuestionAnswer.Text, TextBoxID.Text); //pass variables to web service and insert into SQL

                TextBoxName.Text = ""; TextBoxSurname.Text = ""; TextBoxContact.Text = ""; TextBoxEmail.Text = ""; TextBoxAddress.Text = ""; TextBoxPassword.Text = ""; TextBoxPasswordQuestion.Text = ""; TextBoxPasswordQuestionAnswer.Text = ""; TextBoxID.Text = "";

            }
        }
    }
}