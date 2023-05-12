using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using _movieDataContext.Data.Repositories;
using Movie.Data.Data;
using Movie.Domain.Interfaces;

namespace Movie.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDataContext _movieDataContext;

        public UnitOfWork(MovieDataContext movieDataContext)
        {
            _movieDataContext = movieDataContext;
        }

        public IMovieRepository MovieRepository => new MovieRepository(_movieDataContext);
        public ITypeRepository TypeRepository => new TypeRepository(_movieDataContext);


        public async Task<bool> Complete()
        {
            return await _movieDataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _movieDataContext.Dispose();
        }
    }
}
