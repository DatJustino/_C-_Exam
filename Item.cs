public class Item
{
    public string Name { get; set; }
    public char Code { get; set; }
    public string Group { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
    public bool IsMultipack { get; set; }
    public int MultipackQuantity { get; set; }
    public Promotion? Promotion { get; set; }
    public double Deposit { get; set; }

}