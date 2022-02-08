using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.Models
{
    public class TaskInfo
    {
        [Key]
        [Required]
        public string Task { get; set; }
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
    }
}
