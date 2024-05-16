### MiniRestaurantManagementSystem - Domain Logic

- **TakeOrder function:**
    - It checks for an invalid item ID and provides a message.
    - When a valid item is chosen, it prompts for quantity and creates an `OrderItem` object.
    - The `OrderItem` is added to the current `Order` object.
    - After adding items, it checks if any items were added.
    - If items are present, it displays an order summary with item details, total price, and adds the order to the `orders` list.
- **ViewOrders function:**
    - It checks for empty order list and displays a message.
    - It displays a list of orders with order ID and total price.

This code provides a basic framework for managing menus, taking orders, and viewing order history. You can further enhance it by:

- Implementing functionalities like editing or deleting menu items.
- Adding options for modifying order items before finalizing the order.
- Integrating persistence mechanisms to store data in a database.


**Project Structure:**

- Create a well-organized project structure with clear separation of concerns. Here's a recommended breakdown:

```
ConsoleApp.MiniRestaurantManagementSystem/
  |-- README.md               (Project documentation)
  |-- Models/                 (Classes representing data)
  |     |-- MenuItem.cs
  |     |-- Order.cs
  |     |-- OrderItem.cs
  |-- Servies/                 (Classes representing service)
  |     |-- RestaurantService.cs
  |-- Program.cs               (Main entry point)
```
