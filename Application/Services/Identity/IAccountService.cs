using Application.Features.Identities.Accounts.Commands.Create;
using Application.Features.Identities.Accounts.Commands.DTM;
using Application.Features.Identities.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Identity
{
    public interface IAccountService
    {
        Task<Result> SignUp(SignUpCommand command);
        Task<Result> SignIn(SignInQuery request, CancellationToken cancellationToken);
    }
}
