using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlukData_Insert.Models
{
    public class ContactInfo
    {

        public int ID { get; set; }

        [Required(ErrorMessage ="Name is requried")]
        public string Name { get; set; }

        public string Address { get; set; }

    }
}
