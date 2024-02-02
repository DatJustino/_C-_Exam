public class Promotion
{
    public double DiscountedPrice { get; set; }

    public enum PromotionType
    {
        DiscountAmount,
        BuyXGetYFree,
        SpecialPrice,
        TimeToGo,
        DiscountPercentage
    }
    public string GetDescription()
    {
        switch (Type)
        {
           case PromotionType.DiscountAmount:
                return $"Save {DiscountAmount:C2} when you buy {RequiredQuantity}.";
            case PromotionType.DiscountPercentage:
                return $"Save {DiscountPercentage}% on each, when you buy {RequiredQuantity}.";
            case PromotionType.BuyXGetYFree:
                return $"Buy {RequiredQuantity} get {(int)DiscountAmount} free.";
            case PromotionType.SpecialPrice:
                return $"{RequiredQuantity} for {DiscountAmount:C2}.";
            case PromotionType.TimeToGo:
                return $"Time to go! {TimeToGo} this item is 70% off!";
            default:
                return "Special offer available.";
        }
    }
    public PromotionType Type { get; set; }
    public int RequiredQuantity { get; set; }
    public double DiscountPercentage { get; set; }

    public double DiscountAmount { get; set; }
    public double TimeToGo { get; set; }
}
