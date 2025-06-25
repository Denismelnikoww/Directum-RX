namespace PhoneApp.Domain.DTO
{
    public class UserAddress
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string PostalCode { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Country { get; set; }
    }

 
}