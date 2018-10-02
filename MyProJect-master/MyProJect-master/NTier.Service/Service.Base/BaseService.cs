﻿using NTier.Core.Core.Entity;
using NTier.Core.Core.Entity.Enum;
using NTier.Core.CoreService;
using NTier.DAL.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;


namespace NTier.Service.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private ProjectContext _context;
        public BaseService()
        {
            _context = new ProjectContext();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }


        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);


        public List<T> GetActive() => _context.Set<T>().Where(t => t.Status == Status.Active || t.Status == Status.Updated /*|| t.Status == Status.Deleted*/).ToList();


        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();


        public T GetById(Guid id) => _context.Set<T>().Find(id);


        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save() => _context.SaveChanges();


        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

    }
}
