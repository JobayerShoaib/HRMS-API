using Application.Services.Setup;

namespace Application.Features.Setups.OfficeLevels.Commands.Create
{
    public class OfficeLevelCreateCommand : IRequest<Result>
    {
        public string OfficeLevelName { get; set; }
        public int LevelOrderNo { get; set; }
        public int CompanyID { get; set; }
        public bool IsEditable { get; set; }
        public bool IsActive { get; set; }
    }
    public class OfficeLevelCreateCommandHandler : IRequestHandler<OfficeLevelCreateCommand, Result>
    {
        private readonly IOfficeLevelService _officeLevelService;

        public OfficeLevelCreateCommandHandler(IOfficeLevelService officeLevelService)
        {
            _officeLevelService = officeLevelService;
        }
        public async Task<Result> Handle(OfficeLevelCreateCommand request, CancellationToken cancellationToken)
        {
            return await _officeLevelService.Create(request, true, cancellationToken);
        }
    }
}
