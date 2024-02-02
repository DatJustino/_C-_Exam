public class AdvancedPriceCalculator
{
    private List<Item> scannedItems = new List<Item>();
    private Dictionary<char, int> itemCounts = new Dictionary<char, int>();

    public void OnItemScanned(Item item)
    {
        scannedItems.Add(item);
        if (!itemCounts.ContainsKey(item.Code))
        {
            itemCounts[item.Code] = 0;
        }
        itemCounts[item.Code]++;
    }

    private void DisplayItemsByGroup()
    {
        var groups = scannedItems.GroupBy(item => item.Group)
                                 .OrderBy(group => group.Key);

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Key}:");
            var itemsByCode = group.GroupBy(item => item.Code)
                                   .Select(g => new { Code = g.Key, Count = g.Count(), TotalPrice = CalculateTotalPriceForGroup(g.Key) });

            foreach (var item in itemsByCode)
            {
                Console.WriteLine($"Item {item.Code}: Count = {item.Count}, Total Price: {item.TotalPrice:C2}");
            }
        }
    }
    private double CalculateTotalPriceForGroup(int groupKey)
    {
        double groupTotal = 0;
        var itemsInGroup = scannedItems.Where(item => item.Group == groupKey);
        foreach (var item in itemsInGroup)
        {
            groupTotal += CalculateItemPrice(item, itemCounts[item.Code]);
        }
        return groupTotal;
    }
    private double ApplyPromotion(Item item, int itemCount)
    {
        int setsOfPromotionItems = itemCount / item.Promotion.RequiredQuantity;
        double discountedPrice = setsOfPromotionItems * (item.Price * item.Promotion.RequiredQuantity - item.Promotion.DiscountAmount);
        int remainingItems = itemCount % item.Promotion.RequiredQuantity;

        return discountedPrice + remainingItems * item.Price;
    }
private double CalculateItemPrice(Item item, int itemCount)
{
    double price = 0;

    if (item.Promotion != null)
    {
        // Apply promotion logic
        price += ApplyPromotion(item, itemCount);
    }
    else if (item.IsMultipack)
    {
        // Calculate price for multipack items
        int sets = itemCount / item.MultipackQuantity;
        int singles = itemCount % item.MultipackQuantity;

        double multipackPrice = sets * item.Price * item.MultipackQuantity; // Price for complete sets
        double singleItemPrice = singles * item.Price; // Price for remaining single items

        price += multipackPrice + singleItemPrice;
    }
    else
    {
        // If no promotion or multipack, use standard pricing
        price += item.Price * itemCount;
    }

    return price;
}



    public void PrintReceipt()
    {
        Console.WriteLine("Receipt (Advanced Calculator):");

        double grandTotal = scannedItems.Sum(item => CalculateItemPrice(item, itemCounts[item.Code]));

        Console.WriteLine($"Grand Total: {grandTotal:C2}");
    }
}