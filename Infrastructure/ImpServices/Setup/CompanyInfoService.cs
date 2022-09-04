using Application.Common.Models;
using Application.Features.Setups.CompanyInfos.Commands.DTM;
using Application.Features.Setups.CompanyInfos.Commands.Update;
using Application.Features.Setups.CompanyInfos.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;
using AutoMapper;
using Domain.Entities.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;

        public CompanyInfoService(ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;
        }

        public async Task<Result> Create(CompanyInfoCreateDTM model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = _mapper.Map<CompanyInfoCreateDTM, CompanyInfo>(model);
            entity.IsActive = true;

            await _companyInfoRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _companyInfoRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _companyInfoRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<CompanyInfoGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _companyInfoRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(CompanyInfoUpdateDTM model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _companyInfoRepository.GetByIdAsync(model.CompanyID, cancellationToken);
            
            entity.CompanyName =model.CompanyName;
            entity.CompanyNameUC =model.CompanyNameUC;
            entity.CompanyShortName =model.CompanyShortName;
            entity.CompanyShortNameUC =model.CompanyShortNameUC;
            entity.EstablishedDate =model.EstablishedDate;
            entity.CompanyTypeID =model.CompanyTypeID;           
            entity.CompanyAddress =model.CompanyAddress;
            entity.CompanyAddressUC =model.CompanyAddressUC;
            entity.CountryID =model.CountryID;
            entity.DivisionID =model.DivisionID;
            entity.DistrictID =model.DistrictID;
            entity.ZipCode =model.ZipCode;
            entity.WebSite =model.WebSite;
            entity.Email =model.Email;
            entity.MobileNo =model.MobileNo;
            entity.TelephoneNo =model.TelephoneNo;
            entity.CompanyLogoUrl =model.CompanyLogoUrl;
            await _companyInfoRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
