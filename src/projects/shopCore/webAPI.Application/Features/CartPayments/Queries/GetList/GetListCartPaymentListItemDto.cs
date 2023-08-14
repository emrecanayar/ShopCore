using Core.Application.Dtos;

namespace Application.Features.CartPayments.Queries.GetList;

public class GetListCartPaymentListItemDto : IDto
{
    public uint Id { get; set; }
    public string Method { get; set; }
    public string? MethodTitle { get; set; }
    public uint? CartId { get; set; }
}