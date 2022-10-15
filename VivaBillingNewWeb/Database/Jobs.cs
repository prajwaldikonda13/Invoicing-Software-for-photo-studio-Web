namespace VivaBillingNewWeb.Database
{
    public class Jobs
    {
        public long ID { get; set; }
        public long Product { get; set; }
        public long ProductType { get; set; }
        public long ProductSize { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
        public float TotalPrice { get; set; }
        public long Invoice { get; set; }
        public string Status { get; set; }

    }
}