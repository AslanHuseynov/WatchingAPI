using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;
using Watching.Persistence.Services;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly IMapper _mapper;

        public WatchListController(IWatchListRepository watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateWatchList(CreateWatchListDto createWatchListDto)
        {
            var watchList = _mapper.Map<WatchList>(createWatchListDto);
            var result = await _watchListRepository.CreateWatchList(watchList);
            return Ok(result);
        }

        [HttpPost("AddToWatchList/id")]
        public async Task<ActionResult<int>> AddToWatchList(int contentId, int userId)
        {
            var content2WatchList = await _watchListRepository.AddToWatchList(contentId, userId);
            return Ok(content2WatchList.Id);
        }

        [HttpGet]
        public async Task<ActionResult<List<WatchList>>> GetWithUser(int userId)
        {
            var result = await _watchListRepository.GetWithUser(userId);
            if (result is null)
                return NotFound("Not found.");

            return Ok(result);
        }

        [HttpPut("TagContent/{id}")]
        public async Task<ActionResult<List<Content2WatchList>>> TagContent(TagContent tagContent)
        {

            try
            {
                await _watchListRepository.UpdateIsTaggedAsync(tagContent);
                var updatedList = await _watchListRepository.GetWatchListAsync();

                return Ok(updatedList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<ActionResult<List<WatchList>>> Delete(int id)
        {
            await _watchListRepository.DeleteEntity(id);
            var watchList = await _watchListRepository.GetWatchListAsync();
            return Ok(watchList);
        }
    }
}
