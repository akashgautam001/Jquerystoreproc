using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWthStoreJquery.Models
{
    public class Employess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Dob { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public List<Employess> EmployessList { get; set; }
    }
}