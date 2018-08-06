using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCRDashboard.Models;
using PCRDashboard.Services;

namespace PCRDashboard.Controllers
{
    public class TasksController : ApiController
    {
        private static ITaskRunner TaskService = new PCRDetectorService();

        // GET api/tasks
        public IEnumerable<TaskModel> Get()
        {
            return TaskService.GetTasks();
        }

        // POST api/tasks
        public TaskModel Post([FromBody]PCRTaskSettingsModel settings)
        {
            return TaskService.Create(settings);
        }
    }
}