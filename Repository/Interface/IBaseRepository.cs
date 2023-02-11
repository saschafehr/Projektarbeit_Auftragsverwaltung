using Projektarbeit_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Repository.Interface
{
    internal interface IBaseRepository<T> where T  : class
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public List<T> GetByName(string name);
        public T GetById(int id);
        public List<T> GetAll();
    }
}
