namespace ConsoleApp.MiniRestaurantManagementSystem;

class OrderItem
{
    public MenuItem Item { get; set; }
    public int Quantity { get; set; }

    public decimal GetTotal()
    {
        return Item.Price * Quantity;
    }
}