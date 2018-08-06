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
    public class PCRTaskSettingsModel: TaskSettingsModel
    {
        public string Name { get; set; }

        public int SerialPortNumer { get; set; }

        public int MethodType { get; set; }

        public int MethodCycles { get; set; }

        public int MethodCycleTime { get; set; }

        public int MethodDarkSignal { get; set; }

        public int MethodTrigger { get; set; }
    }
}