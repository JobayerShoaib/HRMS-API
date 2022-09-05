using Application.Features.Setups.Countries.Commands.Update;
using Application.Features.Setups.Divisions.Commands.Create;
using Application.Features.Setups.Divisions.Commands.Update;
using Application.Features.Setups.Divisions.Queries;
using Application.Features.Setups.Divisions.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : BaseApiController
    {
        [HttpGet]
        [Route("{countryId}")]
        public async Task<ActionResult<IList<DivisionGetDataListRM>>> GetDataList([FromRoute] int countryId)
        {
            var result = await Mediator.Send(new DivisionGetDataListQuery {CountryID=countryId });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] DivisionCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DivisionUpdateCommand model)
        {
            if (id != model.CountryID)
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

            var result = await Mediator.Send(new CountryDeleteCommand { CountryID = id });
            return Ok(result);
        }
    }
}