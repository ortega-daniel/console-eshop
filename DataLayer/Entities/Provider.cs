using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; private set; }
        public string City { get; private set; }

        public Provider(int id, string name, string emailAddress)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Provider name can't be left empty");

            if (string.IsNullOrEmpty(emailAddress))
                throw new InvalidOperationException("Provider email address can't be left empty");

            try
            {
                var email = new System.Net.Mail.MailAddress(emailAddress);
                EmailAddress = email.Address;
            }
            catch (FormatException _)
            {
                throw new ArgumentException("Provier email address is invalid");
            }

            Id = id;
            Name = name;
        }

        public void SetAddress(string address, string city) 
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidOperationException("Provider address can't be left empty");

            if (string.IsNullOrEmpty(city))
                throw new InvalidOperationException("Provider city can't be left empty");

            Address = address;
            City = city;
        }

        public void SetPhoneNumber(string phonenumber)
        {
            if (string.IsNullOrEmpty(phonenumber))
                throw new InvalidOperationException("Provider phonenumber can't be left empty");

            if (phonenumber.Length < 10)
                throw new InvalidOperationException("Provider phonenumber needs to be at least 10 digits long");

            PhoneNumber = phonenumber;
        }
    }
}
