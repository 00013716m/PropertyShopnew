using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace PropertyShop.Models
{
    public class Property
    {
        public int id { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public int? AgentId { get; set; }

        [ForeignKey("AgentId")]
        public Agent? Agent { get; set; }
    }
}
