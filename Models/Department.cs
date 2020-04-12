using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDepart.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "DepartName")]
        public string DepartName { get; set; }
        

    }
}
