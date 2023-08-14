using Application.Features.CartRuleTranslations.Constants;
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

namespace Application.Features.CartRuleTranslations.Commands.Delete;

public class DeleteCartRuleTranslationCommand : IRequest<CustomResponseDto<DeletedCartRuleTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleTranslationsOperationClaims.Delete };

    public class DeleteCartRuleTranslationCommandHandler : IRequestHandler<DeleteCartRuleTranslationCommand, CustomResponseDto<DeletedCartRuleTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
        private readonly CartRuleTranslationBusinessRules _cartRuleTranslationBusinessRules;

        public DeleteCartRuleTranslationCommandHandler(IMapper mapper, ICartRuleTranslationRepository cartRuleTranslationRepository,
                                         CartRuleTranslationBusinessRules cartRuleTranslationBusinessRules)
        {
            _mapper = mapper;
            _cartRuleTranslationRepository = cartRuleTranslationRepository;
            _cartRuleTranslationBusinessRules = cartRuleTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleTranslationResponse>> Handle(DeleteCartRuleTranslationCommand request, CancellationToken cancellationToken)
        {
            CartRuleTranslation? cartRuleTranslation = await _cartRuleTranslationRepository.GetAsync(predicate: crt => crt.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleTranslationBusinessRules.CartRuleTranslationShouldExistWhenSelected(cartRuleTranslation);

            await _cartRuleTranslationRepository.DeleteAsync(cartRuleTranslation!);

            DeletedCartRuleTranslationResponse response = _mapper.Map<DeletedCartRuleTranslationResponse>(cartRuleTranslation);

             return CustomResponseDto<DeletedCartRuleTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}