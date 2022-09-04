using Application.Common.Models;
using Application.Services.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Divisions.Commands.Update
{
    public class DivisionUpdateCommand:IRequest<Result>
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public string DivisionNameUC { get; set; }
        public int CountryID { get; set; }
    }
    public class DivisionUpdateCommandHandler : IRequestHandler<DivisionUpdateCommand, Result>
    {
        private readonly IDivisionService _divisionService;

        public DivisionUpdateCommandHandler(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }
        public async Task<Result> Handle(DivisionUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _divisionService.Update(request, true, cancellationToken);
        }
    }
}
