using Saguaro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Saguaro.Sql
{
    public static class SeedStatements
    {

        public static bool CreateUserProfileTableTask()
        {
            StringBuilder userProfileSqlScript = new StringBuilder("CREATE TABLE [dbo].[UserProfile] ( ");

            userProfileSqlScript.Append("[UserID]   INT           IDENTITY (1, 1) NOT NULL, ");
            userProfileSqlScript.Append("[UserName] NVARCHAR (56) NOT NULL, ");
            userProfileSqlScript.Append("[Email]    NCHAR (120)   NULL, ");
            userProfileSqlScript.Append("[Company]  NCHAR (80)    NULL, ");

            userProfileSqlScript.Append("PRIMARY KEY CLUSTERED ([UserID] ASC), ");
            userProfileSqlScript.Append("UNIQUE NONCLUSTERED ([UserName] ASC)");

            userProfileSqlScript.Append(");");

            SqlCommand sqlCommand = new SqlCommand(userProfileSqlScript.ToString(), new SqlConnection(EnvironmentSettings.SqlConnectionString));
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

            return true;
        }

    }
}