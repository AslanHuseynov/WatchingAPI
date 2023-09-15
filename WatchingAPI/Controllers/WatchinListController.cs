using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Dtos.WatchingNameDto;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;
using Watching.Persistence.Services;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchinListController : ControllerBase
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly IMapper _mapper;

        public WatchinListController(IWatchListRepository watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<WatchList>>> AddToWatchList(CreateWatchListDto createWatchListDto)
        {
            var list = _mapper.Map<WatchList>(createWatchListDto);
            var result = await _watchListRepository.AddToWatchList(list);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<WatchList>>> GetWithUser(int userId)
        {
            var result = await _watchListRepository.GetWithUser(userId);
            if (result is null)
                return NotFound("Not found.");

            return Ok(result);
        }

        [HttpPut("updateWatchList/{id}")]
        public async Task<ActionResult<List<WatchList>>> UpdateWatchList(int id, UpdateWatchListDto updateWatchListDto)
        {
            if (id != updateWatchListDto.Id)
            {
                return NotFound("Not found.");
            }

            try
            {
                await _watchListRepository.UpdateIsCheckedAsync(id, updateWatchListDto.IsChecked);
                var updatedList = await _watchListRepository.GetWatchListAsync(); // Get the updated list of items.

                return Ok(updatedList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
