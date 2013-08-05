using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saguaro.Logging.TableEntities
{
    public class LogByActivityTableEntity : TableServiceEntity
    {
        //TABLENAME: [logtype]logbyactivity[enviornment] 

        public LogByActivityTableEntity()
        {
            RowKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
        }

        public string ActivityType  // <----   
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }

    }
}