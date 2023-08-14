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

namespace Application.Features.CatalogRuleChannels.Commands.Update;

public class UpdateCatalogRuleChannelCommand : IRequest<CustomResponseDto<UpdatedCatalogRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleChannelsOperationClaims.Update };

    public class UpdateCatalogRuleChannelCommandHandler : IRequestHandler<UpdateCatalogRuleChannelCommand, CustomResponseDto<UpdatedCatalogRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
        private readonly CatalogRuleChannelBusinessRules _catalogRuleChannelBusinessRules;

        public UpdateCatalogRuleChannelCommandHandler(IMapper mapper, ICatalogRuleChannelRepository catalogRuleChannelRepository,
                                         CatalogRuleChannelBusinessRules catalogRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleChannelRepository = catalogRuleChannelRepository;
            _catalogRuleChannelBusinessRules = catalogRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCatalogRuleChannelResponse>> Handle(UpdateCatalogRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleChannel? catalogRuleChannel = await _catalogRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleChannelBusinessRules.CatalogRuleChannelShouldExistWhenSelected(catalogRuleChannel);
            catalogRuleChannel = _mapper.Map(request, catalogRuleChannel);

            await _catalogRuleChannelRepository.UpdateAsync(catalogRuleChannel!);

            UpdatedCatalogRuleChannelResponse response = _mapper.Map<UpdatedCatalogRuleChannelResponse>(catalogRuleChannel);

          return CustomResponseDto<UpdatedCatalogRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}