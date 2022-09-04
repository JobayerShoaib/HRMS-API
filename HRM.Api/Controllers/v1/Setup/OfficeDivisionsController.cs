using Application.Features.Setups.OfficeDivisions.Commands.Create;
using Application.Features.Setups.OfficeDivisions.Commands.Update;
using Application.Features.Setups.OfficeDivisions.Queries;
using Application.Features.Setups.OfficeDivisions.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeDivisionsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<OfficeDivisionGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new OfficeDivisionGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] OfficeDivisionCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OfficeDivisionUpdateCommand model)
        {
            if (id != model.OfficeDivisionID)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await Mediator.Send(new OfficeDivisionDeleteCommand { OfficeDivisionID = id });
            return Ok(result);
        }
    }
}
