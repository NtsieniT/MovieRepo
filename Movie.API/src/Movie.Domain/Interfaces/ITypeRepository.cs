using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Models.Lookups;

namespace Movie.Domain.Interfaces
{
    public interface ITypeRepository
    {
        Task<IEnumerable<TypeLookup>> ListAllAsync();
    }
}
