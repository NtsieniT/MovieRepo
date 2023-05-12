using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.API.DTOs;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.API.Controllers
{

    public class MovieController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<ActionResult> AddMovie([FromBody] Movies movie)
        {

            try
            {

                _unitOfWork.MovieRepository.Add(movie);
                if (await _unitOfWork.Complete())
                    return Ok(movie);
                return BadRequest("Error adding movie");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ListMovies")]
        public async Task<ActionResult> ListAllMovies()
        {

            try
            {

                var movies = await _unitOfWork.MovieRepository.ListAllAsync();
                var moviesToList = _mapper.Map<IEnumerable<MovieWithTypeDto>>(movies);
                return Ok(moviesToList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("GetMovieById/{id}")]
        public async Task<ActionResult<Movies>> GetMovie(int id)
        {
            try
            {
                var movies = await _unitOfWork.MovieRepository.GetByIdAsync(id);
                if (movies == null)
                    return NotFound();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(Movies movie)
        {

            try
            {
                _unitOfWork.MovieRepository.Update(movie);
                var result = await _unitOfWork.Complete();

                if (result)
                    return NoContent();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [Route("DeleteMovie/{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                var searchedMovie = _unitOfWork.MovieRepository.GetByIdAsync(id);

                if (searchedMovie.Result == null)
                    return NotFound();

                _unitOfWork.MovieRepository.Delete(id);
                if (await _unitOfWork.Complete())
                    return Ok();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



    }
}
