using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clDigital;
using PCRDashboard.Models;

namespace PCRDashboard.Services
{
    public class PCRDetectorService: ITaskRunner
    {
        private Dictionary<String, TaskModel> tasks = new Dictionary<String, TaskModel>();
        private Dictionary<String, TaskMonitorModel> states = new Dictionary<String, TaskMonitorModel>();


        public virtual TaskModel Create(TaskSettingsModel settings) 
        {
            TaskModel task = new TaskModel(settings);
            tasks.Add(task.Id, task);
            return task;
        }

        public virtual IList<TaskModel> GetTasks()
        {
            return tasks.Values.ToList();
        }

        public virtual TaskMonitorModel Run(String Id)
        {
            TaskModel Task = tasks[Id];
            if (Task != null)
            {
                PCRTaskSettingsModel Settings = Task.Settings as PCRTaskSettingsModel;
                TaskMonitorModel Monitor = new TaskMonitorModel(Task);
                Digital Detector = new Digital();

                try
                {
                    Detector.Port = Settings.SerialPortNumer;
                    Detector.Open();
                    Detector.Connect();
                    if (Detector.IsConnected)
                    {
                        Task.State = TaskState.RUNNING;
                        Monitor.Logs.Add(new LogRecordModel("Connect successfully", LogLevel.INFO));
                        Monitor.Logs.Add(new LogRecordModel("Board SN:" + Detector.BoardSN, LogLevel.INFO));
                        Monitor.Logs.Add(new LogRecordModel("Board temperature:" + Detector.BoardTemperature, LogLevel.INFO));
                        Detector.MethodType = Settings.MethodType;
                        Detector.MethodCycles = Settings.MethodCycles;
                        Detector.MethodCycletime = Settings.MethodCycleTime;
                        Detector.MethodDarkSignal = Settings.MethodDarkSignal;
                        Detector.StartMethod();

                        Monitor.StartTime = DateTime.Now;
                        Monitor.Logs.Add(new LogRecordModel("Task Started", LogLevel.INFO));
                        while (Detector.IsMethodRunning)
                        {
                            StringBuilder values = new StringBuilder();
                            values.Append("OnValue1:" + Detector.OnValue1 + ",OffValue1:" + Detector.OffValue1);
                            values.Append(";OnValue2:" + Detector.OnValue2 + ",OffValue2:" + Detector.OffValue2);
                            values.Append(";OnValue3:" + Detector.OnValue3 + ",OffValue3:" + Detector.OffValue3);
                            Monitor.Logs.Add(new LogRecordModel(values.ToString(), LogLevel.INFO));
                        }
                        Detector.StopMethod();
                        Task.State = TaskState.DONE;
                        Monitor.EndTime = DateTime.Now;
                        Monitor.Logs.Add(new LogRecordModel("Task finished", LogLevel.INFO));
                    }
                    else
                    {
                        Monitor.Logs.Add(new LogRecordModel("Can not connect to device", LogLevel.ERROR));
                        Task.State = TaskState.ERROR;
                    }
                }
                catch (Exception e)
                {
                    Monitor.Logs.Add(new LogRecordModel("Task failed due to:" + e.Message, LogLevel.ERROR));
                    Task.State = TaskState.ERROR;
                }
                finally
                {
                    Detector.Disconnect();
                    Detector.Close();
                }
                return Monitor;
            }
            return null;
        }

        public virtual TaskMonitorModel Cancel(String id)
        {
            return null;
        }
    }
}
