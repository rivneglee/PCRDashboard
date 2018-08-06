using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using clDigital;

namespace PCRDashboard.Models
{
     public enum TaskState
    {
        NEW, RUNNING, CANCELED, DONE, ERROR
    }

    public class TaskModel
    {
        public TaskModel(TaskSettingsModel settings)
        {
            Id = GenerateTaskId();
            Settings = settings;
            State = TaskState.NEW;
        }

        public String Id { set; get; }
        public TaskSettingsModel Settings { set; get; }
        public TaskState State { get; set; }

        private string GenerateTaskId()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        } 
    }
}