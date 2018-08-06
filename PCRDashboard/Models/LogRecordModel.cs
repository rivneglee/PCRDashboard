using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PCRDashboard.Models
{
    public enum LogLevel
    {
        DEBUG, INFO, ERROR
    }

    public class LogRecordModel
    {
        public LogRecordModel(string log, LogLevel level)
        {
            Content = log;
            Type = level;
        }

        public String Content { get; set; }
        public LogLevel Type { get; set; }
    }
}