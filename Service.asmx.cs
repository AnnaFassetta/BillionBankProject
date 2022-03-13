


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
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BillionBankProject
{

    

    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        string connString = @"Integrated Security=True;" + @"Initial Catalog =BillionBank; Data Source=DESKTOP-JG4Q650\MSSQLSERVERANNA"; // connection string to SQl

        [WebMethod]
        public string HelloWorld()
        {        
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                sqlConn.Open();
                return "SQL Connection";
            }
            catch (Exception ex)
            {

                return "Error" + ex.ToString();
            }
            
        }

        [WebMethod] // Inserts the users details into SQL
        public string InsertRegister(string name, string surname, string Tel, string Email, string address, string password, string password_question, string Password_qanswer, string ID)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            
            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = @"INSERT INTO Customer (customerName, customerSurname,customerTelNo,customerEmail,customerAddress, customerPassword, 
customerPasswordQuestion,customerPasswordQuestionAnswer, customerIDNumber, customerCapturedDate ) VALUES('" +name+ "','" + surname + "','" + Tel + "','" + Email + "','" + address + "','" + password + "','" + password_question + "','" + Password_qanswer + "' , '" + ID + "','" + DateTime.Now + "')";


                cmd.ExecuteNonQuery();
                return "Succesful";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return "Failed";
            }

        }

        [WebMethod] // Pass the user name and password to allow user to authenticate and returns data table
        public DataTable Login(string ID, string Password)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select customerID, customerName, customerSurname FROm Customer where customerIDNumber = '" + ID + "' AND customerPassword = '" + Password + "'",sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }

        [WebMethod] // Account creation
        public string InsertAccount(string AccountType, string AccountName, string AccountNumber, string customerID)
        {

            int Accountbalance = 0;
            int AccountStatus = 0;
            int accountisTransferred = 0;

            SqlConnection sqlConn = new SqlConnection(connString);

            string accountexist = "";
            try
            {
                using (SqlCommand command = new SqlCommand("select count(accountID) from Account where customerID = '"+customerID+"' ", sqlConn))
                {
                    command.Connection.Open();
                    accountexist = command.ExecuteScalar().ToString();
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {
                
            }
            if(accountexist == "0")
            {
                Accountbalance = 100;
            }
            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = @"INSERT INTO Account (accountType, accountname,accountBalance,accountStatus,accountNumber, accountCreatedDate, 
accountisTransferred,customerID ) VALUES('" + AccountType + "','" + AccountName + "','" + Accountbalance + "','" + AccountStatus + "','" + AccountNumber + "','" + DateTime.Now + "','" + accountisTransferred + "','" + customerID +  "')";


                cmd.ExecuteNonQuery();
                return "Account has been created";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return ole.Message;
            }

        }

        [WebMethod] // returns data table with all the account details
        public DataTable DisplayAccount(string customerID)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select accountID as 'ID', accountType AS 'Account Type', accountName AS 'Account Name', 'R' + CONVERT(varchar(10),accountBalance) AS 'Account Balance', accountNumber AS 'Account Number', case when accountStatus = 0 THEN 'Active' ELSE 'Closed' END as 'Status', accountCreatedDate as 'Date Created' from Account where customerID = '" + customerID+"'", sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }

        [WebMethod] // returns data table according to account type 
        public DataTable AccountDropdown(string customerID, string AccountType)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select accountID, accountName from Account where customerID = '"+customerID+"' and accountType = '"+AccountType+"'", sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }

        [WebMethod] // Returns amount for accountID
        public string getAmount(string accountID)
        {

  
            SqlConnection sqlConn = new SqlConnection(connString);

            string AccountBalance = "";
            try
            {
                using (SqlCommand command = new SqlCommand("select accountBalance from Account where accountID = '" + accountID + "' ", sqlConn))
                {
                    command.Connection.Open();
                    AccountBalance = command.ExecuteScalar().ToString();
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }

            return AccountBalance;
           
        }

        [WebMethod] // updates the balance
        public string UpdateBalance(string accountID, string amount, string isTransfered)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = "update Account set accountBalance = '" + amount+ "',accountisTransferred = '" + isTransfered + "'  where accountID = '" + accountID +"' ";

                cmd.ExecuteNonQuery();
                return "Debited";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return "Failed";
            }

        }

        [WebMethod] // check account 
        public string isTransfered(string Source,string destination)
        {


            SqlConnection sqlConn = new SqlConnection(connString);

            string isTransferedCheck = "";
            try
            {
                using (SqlCommand command = new SqlCommand("select count(transactionID) from transactionAccount  where sourceAccount = '" + Source + "' and destinationAccount = '"+ destination + "'", sqlConn))
                {
                    command.Connection.Open();
                    isTransferedCheck = command.ExecuteScalar().ToString();
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }

            return isTransferedCheck;

        }

        [WebMethod] //track transctions and log a file
        public string InsertTransaction(string source, string destination,string amount,string customerID)
        {

            SqlConnection sqlConn = new SqlConnection(connString);
            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = @"INSERT INTO transactionAccount (sourceAccount, destinationAccount,transactionAmount,transactionDate,customerID) VALUES('" + source + "','" + destination + "','" + amount + "','" + DateTime.Now + "','" + customerID + "')";


                cmd.ExecuteNonQuery();
                String message = "Transfer has been made";
                string path = Path.Combine(@"C:\Users\Anna\OneDrive\Documents\Pearson\Adanced C#\BillionBankProject", "LogFile.txt");
                #region Local
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
                {
                    writer.WriteLine(message);
                }
                #endregion
                return "Inserted";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return ole.Message;
            }

        }

        [WebMethod] // fetches data to display user profile
        public DataTable uodateProfile(string customerID)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select customerID, customerName, customerSurname, customerTelNo, customerEmail, customerAddress, customerPassword, customerPasswordQuestion, customerPasswordQuestionAnswer, customerIDNumber from Customer where customerID = '"+customerID+"'", sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }

        [WebMethod] // Update
        public string UpdateProfile(string customerID, string name, string surname, string Tel, string Email, string address, string password, string password_question, string Password_qanswer, string ID)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = "update customer set customerName = '"+ name+"', customerSurname ='"+ surname+"', customerTelNo = '"+Tel+"', customerEmail = '"+Email+"',customerAddress = '"+address+"',customerPassword = '"+password+"',customerPasswordQuestion = '"+password_question+"',customerPasswordQuestionAnswer = '"+Password_qanswer+"',customerIDNumber = '"+ID+"' where customerID = '"+customerID+"' ";

                cmd.ExecuteNonQuery();
                return "Updated";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return "Failed";
            }

        }

        [WebMethod] // collects user details based on email
        public DataTable ForgotPassword(string customerEmail)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select customerID, customerName, customerSurname, customerTelNo, customerEmail, customerAddress, customerPassword, customerPasswordQuestion, customerPasswordQuestionAnswer, customerIDNumber from Customer where customerEmail = '" + customerEmail + "'", sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }

        [WebMethod] // Update password
        public string UpdatePassword(string Email, string password)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            try

            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = "update customer set customerPassword = '" + password + "' where customerEmail = '" + Email + "' ";

                cmd.ExecuteNonQuery();
                return "Updated";
            }
            catch (SqlException ole)
            {
                Console.WriteLine(ole.Message);
                return "Failed";
            }

        }

        [WebMethod] // display/View transctions based on accountID
        public DataTable DisplayTransaction(string accountID)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            DataTable Response = new DataTable();

            try
            {
                using (SqlCommand command = new SqlCommand("select account.accountName, transactionAmount, transactionDate from transactionAccount inner join Account on transactionAccount.destinationAccount = accountID where sourceAccount = '"+accountID+"'", sqlConn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); //c.con is the connection string
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    command.CommandTimeout = 3600;
                    dataAdapter.Fill(Response);
                    Response.TableName = "MyDt";
                    command.Connection.Close();
                }
            }
            catch (SqlException sqlex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }

            return Response;
        }
    }

}
