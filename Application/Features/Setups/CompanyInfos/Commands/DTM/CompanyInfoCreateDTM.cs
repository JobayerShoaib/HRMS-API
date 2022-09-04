using Application.Common.Mappings;
using Domain.Entities.Setup;

namespace Application.Features.Setups.CompanyInfos.Commands.DTM
{
    public class CompanyInfoCreateDTM : IMapFrom<CompanyInfo>
    {
        public string CompanyName { get; set; }
        public string CompanyNameUC { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyShortNameUC { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyAddressUC { get; set; }
        public int CountryID { get; set; }
        public int? DivisionID { get; set; }
        public int? DistrictID { get; set; }
        public string ZipCode { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string CompanyLogoUrl { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CompanyInfoCreateDTM, CompanyInfo>();
        }
    }
}
