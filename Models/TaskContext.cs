using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.Models
{
    public class TaskContext : DbContext
    {

        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        {

        }

        public DbSet <TaskInfo> TaskInfo { get; set; }
        public DbSet <Category> Categories { get; set; }


    }
}
