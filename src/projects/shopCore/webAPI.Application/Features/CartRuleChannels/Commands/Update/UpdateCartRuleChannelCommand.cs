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

namespace Application.Features.CartRuleChannels.Commands.Update;

public class UpdateCartRuleChannelCommand : IRequest<CustomResponseDto<UpdatedCartRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleChannelsOperationClaims.Update };

    public class UpdateCartRuleChannelCommandHandler : IRequestHandler<UpdateCartRuleChannelCommand, CustomResponseDto<UpdatedCartRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
        private readonly CartRuleChannelBusinessRules _cartRuleChannelBusinessRules;

        public UpdateCartRuleChannelCommandHandler(IMapper mapper, ICartRuleChannelRepository cartRuleChannelRepository,
                                         CartRuleChannelBusinessRules cartRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _cartRuleChannelRepository = cartRuleChannelRepository;
            _cartRuleChannelBusinessRules = cartRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleChannelResponse>> Handle(UpdateCartRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CartRuleChannel? cartRuleChannel = await _cartRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleChannelBusinessRules.CartRuleChannelShouldExistWhenSelected(cartRuleChannel);
            cartRuleChannel = _mapper.Map(request, cartRuleChannel);

            await _cartRuleChannelRepository.UpdateAsync(cartRuleChannel!);

            UpdatedCartRuleChannelResponse response = _mapper.Map<UpdatedCartRuleChannelResponse>(cartRuleChannel);

          return CustomResponseDto<UpdatedCartRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}