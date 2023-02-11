using Projektarbeit_Auftragsverwaltung.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public abstract void Add(T entity);
        public abstract void Delete(int id);
        public abstract List<T> GetAll();
        public abstract T GetById(int id);
        public abstract List<T> GetByName(string name);
        public abstract void Update(T entity);
    }
}
