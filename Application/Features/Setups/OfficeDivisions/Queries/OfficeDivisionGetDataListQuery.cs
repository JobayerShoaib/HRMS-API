using Application.Features.Setups.OfficeDivisions.Queries.QRM;
using Application.Services.Setup;

namespace Application.Features.Setups.OfficeDivisions.Queries
{
    public class OfficeDivisionGetDataListQuery : IRequest<IList<OfficeDivisionGetDataListRM>>
    {
    }
    public class OfficeDivisionGetDataListQueryHandler : IRequestHandler<OfficeDivisionGetDataListQuery, IList<OfficeDivisionGetDataListRM>>
    {
        private readonly IOfficeDivisionService _officeDivisionService;

        public OfficeDivisionGetDataListQueryHandler(IOfficeDivisionService officeDivisionService)
        {
            _officeDivisionService = officeDivisionService;
        }
        public async Task<IList<OfficeDivisionGetDataListRM>> Handle(OfficeDivisionGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _officeDivisionService.GetDataList(cancellationToken);
        }
    }
}
