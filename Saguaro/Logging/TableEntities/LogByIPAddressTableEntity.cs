using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.TableEntities
{
    public class LogByIPAddressTableEntity : TableServiceEntity
    {
        //TABLENAME: [logtype]logbyip[enviornment] 

        public LogByIPAddressTableEntity()
        {
            RowKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
        }

        //public string PartitionKey  // <---- PartitionKey  || Use the ActivityType (Platform or Account variant) Static Class to populate. For Detailed Logs: Switch to item id

        public string IPAddress // <---- RowKey  || Use the ActivityType Static Class to populate.
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        public string UserName { get; set; }
        public string ActivityType { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }

    }
}