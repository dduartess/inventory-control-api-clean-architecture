using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControl.API.Controllers;

[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetAllItems()
    {
        var items = _itemService.GetAllItems();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var item = _itemService.GetItemById(id);

        if (item is null)
        {
            return NotFound("Item not found.");
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateItem(CreateItemRequest request)
    {
        var item = _itemService.CreateItem(request);

        return CreatedAtAction(
            nameof(GetItemById),
            new { id = item.Id },
            item
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, UpdateItemRequest request)
    {
        var updated = _itemService.UpdateItem(id, request);

        if (!updated)
        {
            return NotFound("Item not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        var deleted = _itemService.DeleteItem(id);

        if (!deleted)
        {
            return NotFound("Item not found.");
        }

        return NoContent();
    }

    [HttpPatch("{id}/increase-stock")]
    public IActionResult IncreaseItemStock(int id, [FromQuery] int quantity)
    {
        var updated = _itemService.IncreaseItemStock(id, quantity);

        if (!updated)
        {
            return NotFound("Item not found.");
        }

        return NoContent();
    }

    [HttpPatch("{id}/decrease-stock")]
    public IActionResult DecreaseItemStock(int id, [FromQuery] int quantity)
    {
        var updated = _itemService.DecreaseItemStock(id, quantity);

        if (!updated)
        {
            return NotFound("Item not found.");
        }

        return NoContent();
    }
}