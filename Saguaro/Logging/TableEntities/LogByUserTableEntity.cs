using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.TableEntities
{
    public class LogByUserTableEntity : TableServiceEntity
    {
        //TABLENAME: [logtype]logbyuser[enviornment] 

        public LogByUserTableEntity()
        {
            RowKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N")); // <---- RowKey  
        } 

        public string UserName  // <---- PartitionKey  
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        public string ActivityType { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
    }
}