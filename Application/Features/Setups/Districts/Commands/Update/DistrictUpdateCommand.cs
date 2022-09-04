using Application.Services.Setup;

namespace Application.Features.Setups.Districts.Commands.Update
{
    public class DistrictUpdateCommand : IRequest<Result>
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameUC { get; set; }
        public int DivisionID { get; set; }
    }
    public class DistrictUpdateCommandHandler : IRequestHandler<DistrictUpdateCommand, Result>
    {
        private readonly IDistrictService _districtService;

        public DistrictUpdateCommandHandler(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        public async Task<Result> Handle(DistrictUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _districtService.Update(request, true, cancellationToken);
        }
    }
}
