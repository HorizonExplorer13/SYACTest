using SYACTest.Entitys;

namespace SYACTest.DTOs
{
    public class CreatePurchesOrderDTO
    {
        public string? documentClient { get; set; }
        public string? requestAddress { get; set; }
        public string? priority { get; set; }

        public List<Products> products { get; set; }
        public int quantity { get; set; }

        public int totalPurchesvalue { get; set; }
    }
}
