namespace ConsoleApp.MiniRestaurantManagementSystem;

class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; }

    public Order()
    {
        Items = new List<OrderItem>();
    }

    public decimal GetTotal()
    {
        decimal total = 0;
        foreach (OrderItem item in Items)
        {
            total += item.GetTotal();
        }
        return total;
    }
}