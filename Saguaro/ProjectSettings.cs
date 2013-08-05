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
    public static class ProjectSettings
    {

        public static class Emails
        {
            public const string NewUser_EmailSubjectLine = "Welcome to Saguaro!";
            public const string NewUser_EmailFrom = "no-reply@email.com";
            public const string NewUser_EmailFromName = "fromName";
        }

    }
}