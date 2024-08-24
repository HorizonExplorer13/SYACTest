using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class PurchesOrder
    {
        [Key]
        public int purchesOrderId { get; set; }
        [ForeignKey("clients")]
        public int? clientId { get; set; }
        public ClientsEntity? clients { get; set; }

        public DateTime recordDate { get; set; }

        public string state { get; set; }

        public string RequestAddress { get; set; }
        public string priority { get; set; }

        public List<OrderProduct>? products { get; set; }

        public int TtotalToPurch { get; set; }

        public int totalPurchValue { get; set; }


    }
}
