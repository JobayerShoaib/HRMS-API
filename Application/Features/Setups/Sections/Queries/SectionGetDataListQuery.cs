using Application.Features.Setups.Sections.Queries.QRM;

namespace Application.Features.Setups.Sections.Queries
{
    public class SectionGetDataListQuery : IRequest<IList<SectionGetDataListRM>>
    {
    }
    public class SectionGetDataListQueryHandler : IRequestHandler<SectionGetDataListQuery, IList<SectionGetDataListRM>>
    {
        public SectionGetDataListQueryHandler()
        {

        }
        public Task<IList<SectionGetDataListRM>> Handle(SectionGetDataListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
