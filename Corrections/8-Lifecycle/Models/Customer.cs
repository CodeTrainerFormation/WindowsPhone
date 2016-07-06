using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Lifecycle.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        public Customer(string _firstname, string _lastname)
        {
            Id = Guid.NewGuid();
            Firstname = _firstname;
            Lastname = _lastname;
        }
    }
}
