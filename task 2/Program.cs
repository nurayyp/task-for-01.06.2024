using task_2;

public static class Program
{
    public static void Main()
    {
        Shop shop = new Shop();
        while (true)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 - Mehsul elave et");
            Console.WriteLine("2 - Mehsul sat");
            Console.WriteLine("3 - Mehsullari gor");
            Console.WriteLine("Birini secin");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Name of the product - ");
                    string nameOfAddedProduct = Console.ReadLine();
                    Console.WriteLine("Price of the product - ");
                    double priceOfAddedProduct = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Count - ");
                    int countOfAddedProduct = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type (c - coffee t - tea) of the product - ");
                    string typeOfAddedProduct = Console.ReadLine();
                    if (typeOfAddedProduct == "c")
                    {
                        shop.AddProduct(new Coffee { Name = nameOfAddedProduct, Price = priceOfAddedProduct, Count = countOfAddedProduct });
                    }
                    else if (typeOfAddedProduct == "t")
                    {
                        shop.AddProduct(new Tea { Name = nameOfAddedProduct, Price = priceOfAddedProduct, Count = countOfAddedProduct });
                    }
                    else
                    {
                        Console.WriteLine("try again, type is not valid");
                    }
                    break;
                case "2":
                    Console.WriteLine("Name of the product - ");
                    string nameOfSoldProduct = Console.ReadLine();
                    Console.WriteLine("Count of the product - ");
                    int countOfSoldProduct = Convert.ToInt32(Console.ReadLine());
                    bool possibility = shop.SellProduct(nameOfSoldProduct, countOfSoldProduct);
                    if (possibility)
                    {
                        Console.WriteLine($" income - {shop.TotalIncome}");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("This action is not possible");
                    }
                    break;
                case "3":
                    foreach (var product in shop.Products)
                    {
                        Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
                    }
                    break;
            }
        }
    }
}