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

namespace Application.Features.CartRuleChannels.Commands.Create;

public class CreateCartRuleChannelCommand : IRequest<CustomResponseDto<CreatedCartRuleChannelResponse>>, ISecuredRequest
{
    public uint CartRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleChannelsOperationClaims.Create };

    public class CreateCartRuleChannelCommandHandler : IRequestHandler<CreateCartRuleChannelCommand, CustomResponseDto<CreatedCartRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
        private readonly CartRuleChannelBusinessRules _cartRuleChannelBusinessRules;

        public CreateCartRuleChannelCommandHandler(IMapper mapper, ICartRuleChannelRepository cartRuleChannelRepository,
                                         CartRuleChannelBusinessRules cartRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _cartRuleChannelRepository = cartRuleChannelRepository;
            _cartRuleChannelBusinessRules = cartRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleChannelResponse>> Handle(CreateCartRuleChannelCommand request, CancellationToken cancellationToken)
        {
            CartRuleChannel cartRuleChannel = _mapper.Map<CartRuleChannel>(request);

            await _cartRuleChannelRepository.AddAsync(cartRuleChannel);

            CreatedCartRuleChannelResponse response = _mapper.Map<CreatedCartRuleChannelResponse>(cartRuleChannel);
         return CustomResponseDto<CreatedCartRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}