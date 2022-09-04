using Application.Services.Setup;

namespace Application.Features.Setups.OfficeDivisions.Commands.Update
{
    public class OfficeDivisionDeleteCommand : IRequest<Result>
    {
        public int OfficeDivisionID { get; set; }
    }
    public class OfficeDivisionDeleteCommandHandler : IRequestHandler<OfficeDivisionDeleteCommand, Result>
    {
        private readonly IOfficeDivisionService _officeDivisionService;

        public OfficeDivisionDeleteCommandHandler(IOfficeDivisionService officeDivisionService)
        {
            _officeDivisionService = officeDivisionService;
        }
        public async Task<Result> Handle(OfficeDivisionDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _officeDivisionService.Delete(request.OfficeDivisionID,true,cancellationToken);
        }
    }
}
