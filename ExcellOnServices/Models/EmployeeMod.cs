using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExcellOnServices.Models
{
    public class EmployeeMod
    {

        public int Id { get; set; }
        [Display(Name = "Employee ID")]
        public string Employee_Id { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Cell No")]
        public string Cell_No { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public string Addrerss { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Services { get; set; }
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }








    }
}