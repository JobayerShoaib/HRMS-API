using Application.Features.Setups.CompanyTypes.Commands.Create;
using Application.Features.Setups.CompanyTypes.Commands.Update;
using Application.Features.Setups.CompanyTypes.Queries;
using Application.Features.Setups.CompanyTypes.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<CompanyTypeGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new CompanyTypeGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] CompanyTypeCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyTypeUpdateCommand model)
        {
            if (id != model.CompanyTypeID)
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

            var result = await Mediator.Send(new CompanyTypeDeleteCommand { CompanyTypeID = id });
            return Ok(result);
        }
    }
}
