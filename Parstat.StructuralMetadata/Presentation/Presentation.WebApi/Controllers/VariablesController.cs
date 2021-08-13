using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Variables.Commands.CreteVariable;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Application.Variables.Queries.GetVariableList;

namespace Presentation.WebApi.Controllers
{
    public class VariablesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableListVm>> GetAll(string language) => Ok(await Mediator.Send(new GetVariableListQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VariableVm>> Get(long id) => Ok(await Mediator.Send(new GetVariableQuery {Id = id}));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateVariableCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}