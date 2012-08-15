namespace EventbriteNET.Model
{
    using System;
    using Json.Converters;
    using Newtonsoft.Json;

    public enum TicketType
    {
        FixedPrice = 0,
        Donation = 1,
    }

    public class Ticket2 : IOuterConverter<Ticket2, Ticket>
    {
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }

        public Func<Ticket2, Ticket> Convert { get { return _ => _.Ticket; } }
    }

    public class Ticket : ModelWithId
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity_available")]
        public int? QuantityAvailable { get; set; }

        [JsonProperty("quantity_sold")]
        public int? QuantitySold { get; set; }

        [JsonProperty("start_date")]
        public DateTime? StartDateTime { get; set; }

        [JsonProperty("type")]
        public TicketType Type { get; set; }

    }
}