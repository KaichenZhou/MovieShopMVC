﻿using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;

        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            //get all the records from the table
            //we can use this method for getting all the list of genres
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}