using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace PhonebookApp
{
    public class PhoneBook
    {
        public Contact[] contacts = new Contact[100];
        private int count = 0;

        // Method to load contacts from JSON file
        public void LoadContactsFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Contact> contactList = JsonSerializer.Deserialize<List<Contact>>(json);

            foreach (var contact in contactList)
            {
                if (count < contacts.Length)
                {
                    contacts[count++] = contact;
                }
                else
                {
                    Console.WriteLine("Phonebook is full.");
                    break;
                }
            }
        }

        // Method to display all contacts
        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                if (contact != null)
                {
                    Console.WriteLine(Display(contact));
                }
            }
        }

        // Method to display a single contact (Fancy Contact Card)
        public static string Display(Contact c)
        {
            return $@"
    ===============================
    Contact Information
    ===============================
    Name:        {c.FirstName} {c.LastName}
    Mobile:      {c.MobileNumber}
    Birthday:    {c.Birthday.ToShortDateString()}
    Address:     {c.Address.Street}, {c.Address.City}
    ===============================
    ";
        }

        // Method to search for contacts
        public Contact[] Search(string searchTerm)
        {
            List<Contact> matchedContacts = new List<Contact>();

            foreach (var contact in contacts)
            {
                if (contact != null && (
                    contact.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.MobileNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Birthday.ToShortDateString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Address.Street.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Address.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                {
                    matchedContacts.Add(contact);
                }
            }

            return matchedContacts.ToArray();
        }

        // Method to sort contacts
        public Contact[] Sort(SortCategory category, SortOrder order)
        {
            IEnumerable<Contact> sortedContacts = contacts.Where(c => c != null);

            switch (category)
            {
                case SortCategory.FirstName:
                    sortedContacts = order == SortOrder.Ascending
                        ? sortedContacts.OrderBy(c => c.FirstName)
                        : sortedContacts.OrderByDescending(c => c.FirstName);
                    break;
                case SortCategory.LastName:
                    sortedContacts = order == SortOrder.Ascending
                        ? sortedContacts.OrderBy(c => c.LastName)
                        : sortedContacts.OrderByDescending(c => c.LastName);
                    break;
                case SortCategory.MobileNumber:
                    sortedContacts = order == SortOrder.Ascending
                        ? sortedContacts.OrderBy(c => c.MobileNumber)
                        : sortedContacts.OrderByDescending(c => c.MobileNumber);
                    break;
                case SortCategory.Birthday:
                    sortedContacts = order == SortOrder.Ascending
                        ? sortedContacts.OrderBy(c => c.Birthday)
                        : sortedContacts.OrderByDescending(c => c.Birthday);
                    break;
                case SortCategory.City:
                    sortedContacts = order == SortOrder.Ascending
                        ? sortedContacts.OrderBy(c => c.Address.City)
                        : sortedContacts.OrderByDescending(c => c.Address.City);
                    break;
            }

            return sortedContacts.ToArray();
        }
    }
}
