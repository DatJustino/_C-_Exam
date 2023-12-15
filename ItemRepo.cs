public static class ItemRepository
{
    public static Dictionary<char, Item> Items = new Dictionary<char, Item>
    {
        { 'A', new Item { Code = 'A', Group = 1, Price = 100.00 } },
        { 'B', new Item { Code = 'B', Group = 1, Price = 200.00, IsMultipack = true, MultipackQuantity = 3 } },
        { 'C', new Item { Code = 'C', Group = 2, Price = 150.00, Promotion = new Promotion { RequiredQuantity = 2, DiscountAmount = 50.00, Type = Promotion.PromotionType.DiscountAmount } }},
        { 'D', new Item { Code = 'D', Group = 3, Price = 120.00, IsMultipack = true, MultipackQuantity = 2 } },
        { 'E', new Item { Code = 'E', Group = 4, Price = 90.00, Promotion = new Promotion { RequiredQuantity = 3, DiscountAmount = 10.00, Type = Promotion.PromotionType.BuyXGetYFree } }},
        { 'F', new Item { Code = 'F', Group = 5, Price = 180.00, Promotion = new Promotion { RequiredQuantity = 5, DiscountedPrice = 160.00, Type = Promotion.PromotionType.SpecialPrice } }},
    };
}