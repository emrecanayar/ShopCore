using Application.Features.CartRuleChannels.Constants;
using Application.Features.CartRuleChannels.Constants;
using Application.Features.CartRuleChannels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleChannels.Constants.CartRuleChannelsOperationClaims;

namespace Application.Features.CartRuleChannels.Commands.Delete;

public class DeleteCartRuleChannelCommand : IRequest<CustomResponseDto<DeletedCartRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleChannelsOperationClaims.Delete };

    public class DeleteCartRuleChannelCommandHandler : IRequestHandler<DeleteCartRuleChannelCommand, CustomResponseDto<DeletedCartRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
        private readonly CartRuleChannelBusinessRules _cartRuleChannelBusinessRules;

        public DeleteCartRuleChannelCommandHandler(IMapper mapper, ICartRuleChannelRepository cartRuleChannelRepository,
                                         CartRuleChannelBusinessRules cartRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _cartRuleChannelRepository = cartRuleChannelRepository;
            _cartRuleChannelBusinessRules = cartRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleChannelResponse>> Handle(DeleteCartRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CartRuleChannel? cartRuleChannel = await _cartRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleChannelBusinessRules.CartRuleChannelShouldExistWhenSelected(cartRuleChannel);

            await _cartRuleChannelRepository.DeleteAsync(cartRuleChannel!);

            DeletedCartRuleChannelResponse response = _mapper.Map<DeletedCartRuleChannelResponse>(cartRuleChannel);

             return CustomResponseDto<DeletedCartRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}