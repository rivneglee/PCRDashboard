﻿using System;
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
    public abstract class TaskSettingsModel
    {
        public string Name { get; set; }
    }
}