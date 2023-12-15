public class AdvancedPriceCalculator
{
    private List<Item> scannedItems = new List<Item>();

    public void OnItemScanned(Item item)
    {
        scannedItems.Add(item);
        DisplayItemsByGroup();
    }

  private void DisplayItemsByGroup()
    {
        var groups = scannedItems.GroupBy(item => item.Group)
                                 .OrderBy(group => group.Key);

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Key}:");
            var itemsByCode = group.GroupBy(item => item.Code)
                                   .Select(g => new { Code = g.Key, Count = g.Count(), TotalPrice = g.Sum(item => item.Price) });

            foreach (var item in itemsByCode)
            {
                Console.WriteLine($"Item {item.Code}: Count = {item.Count}, Total Price: {item.TotalPrice:C2}");
            }
        }
    }

     public void PrintReceipt()
    {
        Console.WriteLine("Receipt (Advanced Calculator):");

        var groups = scannedItems.GroupBy(item => item.Group)
                                 .OrderBy(group => group.Key);

        double grandTotal = 0;

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Key}:");

            var itemsByCode = group.GroupBy(item => item.Code)
                                   .Select(g => new { Code = g.Key, Count = g.Count(), TotalPrice = g.Sum(item => item.Price) });

            double groupTotal = 0;
            foreach (var item in itemsByCode)
            {
                Console.WriteLine($"Item {item.Code}: Count = {item.Count}, Total Price: {item.TotalPrice:C2}");
                groupTotal += item.TotalPrice;
            }

            Console.WriteLine($"Subtotal for Group {group.Key}: {groupTotal:C2}\n");
            grandTotal += groupTotal;
        }

        Console.WriteLine($"Grand Total: {grandTotal:C2}");
    }
}
