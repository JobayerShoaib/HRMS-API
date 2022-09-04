using Application.Features.Setups.OfficeLevels.Queries.QRM;
using Application.Services.Setup;

namespace Application.Features.Setups.OfficeLevels.Queries
{
    public class OfficeLevelGetDataListQuery : IRequest<IList<OfficeLevelGetDataListRM>>
    {
    }
    public class OfficeLevelGetDataListQueryHandler : IRequestHandler<OfficeLevelGetDataListQuery, IList<OfficeLevelGetDataListRM>>
    {
        private readonly IOfficeLevelService _officeLevelService;

        public OfficeLevelGetDataListQueryHandler(IOfficeLevelService officeLevelService)
        {
            _officeLevelService = officeLevelService;
        }
        public async Task<IList<OfficeLevelGetDataListRM>> Handle(OfficeLevelGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _officeLevelService.GetDataList(cancellationToken);
        }
    }
}
