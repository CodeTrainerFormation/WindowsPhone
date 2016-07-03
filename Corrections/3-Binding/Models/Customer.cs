using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Binding.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Customer(string _firstname, string _lastname)
        {
            Id = Guid.NewGuid();
            Firstname = _firstname;
            Lastname = _lastname;
        }
    }
}
