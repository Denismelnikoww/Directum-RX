using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhoneApp.Domain.DTO
{
    public partial class EmployeesDTO : DataTransferObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name is required");
                }
                _name = value;
            }
        }
        public string Phone
        {
            get { return _phones.Any() ? _phones.LastOrDefault().Value : "-"; }
        }
        public void AddPhone(string phone)
        {
            if (String.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Phone must be provided!");
            }
            if (!IsValidPhoneNumber(phone) )
            {
                throw new ArgumentException("Invalid number");
            }

            _phones.Add(DateTime.Now, phone);
        }

        private Dictionary<DateTime, string> _phones = new Dictionary<DateTime, string>();

        private bool IsValidRussianPhone(string phone)
        {
            string pattern = @"^(?:\+7|8)[\s\-]?\(?(9\d{2})\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";
            return Regex.IsMatch(phone, pattern);
        }

        //в dummyjson номера разных стран, сложно и долго обрабатывать каждый, поэтому
        //это псевдовалидация телефонного номера
        private bool IsValidPhoneNumber(string phone)
        {
            string pattern = @"^\+?[\d\s\-\(\)]{7,20}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}
