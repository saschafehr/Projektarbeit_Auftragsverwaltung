using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string Password { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
