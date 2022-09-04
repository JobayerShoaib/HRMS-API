using Application.Features.Setups.OfficeLevels.Commands.Create;
using Application.Features.Setups.OfficeLevels.Commands.Update;
using Application.Features.Setups.OfficeLevels.Queries;
using Application.Features.Setups.OfficeLevels.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeLevelsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<OfficeLevelGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new OfficeLevelGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] OfficeLevelCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OfficeLevelUpdateCommand model)
        {
            if (id != model.OfficeLevelID)
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

            var result = await Mediator.Send(new OfficeLevelDeleteCommand { OfficeLevelID = id });
            return Ok(result);
        }
    }
}
