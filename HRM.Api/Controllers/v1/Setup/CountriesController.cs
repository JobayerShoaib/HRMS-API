using Application.Features.Setups.Countries.Commands.Create;
using Application.Features.Setups.Countries.Commands.Update;
using Application.Features.Setups.Countries.Queries;
using Application.Features.Setups.Countries.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<CountryGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new CountryGetDataListQuery { });
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            if (id ==0)
                return BadRequest();

            var result = await Mediator.Send(new CountryGetDataByIDQuery { CountryID=id});
            return Ok(result);
        }
        [HttpGet]
        [Route("ddl")]
        public async Task<IActionResult> DDLCountries()
        {
            var result = await Mediator.Send(new CountryGetDDLQuery {});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] CountryCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CountryUpdateCommand model)
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
