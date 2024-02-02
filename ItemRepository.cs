public class ItemRepository : IItemRepository
{
    private readonly Dictionary<char, Item> items = new()
    {
        { 'A', new Item { Code = 'A',
            Name ="Milk", Group = "Dairy", Price = 2.99, Brand = "Fresh Farms" } },
        { 'B', new Item { Code = 'B',
            Name = "Ajax", Group = "Household", Price = 1.99, IsMultipack = true, MultipackQuantity = 3,
            Promotion = new Promotion { RequiredQuantity = 3, DiscountAmount = 1.00,
            Type = Promotion.PromotionType.DiscountAmount }, Brand = "CleanCo" } },
        { 'C', new Item { Code = 'C',
            Name = "Banana", Group = "Food Items", Price = 0.49, Promotion = new
            Promotion { RequiredQuantity = 5, DiscountAmount = 0.50,
            Type = Promotion.PromotionType.BuyXGetYFree }, Brand = "Tropical Delight" } },
        { 'D', new Item { Code = 'D',
            Name = "Bread", Group = "Bakery", Price = 1.99, IsMultipack = true,
            MultipackQuantity = 2, Brand = "Baker's Choice" } },
        { 'E', new Item { Code = 'E',
            Name = "Cheese", Group = "Dairy", Price = 3.99, Promotion = new
            Promotion { RequiredQuantity = 2, DiscountAmount = 1.00,
            Type = Promotion.PromotionType.DiscountAmount }, Brand = "Cheesy Delights" } },
        { 'F', new Item { Code = 'F',
            Name = "Apple", Group = "Fruits", Price = 0.79, Promotion = new
            Promotion { RequiredQuantity = 4, DiscountAmount = 0.50,
            Type = Promotion.PromotionType.BuyXGetYFree }, Brand = "Fruit Paradise" } },
        { 'G', new Item { Code = 'G',
            Name = "Chicken", Group = "Meat", Price = 5.99, Brand = "Farm Fresh" } },
        { 'H', new Item { Code = 'H',
            Name = "Shampoo", Group = "Personal Care", Price = 4.99, Brand = "Silky Smooth" } },
        { 'I', new Item { Code = 'I',
            Name = "Yogurt", Group = "Dairy", Price = 1.49, Brand = "Yummy Yogurt" } },
        { 'J', new Item { Code = 'J',
            Name = "Cereal", Group = "Breakfast", Price = 2.49, Brand = "Morning Crunch" } },
        { 'K', new Item { Code = 'K',
            Name = "Toothpaste", Group = "Personal Care", Price = 2.99, Brand = "Fresh Breath" } },
        { 'L', new Item { Code = 'L',
            Name = "Orange Juice", Group = "Beverages", Price = 3.49, Brand = "Citrus Delight" } },
        { 'M', new Item { Code = 'M',
            Name = "Pasta", Group = "Pantry", Price = 1.29, Brand = "Italiano" } },
        { 'N', new Item { Code = 'N',
            Name = "Ice Cream", Group = "Frozen Foods", Price = 4.99, Promotion = new
            Promotion { RequiredQuantity = 2, DiscountAmount = 2.00,
            Type = Promotion.PromotionType.DiscountAmount }, Brand = "Sweet Treats" } },
        { 'O', new Item { Code = 'O',
            Name = "Soda", Group = "Beverages", Price = 2.49, Brand = "Fresh It Up!" } },
        { 'P', new Item { Code = 'P',
            Name = "Deposit", Group = "Tax", Price = 0.25, Brand = "Federal Reserve" } },
        { 'Q', new Item { Code = 'Q',
            Name = "Chips", Group = "Snacks", Price = 1.99, Brand = "Crunchy Munch" } },
        { 'R', new Item { Code = 'R',
            Name = "Tomato Sauce", Group = "Pantry", Price = 1.49, Brand = "Saucy Delights" } },
        { 'S', new Item { Code = 'S',
            Name = "Paper Towels", Group = "Household", Price = 3.99, Brand = "Absorbent Plus" } },
        { 'T', new Item { Code = 'T',
            Name = "Coffee", Group = "Beverages", Price = 4.99, Brand = "Morning Brew" } },
        { 'U', new Item { Code = 'U',
            Name = "Toilet Paper", Group = "Household", Price = 5.99, Brand = "Soft & Strong" } },
        { 'V', new Item { Code = 'V',
            Name = "Peanut Butter", Group = "Pantry", Price = 2.99, Brand = "Nutty Delights" } },
        { 'W', new Item { Code = 'W',
            Name = "Dish Soap", Group = "Household", Price = 2.49, Brand = "Sparkle Clean" } },
        { 'X', new Item { Code = 'X',
            Name = "Cookies", Group = "Snacks", Price = 1.49, Brand = "Sweet Cravings" } },
        { 'Y', new Item { Code = 'Y',
            Name = "Candy", Group = "Snacks", Price = 0.99, Brand = "Sugar Rush" } },
        { 'Z', new Item { Code = 'Z',
            Name = "Water", Group = "Beverages", Price = 0.79, Brand = "Pure Aqua" } },
    };

    public Item GetItem(char code)
    {
        items.TryGetValue(code, out var item);
        return item;
    }

    public IEnumerable<Item> GetAllItems()
    {
        return items.Values;
    }
}
