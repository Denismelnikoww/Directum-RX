using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace PhoneApp.Domain.DTO
{
    public class DummyEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
        public string Image { get; set; }
        public string BloodGroup { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EyeColor { get; set; }
        public Hair Hair { get; set; }
        public string Ip { get; set; }
        [JsonProperty("adress")]
        public UserAddress Address { get; set; }
        public string MacAddress { get; set; }
        public string University { get; set; }
        public Bank Bank { get; set; }
        public Company Company { get; set; }
        public string Ein { get; set; }
        public string Ssn { get; set; }
        public string UserAgent { get; set; }
        public Crypto Crypto { get; set; }
        public string Role { get; set; }
    }
}