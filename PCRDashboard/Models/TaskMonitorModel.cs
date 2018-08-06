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
    public class TaskMonitorModel
    {
        public TaskMonitorModel(TaskModel task)
        {
            Logs = new List<LogRecordModel>();
            Task = task;
        }

        public TaskModel Task { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IList<LogRecordModel> Logs { get; set; }
    }
}