namespace Application.Features.Setups.Sections.Commands.Update
{
    public class SectionUpdateCommand : IRequest<Result>
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string SectionNameUC { get; set; }
        public string SectionCode { get; set; }
        public string SectionCodeUC { get; set; }

    }
    public class SectionUpdateCommandHandler : IRequestHandler<SectionUpdateCommand, Result>
    {
        public SectionUpdateCommandHandler()
        {

        }
        public Task<Result> Handle(SectionUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
