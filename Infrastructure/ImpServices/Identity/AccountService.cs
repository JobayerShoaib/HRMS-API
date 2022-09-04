using Application.Common.Models;
using Application.Features.Identities.Accounts.Commands.Create;
using Application.Features.Identities.Accounts.Commands.DTM;
using Application.Features.Identities.Accounts.Queries;
using Application.Features.Identities.AuditSecrets.Commands;
using Application.IdentityEntities;
using Application.Services.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImpServices.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuditSecretsService _auditSecretsService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, IAuditSecretsService auditSecretsService
            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _auditSecretsService = auditSecretsService;
            _signInManager = signInManager;
        }

        public async Task<Result> SignIn(SignInQuery model, CancellationToken cancellationToken)
        {
            Result result = new();

            var userLogin = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (userLogin.Succeeded)
            {
                return result.Success();
            }
            else
            {
                result.Succeeded = 0;
                return result;
            }
            
        }

        public async Task<Result> SignUp(SignUpCommand model)
        {
            Result result = new();
            try
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email,
                    EmployeeID = model.EmployeeID,
                    EmployeeCode = model.EmployeeCode,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                };
                var identityResult = await _userManager.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    var secretModel = new AuditSecretsCreateCommand()
                    {
                        UserID = user.Id,
                        UserName = user.UserName,
                        Secret = model.Password
                    };
                    await _auditSecretsService.Create(secretModel);
                    return result.Success();
                }
                else
                {
                    result.Succeeded = 0;
                    result.Message = "Failure";
                    return result;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
