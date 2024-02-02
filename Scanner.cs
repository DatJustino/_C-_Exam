using System;
using System.Threading;
public class Scanner
{
    public delegate void ItemScannedEventHandler(Item item);
    public event ItemScannedEventHandler? ItemScanned;

    public void ScanItem(Item item)
    {
        Console.WriteLine($"Scanning item: {item.Code} - {item.Brand} : {item.Name} <3");
        Thread.Sleep(500); // 500 in millisecs
        ItemScanned?.Invoke(item);
    }
}