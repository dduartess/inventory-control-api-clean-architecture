using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Interfaces;

public interface IItemRepository
{
    List<Item> GetAllItems();

    Item? GetItemById(int id);

    Item CreateItem(Item item);

    bool UpdateItem(Item item);

    bool DeleteItem(int id);
}