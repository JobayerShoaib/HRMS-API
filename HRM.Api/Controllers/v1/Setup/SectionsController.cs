using Application.Features.Setups.Sections.Commands.Create;
using Application.Features.Setups.Sections.Commands.Update;
using Application.Features.Setups.Sections.Queries;
using Application.Features.Setups.Sections.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<SectionGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new SectionGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] SectionCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SectionUpdateCommand model)
        {
            if (id != model.SectionID)
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

            var result = await Mediator.Send(new SectionDeleteCommand { SectionID = id });
            return Ok(result);
        }
    }
}
