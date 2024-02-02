public class Promotion
{
    public double DiscountedPrice { get; set; }

    public enum PromotionType
    {
        DiscountAmount,
        BuyXGetYFree, 
        SpecialPrice 
    }

    public PromotionType Type { get; set; }
    public int RequiredQuantity { get; set; }
    public double DiscountAmount { get; set; }
    public double SpecialPrice { get; set; }
}
