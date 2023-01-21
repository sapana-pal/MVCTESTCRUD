using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCTESTCRUD.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(9, ErrorMessage = "less than or equal to four characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Active")]
        [StringLength(10, ErrorMessage = "less than or equal to ten characters.")]
        public bool Active { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Your Date.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public List<Customer> ShowallCustomer { get; set; }
        public List<Customer> AllActiveData { get; set; }


    }
}