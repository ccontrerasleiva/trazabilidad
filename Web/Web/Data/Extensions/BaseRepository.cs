namespace Data.Extensions
{
    using Domain.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseRepository<T> : Interfaces.IBaseRepository<T> where T : BaseModel
    {
        protected readonly ProyectoGestionContext _context;

        public BaseRepository(ProyectoGestionContext context)
        {
            _context = context;
        }

        public void Add(T item) => Model.Add(item);

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Model.Add(item);
            }
        }

        public void Delete(T item) => Model.Remove(item);

        public void Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Model.Remove(item);
            }
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            var result = Model.AsQueryable();
            Array.ForEach(includes, exp => result = result.Include(exp));
            return result;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync().ConfigureAwait(false);

        public void Update(T item) => _context.Entry(item).State = EntityState.Modified;

        private IDbSet<T> Model => _context.Set<T>();

        public IQueryable<T> GetWithoutTracking(params Expression<Func<T, object>>[] includes)
        {
            var result = Model.AsNoTracking();
            Array.ForEach(includes, exp => result = result.Include(exp));
            return result;
        }

        //public DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters) { return _context.Database.SqlQuery<T>(sql,parameters); } 
        public void SQLQuery(string sql)
        {
            _context.Database.ExecuteSqlCommand(sql);
        }

    }
}