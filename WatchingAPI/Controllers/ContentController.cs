using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Interfaces;
using Watching.Application.Queries.ContentQueries.DeleteContentByIdQuery;
using Watching.Application.Queries.ContentQueries.GetContentByIdQuery;
using Watching.Application.Queries.ContentQueries.GetContentQueries;
using Watching.Application.Queries.ContentQueries.SearchContentByNameQuery;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentController(IMediator mediator, IContentService contentService, IMapper mapper)
        {
            _mediatR = mediator;
            _contentService = contentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Content>>> Contents([FromQuery]GetContentQueries queries) 
            => await _mediatR.Send(queries);

        [HttpGet("id")]
        public async Task<ActionResult<Content>> Content([FromQuery]GetContentByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("name")]
        public async Task<ActionResult<Content>> Search([FromQuery]SearchContentByNameQuery searchContent)
        {
            var result = await _mediatR.Send(searchContent);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Content>> Create(CreateContentCommand command) 
            => await _mediatR.Send(command);

        [HttpPut]
        public async Task<ActionResult<Content>> Update(UpdateContentCommand command)
            => await _mediatR.Send(command);

        [HttpDelete]
        public async Task<ActionResult<List<Content>>> Delete([FromQuery]DeleteContentByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
