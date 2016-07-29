using System;
using System.ComponentModel.DataAnnotations;

namespace BEEPOApp.Models
{
    public class Employee : Person
    {

        //public int DepartmentId { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }

    }
}