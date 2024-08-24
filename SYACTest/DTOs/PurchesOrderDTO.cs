namespace SYACTest.DTOs
{
    public record PurchesOrderDTO
    {
        public string documentClient { get; set; }
        public string nameClient { get; set; }
        public string addressClient { get; set; }
        public DateTime recordDate { get; set; }

        public string state { get; set; }

        public string RequestAddress { get; set; }
        public string priority { get; set; }

        public string ProductName { get; set; }
        public string ProductoCode { get; set; }

    }
}
