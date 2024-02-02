using System;
using ExamMarket;

namespace ExamMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            IItemRepository itemRepository = new ItemRepository();
            var scanner = new Scanner();
            var basicCalculator = new BasicPriceCalculator(itemRepository);
            var advancedCalculator = new AdvancedPriceCalculator(itemRepository);

            scanner.ItemScanned += basicCalculator.OnItemScanned;
            scanner.ItemScanned += advancedCalculator.OnItemScanned;

            Console.WriteLine("Welcome to the Supermarket Checkout System.");
            Console.WriteLine("Available products:");

            foreach (var item in itemRepository.GetAllItems())
            {
                string promoText = item.Promotion != null ? $" - Promotion: {item.Promotion.GetDescription()}" : "";
                Console.WriteLine($"Code: {item.Code}, {item.Name} from {item.Brand} - Price: {item.Price:C2}{promoText}");
            }
            Console.WriteLine("Please scan a product by entering its code (A-Z), or type 'exit' to finish.");

            while (true)
            {
                Console.Write("Scan item: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Are you sure you want to check out? (Y/N): ");
                    if (Console.ReadLine()?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
                {
                    char itemCode = char.ToUpper(input[0]);
                    Item itemToScan = itemRepository.GetItem(itemCode);
                    if (itemToScan != null)
                    {
                        scanner.ScanItem(itemToScan);
                    }
                    else
                    {
                        Console.WriteLine("Product does not exist. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a single letter representing an item or 'exit' to finish.");
                }
            }

            Console.WriteLine("Final Summary:");
            basicCalculator.PrintReceipt();
            advancedCalculator.PrintReceipt();
            Console.WriteLine("Checkout complete. Have a great day!");
        }
    }
}
