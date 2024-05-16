namespace ConsoleApp.MiniRestaurantManagementSystem.Models;

class OrderItem
{
    public MenuItem Item { get; set; }
    public int Quantity { get; set; }

    public decimal GetTotal()
    {
        return Item.Price * Quantity;
    }
}