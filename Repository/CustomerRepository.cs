using Microsoft.EntityFrameworkCore;
using Projektarbeit_Auftragsverwaltung.Model;
using Projektarbeit_Auftragsverwaltung.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public override void Add(Customer entity)
        {
            using (var context = new OrderContext())
            {
                entity.Address = null;
                context.Customers.Add(entity);
                context.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (var context = new OrderContext())
            {
                context.Customers.Remove(GetById(id));
                context.SaveChanges();
            }
        }

        public override List<Customer> GetAll()
        {
            using (var context = new OrderContext())
            {
                List<Customer> customers = new List<Customer>();

                var entitys = context.Customers;
                foreach (Customer customer  in entitys)
                   customers.Add(customer);

                return customers;
            }
        }

        public override Customer GetById(int id)
        {
            using (var context = new OrderContext())
            {
                try
                {
                    return context.Customers.First(x => x.CustomerID == id);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show($"Es wurde keine Person mit der ID = {ex.Message}");


                }
                return null; // Ist das richtig?
            }
        }

        public override List<Customer> GetByName(string name)
        {
            using (var context = new OrderContext())
            {
                return context.Customers.Where(x => x.Firstname.Contains(name) || x.Firstname.Contains(name)).ToList();
            }
        }

        public override void Update(Customer entity)
        {
            using (var context = new OrderContext())
            {
                context.Customers.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
