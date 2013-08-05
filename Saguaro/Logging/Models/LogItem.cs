using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.Models
{
    public class LogItem
    {
        public string LogType { get; set; }
        public string LogSubtype { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
    }

}   