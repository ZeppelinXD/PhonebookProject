using System;

namespace PhonebookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.LoadContactsFromJson("contacts.json"); // Load contacts from JSON file

            bool running = true;

            // Interactive menu
            while (running)
            {
                Console.WriteLine("===== Phonebook Application =====");
                Console.WriteLine("1. Display All Contacts");
                Console.WriteLine("2. Search for a Contact");
                Console.WriteLine("3. Sort Contacts");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        phoneBook.DisplayAllContacts();
                        break;

                    case "2":
                        Console.Write("Enter search term: ");
                        string searchTerm = Console.ReadLine();
                        Contact[] searchResults = phoneBook.Search(searchTerm);
                        if (searchResults.Length > 0)
                        {
                            foreach (var contact in searchResults)
                            {
                                Console.WriteLine(PhoneBook.Display(contact));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Sort by: 1. FirstName, 2. LastName, 3. MobileNumber, 4. Birthday, 5. City");
                        string sortOption = Console.ReadLine();
                        SortCategory category = sortOption switch
                        {
                            "1" => SortCategory.FirstName,
                            "2" => SortCategory.LastName,
                            "3" => SortCategory.MobileNumber,
                            "4" => SortCategory.Birthday,
                            "5" => SortCategory.City,
                            _ => SortCategory.FirstName
                        };

                        Console.WriteLine("Sort order: 1. Ascending, 2. Descending");
                        string sortOrder = Console.ReadLine();
                        SortOrder order = sortOrder == "2" ? SortOrder.Descending : SortOrder.Ascending;

                        Contact[] sortedContacts = phoneBook.Sort(category, order);
                        foreach (var contact in sortedContacts)
                        {
                            Console.WriteLine(PhoneBook.Display(contact));
                        }
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
