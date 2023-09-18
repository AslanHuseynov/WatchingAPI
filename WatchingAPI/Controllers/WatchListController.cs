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
        private readonly IWatchListService _watchListService;
        private readonly IMapper _mapper;

        public WatchListController(IWatchListService watchListService, IMapper mapper)
        {
            _watchListService = watchListService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateWatchList(CreateWatchListDto createWatchListDto)
        {
            var watchList = _mapper.Map<WatchList>(createWatchListDto);
            var result = await _watchListService.CreateWatchList(watchList);
            return Ok(result);
        }

        [HttpPost("AddToWatchList/id")]
        public async Task<ActionResult<int>> AddToWatchList(int contentId, int userId)
        {
            var content2WatchList = await _watchListService.AddToWatchList(contentId, userId);
            return Ok(content2WatchList.Id);
        }

        [HttpGet]
        public async Task<ActionResult<List<WatchList>>> GetWithUser(int userId)
        {
            var result = await _watchListService.GetWithUser(userId);
            if (result is null)
                return NotFound("Not found.");

            return Ok(result);
        }

        [HttpPut("TagContent/{id}")]
        public async Task<ActionResult<List<Content2WatchList>>> TagContent(TagContent tagContent)
        {

            try
            {
                await _watchListService.UpdateIsTaggedAsync(tagContent);
                var updatedList = await _watchListService.GetWatchListAsync();

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
            await _watchListService.DeleteEntity(id);
            var watchList = await _watchListService.GetWatchListAsync();
            return Ok(watchList);
        }
    }
}
