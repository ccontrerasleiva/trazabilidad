namespace Services.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseService<T> where T : Domain.Extensions.BaseModel
    {
        /// <summary>
        /// Obtener una secuencia de <see cref="Domain.Extensions.BaseModel"/>
        /// </summary>
        /// <param name="includes">Propiedades del objeto a incluir.</param>
        /// <returns>Una secuencia de <see cref="Domain.Extensions.BaseModel"/></returns>
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Obtener un <see cref="Domain.Extensions.BaseModel"/> por su ID.
        /// </summary>
        /// <param name="id">ID Del elemento a obtener.</param>
        /// <returns>Una secuencia de <see cref="Domain.Extensions.BaseModel"/></returns>
        T GetById(int id);

        /// <summary>
        /// Guardar un único elemento de forma asíncrona.
        /// </summary>
        /// <param name="item"><see cref="Domain.Extensions.BaseModel"/> a guardar.</param>
        /// <returns></returns>
        Task<T> Save(T item);

        /// <summary>
        /// Guardar una secuencia de elementos de forma asíncrona.
        /// </summary>
        /// <param name="items">Elementos a guardar.</param>
        /// <returns></returns>
        //Task<int> Save(IEnumerable<T> items);

        /// <summary>
        /// Eliminar un único <see cref="Domain.Extensions.BaseModel"/> de forma asíncrona.
        /// </summary>
        /// <param name="item">Elemento a eliminar.</param>
        void Delete(T item);

        /// <summary>
        /// Eliminar una secuencia de <see cref="Domain.Extensions.BaseModel"/> de forma asíncrona.
        /// </summary>
        /// <param name="items">Elementos a eliminar.</param>
        void Delete(IEnumerable<T> items);
    }
}