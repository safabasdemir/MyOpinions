using Microsoft.EntityFrameworkCore;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.BLL.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        MyDbContext _db;
        protected DbSet<T> table;
        public Repository(MyDbContext db)
        {
            _db = db;
            table = db.Set<T>();

        }

        private void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            table.Add(item);
            Save();
        }

        public bool any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public int Count()
        {
            return table.Count();
        }

        public void Delete(int id)
        {
            T item = GetById(id);
            item.Status = MODEL.Enums.DataStatus.Deleted;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }

        public List<T> GetActives()
        {
            return table.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public List<T> SelectActivesByLimit(int count)
        {
            return table.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Take(count).ToList();
        }

        public void SpecialDelete(int id)
        {
            T item = GetById(id);
            table.Remove(item);
            Save();
        }

        public void Update(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
            return table.FirstOrDefault(exp);
        }
    }
}
