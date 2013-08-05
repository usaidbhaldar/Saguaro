using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.Types
{

    public static class LogTypes
    {
        public const string Activity = "activity";
        public const string Platform = "platform";
        public const string Error = "error";
    }



    public static class ActivityTypes
    {
        public const string Download = "download";
        public const string Login = "login";
    }

    public static class PlatformTypes
    {
        public const string UserCreated = "user-created";
    }

    public static class ErrorTypes
    {
        public const string Exception = "exception";
    }


}