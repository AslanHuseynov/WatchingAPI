using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Content>>> Contents()
        {
            return await _contentService.GetAllEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Content>> Content(int id)
        {
            var result = await _contentService.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("name")]
        public async Task<ActionResult<Content>> Search(string name)
        {
            var result = await _contentService.SearchWithName(name);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContentDto createContentDto)
        {
            var name = _mapper.Map<Content>(createContentDto);
            var result = await _contentService.AddEntity(name);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Content>> Update(UpdateContentDto updateContentDto)
        {
            var name = _mapper.Map<Content>(updateContentDto);
            var result = await _contentService.UpdateEntity(updateContentDto.Id, name);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Content>>> Delete(int id)
        {
            var result = await _contentService.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
