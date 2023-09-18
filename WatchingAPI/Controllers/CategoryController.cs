using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return await _categoryService.GetAllEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var result = await _categoryService.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            var result = await _categoryService.AddEntity(category);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryService.UpdateEntity(updateCategoryDto.Id, category);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
