using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class OrderProduct
    {
        
            [Key]
            public int OrderProductId { get; set; }

            [ForeignKey("Order")]
            public int OrderId { get; set; }
            public PurchesOrder Order { get; set; }

            [ForeignKey("Product")]
            public int ProductId { get; set; }
            public Products Product { get; set; }

            public int Quantity { get; set; }
            public decimal PartialValue { get; set; }
        }
    
}
