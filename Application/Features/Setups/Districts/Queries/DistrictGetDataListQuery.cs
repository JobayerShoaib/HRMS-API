using Application.Features.Setups.Districts.Queries.QRM;
using Application.Services.Setup;

namespace Application.Features.Setups.Districts.Queries
{
    public class DistrictGetDataListQuery : IRequest<IList<DistrictGetDataListRM>>
    {
    }
    public class DistrictGetDataListQueryHandler : IRequestHandler<DistrictGetDataListQuery, IList<DistrictGetDataListRM>>
    {
        private readonly IDistrictService _districtService;

        public DistrictGetDataListQueryHandler(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        public async Task<IList<DistrictGetDataListRM>> Handle(DistrictGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _districtService.GetDataList(cancellationToken);
        }
    }
}
