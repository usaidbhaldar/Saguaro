using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Configuration;
using System.Text;
using Microsoft.WindowsAzure;

namespace Saguaro
{
    public static class EnvironmentSettings
    {

        public static class SendGridAccount
        {
            public static string UserName = ConfigurationManager.AppSettings["SendGrid_AccountName"];
            public static string APIKey = ConfigurationManager.AppSettings["SendGrid_ApiKey"];
            public static string SMTPAddress = ConfigurationManager.AppSettings["SendGrid_SmtpAddress"];
            public static string FromEmail = ConfigurationManager.AppSettings["SendGrid_FromEmail"];

        }

        public static class AzureCloudStorageAccountLogin
        {
            public static string Name = ConfigurationManager.AppSettings["CloudStorage_AccountName"];
            public static string Key = ConfigurationManager.AppSettings["CloudStorage_AccountKey"];
        }

        public static CloudStorageAccount AzureCloudStorageAccount
        {
            get
            {
                CloudStorageAccount _storageAccount;

                StorageCredentialsAccountAndKey _storageCredentials = new StorageCredentialsAccountAndKey(AzureCloudStorageAccountLogin.Name, AzureCloudStorageAccountLogin.Key);

                _storageAccount = new CloudStorageAccount(_storageCredentials, false);

                return _storageAccount;
            }
        }


        public static class Environment
        {
            public static string Current = ConfigurationManager.AppSettings["Environment"];
        }


        public static class SqlConnectionVariables
        {
            public static string ServerName = ConfigurationManager.AppSettings["SQL_ServerName"];
            public static string ServerAddress = ConfigurationManager.AppSettings["SQL_ServerAddress"];
            public static string DatabaseName = ConfigurationManager.AppSettings["SQL_DatabaseName"];
            public static string LoginName = ConfigurationManager.AppSettings["SQL_ServerLoginName"];
            public static string Password = ConfigurationManager.AppSettings["SQL_ServerPassword"];

        }

        public static string SqlConnectionString
        {
            get
            {
                StringBuilder connectionString = new StringBuilder();

                connectionString.Append("Server=tcp:");
                connectionString.Append(SqlConnectionVariables.ServerAddress);
                connectionString.Append(",1433;Database=");
                connectionString.Append(SqlConnectionVariables.DatabaseName);
                connectionString.Append(";User ID=");
                connectionString.Append(SqlConnectionVariables.LoginName);
                connectionString.Append("@");
                connectionString.Append(SqlConnectionVariables.ServerName);
                connectionString.Append(";Password=");
                connectionString.Append(SqlConnectionVariables.Password);
                connectionString.Append(";Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");

                return connectionString.ToString();
            }
        }

    }
}