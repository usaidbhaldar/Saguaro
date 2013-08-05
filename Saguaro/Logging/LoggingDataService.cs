using Saguaro.Logging.DataContexts;
using Saguaro.Logging.Models;
using Saguaro.Logging.TableEntities;
using Saguaro.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Saguaro.Logging
{
    public class LoggingDataService
    {

        private CloudStorageAccount _storageAccount;

        public LoggingDataService()
        {
            _storageAccount = EnvironmentSettings.AzureCloudStorageAccount;
        }

        public async Task<bool> LogAsync(UserProfile userProfile, string logType, string logSubType, string description, HttpRequestBase request)
        {
                LogItem logItem = new LogItem();

                logItem.LogType = logType;
                logItem.LogSubtype = logSubType;
                logItem.Company = userProfile.Company;
                logItem.UserName = userProfile.UserName;
                logItem.Email = userProfile.Email;
                logItem.Description = description;

                try
                {
                    logItem.IPAddress = (request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim().Split(':')[0].ToString();
                }
                catch
                {
                    logItem.IPAddress = "null";
                }

                LoggingDataService loggingDataService = new LoggingDataService();

                return await loggingDataService.LogItemAsync(logItem);
        }

        private async Task<bool> LogItemAsync(LogItem logItem)
        {
            LogDataContext logDataContext = new LogDataContext(logItem.LogType, _storageAccount);
            bool response = await logDataContext.LogActivity(logItem);

            return response;
        }

        public async Task<List<LogByTimeTableEntity>> GetLogsByTimeAsync(string logType, int amount)
        {
            LogDataContext logDataContext = new LogDataContext(logType, _storageAccount);
            return await logDataContext.GetLogsByTimeTask(amount);
        }

        public async Task<List<LogByUserTableEntity>> GetLogsByUserAsync(string logType, string userName, int amount)
        {
            LogDataContext logDataContext = new LogDataContext(logType, _storageAccount);
            return await logDataContext.GetLogsByUserTask(userName, amount);
        }

        public async Task<List<LogByActivityTableEntity>> GetLogsByActivityAsync(string logType, string activity, int amount)
        {
            LogDataContext logDataContext = new LogDataContext(logType, _storageAccount);
            return await logDataContext.GetLogsByActivityTask(activity, amount);
        }

        public async Task<List<LogByIPAddressTableEntity>> GetLogsByIPAddressAsync(string logType, string ipAddress, int amount)
        {
            LogDataContext logDataContext = new LogDataContext(logType, _storageAccount);
            return await logDataContext.GetLogsByIPTask(ipAddress, amount);
        }

    }
}