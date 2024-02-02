public interface IItemRepository
{
    Item GetItem(char code);
    IEnumerable<Item> GetAllItems();
}