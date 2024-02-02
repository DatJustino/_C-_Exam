using System;
using System.Collections.Generic;

public class BasicPriceCalculator
{
    public double Total { get; private set; }
    private Dictionary<char, int> itemCounts = new();

 
 private double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var itemCode in itemCounts.Keys)
        {
            var item = ItemRepository.Items[itemCode];
            double itemPrice = CalculateItemPrice(item, itemCounts[itemCode]);
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

        Total = CalculateTotalPrice();  // Update total

        Console.WriteLine($"Item {item.Code} scanned. \nNew total: {Total:C2}");
    }


    private double CalculateItemPrice(Item item, int itemCount)
    {
        double price = 0;
        if (item.Promotion != null)
        {
            price += ApplyPromotion(item, itemCount);
        }
        else if (item.IsMultipack)
        {
            int sets = itemCount / item.MultipackQuantity;
            int singles = itemCount % item.MultipackQuantity;

            price += sets * item.Price * item.MultipackQuantity + singles * item.Price;
        }
        else
        {
            price += item.Price * itemCount;
        }
        return price;
    }
    
    private double ApplyPromotion(Item item, int itemCount)
    {
        int setsOfPromotionItems = itemCount / item.Promotion.RequiredQuantity;
        double discountedPrice = setsOfPromotionItems * (item.Price * item.Promotion.RequiredQuantity - item.Promotion.DiscountAmount);
        int remainingItems = itemCount % item.Promotion.RequiredQuantity;

        return discountedPrice + remainingItems * item.Price;
    }

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt (Basic Calculator):");
        Console.WriteLine($"Total: {Total:C2}");
    }
}

   