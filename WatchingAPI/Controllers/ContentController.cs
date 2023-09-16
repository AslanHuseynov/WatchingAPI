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
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Content>>> Contents()
        {
            return await _contentRepository.GetAllEntity();
        }

        [HttpGet]
        public async Task<ActionResult<Content>> Content(int id)
        {
            var result = await _contentRepository.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<Content>> Search(string name)
        {
            var result = await _contentRepository.SearchWithName(name);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContentDto createContentDto)
        {
            var name = _mapper.Map<Content>(createContentDto);
            var result = await _contentRepository.AddEntity(name);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Content>> Update(UpdateContentDto updateContentDto)
        {
            var name = _mapper.Map<Content>(updateContentDto);
            var result = await _contentRepository.UpdateEntity(updateContentDto.Id, name);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Content>>> Delete(int id)
        {
            var result = await _contentRepository.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
