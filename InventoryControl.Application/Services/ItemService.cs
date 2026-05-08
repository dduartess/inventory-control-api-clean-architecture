using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;
using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public List<ItemResponse> GetAllItems()
    {
        var items = _itemRepository.GetAllItems();

        return items.Select(MapToResponse).ToList();
    }

    public ItemResponse? GetItemById(int id)
    {
        var item = _itemRepository.GetItemById(id);

        if (item is null)
        {
            return null;
        }

        return MapToResponse(item);
    }

    public ItemResponse CreateItem(CreateItemRequest request)
    {
        var item = new Item(
            request.Name,
            request.Description,
            request.Price,
            request.Quantity
        );

        var createdItem = _itemRepository.CreateItem(item);

        return MapToResponse(createdItem);
    }

    public bool UpdateItem(int id, UpdateItemRequest request)
    {
        var item = _itemRepository.GetItemById(id);

        if (item is null)
        {
            return false;
        }

        item.Update(
            request.Name,
            request.Description,
            request.Price,
            request.Quantity
        );

        return _itemRepository.UpdateItem(item);
    }

    public bool DeleteItem(int id)
    {
        var item = _itemRepository.GetItemById(id);

        if (item is null)
        {
            return false;
        }

        return _itemRepository.DeleteItem(id);
    }

    public bool IncreaseItemStock(int id, int quantity)
    {
        var item = _itemRepository.GetItemById(id);

        if (item is null)
        {
            return false;
        }

        item.IncreaseStock(quantity);

        return _itemRepository.UpdateItem(item);
    }

    public bool DecreaseItemStock(int id, int quantity)
    {
        var item = _itemRepository.GetItemById(id);

        if (item is null)
        {
            return false;
        }

        item.DecreaseStock(quantity);

        return _itemRepository.UpdateItem(item);
    }

    private static ItemResponse MapToResponse(Item item)
    {
        return new ItemResponse
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Quantity = item.Quantity
        };
    }
}