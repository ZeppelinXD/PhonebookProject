namespace PhonebookApp
{   // getter-setter and constructor for address property alone because it has 2 properties
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }
    }
}
