using Application.Features.Setups.Divisions.Queries.QRM;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.Divisions.Queries
{
    public class DivisionGetDataListQuery : IRequest<IList<DivisionGetDataListRM>>
    {
    }
    public class DivisionGetDataListQueryHandler : IRequestHandler<DivisionGetDataListQuery, IList<DivisionGetDataListRM>>
    {
        private readonly IDivisionService _divisionService;

        public DivisionGetDataListQueryHandler(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }
        public async Task<IList<DivisionGetDataListRM>> Handle(DivisionGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _divisionService.GetDataList(cancellationToken);
        }
    }
}
