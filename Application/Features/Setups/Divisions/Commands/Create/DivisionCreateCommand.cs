using Application.Services.Setup;

namespace Application.Features.Setups.Divisions.Commands.Create
{
    public class DivisionCreateCommand : IRequest<Result>
    {
        public string DivisionName { get; set; }
        public string DivisionNameUC { get; set; }
        public int CountryID { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class DivisionCreateCommandHandler : IRequestHandler<DivisionCreateCommand, Result>
    {
        private readonly IDivisionService _divisionService;

        public DivisionCreateCommandHandler(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }
        public async Task<Result> Handle(DivisionCreateCommand request, CancellationToken cancellationToken)
        {
            return await _divisionService.Create(request, true, cancellationToken);
        }
    }
}
