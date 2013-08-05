using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace Saguaro
{
    public class InitConfig
    {

        public static void InitializeData()
        {

            if (!WebSecurity.Initialized)
            {

                //Generate intial tables:

                if(!Sql.VerificationStatements.TableExists("UserProfile"))
                {
                    Sql.SeedStatements.CreateUserProfileTableTask();
                }

                //Intialize DB Connection, Roles & initial Admin user:

                WebSecurity.InitializeDatabaseConnection("db_name", "UserProfile", "UserID", "UserName", autoCreateTables: true);

                if (!Roles.RoleExists("Admin"))
                {
                    Roles.CreateRole("Admin");
                }
                if (!Roles.RoleExists("User"))
                {
                    Roles.CreateRole("User");
                }
                if (!WebSecurity.UserExists("admin"))
                {
                    WebSecurity.CreateUserAndAccount("admin", "adminPassword");
                    Roles.AddUserToRole("admin", "Admin");
                }
            }


        }
    }
}