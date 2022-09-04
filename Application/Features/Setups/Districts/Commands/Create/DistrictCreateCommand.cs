using Application.Services.Setup;

namespace Application.Features.Setups.Districts.Commands.Create
{
    public class DistrictCreateCommand : IRequest<Result>
    {
        public string DistrictName { get; set; }
        public string DistrictNameUC { get; set; }
        public int DivisionID { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class DistrictCreateCommandHandler : IRequestHandler<DistrictCreateCommand, Result>
    {

        public DistrictCreateCommandHandler(IDistrictService districtService)
        {

        }
        public Task<Result> Handle(DistrictCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
