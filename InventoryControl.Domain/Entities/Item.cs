namespace InventoryControl.Domain.Entities;

public class Item
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Item(string name, string description, decimal price, int quantity)
    {
        Validate(name, price, quantity);

        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public void SetId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("The item id must be greater than zero.");
        }

        Id = id;
    }

    public void Update(string name, string description, decimal price, int quantity)
    {
        Validate(name, price, quantity);

        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("The quantity to increase must be greater than zero.");
        }

        Quantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("The quantity to decrease must be greater than zero.");
        }

        if (quantity > Quantity)
        {
            throw new InvalidOperationException("The quantity to decrease cannot be greater than the current stock.");
        }

        Quantity -= quantity;
    }

    private static void Validate(string name, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The item name is required.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("The item price must be greater than zero.");
        }

        if (quantity < 0)
        {
            throw new ArgumentException("The item quantity cannot be negative.");
        }
    }
}