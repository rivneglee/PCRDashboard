using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCRDashboard.Models;

namespace PCRDashboard.Services
{
    interface ITaskRunner
    {
        TaskMonitorModel Run(String id);

        TaskModel Create(TaskSettingsModel settings);

        IList<TaskModel> GetTasks();

        TaskMonitorModel Cancel(String id);
    }
}
