using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSCustomFunc
{
    public class MTBFEntity : TableEntity
    {
        public MTBFEntity() { }

        public MTBFEntity(string deviceid, DateTime eventtime)
        {
            this.PartitionKey = deviceid;
            this.RowKey = eventtime.ToString();
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double MTBF { get; set; }

    }
}