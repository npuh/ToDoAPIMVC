using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoMVC.Models
{
    public class MVCTDoDBModel
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage="This field is required!")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string TaskDescription { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
    }
}