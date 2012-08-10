namespace EventbriteNET.Model
{
    using System;

    public enum AttendeeGender
    {
        Male,
        Female
    }

    public class Attendee
    {
        public int? Age;
        public float? AmountPaid;
        public string Barcode;
        public DateTime? BirthDate;
        public string Blog;
        public string CellPhone;
        public string Company;
        public DateTime? Created;
        public string Currency;
        public string Discount;
        public string Email;
        public DateTime? EventDate;
        public long EventId;
        public string FirstName;
        public AttendeeGender? Gender;
        public string HomeAddress;
        public string HomeAddress2;
        public string HomeCity;
        public string HomeCountry;
        public string HomeCountryCode;
        public string HomePhone;
        public string HomePostalCode;
        public string HomeRegion;
        public long Id;
        public string JobTitle;
        public string LastName;
        public DateTime? Modified;
        public string Notes;
        public int? OrderId;
        public string OrderType;
        public string Prefix;
        public int? Quantity;
        public string ShipAddress;
        public string ShipAddress2;
        public string ShipCity;
        public string ShipCountry;
        public string ShipCountryCode;
        public string ShipPostalCode;
        public string ShipRegion;
        public string Suffix;
        public long? TicketId;
        public string Website;
        public string WorkAddress;
        public string WorkAddress2;
        public string WorkCity;
        public string WorkCountry;
        public string WorkCountryCode;
        public string WorkPhone;
        public string WorkPostalCode;
        public string WorkRegion;
    }
}