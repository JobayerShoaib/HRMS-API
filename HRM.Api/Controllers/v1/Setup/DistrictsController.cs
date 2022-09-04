using Application.Features.Setups.Districts.Commands.Create;
using Application.Features.Setups.Districts.Commands.Update;
using Application.Features.Setups.Districts.Queries;
using Application.Features.Setups.Districts.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<DistrictGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new DistrictGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] DistrictCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DistrictUpdateCommand model)
        {
            if (id != model.DistrictID)
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

            var result = await Mediator.Send(new DistrictDeleteCommand { DistrictID = id });
            return Ok(result);
        }
    }
}
