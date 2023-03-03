using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.Repository
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime HireDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
