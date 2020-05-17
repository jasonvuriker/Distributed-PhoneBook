using Microsoft.EntityFrameworkCore;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PhoneBook.Common.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RegisterEntities(modelBuilder);
        }

        private void RegisterEntities(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetEntryAssembly();
             var entityTypes = assembly.GetTypes()
                .Where(x => x.GetTypeInfo().IsSubclassOf(typeof(Entity)) && !x.GetTypeInfo().IsAbstract);
            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
