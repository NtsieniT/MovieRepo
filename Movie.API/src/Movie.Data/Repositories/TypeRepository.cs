using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movie.Data.Data;
using Movie.Domain.Interfaces;
using Movie.Domain.Models.Lookups;
using Movie.Data.Data;

namespace Movie.Data.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MovieDataContext _movieDataContext;

        public TypeRepository(MovieDataContext movieDataContext)
        {
            _movieDataContext = movieDataContext;
        }

        public async Task<IEnumerable<TypeLookup>> ListAllAsync()
        {
            return await _movieDataContext.Types.ToListAsync();
        }
    }
}
