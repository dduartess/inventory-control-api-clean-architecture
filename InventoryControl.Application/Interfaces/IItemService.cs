using InventoryControl.Application.DTOs;

namespace InventoryControl.Application.Interfaces;

public interface IItemService
{
    List<ItemResponse> GetAllItems();

    ItemResponse? GetItemById(int id);

    ItemResponse CreateItem(CreateItemRequest request);

    bool UpdateItem(int id, UpdateItemRequest request);

    bool DeleteItem(int id);

    bool IncreaseItemStock(int id, int quantity);

    bool DecreaseItemStock(int id, int quantity);
}