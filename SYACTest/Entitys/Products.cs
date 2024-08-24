using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public string productoCode { get; set; }

        public int productUnitValue { get; set; }
        [ForeignKey("purchesOrder")]
        public int? purchesOrderId { get; set; }

        //public PurchesOrder? purchesOrder { get; set; }

    }
}
