public class Promotion
{
    public double DiscountedPrice { get; set; }

    public enum PromotionType
    {
        DiscountAmount, // Direct discount off the total
        BuyXGetYFree, // Buy a certain amount and get some free
        SpecialPrice // Special price for a certain quantity
    }

    public PromotionType Type { get; set; }
    public int RequiredQuantity { get; set; }
    public double DiscountAmount { get; set; }
    public double SpecialPrice { get; set; }
}
