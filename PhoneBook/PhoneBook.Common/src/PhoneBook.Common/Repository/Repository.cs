using Microsoft.EntityFrameworkCore;
using PhoneBook.Common.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public DataContext Context { get; private set; }

        public DbSet<TEntity> DbSet { get; private set; }

        public Repository(DataContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, bool autoSave = true)
        {
            await DbSet.AddAsync(entity);
            Context.Entry(entity).State = EntityState.Added;

            if (autoSave)
                await SaveChangesAsync();
        }

        public void Delete(int id, bool autoSave = true)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;

            if (autoSave)
                SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable().AsNoTracking();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            if (query != null)
                return Query();

            return DbSet.AsQueryable().Where(query);
        }

        public async Task<TEntity> SingleAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(TEntity entity, bool autoSave = true)
        {
            DbSet.Update(entity);
            Context.Entry(entity).State = EntityState.Modified;

            if (autoSave)
                SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }
    }
}
