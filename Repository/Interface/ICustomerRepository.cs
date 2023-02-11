using Projektarbeit_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Repository.Interface
{
    interface ICustomerRepository
    {
        public abstract void Add(Customer entity);
        public abstract void Update(Customer entity);
        public abstract void Delete(int id);
        public abstract List<Customer> GetByName(string name);

        public Customer GetById(int id);

        public List<Customer> GetAll();
        
    }
}
