using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.WatchingNameDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchingNameController : ControllerBase
    {
        private readonly IWatchingNameRepository _watchingNameRepository;
        private readonly IMapper _mapper;

        public WatchingNameController(IWatchingNameRepository watchingNameRepository, IMapper mapper)
        {
            _watchingNameRepository = watchingNameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<WatchingName>>> GetAllWatchingNames()
        {
            return await _watchingNameRepository.GetAllEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WatchingName>> GetWatchingName(int id)
        {
            var result = await _watchingNameRepository.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<WatchingName>>> CreateWatchingName(CreateWatchingNameDto createWatchingNameDto)
        {
            var name = _mapper.Map<WatchingName>(createWatchingNameDto);
            var result = await _watchingNameRepository.AddEntity(name);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<WatchingName>>> UpdateWatchingName(UpdateWatchingNameDto updateWatchingNameDto)
        {
            var name = _mapper.Map<WatchingName>(updateWatchingNameDto);
            var result = await _watchingNameRepository.UpdateEntity(updateWatchingNameDto.Id, name);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WatchingName>>> DeleteWatchingName(int id)
        {
            var result = await _watchingNameRepository.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
