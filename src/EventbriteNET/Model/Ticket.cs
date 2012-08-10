namespace EventbriteNET.Model
{
    using System;

    public enum TicketType
    {
        FixedPrice,
        Donation
    }

    public class Ticket
    {
        public string Currency;
        public string Description;
        public DateTime EndDateTime;
        public long Id;
        public string Name;
        public decimal Price;
        public int? QuantityAvailable;
        public int? QuantitySold;
        public DateTime? StartDateTime;
        public TicketType Type;

    }
}