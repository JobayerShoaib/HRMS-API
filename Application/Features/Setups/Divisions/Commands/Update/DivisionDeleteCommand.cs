using Application.Common.Models;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.Divisions.Commands.Update
{
    public class DivisionDeleteCommand : IRequest<Result>
    {
        public int DivisionID { get; set; }
    }
    public class DivisionDeleteCommandHandler : IRequestHandler<DivisionDeleteCommand, Result>
    {
        private readonly IDivisionService _divisionService;

        public DivisionDeleteCommandHandler(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }
        public async Task<Result> Handle(DivisionDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _divisionService.Delete(request.DivisionID, true, cancellationToken);
        }
    }
}
