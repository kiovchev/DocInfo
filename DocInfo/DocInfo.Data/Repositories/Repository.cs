namespace DocInfo.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class Repository<T> : IRepository<T>
            where T : class
    {
        private DocDbContext context;
        private DbSet<T> table;
        public Repository(DocDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();

        }
        public T GetById(int id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
