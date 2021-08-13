using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits;

namespace Presentation.WebApi.Controllers
{
    public class MeasurementUnitController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementUnitsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetMeasurementUnitsQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementUnitVm>> Get(long id) => Ok(await Mediator.Send(new GetMeasurementUnitQuery {Id = id}));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateMeasurementUnitCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}