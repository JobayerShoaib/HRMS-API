using Application.Features.Identities.Accounts.Commands.DTM;
using Application.Services.Identity;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Identities.Accounts.Commands.Create
{
    public class SignUpCommand : IRequest<Result>
    {
        // public SignUpDTM SignUp { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string UserType { get; set; }
    }
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result>
    {
        private readonly IAccountService _accountService;

        public SignUpCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.SignUp(request);
        }
    }
}
