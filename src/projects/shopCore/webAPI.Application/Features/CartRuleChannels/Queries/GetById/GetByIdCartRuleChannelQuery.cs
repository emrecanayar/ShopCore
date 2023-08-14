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

namespace Application.Features.CartRuleChannels.Queries.GetById;

public class GetByIdCartRuleChannelQuery : IRequest<CustomResponseDto<GetByIdCartRuleChannelResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleChannelQueryHandler : IRequestHandler<GetByIdCartRuleChannelQuery, CustomResponseDto<GetByIdCartRuleChannelResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
        private readonly CartRuleChannelBusinessRules _cartRuleChannelBusinessRules;

        public GetByIdCartRuleChannelQueryHandler(IMapper mapper, ICartRuleChannelRepository cartRuleChannelRepository, CartRuleChannelBusinessRules cartRuleChannelBusinessRules)
        {
            _mapper = mapper;
            _cartRuleChannelRepository = cartRuleChannelRepository;
            _cartRuleChannelBusinessRules = cartRuleChannelBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleChannelResponse>> Handle(GetByIdCartRuleChannelQuery request, CancellationToken cancellationToken)
        {
            CartRuleChannel? cartRuleChannel = await _cartRuleChannelRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleChannelBusinessRules.CartRuleChannelShouldExistWhenSelected(cartRuleChannel);

            GetByIdCartRuleChannelResponse response = _mapper.Map<GetByIdCartRuleChannelResponse>(cartRuleChannel);

          return CustomResponseDto<GetByIdCartRuleChannelResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}