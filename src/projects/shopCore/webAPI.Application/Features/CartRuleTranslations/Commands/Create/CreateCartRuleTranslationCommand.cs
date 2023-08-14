using Application.Features.CartRuleTranslations.Constants;
using Application.Features.CartRuleTranslations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleTranslations.Constants.CartRuleTranslationsOperationClaims;

namespace Application.Features.CartRuleTranslations.Commands.Create;

public class CreateCartRuleTranslationCommand : IRequest<CustomResponseDto<CreatedCartRuleTranslationResponse>>, ISecuredRequest
{
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint CartRuleId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleTranslationsOperationClaims.Create };

    public class CreateCartRuleTranslationCommandHandler : IRequestHandler<CreateCartRuleTranslationCommand, CustomResponseDto<CreatedCartRuleTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
        private readonly CartRuleTranslationBusinessRules _cartRuleTranslationBusinessRules;

        public CreateCartRuleTranslationCommandHandler(IMapper mapper, ICartRuleTranslationRepository cartRuleTranslationRepository,
                                         CartRuleTranslationBusinessRules cartRuleTranslationBusinessRules)
        {
            _mapper = mapper;
            _cartRuleTranslationRepository = cartRuleTranslationRepository;
            _cartRuleTranslationBusinessRules = cartRuleTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleTranslationResponse>> Handle(CreateCartRuleTranslationCommand request, CancellationToken cancellationToken)
        {
            CartRuleTranslation cartRuleTranslation = _mapper.Map<CartRuleTranslation>(request);

            await _cartRuleTranslationRepository.AddAsync(cartRuleTranslation);

            CreatedCartRuleTranslationResponse response = _mapper.Map<CreatedCartRuleTranslationResponse>(cartRuleTranslation);
         return CustomResponseDto<CreatedCartRuleTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}