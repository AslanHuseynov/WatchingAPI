using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Interfaces;
using Watching.Application.Queries.CategoryQueries.DeleteCategoryByIdQuery;
using Watching.Application.Queries.CategoryQueries.GetCaregoryQueries;
using Watching.Application.Queries.CategoryQueries.GetCategoryByIdQuery;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CategoryController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories([FromQuery]GetCategoryQueries query)
        => await _mediatR.Send(query);

        [HttpGet("id")]
        public async Task<ActionResult<Category>> GetCategory([FromQuery]GetCategoryByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if(result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryCommand createCategoryCommand)
            => await _mediatR.Send(createCategoryCommand);

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
            => await _mediatR.Send(updateCategoryCommand);

        [HttpDelete("id")]
        public async Task<ActionResult<List<Category>>> DeleteCategory([FromQuery]DeleteCategoryByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if(result is null) return NotFound();
            return Ok(result);
        }
    }
}
