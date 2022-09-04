using Application.Features.Identities.Accounts.Commands.Create;
using Application.Features.Identities.Accounts.Commands.DTM;
using Application.Features.Identities.Accounts.Queries;
using Application.IdentityEntities;
using Application.Services.Identity;
using Microsoft.AspNetCore.Identity;

namespace HRM.Api.Controllers.v1.Identity
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;

        public AccountController(SignInManager<ApplicationUser> signInManager
            , UserManager<ApplicationUser> userManager
            , IAccountService accountService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountService = accountService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(model);
            return Ok(result);
        }

    }
}
