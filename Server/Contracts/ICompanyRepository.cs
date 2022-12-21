
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.CompanyOwnership;
using MoeSystem.Shared.Models.Logs;

namespace MoeSystem.Server.Contracts
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<CompanyDetailDto> GetCompanyDetail(int? id);
        Task<PagedResult<CompanyLicenceDto>> GetExpiredCompany(SearchCompanyDto queryParameters);
        Task<PagedResult<CompanyLicenceDto>> GetExpiringCompany(SearchCompanyDto queryParameters);
        Task<PagedResult<CompanyDto>> GetPagedResult(SearchCompanyDto queryParameters);
        Task<List<BaseLogsDto>> GetLogs(int? companyId);
        Task<List<CompanyDocumentDto>> GetCompanyDocuments(int? companyId);
        Task<List<CompanyOwnershipDto>> GetCompanyOwnerships(int? companyId);
        Task<List<CompanyLicenceDto>> GetCompanyLicences(int? companyId);
    }
}
