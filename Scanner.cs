public class Scanner
{
    public delegate void ItemScannedEventHandler(Item item);
public event ItemScannedEventHandler? ItemScanned;

    public void ScanItem(Item item)
    {
        Console.WriteLine($"Scanning item {item.Code}...");
        System.Threading.Thread.Sleep(500); // 500 ms delay
        ItemScanned?.Invoke(item);
    }
}