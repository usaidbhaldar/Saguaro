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
    public static class VerificationStatements
    {

        public static bool TableExists(string tableName)
        {
            bool exists = false;

            string SqlStatement =
                 "IF OBJECT_ID ('dbo." + tableName + "') IS NOT NULL SELECT 'true' ELSE SELECT 'false'";

            SqlCommand sqlCommand = new SqlCommand(SqlStatement.ToString(), new SqlConnection(EnvironmentSettings.SqlConnectionString));
            sqlCommand.Connection.Open();
            exists = Convert.ToBoolean(sqlCommand.ExecuteScalar());

            sqlCommand.Connection.Close();

            return exists;
        }

    }
}