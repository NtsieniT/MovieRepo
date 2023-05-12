using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Interfaces;
using Movie.Domain.Models.Lookups;
using System;
using System.Threading.Tasks;

namespace Movie.API.Controllers
{

    public class TypesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetMovieTypes")]
        public async Task<ActionResult<TypeLookup>> ListAllCustomers()
        {
            try
            {
                var types = await _unitOfWork.TypeRepository.ListAllAsync();
                return Ok(types);
            }
            catch (Exception ex)
            {

                //replace with logger
                return BadRequest(ex.Message);
            }

        }
    }
}
