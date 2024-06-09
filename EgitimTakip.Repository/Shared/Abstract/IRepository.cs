﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        //T=Employee
        ICollection<T> GettAll();
        T Add(T Entity);
        List<T> AddRange(List<T> entities);
        T Update(T Entity);
        void Delete(int id);
        T GetById(int id);
        T GetFirstOrDefalut(Expression<Func<T,bool>> predicate);
        void Save();

    }
}