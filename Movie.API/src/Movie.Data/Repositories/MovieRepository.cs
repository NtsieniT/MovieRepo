using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movie.Data.Data;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace _movieDataContext.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDataContext _context;

        public MovieRepository(MovieDataContext context)
        {
            _context = context;
        }

        public void Add(Movies movies )
        {
            _context.Movies.Add(movies);
        }

        public void Delete(int id)
        {
            var movies = _context.Movies.Find(id);
            if (movies != null)
            {
                _context.Movies.Remove(movies);
            }
        }

        public async Task<Movies> GetByIdAsync(int id)
        {
            return await _context.Movies.Include(t => t.Type).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Movies>> ListAllAsync()
        {
            return await _context.Movies.Include(t => t.Type).ToListAsync();
        }

        public void Update(Movies movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
        }
    }
}
