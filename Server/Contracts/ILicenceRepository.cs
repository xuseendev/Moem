﻿
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.Licence;
using MoeSystem.Shared.Models.LicenceComment;
using MoeSystem.Shared.Models.LicenceCordinate;
using MoeSystem.Shared.Models.LicenceDocument;
using MoeSystem.Shared.Models.LicenceWorkflow;
using MoeSystem.Shared.Models.Logs;


namespace MoeSystem.Server.Contracts
{
    public interface ILicenceRepository : IGenericRepository<Licence>
    {
        Task<LicenceDetailDto> GetLicenceDetail(int? id);
        Task<List<LicenceOnlyDto>> GetLicenceWithIds(CancellationToken cancellationToken);
        Task<List<LicenceOnlyDto>> GetLicenceCompletedWithIds(CancellationToken cancellationToken);
        Task<List<LicenceOnlyDto>> GetLicencePendingWithIds(CancellationToken cancellationToken);
        Task<LicenceDetailPrintDto> GetLicenceDetailPrint(int? id);
        Task<LicenceDetailDto> GetLicence(int? id);
        Task<List<LicenceWorkFlowDto>> GetTaskLicences(string userGroupId);
        Task<List<LicenceWorkFlowDto>> GetToClaimLicences(int? userGroupId);
        Task<List<BaseLogsDto>> GetLogs(int? licenceId);
        Task<List<LicenceDocumentDto>> GetLicenceDocuments(int? licenceId);
        Task<List<LicenceCommentDto>> GetLicenceComments(int? licenceId);
        Task<List<LicenceCordinateDto>> GetLicenceCordinates(int? licenceId);
        Task<List<LicenceWorkFlowDto>> GetLicenceWorkflows(int? licenceId);
        Task<LicenceWorkFlowDetailDto> GetLicenceWorkFlowDetail(int? id);
        Task<LicenceWorkFlowDto> ClaimTask(int? id, string user);
        Task<LicenceWorkFlowDto> UnClaimTask(int? id);
        Task<LicenceWorkFlowDto> ApproveLicence(int? id, HttpContext context);
        Task<LicenceWorkFlowDto> RejectLicence(int? id, HttpContext context);
        Task<LicenceWorkFlowDto> ApproveRejectLicence(int? id, HttpContext context);
        Task<List<LicenceWorkFlowDto>> RejectedLicences();
        Task<List<LicenceDto>> ApprovedLicences();
        Task<List<LicenceDto>> GetLastLicences(CancellationToken cancellationToken);
        Task<List<LicenceDto>> SearchLicence(SearchLicenceDetailDto search);
        Task<CreateLicenceDto> CreateLicence(CreateLicenceDto createLicenceDto, HttpContext context);
        Task<PagedResult<LicenceDto>> GetPagedResult(SearchLicenceDto queryParameters);
        Task<PagedResult<LicenceDto>> GetExpiredLicences(SearchLicenceDto queryParameters);
        Task<PagedResult<LicenceDto>> GetExpiringLicences(SearchLicenceDto queryParameters);
        Task<PagedResult<LicenceDto>> ProgressLicences(SearchLicenceDto queryParameters);
        Task<PagedResult<LicenceDto>> FinishedLicences(SearchLicenceDto queryParameters);
        Task<List<PendingWorkflowsDto>> CalculateWorkflow();
        Task<List<TopLicenceGrouping>> TopLicences();
    }
}
