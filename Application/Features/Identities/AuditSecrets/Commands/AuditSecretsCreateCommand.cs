using Application.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identities.AuditSecrets.Commands
{
    public class AuditSecretsCreateCommand:IRequest<Result>
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string Secret { get; set; }
    }
    public class AuditSecretsDeleteCommandHandler : IRequestHandler<AuditSecretsCreateCommand, Result>
    {
        private readonly IAuditSecretsService _auditSecretsService;

        public AuditSecretsDeleteCommandHandler(IAuditSecretsService auditSecretsService)
        {
            _auditSecretsService = auditSecretsService;
        }
        public async Task<Result> Handle(AuditSecretsCreateCommand request, CancellationToken cancellationToken)
        {
            return await _auditSecretsService.Create(request, true, cancellationToken);
        }
    }
}
