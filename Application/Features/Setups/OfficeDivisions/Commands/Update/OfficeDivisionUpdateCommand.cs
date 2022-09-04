using Application.Services.Setup;

namespace Application.Features.Setups.OfficeDivisions.Commands.Update
{
    public class OfficeDivisionUpdateCommand:IRequest<Result>
    {
        public int OfficeDivisionID { get; set; }
        public string OfficeDivisionName { get; set; }
        public string OfficeDivisionNameUC { get; set; }
        public string OfficeDivisionCode { get; set; }
        public string OfficeDivisionCodeUC { get; set; }
        public string OfficeDivisionColor { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
    public class OfficeDivisionUpdateCommandHandler : IRequestHandler<OfficeDivisionUpdateCommand, Result>
    {
        private readonly IOfficeDivisionService _officeDivisionService;

        public OfficeDivisionUpdateCommandHandler(IOfficeDivisionService officeDivisionService)
        {
            _officeDivisionService = officeDivisionService;
        }
        public async Task<Result> Handle(OfficeDivisionUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _officeDivisionService.Update(request,true,cancellationToken);
        }
    }
}
