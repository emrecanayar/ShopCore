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

namespace Application.Features.CatalogRuleChannels.Queries.GetById;

public class GetByIdCatalogRuleChannelQuery : IRequest<CustomResponseDto<GetByIdCatalogRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCatalogRuleChannelQueryHandler : IRequestHandler<GetByIdCatalogRuleChannelQuery, CustomResponseDto<GetByIdCatalogRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
        private readonly CatalogRuleChannelBusinessRules _catalogRuleChannelBusinessRules;

        public GetByIdCatalogRuleChannelQueryHandler(IMapper mapper, ICatalogRuleChannelRepository catalogRuleChannelRepository, CatalogRuleChannelBusinessRules catalogRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleChannelRepository = catalogRuleChannelRepository;
            _catalogRuleChannelBusinessRules = catalogRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCatalogRuleChannelResponse>> Handle(GetByIdCatalogRuleChannelQuery request, CancellationToken cancellationToken)
        {
            CatalogRuleChannel? catalogRuleChannel = await _catalogRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleChannelBusinessRules.CatalogRuleChannelShouldExistWhenSelected(catalogRuleChannel);

            GetByIdCatalogRuleChannelResponse response = _mapper.Map<GetByIdCatalogRuleChannelResponse>(catalogRuleChannel);

          return CustomResponseDto<GetByIdCatalogRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}