namespace Application.Features.Setups.Sections.Commands.Update
{
    public class SectionDeleteCommand : IRequest<Result>
    {
        public int SectionID { get; set; }
    }
    public class SectionDeleteCommandHandler : IRequestHandler<SectionDeleteCommand, Result>
    {
        public SectionDeleteCommandHandler()
        {

        }
        public Task<Result> Handle(SectionDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
