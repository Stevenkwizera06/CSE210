using OnlineOrdering;

var usaAddress = new Address("123 Main St", "Rexburg", "ID", "USA");
var intlAddress = new Address("45 Sheikh Zayed Rd", "Dubai", "Dubai", "United Arab Emirates");

var alice = new Customer("Alice Johnson", usaAddress);
var hamid = new Customer("Hamid Al-Farsi", intlAddress);

var order1 = new Order(alice);
order1.AddProduct(new Product("USB-C Cable", "CABL-001", 7.99m, 3));
order1.AddProduct(new Product("Wireless Mouse", "MOUS-210", 24.50m, 1));

var order2 = new Order(hamid);
order2.AddProduct(new Product("Mechanical Keyboard", "KEYB-550", 79.00m, 1));
order2.AddProduct(new Product("4K Webcam", "CAM-4K22", 109.99m, 1));
order2.AddProduct(new Product("Desk Mat", "DESK-777", 19.95m, 2));

var orders = new List<Order> { order1, order2 };

int idx = 1;
foreach (var order in orders)
{
    Console.WriteLine($"Order #{idx}");
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine($"Total: ${order.CalculateTotal():0.00}");
    Console.WriteLine(new string('-', 40));
    idx++;
}
