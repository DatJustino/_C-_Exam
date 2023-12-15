public class Item
{
    public char Code { get; set; }
    public int Group { get; set; }
    public double Price { get; set; }
    public bool IsMultipack { get; set; }
    public int MultipackQuantity { get; set; }
    public Promotion? Promotion { get; set; }
}