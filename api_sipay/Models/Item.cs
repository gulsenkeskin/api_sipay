using System.Text.Json.Serialization;

namespace ApiSipay.Models
{
    public class Item
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        public string name { get { return this.Name; } }
        public string price { get { return Price.ToString("0.00").Replace(",", "."); } }
        public int qty { get { return this.Quantity; } }

        public int qnantity { get { return this.Quantity; } }
        public string description { get { return this.Description; } }
    }
}
