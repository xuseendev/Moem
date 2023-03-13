using AutoMapper;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.Areas;
using MoeSystem.Shared.Models.City;
using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.CompanyOwnership;
using MoeSystem.Shared.Models.CompanyTypes;
using MoeSystem.Shared.Models.DocumentType;
using MoeSystem.Shared.Models.Licence;
using MoeSystem.Shared.Models.LicenceComment;
using MoeSystem.Shared.Models.LicenceStatus;
using MoeSystem.Shared.Models.LicenceTypes;
using MoeSystem.Shared.Models.LicenceWorkflow;
using MoeSystem.Shared.Models.MineralTypes;
using MoeSystem.Shared.Models.Region;
using MoeSystem.Shared.Models.User;
using MoeSystem.Shared.Models.UserGroup;
using MoeSystem.Shared.Models.Workflow;
using MoeSystem.Shared.Models.LicenceCordinate;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Messages;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.LicenceDocument;
using MoeSystem.Shared.Models.Logs;
using MoeSystem.Shared.Models.Signature;
using MoeSystem.Shared.Models.LicenceTypeTemplate;
using Microsoft.AspNetCore.Identity;


namespace MoeSystem.Server.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, CreateRegionDto>().ReverseMap();
            CreateMap<Region, UpdateRegionDto>().ReverseMap();
            CreateMap<Region, BaseLookUpDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, BaseLookUpDto>().ReverseMap();

            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, CreateAreaDto>().ReverseMap();
            CreateMap<Area, UpdateAreaDto>().ReverseMap();
            CreateMap<Area, BaseLookUpDto>().ReverseMap();

            CreateMap<UserGroup, UserGroupDto>().ReverseMap();
            CreateMap<UserGroup, CreateUserGroupDto>().ReverseMap();
            CreateMap<UserGroup, UpdateUserGroupDto>().ReverseMap();
            CreateMap<UserGroup, BaseLookUpDto>().ReverseMap();

            CreateMap<Messages, MessageDto>().ReverseMap();
            CreateMap<Messages, CreateMessageDto>().ReverseMap();
            CreateMap<Messages, UpdateMessageDto>().ReverseMap();
            CreateMap<Messages, UpdateMessageDto>().ReverseMap();

            CreateMap<CompanyType, CompanyTypeDto>().ReverseMap();
            CreateMap<CompanyType, CreateCompanyTypeDto>().ReverseMap();
            CreateMap<CompanyType, UpdateCompanyTypeDto>().ReverseMap();
            CreateMap<CompanyType, BaseLookUpDto>().ReverseMap();

            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, CreateDocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, UpdateDocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, BaseLookUpDto>().ReverseMap();

            CreateMap<Signature, SignatureDto>().ReverseMap();
            CreateMap<Signature, CreateUpdateSignatureDto>().ReverseMap();
            CreateMap<Signature, BaseLookUpDto>().ReverseMap();
            CreateMap<Signature, SignatureDetailDto>().ReverseMap();

            CreateMap<LicenceTypeTemplate, LicenceTypeTemplateDto>().ReverseMap();
            CreateMap<LicenceTypeTemplate, CreateUpdateLicenceTypeTemplateDto>().ReverseMap();
            CreateMap<LicenceTypeTemplate, BaseLookUpDto>().ReverseMap();
            CreateMap<LicenceTypeTemplate, BaseLookUpDto>().ReverseMap();

            CreateMap<CompanyDocument, CompanyDocumentDto>()
                                .ForMember(src => src.DocumentType, dest => dest.MapFrom(x => x.DocumentType.Name))

                .ReverseMap();
            CreateMap<CompanyDocument, UpdateCompanyDocumentDto>().ReverseMap();
            CreateMap<CompanyDocument, CreateCompanyDocumentDto>().ReverseMap();
            CreateMap<CompanyDocument, BaseLookUpDto>().ReverseMap();
            CreateMap<CompanyDocument, CompanyDocumentDetailDto>().ReverseMap();


            CreateMap<LicenceDocument, LicenceDocumentDto>()
                  .ForMember(src => src.DocumentType, dest => dest.MapFrom(x => x.DocumentType.Name))
                .ReverseMap();
            CreateMap<LicenceDocument, CreateLicenceDocumentDto>().ReverseMap();
            CreateMap<LicenceDocument, UpdateLicenceDocumentDto>().ReverseMap();
            CreateMap<LicenceDocument, LicenceDocumentDetailDto>().ReverseMap();

            CreateMap<CompanyLicence, CompanyLicenceDto>()
                                .ForMember(src => src.CompanyName, dest => dest.MapFrom(x => x.Company.Name))
                                .ForMember(src => src.TellPhone, dest => dest.MapFrom(x => x.Company.TellPhone))
                .ReverseMap();
            CreateMap<CompanyLicence, CreateCompanyLicenceDto>().ReverseMap();
            CreateMap<CompanyLicence, UpdateCompanyLicenceDto>().ReverseMap();

            CreateMap<CompanyDocument, BaseLookUpDto>().ReverseMap();
            CreateMap<CompanyDocument, LicenceDocumentDetailDto>().ReverseMap();



            CreateMap<MineralType, MineralTypeDto>().ReverseMap();
            CreateMap<MineralType, CreateMineralTypeDto>().ReverseMap();
            CreateMap<MineralType, UpdateMineralTypeDto>().ReverseMap();
            CreateMap<MineralType, BaseLookUpDto>().ReverseMap();

            CreateMap<CompanyOwnership, CompanyOwnershipDto>().ReverseMap();
            CreateMap<CompanyOwnership, CreateCompanyOwnershipDto>().ReverseMap();
            CreateMap<CompanyOwnership, UpdateCompanyOwnershipDto>().ReverseMap();

            CreateMap<LicenceType, LicenceTypeDto>().ReverseMap();
            CreateMap<LicenceType, CreateLicenceTypeDto>().ReverseMap();
            CreateMap<LicenceType, UpdateLicenceTypeDto>().ReverseMap();
            CreateMap<LicenceType, BaseLookUpDto>().ReverseMap();

            CreateMap<LicenceStatus, LicenceStatusDto>().ReverseMap();
            CreateMap<LicenceStatus, CreateLicenceStatusDto>().ReverseMap();
            CreateMap<LicenceStatus, UpdateLicenceStatusDto>().ReverseMap();
            CreateMap<LicenceStatus, BaseLookUpDto>().ReverseMap();


            CreateMap<LicenceCordinates, LicenceCordinateDto>().ReverseMap();

            CreateMap<LicenceComments, LicenceCommentDto>().ReverseMap();
            CreateMap<LicenceComments, CreateLicenceCommentDto>().ReverseMap();
            CreateMap<LicenceComments, UpdateLicenceCommentDto>().ReverseMap();

            CreateMap<WorkFlow, WorkFlowDto>()
                .ForMember(src => src.LicenceStatus, dest => dest.MapFrom(x => x.LicenceStatus.Name))
                .ForMember(src => src.LicenceType, dest => dest.MapFrom(x => x.LicenceType.Name))
                .ForMember(src => src.UserGroup, dest => dest.MapFrom(x => x.UserGroup.Name))
                .ReverseMap();
            CreateMap<WorkFlow, CreateWorkFlowDto>().ReverseMap();
            CreateMap<WorkFlow, UpdateWorkFlowDto>().ReverseMap();

            CreateMap<Licence, LicenceDto>()
                .ForMember(src => src.LicenceType, dest => dest.MapFrom(x => x.LicenceType.Name))
                .ForMember(src => src.MineralType, dest => dest.MapFrom(x => x.LicenceType.Name))
                .ForMember(src => src.CompanyName, dest => dest.MapFrom(x => x.Company.Name))
                .ForMember(src => src.TellPhone, dest => dest.MapFrom(x => x.Company.TellPhone))
                .ReverseMap();
            CreateMap<Licence, LicenceDetailDto>()
                .ForMember(src => src.MineralType, dest => dest.MapFrom(x => x.MineralType.Name))
                .ForMember(src => src.Region, dest => dest.MapFrom(x => x.Region.Name))
                .ForMember(src => src.City, dest => dest.MapFrom(x => x.City.Name))
                .ForMember(src => src.Area, dest => dest.MapFrom(x => x.Area.Name))
                .ReverseMap();

            CreateMap<Licence, LicenceDetailPrintDto>()
           .ForMember(src => src.MineralType, dest => dest.MapFrom(x => x.MineralType.Name))
           .ForMember(src => src.Region, dest => dest.MapFrom(x => x.Region.Name))
           .ForMember(src => src.RegionCode, dest => dest.MapFrom(x => x.Region.Code))
           .ForMember(src => src.City, dest => dest.MapFrom(x => x.City.Name))
           .ForMember(src => src.Area, dest => dest.MapFrom(x => x.Area.Name))
           .ReverseMap();

            CreateMap<LicenceWorkFlow, GetLicenceWorkflowDto>()
                .ForMember(src => src.WorkFlowName, dest => dest.MapFrom(x => x.WorkFlow.LicenceStatus.Name))
                .ForMember(src => src.UserGroup, dest => dest.MapFrom(x => x.UserGroup.Name))
                .ReverseMap();

            CreateMap<LicenceWorkFlow, LicenceWorkFlowDetailDto>()
             .ForMember(src => src.WorkFlowName, dest => dest.MapFrom(x => x.WorkFlow.LicenceStatus.Name))
             .ForMember(src => src.UserGroup, dest => dest.MapFrom(x => x.UserGroup.Name))
             .ReverseMap();

            CreateMap<LicenceWorkFlow, LicenceWorkFlowDto>()
                .ForMember(src => src.WorkFlowName, dest => dest.MapFrom(x => x.WorkFlow.LicenceStatus.Name))
                .ForMember(src => src.UserGroup, dest => dest.MapFrom(x => x.UserGroup.Name))
                .ReverseMap();

            CreateMap<Licence, CreateLicenceDto>().ReverseMap()
            .ForMember(d => d.Company, o => o.Ignore());
            CreateMap<Licence, UpdateLicenceDto>().ReverseMap();
            //CreateMap<Licence, LicenceDetailDto>().ReverseMap();

            CreateMap<Company, CompanyDto>().
                ForMember(x => x.CompanyType, dest => dest.MapFrom(x => x.CompanyType.Name)).
                ForMember(x => x.Region, dest => dest.MapFrom(x => x.Regoin.Name)).
                ForMember(x => x.City, dest => dest.MapFrom(x => x.City.Name)).
                ReverseMap();

            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyDetailDto>()
                .ForMember(src => src.Regoin, dest => dest.MapFrom(x => x.Regoin.Name))
                .ForMember(src => src.City, dest => dest.MapFrom(x => x.City.Name))
                .ForMember(src => src.CompanyType, dest => dest.MapFrom(x => x.CompanyType.Name))
                .ReverseMap();
            CreateMap<Company, BaseLookUpDto>().ReverseMap();

            CreateMap<LicenceCordinates, LicenceCordinateDto>().ReverseMap();
            CreateMap<LicenceCordinates, CreateLicenceCordinateDto>().ReverseMap();
            CreateMap<LicenceCordinates, UpdateLicenceCordinateDto>().ReverseMap();

            CreateMap<ApiUserDto, User>().ReverseMap();
            CreateMap<Logs, BaseLogsDto>().ReverseMap();
            CreateMap<User, UserDto>()
            .ForMember(x => x.UserGroup, dest => dest.MapFrom(x => x.UserGroup.Name))
            .ReverseMap();

            CreateMap<IdentityRole, RolesDto>().ReverseMap();
        }
    }
}
