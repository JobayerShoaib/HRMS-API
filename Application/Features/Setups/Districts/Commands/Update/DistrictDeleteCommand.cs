using Application.Services.Setup;

namespace Application.Features.Setups.Districts.Commands.Update
{
    public class DistrictDeleteCommand : IRequest<Result>
    {
        public int DistrictID { get; set; }
    }
    public class DistrictDeleteCommandHandler : IRequestHandler<DistrictDeleteCommand, Result>
    {
        private readonly IDistrictService _districtService;

        public DistrictDeleteCommandHandler(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        public async Task<Result> Handle(DistrictDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _districtService.Delete(request.DistrictID,true,cancellationToken);
        }
    }
}
