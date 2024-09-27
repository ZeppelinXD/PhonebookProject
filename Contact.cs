namespace PhonebookApp
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }

        public Contact(string firstName, string lastName, string mobileNumber, DateTime birthday, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Birthday = birthday;
            Address = address;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\nMobile: {MobileNumber}\nBirthday: {Birthday.ToShortDateString()}\nAddress: {Address.Street}, {Address.City}";
        }
    }
}
