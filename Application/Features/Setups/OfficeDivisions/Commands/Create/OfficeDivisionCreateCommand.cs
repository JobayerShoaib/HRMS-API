using Application.Services.Setup;

namespace Application.Features.Setups.OfficeDivisions.Commands.Create
{
    public class OfficeDivisionCreateCommand:IRequest<Result>
    {        
        public string OfficeDivisionName { get; set; }
        public string OfficeDivisionNameUC { get; set; }
        public string OfficeDivisionCode { get; set; }
        public string OfficeDivisionCodeUC { get; set; }
        public string OfficeDivisionColor { get; set; }
        public DateTime EstablishedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class OfficeDivisionCreateCommandHandler : IRequestHandler<OfficeDivisionCreateCommand, Result>
    {
        private readonly IOfficeDivisionService _officeDivisionService;

        public OfficeDivisionCreateCommandHandler(IOfficeDivisionService officeDivisionService)
        {
            _officeDivisionService = officeDivisionService;
        }
        public async Task<Result> Handle(OfficeDivisionCreateCommand request, CancellationToken cancellationToken)
        {
            return await _officeDivisionService.Create(request, true, cancellationToken);
        }
    }
}
