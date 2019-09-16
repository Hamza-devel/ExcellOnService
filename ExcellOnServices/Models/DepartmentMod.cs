using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExcellOnServices.Models
{
    public class DepartmentMod
    {

        public int Id { get; set; }
        public string Department { get; set; }
        [Display(Name ="Entry Date")]
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime  Date{ get; set; }


    }
}