using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace HSCustomFunc
{
    public static class MTBFCalcFunc
    {

        static CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                "simulationstorageaccount", "6t66NE6XbUi8djk2B7JUp4pobzVG+k7jsVFaWq+DDxsauugfP5sybgkHBC2tdPlFEhtNz35Bvwbu9mFTxGTynQ=="), true);

        static CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        [FunctionName("MTBFCalcFunc")]
        public static void Run([TimerTrigger("0 0 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            CloudTable peopleTable = tableClient.GetTableReference("MakersStopReasons");

            TableQuery<MakersStopsStorageEntity> query = new TableQuery<MakersStopsStorageEntity>()
                .Where(TableQuery.GenerateFilterCondition("EventTime", QueryComparisons.GreaterThan, DateTime.Now.GetHourBegin().AddHours(-1).ToUTCString()))
                .Where(TableQuery.GenerateFilterCondition("EventTime", QueryComparisons.LessThan, DateTime.Now.GetHourBegin().ToUTCString()))
                ;





        }

        static string ToUTCString(this DateTime dateTime)
        {
            return string.Format("{0:s}Z", dateTime);
        }

        static DateTime GetHourBegin(this DateTime dateTime)
        {
            return
                dateTime.AddMilliseconds(dateTime.Millisecond)
                .AddMinutes(dateTime.Minute)
                .AddSeconds(dateTime.Second)
                ;
        }
    }
}