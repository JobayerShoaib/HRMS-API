using Application.Common.Models;
using Application.Features.Identities.AuditSecrets.Commands;
using Application.Repositories.Identity;
using Application.Services.Identity;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImpServices.Identity
{
    public class AuditSecretsService : IAuditSecretsService
    {
        private readonly IAuditSecretsRepository _auditSecretsRepository;

        public AuditSecretsService(IAuditSecretsRepository auditSecretsRepository)
        {
            _auditSecretsRepository = auditSecretsRepository;
        }
        public async Task<Result> Create(AuditSecretsCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            AuditSecrets entity = new()
            {
                UserName = model.UserName,
                UserID = model.UserID,
                Secret = model.Secret,
               
            };
            await _auditSecretsRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }
    }
}
