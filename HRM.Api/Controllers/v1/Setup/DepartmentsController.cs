using Application.Features.Setups.Departments.Commands.Create;
using Application.Features.Setups.Departments.Commands.Update;
using Application.Features.Setups.Departments.Queries;
using Application.Features.Setups.Departments.Queries.QRM;

namespace HRM.Api.Controllers.v1.Setup
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<DepartmentGetDataListRM>>> GetDataList()
        {
            var result = await Mediator.Send(new DepartmentGetDataListQuery { });
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] DepartmentCreateCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DepartmentUpdateCommand model)
        {
            if (id != model.DepartmentID)
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

            var result = await Mediator.Send(new DepartmentDeleteCommand { DepartmentID = id });
            return Ok(result);
        }
    }
}
