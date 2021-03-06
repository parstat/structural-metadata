using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NodeSets.CodeList.Commands.RemoveCodeItemCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.AddCodeItemCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.CreateCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.DeleteCommand;
using Presentation.Application.NodeSets.CodeLists.Commands.UpdateCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedCodeListsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCodeListCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateCodeListCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("codeitems")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddCodeItem([FromBody] AddCodeItemCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {            
            return Ok(await Mediator.Send(new DeleteCodeListCommand { Id = id }));
        }

        [HttpDelete("{codeListId}/codeitems/{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveCodeItem(long codeListId, string code)
        {
            return Ok(await Mediator.Send(new RemoveCodeItemCommand { NodeSetId = codeListId, Code = code}));
        }
    }
}