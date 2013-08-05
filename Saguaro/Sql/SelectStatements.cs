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
    public static class SelectStatements
    {

        public async static Task<UserProfile> GetUserProfileTask(string UserName)
        {
            UserProfile response = new UserProfile();

            StringBuilder SqlStatement = new StringBuilder();

            //SQL Statement =============================================================
            SqlStatement.Append("SELECT * FROM UserProfile WHERE UserName = '");
            SqlStatement.Append(UserName);
            SqlStatement.Append("'");

            SqlCommand sqlCommand = new SqlCommand(SqlStatement.ToString(), new SqlConnection(EnvironmentSettings.SqlConnectionString));
            sqlCommand.Connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                response.Company = reader["Company"].ToString();
                response.Email = reader["Email"].ToString();
                response.UserID = Convert.ToInt32(reader["UserID"].ToString());
                response.UserName = reader["UserName"].ToString();
            }

            sqlCommand.Connection.Close();

            return response;
        }


        public async static Task<string> GetCompanyForUserTask(string UserName)
        {
            string response = String.Empty;

            StringBuilder SqlStatement = new StringBuilder();

            //SQL Statement =============================================================
            SqlStatement.Append("SELECT Company FROM UserProfile WHERE UserName = '");
            SqlStatement.Append(UserName);
            SqlStatement.Append("'");

            SqlCommand sqlCommand = new SqlCommand(SqlStatement.ToString(), new SqlConnection(EnvironmentSettings.SqlConnectionString));
            sqlCommand.Connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader(); 

            while (reader.Read())
            {
                response = reader["Company"].ToString();
            }

            sqlCommand.Connection.Close();

            return response;
        }

        public async static Task<string> GetEmailForUserTask(string UserName)
        {
            string response = String.Empty;

            StringBuilder SqlStatement = new StringBuilder();

            //SQL Statement =============================================================
            SqlStatement.Append("SELECT Email FROM UserProfile WHERE UserName = '");
            SqlStatement.Append(UserName);
            SqlStatement.Append("'");

            SqlCommand sqlCommand = new SqlCommand(SqlStatement.ToString(), new SqlConnection(EnvironmentSettings.SqlConnectionString));
            sqlCommand.Connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader(); 

            while (reader.Read())
            {
                response = reader["Email"].ToString();
            }

            sqlCommand.Connection.Close();

            return response;
        }

    }
}