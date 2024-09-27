namespace PhonebookApp
{
    public class Contact
    {   // getter-setter for properties in the array it's pulling from
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        // Constructor to initialize a new contact with provided details
        public Contact(string firstName, string lastName, string mobileNumber, DateTime birthday, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Birthday = birthday;
            Address = address;
        }
        // Making sure the contact data is in a readable format
        public override string ToString()
        {
            return $"{FirstName} {LastName}\nMobile: {MobileNumber}\nBirthday: {Birthday.ToShortDateString()}\nAddress: {Address.Street}, {Address.City}";
        }
    }
}
