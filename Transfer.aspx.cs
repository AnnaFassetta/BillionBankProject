
// FileName: Logon
//Author: Anna Msomi
// Created: 23/02/2022
//Operating system : Visual Studio 2019
// Version: 2019
//Description : Wed form for Billion Bank

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillionBankProject
{
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerName"] == null)
            {
                Server.Transfer("LogonPage.aspx");
            }
        }

        void populateDropDowns()
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            int debit = 0;
            int credit = 0;
            int balance = 0;
            int BalanceDestination = 0;
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
            try
            {
                balance = int.Parse(client.getAmount(DropDownListAccountFrom.SelectedValue.ToString()));
            }
            catch (Exception)
            {
                balance = 0;
            }


            try
            {
                debit = int.Parse(TextBoxAmount.Text);
            }
            catch (Exception)
            {
                debit = 0;
            }


            credit = balance - debit;

            BalanceDestination = int.Parse(client.getAmount(DropDownListAccountTo.SelectedValue.ToString()));

            BalanceDestination = BalanceDestination + debit;
            string isTransfered = client.isTransfered(DropDownListAccountTo.SelectedValue.ToString(), DropDownListAccountFrom.SelectedValue.ToString());
            if (isTransfered == "0")
            {
                client.UpdateBalance(DropDownListAccountFrom.SelectedValue.ToString(), credit.ToString(), "1");
                string returnbalance = client.UpdateBalance(DropDownListAccountTo.SelectedValue.ToString(), BalanceDestination.ToString(), "0");

                //Track Transaction
                client.InsertTransaction(DropDownListAccountFrom.SelectedValue.ToString(), DropDownListAccountTo.SelectedValue.ToString(), TextBoxAmount.Text, Session["customerID"].ToString());
                String message = "Transfer has been actioned from account" + DropDownListAccountFrom.SelectedItem.Text + "To" + DropDownListAccountTo.SelectedItem.Text;
                logthefile(message);


                lblDisplay.Text = "Successful";

            }
            else
            {
                lblDisplay.Text = "Cannot do reverses";
            }

        }

        void logthefile(string msg)
        {
            string path = Path.Combine(@"C:\Users\Anna\OneDrive\Documents\Pearson\Adanced C#\BillionBankProject", "LogFile.txt");
            #region Local
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
            {
                writer.WriteLine(msg);
            }
            #endregion
        }

        protected void DropDownListAccountTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Response = new DataTable();
            ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
            Response = client.AccountDropdown(Session["customerID"].ToString(), DropDownListAccountTypes.SelectedValue.ToString());
            DropDownListAccountFrom.DataSource = Response;
            DropDownListAccountFrom.DataTextField = "accountName";
            DropDownListAccountFrom.DataValueField = "accountID";
            DropDownListAccountFrom.DataBind();

            DropDownListAccountTo.DataSource = Response;
            DropDownListAccountTo.DataTextField = "accountName";
            DropDownListAccountTo.DataValueField = "accountID";
            DropDownListAccountTo.DataBind();
        }
    }
}