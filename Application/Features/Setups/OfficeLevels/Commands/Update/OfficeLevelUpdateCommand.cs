using Application.Services.Setup;

namespace Application.Features.Setups.OfficeLevels.Commands.Update
{
    public class OfficeLevelUpdateCommand : IRequest<Result>
    {
        public int OfficeLevelID { get; set; }
        public string OfficeLevelName { get; set; }
        public int LevelOrderNo { get; set; }
        public int CompanyID { get; set; }
        public bool IsEditable { get; set; }
    }
    public class OfficeLevelUpdateCommandHandler : IRequestHandler<OfficeLevelUpdateCommand, Result>
    {
        private readonly IOfficeLevelService _officeLevelService;

        public OfficeLevelUpdateCommandHandler(IOfficeLevelService officeLevelService)
        {
            _officeLevelService = officeLevelService;
        }
        public async Task<Result> Handle(OfficeLevelUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _officeLevelService.Update(request, true, cancellationToken);
        }
    }
}
