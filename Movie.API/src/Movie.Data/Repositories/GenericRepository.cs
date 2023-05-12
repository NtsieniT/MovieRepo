using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movie.Data.Data;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MovieDataContext _movieDataContext;

        public GenericRepository(MovieDataContext movieDataContext)
        {
            _movieDataContext = movieDataContext;
        }
        public void Add(T entity)
        {
            _movieDataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _movieDataContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _movieDataContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _movieDataContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            // attach entity to be changed
            _movieDataContext.Set<T>().Attach(entity);
            _movieDataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
