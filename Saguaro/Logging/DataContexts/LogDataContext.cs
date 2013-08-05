using Saguaro.Logging.Models;
using Saguaro.Logging.TableEntities;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Saguaro.Logging.DataContexts
{
    class LogDataContext : TableServiceContext
    {
        private CloudStorageAccount _storageAccount;
        private string _tableName = string.Empty;

        public LogDataContext(string logType, CloudStorageAccount storageAccount)
            : base(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials)
        {
            _storageAccount = storageAccount;
            var tableStorage = new CloudTableClient(_storageAccount.TableEndpoint.AbsoluteUri, _storageAccount.Credentials);

            _tableName = logType.ToLower() + "log";

            try
            {
                tableStorage.CreateTableIfNotExist(_tableName + "byactivity" + EnvironmentSettings.Environment.Current);
                tableStorage.CreateTableIfNotExist(_tableName + "bytime" + EnvironmentSettings.Environment.Current);
                tableStorage.CreateTableIfNotExist(_tableName + "byuser" + EnvironmentSettings.Environment.Current);
                tableStorage.CreateTableIfNotExist(_tableName + "byip" + EnvironmentSettings.Environment.Current);
            }
            catch (Exception e)
            {
            }
        }


        public async Task<bool> LogActivity(LogItem logItem)
        {
            var tableStorage = new CloudTableClient(_storageAccount.TableEndpoint.AbsoluteUri, _storageAccount.Credentials);

            #region Update to Parallel Tasks (not consistent)
                  
            /*
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Factory.StartNew(() => logItemTask("byactivity", logItem)));
            tasks.Add(Task.Factory.StartNew(() => logItemTask("bytime", logItem)));
            tasks.Add(Task.Factory.StartNew(() => logItemTask("byip", logItem)));
            tasks.Add(Task.Factory.StartNew(() => logItemTask("byuser", logItem)));
            
            Task.WaitAll(tasks.ToArray());
             */
             
            #endregion

            #region Non Parallel

            
            logItemTask("byactivity", logItem);
            logItemTask("bytime", logItem);
            logItemTask("byip", logItem);
            logItemTask("byuser", logItem);
            

            #endregion

            return true;
        }

        private async Task<bool> logItemTask(string logType, LogItem logItem)
        {
            switch (logType)
            {
                case "byactivity":
                    try
                    {
                        // 1. Store by Activity: ===================================================================
                        //[logtype]logbyactivity 
                        LogByActivityTableEntity logByActivityTableEntity = new LogByActivityTableEntity();
                        logByActivityTableEntity.ActivityType = logItem.LogSubtype;
                        logByActivityTableEntity.UserName = logItem.UserName;
                        logByActivityTableEntity.IPAddress = logItem.IPAddress;
                        logByActivityTableEntity.Description = logItem.Description;
                        logByActivityTableEntity.Company = logItem.Company;
                        logByActivityTableEntity.Email = logItem.Email;

                        AddObject(_tableName + "byactivity" + EnvironmentSettings.Environment.Current, logByActivityTableEntity);
                        SaveChanges();

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                    

                case "byip":
                    try
                    {
                        // 2. Store by IP: ===================================================================
                        //[logtype]logbyip
                        LogByIPAddressTableEntity logByIPAddressTableEntity = new LogByIPAddressTableEntity();
                        logByIPAddressTableEntity.ActivityType = logItem.LogSubtype;
                        logByIPAddressTableEntity.UserName = logItem.UserName;
                        logByIPAddressTableEntity.IPAddress = logItem.IPAddress;
                        logByIPAddressTableEntity.Description = logItem.Description;
                        logByIPAddressTableEntity.Company = logItem.Company;
                        logByIPAddressTableEntity.Email = logItem.Email;

                        AddObject(_tableName + "byip" + EnvironmentSettings.Environment.Current, logByIPAddressTableEntity);
                        SaveChanges();

                        return true;
                    }
                    catch(Exception e)
                    {
                        return false;
                    }

                    

                case "byuser":
                    try
                    {
                        // 3. Store by User: ===================================================================
                        //[logtype]logbyuser

                        LogByUserTableEntity logByUserTableEntity = new LogByUserTableEntity();
                        logByUserTableEntity.ActivityType = logItem.LogSubtype;
                        logByUserTableEntity.UserName = logItem.UserName;
                        logByUserTableEntity.IPAddress = logItem.IPAddress;
                        logByUserTableEntity.Description = logItem.Description;
                        logByUserTableEntity.Company = logItem.Company;
                        logByUserTableEntity.Email = logItem.Email;

                        AddObject(_tableName + "byuser" + EnvironmentSettings.Environment.Current, logByUserTableEntity);
                        SaveChanges();

                        return true;
                    }
                    catch(Exception e)
                    {
                        return false;
                    }

                case "bytime":

                    try
                    {
                        // 4. Store by Time: ===================================================================
                        //[logtype]logbytime

                        LogByTimeTableEntity logByTimeTableEntity = new LogByTimeTableEntity();
                        logByTimeTableEntity.ActivityType = logItem.LogSubtype;
                        logByTimeTableEntity.UserName = logItem.UserName;
                        logByTimeTableEntity.IPAddress = logItem.IPAddress;
                        logByTimeTableEntity.Description = logItem.Description;
                        logByTimeTableEntity.Company = logItem.Company;
                        logByTimeTableEntity.Email = logItem.Email;


                        AddObject(_tableName + "bytime" + EnvironmentSettings.Environment.Current, logByTimeTableEntity);
                        SaveChanges();

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                default:
                    return false;

            }
        }


        public async Task<List<LogByUserTableEntity>> GetLogsByUserTask(string userName, int amount)
        {

            List<LogByUserTableEntity> entities = new List<LogByUserTableEntity>();

            try
            {
                entities = (from p in CreateQuery<LogByUserTableEntity>(_tableName + "byuser" + EnvironmentSettings.Environment.Current) where p.PartitionKey == userName select p).Take(amount).ToList();
            }
            catch (Exception e)
            {
                entities = (from p in CreateQuery<LogByUserTableEntity>(_tableName + "byuser" + EnvironmentSettings.Environment.Current) where p.PartitionKey == userName select p).ToList();
            }

            return entities;
        }

        public async Task<List<LogByIPAddressTableEntity>> GetLogsByIPTask(string ipAddress, int amount)
        {

            List<LogByIPAddressTableEntity> entities = new List<LogByIPAddressTableEntity>();

            try
            {
                entities = (from p in CreateQuery<LogByIPAddressTableEntity>(_tableName + "byip" + EnvironmentSettings.Environment.Current) where p.PartitionKey == ipAddress select p).Take(amount).ToList();
            }
            catch (Exception e)
            {
                entities = (from p in CreateQuery<LogByIPAddressTableEntity>(_tableName + "byip" + EnvironmentSettings.Environment.Current) where p.PartitionKey == ipAddress select p).ToList();
            }

            return entities;
        }

        public async Task<List<LogByActivityTableEntity>> GetLogsByActivityTask(string activity, int amount)
        {

            List<LogByActivityTableEntity> entities = new List<LogByActivityTableEntity>();

            try
            {
                entities = (from p in CreateQuery<LogByActivityTableEntity>(_tableName + "byactivity" + EnvironmentSettings.Environment.Current) where p.PartitionKey == activity select p).Take(amount).ToList();
            }
            catch (Exception e)
            {
                entities = (from p in CreateQuery<LogByActivityTableEntity>(_tableName + "byactivity" + EnvironmentSettings.Environment.Current) where p.PartitionKey == activity select p).ToList();
            }

            return entities;
        }

        public async Task<List<LogByTimeTableEntity>> GetLogsByTimeTask(int amount)
        {

            List<LogByTimeTableEntity> entities = new List<LogByTimeTableEntity>();

            try
            {
                entities = (from p in CreateQuery<LogByTimeTableEntity>(_tableName + "bytime" + EnvironmentSettings.Environment.Current) select p).Take(amount).ToList();
            }
            catch (Exception e)
            {
                entities = (from p in CreateQuery<LogByTimeTableEntity>(_tableName + "bytime" + EnvironmentSettings.Environment.Current) select p).ToList();
            }

            return entities;
        }




    }
}