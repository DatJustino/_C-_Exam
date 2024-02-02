public class BasicPriceCalculator
{
    private readonly IItemRepository itemRepository;
    public double Total { get; private set; }

    public BasicPriceCalculator(IItemRepository itemRepository)
    {
        this.itemRepository = itemRepository;
    }

    public void OnItemScanned(Item item)
    {
        Total += item.Price;
        Console.WriteLine($"Product {item.Code} scanned. New total: {Total:C2}");
    }

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt (Basic Calculator):");
        Console.WriteLine($"Total: {Total:C2}");
    }
}
