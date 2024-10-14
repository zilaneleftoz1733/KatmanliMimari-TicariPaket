﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.Entities.Abstract;

namespace Ticari.DataAccsessLayer.GenericRepository.ECore.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        public int Create(T entity);
        public int Update(T entity);
        public int Delete(T entity);

        public T? GetById(int id);
        public T? Get(Expression<Func<T, bool>> predicate);

        public List<T>? GetAll(Expression<Func<T,bool>>predicate=null);//(sorgu yazabilmek için bu sorguyu vermek lazım p öyledir ki gibi

        public IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] include);
    }
}
