using Application.Features.Setups.CompanyInfos.Commands.Create;
using Application.Features.Setups.CompanyInfos.Commands.DTM;
using Application.Features.Setups.CompanyInfos.Commands.Update;
using Application.Features.Setups.CompanyInfos.Queries;
using Application.Features.Setups.CompanyInfos.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<CompanyInfoGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new CompanyInfoGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] CompanyInfoCreateDTM model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(new CompanyInfoCreateCommand { CompanyInfo = model });
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyInfoUpdateDTM model)
        {
            if (id != model.CompanyTypeID)
                return BadRequest();

            var result = await Mediator.Send(new CompanyInfoUpdateCommand { CompanyInfo = model });
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await Mediator.Send(new CompanyInfoDeleteCommand { CompanyID = id });
            return Ok(result);
        }
    }
}
