using System.ComponentModel.DataAnnotations;

namespace SYACTest.Entitys
{
    public class ClientsEntity
    {
        [Key]
        public int clientId { get; set; }
        public string document { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
