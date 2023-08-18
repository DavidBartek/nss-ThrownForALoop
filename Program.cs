// See https://aka.ms/new-console-template for more information
string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting equipment";

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        Quantity = 10,
        StockDate = new DateTime(2023, 7, 1),
        ManufactureYear = 2015,
        Condition = 4.5
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.99M,
        Sold = false,
        Quantity = 5,
        StockDate = new DateTime(2022, 10, 5),
        ManufactureYear = 2017,
        Condition = 4.6
    },
    new Product()
    {
        Name = "Baseball",
        Price = 5.49M,
        Sold = true,
        Quantity = 0,
        StockDate = new DateTime(2020, 3, 15),
        ManufactureYear = 2019,
        Condition = 4.1
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 10.99M,
        Sold = false,
        Quantity = 2,
        StockDate = new DateTime(2019, 4, 10),
        ManufactureYear = 1995,
        Condition = 2.5
    },
    new Product()
    {
        Name = "Helmet",
        Price = 25.25M,
        Sold = true,
        Quantity = 0,
        StockDate = new DateTime(2023, 8, 14),
        ManufactureYear = 1993,
        Condition = 1.9        
    },
    new Product()
    {
        Name = "Soccer Ball",
        Price = 15.69M,
        Sold = false,
        Quantity = 15,
        StockDate = new DateTime(2023, 8, 4),
        ManufactureYear = 1500,
        Condition = 5.0
    }
};

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    DateTime now = DateTime.Now;

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {now.Year - chosenProduct.ManufactureYear} years old.
    Its condition rating: {chosenProduct.Condition} / 5.
    {(chosenProduct.Sold ? "It is sold out" : $"There is {chosenProduct.Quantity} in stock, it has been in stock for {timeInStock.Days} days.")}");

    // Console.WriteLine(chosenProduct);
    // ^ does not display the whole object with all its properties; only displays *class* of chosenProduct!

}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    //create new empty list to store latest products
    List<Product> latestProducts = new List<Product>();
    //calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through products
    foreach (Product product in products)
    {
        // add product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print latest products to the console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

//

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Newest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}