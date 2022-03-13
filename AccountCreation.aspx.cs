

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
    public partial class AccountCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerName"] == null)
            {
                Server.Transfer("LogonPage.aspx");
            }
        }


        public static string RandomString(int length)
        {
            var chars = "0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);


            return finalString.ToString();
        }

        protected void BrnCreate_Click(object sender, EventArgs e)
        {
            string accountNumber = RandomString(10); // Generates a random number of the account
            string CustomerID = Session["CustomerID"].ToString();

            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient(); // pass details to web service to create account
            LblCreationMessage.Text = client.InsertAccount(DropDownListAccount.SelectedValue.ToString(), TextBoxAccountName.Text, accountNumber, CustomerID);
        }
    }
}