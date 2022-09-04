using Application.Services.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identities.Accounts.Queries
{
    public class SignInQuery:IRequest<Result>
    {
        [Required]
        public string UserName { get; set; }      
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class SignInQueryHandler : IRequestHandler<SignInQuery, Result>
    {
        private readonly IAccountService _accountService;

        public SignInQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Result> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.SignIn(request, cancellationToken);
        }
    }
}
