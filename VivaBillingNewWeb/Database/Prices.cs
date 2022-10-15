namespace VivaBillingNewWeb.Database
{
    public class Prices
    {
        public long ID { get; set; }
        public long Product { get; set; }
        public long ProductType { get; set; }
        public long ProductSize { get; set; }
        public float RegularPrice { get; set; }
        public float CounterPrice { get; set; }
    }
}