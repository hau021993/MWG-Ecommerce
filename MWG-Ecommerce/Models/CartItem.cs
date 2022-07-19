namespace MWG_Ecommerce.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public int Quanlity { get; set; }
        public double TotalPrice => Quanlity * Price;
    }
}
