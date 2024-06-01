namespace task_2
{
    internal class Shop
    {
        public List<Product> Products { get; private set; }
        public double TotalIncome { get; private set; }
        public Shop()
        {
            Products = new List<Product>();
            TotalIncome = 0;
        }
        public void AddProduct(Product product)
        {
            var currentProduct = Products.FirstOrDefault(p => p.Name == product.Name);
            if (currentProduct is null)
            {
                Products.Add(product);
            }
            else
            {
                Console.WriteLine("this product already exists");
            }
        }
        public bool SellProduct(string name, int count)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            if (product != null && product.Count >= count)
            {
                TotalIncome = TotalIncome + (product.Price * count);
                product.Count -= count;
                return true;
            }
            return false;
        }
    }
}
