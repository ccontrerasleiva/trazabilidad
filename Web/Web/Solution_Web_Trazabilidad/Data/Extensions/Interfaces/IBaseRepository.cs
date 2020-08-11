namespace Data.Extensions.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Interfaz de repositorio base para las entidades.
    /// <para>NOTA: <see cref="T"/> debe heredar de <see cref="BaseModel"/>.</para>
    /// </summary>
    /// <typeparam name="T">Tipo de objeto el cual implementará la interfaz <see cref="IBaseRepository{T}"/>. </typeparam>
    public interface IBaseRepository<T> where T : Domain.Extensions.BaseModel
    {
        /// <summary>
        /// Agregar un item al contexto.
        /// </summary>
        /// <param name="item">Item a agregar</param>
        void Add(T item);

        /// <summary>
        /// Añadir una colección de items al contexto.
        /// </summary>
        /// <param name="items"><see cref="IEnumerable{T}"/> de items a agregar.</param>
        void AddRange(IEnumerable<T> items);

        /// <summary>
        /// Eliminar un item del contexto.
        /// </summary>
        /// <param name="item">Item a eliminar.</param>
        void Delete(T item);

        /// <summary>
        /// Eliminar una serie de items del contexto
        /// </summary>
        /// <param name="item">Items a eliminar</param>
        void Delete(IEnumerable<T> item);

        /// <summary>
        /// Actualizar item
        /// </summary>
        /// <param name="item"><see cref="T"/> a Actualizar.</param>
        void Update(T item);

        /// <summary>
        /// Obtener items.
        /// </summary>
        /// <returns>Un <see cref="IQueryable{T}"/> de <see cref="T"/></returns>
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Guardar cambios en el contexto de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Obtener un IQueryable con los resultados no cacheados en el contexto de la base de datos.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetWithoutTracking(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Ejecutar procedimientos almacenados
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);
        void SQLQuery(string sql);
    }
}