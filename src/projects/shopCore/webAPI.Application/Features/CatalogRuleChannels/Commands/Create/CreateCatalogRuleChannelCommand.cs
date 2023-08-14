using Application.Features.CatalogRuleChannels.Constants;
using Application.Features.CatalogRuleChannels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CatalogRuleChannels.Constants.CatalogRuleChannelsOperationClaims;

namespace Application.Features.CatalogRuleChannels.Commands.Create;

public class CreateCatalogRuleChannelCommand : IRequest<CustomResponseDto<CreatedCatalogRuleChannelResponse>>, ISecuredRequest
{
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleChannelsOperationClaims.Create };

    public class CreateCatalogRuleChannelCommandHandler : IRequestHandler<CreateCatalogRuleChannelCommand, CustomResponseDto<CreatedCatalogRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
        private readonly CatalogRuleChannelBusinessRules _catalogRuleChannelBusinessRules;

        public CreateCatalogRuleChannelCommandHandler(IMapper mapper, ICatalogRuleChannelRepository catalogRuleChannelRepository,
                                         CatalogRuleChannelBusinessRules catalogRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleChannelRepository = catalogRuleChannelRepository;
            _catalogRuleChannelBusinessRules = catalogRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCatalogRuleChannelResponse>> Handle(CreateCatalogRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleChannel catalogRuleChannel = _mapper.Map<CatalogRuleChannel>(request);

            await _catalogRuleChannelRepository.AddAsync(catalogRuleChannel);

            CreatedCatalogRuleChannelResponse response = _mapper.Map<CreatedCatalogRuleChannelResponse>(catalogRuleChannel);
         return CustomResponseDto<CreatedCatalogRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}