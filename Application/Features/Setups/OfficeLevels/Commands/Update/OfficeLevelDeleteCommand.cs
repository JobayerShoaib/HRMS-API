using Application.Services.Setup;

namespace Application.Features.Setups.OfficeLevels.Commands.Update
{
    public class OfficeLevelDeleteCommand : IRequest<Result>
    {
        public int OfficeLevelID { get; set; }
    }
    public class OfficeLevelDeleteCommandHandler : IRequestHandler<OfficeLevelDeleteCommand, Result>
    {
        private readonly IOfficeLevelService _officeLevelService;

        public OfficeLevelDeleteCommandHandler(IOfficeLevelService officeLevelService)
        {
            _officeLevelService = officeLevelService;
        }
        public async Task<Result> Handle(OfficeLevelDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _officeLevelService.Delete(request.OfficeLevelID, true, cancellationToken);
        }
    }
}
