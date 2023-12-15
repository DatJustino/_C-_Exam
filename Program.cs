class Program
{
    static void Main(string[] args)
    {
        var scanner = new Scanner();
        var basicCalculator = new BasicPriceCalculator();
        var advancedCalculator = new AdvancedPriceCalculator();

        scanner.ItemScanned += basicCalculator.OnItemScanned;
        scanner.ItemScanned += advancedCalculator.OnItemScanned;

        Console.WriteLine("Welcome to the Supermarket Checkout System.");
        Console.WriteLine("Available items:");
        foreach (var item in ItemRepository.Items)
        {
            Console.WriteLine($"Code: {item.Key}, Price: {item.Value.Price:C2}");
        }
        Console.WriteLine("Please scan an item by entering its code (A-Z), or type 'exit' to finish.");

        while (true)
        {
            Console.Write("Scan item: ");
            string input = Console.ReadLine();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (input.Length == 1 && char.IsLetter(input[0]) && ItemRepository.Items.TryGetValue(char.ToUpper(input[0]), out Item? itemToScan))
            {
                if (itemToScan != null)
                {
                    scanner.ScanItem(itemToScan);
                }
                else
                {
                    Console.WriteLine("Invalid input or item does not exist. Please enter a single letter representing an item or 'exit' to finish.");
                }
            }
        }
            Console.WriteLine("Final Summary:");
            basicCalculator.PrintReceipt();
            advancedCalculator.PrintReceipt();
            Console.WriteLine("Checkout complete. Have a great day!");
        
    }
}