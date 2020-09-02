﻿using GameStore.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repository.Implementation
{
   public class FileRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public void Create(TEntity entity)
        {
            var type = entity.GetType();
            var props = type.GetProperties();

            foreach (PropertyInfo item in props)
            {
                string text = $"{item.Name} ==> {item.GetValue(entity)}";

                File.AppendAllText("D:\\testRepo.txt",text);
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> gameFilters)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
