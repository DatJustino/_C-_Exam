using System;
using System.Collections.Generic;

public class BasicPriceCalculator
{
    public double Total { get; private set; }
    private Dictionary<char, int> itemCounts = new Dictionary<char, int>();

    private double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var itemCode in itemCounts.Keys)
        {
            var item = ItemRepository.Items[itemCode];
            double itemPrice = CalculateItemPrice(item);
            totalPrice += itemPrice;
        }
        return totalPrice;
    }

    public void OnItemScanned(Item item)
    {
        if (!itemCounts.ContainsKey(item.Code))
        {
            itemCounts[item.Code] = 0;
        }
        itemCounts[item.Code]++;

        double itemPrice = CalculateItemPrice(item);
        Total += itemPrice;

        Console.WriteLine($"Item {item.Code} scanned: {itemPrice:C2}. New total: {Total:C2}");
    }

    private double CalculateItemPrice(Item item)
    {
        if (item.Promotion != null)
        {
            if (itemCounts[item.Code] >= item.Promotion.RequiredQuantity)
            {
                return ApplyPromotion(item);
            }
            else
            {
                return item.Price;
            }
        }
        else if (item.IsMultipack)
        {
            if (itemCounts[item.Code] >= item.MultipackQuantity)
            {
            ApplyMultipackDiscount(1);
                return item.Price * item.MultipackQuantity;
            }
            else
            {
                return 0; // No additional cost until the next full set is scanned
            }
        }
        else
        {
            return item.Price; // Regular price for a single item
        }
    }
private double ApplyPromotion(Item item)
{
    double price = item.Price;
    int itemCount = itemCounts[item.Code];

    double fullPrice = itemCount * price;

    int setsOfPromotionItems = itemCount / item.Promotion.RequiredQuantity;

    double totalDiscount = setsOfPromotionItems * item.Promotion.DiscountAmount;

    double discountedPrice = fullPrice - totalDiscount;

    itemCount -= setsOfPromotionItems * item.Promotion.RequiredQuantity;
    itemCounts[item.Code] = itemCount;

    // Apply the multipack discount to the remaining items, if any
    if (itemCount > 0 && item.IsMultipack)
    {
        ApplyMultipackDiscount(itemCount);
    }

    return discountedPrice;
}


private void ApplyMultipackDiscount(int remainingCount)
{
    // Remove the multipack discount from the item count and adjust the total price
    if (remainingCount > 0)
    {
        var item = ItemRepository.Items[itemCounts.First().Key];
        itemCounts[itemCounts.First().Key] = remainingCount;

        double multipackPrice = item.Price * item.MultipackQuantity;
        Total -= multipackPrice;
    }
}

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt (Basic Calculator):");
        Console.WriteLine($"Total: {Total:C2}");
    }
}
