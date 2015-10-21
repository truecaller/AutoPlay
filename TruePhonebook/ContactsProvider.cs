using System;
using System.Collections.Generic;
using System.Linq;

namespace TruePhonebook
{
    public class ContactsProvider
    {
        const string AssetsBasePath = "ms-appx:///Assets/Contacts/";

        static readonly Contact[] FakeContacts =
        {
            new Contact { Name = "Emma Müller", PhoneNumber = "076XXXXXXX", NumberType = "Work", PhotoUrl = $"{AssetsBasePath}333.png"},
            new Contact { Name = "Zhang Wei", PhoneNumber = "076XXXXXXX", NumberType = "Other", PhotoUrl = $"{AssetsBasePath}703.png"},
            new Contact { Name = "Thomas Moreau", PhoneNumber = "076XXXXXXX", NumberType = "Mobile", PhotoUrl = $"{AssetsBasePath}true.png"},
            new Contact { Name = "محمد بن موسى الخوارزمی‎", PhoneNumber = "070XXXXXXX", NumberType = "Work", PhotoUrl = $"{AssetsBasePath}1665.png"},
            new Contact { Name = "Frank Martin", PhoneNumber = "073XXXXXXX", NumberType = "Mobile", PhotoUrl = $"{AssetsBasePath}1666.png"},
            new Contact { Name = "Daniel Moore", PhoneNumber = "076XXXXXXX", NumberType = "Other", PhotoUrl = $"{AssetsBasePath}1676.png"},
            new Contact { Name = "Siq Carsashta", PhoneNumber = "076XXXXXXX", NumberType = "Home", PhotoUrl = $"{AssetsBasePath}1661.png"}
        }; 

        public IEnumerable<Contact> GetContacts(string searchQuery = "")
        {
            return !string.IsNullOrWhiteSpace(searchQuery) ? 
                FakeContacts.Where(x => x.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) != -1 ||
                    x.PhoneNumber.Contains(searchQuery)) : 
                FakeContacts;
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NumberType { get; set; }
        public string PhotoUrl { get; set; }
    }
}
