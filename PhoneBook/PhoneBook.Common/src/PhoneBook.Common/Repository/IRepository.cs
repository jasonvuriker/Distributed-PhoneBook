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
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        DataContext Context { get; }

        DbSet<TEntity> DbSet { get; }

        Task AddAsync(TEntity entity, bool autoSave = true);

        void Update(TEntity entity, bool autoSave = true);

        Task<TEntity> SingleAsync(int id);

        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query);

        void Delete(int id, bool autoSave = true);

        Task SaveChangesAsync();

        bool SaveChanges();
    }
}
