public class AdvancedPriceCalculator
{
    private readonly IItemRepository itemRepository;
    private readonly List<Item> scannedItems = new List<Item>();

    public AdvancedPriceCalculator(IItemRepository itemRepository)
    {
        this.itemRepository = itemRepository;
    }

    public void OnItemScanned(Item item)
    {
        scannedItems.Add(item);
    }

    public void DisplayItemsByGroup()
    {
        var groups = scannedItems.GroupBy(item => item.Group)
                                 .OrderBy(group => group.Key)
                                 .Select(group => new
                                 {
                                     Group = group.Key,
                                     Items = group.GroupBy(item => item.Code)
                                                  .Select(g => new { Item = g.First(), Count = g.Count() })
                                                  .OrderByDescending(g => g.Count)
                                 });

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Group}:");
            foreach (var item in group.Items)
            {
                double totalItemPrice = item.Item.Price * item.Count;
                Console.WriteLine($"Product {item.Item.Code} ({item.Item.Name}): Count = {item.Count}, Total Price: {totalItemPrice:C2}");
            }
        }
    }

    public void PrintReceipt()
    {
        double grandTotal = scannedItems.Sum(item => item.Price); 

        Console.WriteLine("Receipt (Advanced Calculator):");
        Console.WriteLine($"Grand Total: {grandTotal:C2}");
    }
}
