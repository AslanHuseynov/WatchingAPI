using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Application.Queries.WatchListQueries.DeleteWatchListByIdQuery;
using Watching.Application.Queries.WatchListQueries.GetWatchListByUserQueries;
using Watching.Model.Models;
using Watching.Persistence.Services;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IWatchListService _watchListService;
        private readonly IMapper _mapper;

        public WatchListController(IMediator mediator, IWatchListService watchListService, IMapper mapper)
        {
            _mediatR = mediator;
            _watchListService = watchListService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateWatchList(CreateWatchListCommand command) 
            => await _mediatR.Send(command);

        [HttpPost("AddToWatchList/id")]
        public async Task<ActionResult<Content2WatchList>> AddToWatchList(AddToWatchListCommand command) 
            => await _mediatR.Send(command);

        [HttpGet]
        public async Task<ActionResult<List<WatchList>>> GetWithUser([FromQuery]GetWatchListByUserQueries queries)
        {
            var result = await _mediatR.Send(queries);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("TagContent/id")]
        public async Task<ActionResult<List<Content2WatchList>>> TagContent(TagContent tagContent)
        {
            try
            {
                return await _mediatR.Send(tagContent);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<ActionResult<List<WatchList>>> Delete([FromQuery]DeleteWatchListByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if (result is null) 
                return NotFound();

            return Ok(result);
        }
    }
}
