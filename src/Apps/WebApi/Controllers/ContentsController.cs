using CleanApplication.Application.Common.Models;
using CleanApplication.Application.Contents.Queries.GetContents;
using CleanApplication.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanApplication.WebApi.Controllers
{
    [Authorize]
    public class ContentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PaginatedList<ContentDto>>>> Get([FromQuery] GetContentsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
