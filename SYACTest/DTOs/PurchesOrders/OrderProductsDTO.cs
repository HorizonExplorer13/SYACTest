using SYACTest.Entitys;

namespace SYACTest.DTOs.PurchesOrders
{
    public record OrderProductsDTO
    {
        public int productId { get; set; }
        public Products? products { get; set; }
        public int Quantity { get; set; }
        public decimal PartialValue { get; set; }
    }
}
