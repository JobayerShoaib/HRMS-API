using Application.Features.Identities.AuditSecrets.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Identity
{
    public interface IAuditSecretsService
    {
        Task<Result> Create(AuditSecretsCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
