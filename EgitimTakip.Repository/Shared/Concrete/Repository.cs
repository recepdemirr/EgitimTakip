using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel

        //Repository<Employee>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            
        }

        public T Add(T Entity)
        {
           // _context.Set<T>().Add(Entity);
           _dbSet.Add(Entity);
            Save();
            return Entity;
        }

        public List<T> AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
            Save();
            return entities;
        }

        //SOFT DELETE
        public void Delete(int id)
        {
           T Entity= _dbSet.Find();
            Entity.IsDeleted = true;
            _dbSet.Update(Entity);
            Save();

        }

        public T GetById(int id)
        {
            return _dbSet.Find();
        }

        public T GetFirstOrDefalut(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public ICollection<T> GettAll()
        {
            return _dbSet.Where(x => !x.IsDeleted).ToList();
            
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Update(T Entity)
        {
           _dbSet.Update(Entity);
            Save();
            return Entity;
        }
    }

    
}
