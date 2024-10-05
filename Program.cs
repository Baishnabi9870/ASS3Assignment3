namespace ASS3Assignment3
{
    public class Program
    {
        static void Main(string[] args)
        {
            DeliveryService deliveryService = new DeliveryService();
            Console.WriteLine("enter your product");
            string name=Console.ReadLine();
            Console.WriteLine("enter stock");
            int stock=int.Parse(Console.ReadLine());
            Console.WriteLine("enter the quantity");
            int quantity=int.Parse(Console.ReadLine());
            Product product = new Product() { Name = name, Stock = stock };
            try
            {
                deliveryService.PlaceOrder(product, quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Order process completed");
            }

        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }
    public class DeliveryService
    {
        public void PlaceOrder(Product product, int quantity)
        {
            if (String.IsNullOrEmpty(product.Name)) {
                throw new Exception("ProductName is blank");
            }

            if (product.Stock <= 0) {
                throw new Exception("Product is out of stock");
            }
            else if (product.Stock < quantity) {
                throw new Exception("insufficient stock");
            }
            else
            {
                product.Stock -= quantity;
                Console.WriteLine($"remaining stock:{ product.Stock}");

            }
        }

    }

}
