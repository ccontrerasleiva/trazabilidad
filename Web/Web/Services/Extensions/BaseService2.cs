namespace Services.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseService2<T> : IBaseService2<T> where T : Domain.Extensions.BaseModel2
    {
        protected readonly Data.Extensions.Interfaces.IBaseRepository2<T> _repository;

        public BaseService2(Data.Extensions.Interfaces.IBaseRepository2<T> baseRepo)
        {
            _repository = baseRepo;
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes) => _repository.Get();
        public IQueryable<T> GetWithoutTracking(params Expression<Func<T, object>>[] includes) => _repository.GetWithoutTracking(); // .Get();

        public T GetById(int id) => _repository.Get().FirstOrDefault(t => t.Id == id);


        public async Task<T> Save(T item)
        {

            _repository.Add(item);
            await _repository.SaveChangesAsync();
            return item;
        }

        public async Task<int> Save(IEnumerable<T> items)
        {
            _repository.AddRange(items);
            return await _repository.SaveChangesAsync();
        }

        public async void Delete(T item)
        {
            _repository.Delete(item);
            await _repository.SaveChangesAsync();
        }

        public async void Delete(IEnumerable<T> items)
        {
            _repository.Delete(items);
            await _repository.SaveChangesAsync();
        }

        public void Edit(T item)
            => _repository.Update(item);
    }
}