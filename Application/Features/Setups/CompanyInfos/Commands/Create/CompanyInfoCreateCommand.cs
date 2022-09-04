
using Application.Features.Setups.CompanyInfos.Commands.DTM;


namespace Application.Features.Setups.CompanyInfos.Commands.Create
{
    public class CompanyInfoCreateCommand : IRequest<Result>
    {
        public CompanyInfoCreateDTM CompanyInfo { get; set; }
    }
    public class CompanyInfoCreateCommandHandler : IRequestHandler<CompanyInfoCreateCommand, Result>
    {
        public CompanyInfoCreateCommandHandler()
        {

        }
        public Task<Result> Handle(CompanyInfoCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
