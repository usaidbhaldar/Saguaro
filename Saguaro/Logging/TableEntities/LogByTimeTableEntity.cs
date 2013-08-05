using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.TableEntities
{
    public class LogByTimeTableEntity : TableServiceEntity
    {
        //TABLENAME: [logtype]logbytime[enviornment] 

        public LogByTimeTableEntity()
        {
            PartitionKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N")); // <---- PartitionKey  
        }

        public string UserName  // <---- RowKey  
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string ActivityType { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
    }
}