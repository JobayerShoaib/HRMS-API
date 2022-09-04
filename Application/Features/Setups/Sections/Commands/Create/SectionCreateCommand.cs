namespace Application.Features.Setups.Sections.Commands.Create
{
    public class SectionCreateCommand:IRequest<Result>
    {        
        public string SectionName { get; set; }
        public string SectionNameUC { get; set; }
        public string SectionCode { get; set; }
        public string SectionCodeUC { get; set; }
        public bool IsActive { get; set; }
    }
    public class SectionCreateCommandHandler : IRequestHandler<SectionCreateCommand, Result>
    {
        public SectionCreateCommandHandler()
        {

        }
        public Task<Result> Handle(SectionCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
