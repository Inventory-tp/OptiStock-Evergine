namespace OptiStock.MAUI.Models
{
    public class ProductModel :DomainObject
    {
        public string name { get; set; }
        public string brand { get; set; }
        public int quantity { get; set; }
        public float weigth { get; set; }
    }
}
