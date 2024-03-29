﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Model
{
    public class Address
    {
        public int AddressID { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
