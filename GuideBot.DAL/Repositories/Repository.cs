using GuideBot.DAL.Contexts;
using GuideBot.DAL.Entities.BaseEntities;
using GuideBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuideBot.DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            var query = Include(includeProperties);
            return query.Where(predicate);
        }

        public T GetExemplarByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            var query = Include(includeProperties);
            return query.AsEnumerable().Where(e => predicate(e)).FirstOrDefault();
        }

        public T AddExemplar<T>(T exemplar) where T : BaseDto
        {
            T newExemplar = this.dbContext.Set<T>().Add(exemplar).Entity;
            this.dbContext.SaveChanges();
            return newExemplar;
        }

        public void DeleteById<T>(int id) where T : BaseEntity
        {
            this.dbContext.Set<T>().Remove(this.dbContext.Set<T>().Find(id));
            this.dbContext.SaveChanges();
        }

        public void DeleteByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            this.dbContext.Set<T>().RemoveRange(this.GetByFilter<T>(predicate, includeProperties));
            this.dbContext.SaveChanges();
        }

        public void UpdateExemplar<T>(T exemplar) where T : BaseDto
        {
            this.dbContext.Set<T>().Update(exemplar);
            this.dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            var query = await Include(includeProperties).ToListAsync();
            return query.Where(predicate);
        }

        public async Task<T> GetExemplarByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            var query = await Include(includeProperties).ToListAsync();
            return query.FirstOrDefault(predicate);
        }

        public async Task<T> AddExemplarAsync<T>(T exemplar) where T : BaseDto
        {
            var newExemplarTask = await this.dbContext.Set<T>().AddAsync(exemplar);
            await this.dbContext.SaveChangesAsync();
            return newExemplarTask.Entity;
        }

        public async Task DeleteByIdAsync<T>(int id) where T : BaseEntity
        {
            this.dbContext.Set<T>().Remove(this.dbContext.Set<T>().Find(id));
            await this.dbContext.SaveChangesAsync();
        }

        public Task DeleteByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            this.dbContext.Set<T>().RemoveRange(this.GetByFilter<T>(predicate, includeProperties));
            return this.dbContext.SaveChangesAsync();
        }

        public Task UpdateExemplarAsync<T>(T exemplar) where T : BaseDto
        {
            this.dbContext.Set<T>().Update(exemplar);
            return this.dbContext.SaveChangesAsync();
        }

        private IQueryable<T> Include<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseDto
        {
            IQueryable<T> query = dbContext.Set<T>().AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
