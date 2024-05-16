namespace ConsoleApp.MiniRestaurantManagementSystem;

public static class RestaurantService
{
    static List<MenuItem> menuItems = new List<MenuItem>();
    static List<Order> orders = new List<Order>();

    public static void Run()
    {
        int choice;
        do

        {
            Console.WriteLine("\nRestaurant Management System");
            Console.WriteLine("1. Manage Menu");
            Console.WriteLine("2. Take Order");
            Console.WriteLine("3. View Orders");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ManageMenu();
                    break;
                case 2:
                    TakeOrder();
                    break;
                case 3:
                    ViewOrders();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        } while (choice != 4);
    }

    static void ManageMenu()
    {
        int option;

        do
        {
            Console.WriteLine("\nMenu Management");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. View Menu");
            Console.WriteLine("3. Back");
            Console.Write("Enter your choice: ");

            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddMenuItem();
                    break;
                case 2:
                    ViewMenu();
                    break;
                case 3:
                    Console.WriteLine("Returning to main menu...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        } while (option != 3);
    }

    static void AddMenuItem()
    {
        MenuItem newItem = new MenuItem();
        Console.Write("Enter item name: ");
        newItem.Name = Console.ReadLine();
        Console.Write("Enter item price: ");
        newItem.Price = Convert.ToDecimal(Console.ReadLine());
        newItem.Id = menuItems.Count + 1; // Assuming unique ID based on count
        menuItems.Add(newItem);
        Console.WriteLine("Item added successfully!");
    }

    static void ViewMenu()
    {
        if (menuItems.Count == 0)
        {
            Console.WriteLine("Menu is empty!");
            return;
        }

        Console.WriteLine("\nMenu:");
        Console.WriteLine("{0,-5} {1,-20} {2,10}", "ID", "Name", "Price");
        foreach (MenuItem item in menuItems)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,10:C2}", item.Id, item.Name, item.Price);
        }
    }

    static void TakeOrder()
    {
        Order newOrder = new Order();
        int itemId;
        int quantity;

        do
        {
            ViewMenu();
            Console.Write("Enter item ID (-1 to finish): ");
            itemId = Convert.ToInt32(Console.ReadLine());

            if (itemId == -1)
            {
                break;
            }

            MenuItem selectedItem = menuItems.Find(item => item.Id == itemId);
            if (selectedItem == null)
            {
                Console.WriteLine("Invalid item ID!");
            }
            else
            {
                Console.Write("Enter quantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());
                OrderItem newItem = new OrderItem { Item = selectedItem, Quantity = quantity };
                newOrder.Items.Add(newItem);
            }
        } while (itemId != -1);

        if (newOrder.Items.Count > 0)
        {
            Console.WriteLine("\nOrder Summary:");
            Console.WriteLine("{0,-5} {1,-20} {2,5} {3,10:C2}", "ID", "Name", "Qty", "Price");
            foreach (OrderItem item in newOrder.Items)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,5} {3,10:C2}", item.Item.Id, item.Item.Name, item.Quantity,
                    item.GetTotal());
            }

            Console.WriteLine("Total: {0:C2}", newOrder.GetTotal());
            orders.Add(newOrder);
            Console.WriteLine("Order placed successfully!");
        }
        else
        {
            Console.WriteLine("No items added to order!");
        }
    }

    static void ViewOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders found!");
            return;
        }

        Console.WriteLine("\nOrders:");
        Console.WriteLine("{0,-5} {1,10:C2}", "Order ID", "Total");
        foreach (Order order in orders)
        {
            Console.WriteLine("{0,-5} {1,10:C2}", order.Id, order.GetTotal());
        }
    }
}