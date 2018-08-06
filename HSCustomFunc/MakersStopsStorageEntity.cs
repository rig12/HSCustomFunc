using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSCustomFunc
{
    public class MakersStopsStorageEntity : TableEntity
    {
        
        public DateTime EventTime { get; set; }
        public int PartitionId { get; set; }
        public string deviceId { get; set; }
        public string pointInfo { get; set; }
        public float Productivity { get; set; }
        public string state { get; set; }
        public string reason { get; set; }
    }
}