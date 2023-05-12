using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Models.Movies>> ListAllAsync();
        Task<Models.Movies> GetByIdAsync(int id);
        void Add(Models.Movies movie );
        void Update(Models.Movies movie);
        void Delete(int id);
    }
}
