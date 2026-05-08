using InventoryControl.Application.Interfaces;
using InventoryControl.Domain.Entities;

namespace InventoryControl.Infrastructure.Repositories;

public class InMemoryItemRepository : IItemRepository
{
    private readonly List<Item> _items = new();

    public List<Item> GetAllItems()
    {
        return _items;
    }

    public Item? GetItemById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Item CreateItem(Item item)
    {
        var nextId = _items.Count + 1;

        item.SetId(nextId);

        _items.Add(item);

        return item;
    }

    public bool UpdateItem(Item item)
    {
        var existingItem = GetItemById(item.Id);

        if (existingItem is null)
        {
            return false;
        }

        return true;
    }

    public bool DeleteItem(int id)
    {
        var item = GetItemById(id);

        if (item is null)
        {
            return false;
        }

        _items.Remove(item);

        return true;
    }
}