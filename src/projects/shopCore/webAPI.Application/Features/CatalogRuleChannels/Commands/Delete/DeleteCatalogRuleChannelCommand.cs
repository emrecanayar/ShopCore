using Application.Features.CatalogRuleChannels.Constants;
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

namespace Application.Features.CatalogRuleChannels.Commands.Delete;

public class DeleteCatalogRuleChannelCommand : IRequest<CustomResponseDto<DeletedCatalogRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleChannelsOperationClaims.Delete };

    public class DeleteCatalogRuleChannelCommandHandler : IRequestHandler<DeleteCatalogRuleChannelCommand, CustomResponseDto<DeletedCatalogRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
        private readonly CatalogRuleChannelBusinessRules _catalogRuleChannelBusinessRules;

        public DeleteCatalogRuleChannelCommandHandler(IMapper mapper, ICatalogRuleChannelRepository catalogRuleChannelRepository,
                                         CatalogRuleChannelBusinessRules catalogRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleChannelRepository = catalogRuleChannelRepository;
            _catalogRuleChannelBusinessRules = catalogRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCatalogRuleChannelResponse>> Handle(DeleteCatalogRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleChannel? catalogRuleChannel = await _catalogRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleChannelBusinessRules.CatalogRuleChannelShouldExistWhenSelected(catalogRuleChannel);

            await _catalogRuleChannelRepository.DeleteAsync(catalogRuleChannel!);

            DeletedCatalogRuleChannelResponse response = _mapper.Map<DeletedCatalogRuleChannelResponse>(catalogRuleChannel);

             return CustomResponseDto<DeletedCatalogRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}