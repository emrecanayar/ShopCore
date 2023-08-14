using Core.Application.Responses;

namespace Application.Features.CartRules.Queries.GetById;

public class GetByIdCartRuleResponse : IResponse
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool Status { get; set; }
    public int CouponType { get; set; }
    public bool UseAutoGeneration { get; set; }
    public int UsagePerCustomer { get; set; }
    public int UsesPerCoupon { get; set; }
    public uint TimesUsed { get; set; }
    public bool? ConditionType { get; set; }
    public string? Conditions { get; set; }
    public bool EndOtherRules { get; set; }
    public bool UsesAttributeConditions { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public int DiscountQuantity { get; set; }
    public string DiscountStep { get; set; }
    public bool ApplyToShipping { get; set; }
    public bool FreeShipping { get; set; }
    public uint SortOrder { get; set; }
}