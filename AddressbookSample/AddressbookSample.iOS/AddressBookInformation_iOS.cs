using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using AddressbookSample.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(AddressBookInformation_iOS))]
namespace AddressbookSample.iOS
{
    using System.Linq;
    using System.Threading.Tasks;

    using AddressbookSample.Model;
    using Xamarin.Contacts;

    public class AddressBookInformation_iOS : IAddressBookInformation
    {
        /// <summary>
        /// The book.
        /// </summary>
        private AddressBook book = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookInformation_iOS"/> class.
        /// </summary>
        public AddressBookInformation_iOS()
        {
            this.book = new AddressBook();
        }

        public async Task<List<Contacts>> GetContacts()
        {
            var contacts = new List<Contacts>();
            
            // Observation:
            // On device this returns false sometimes so you can use like this.book.RequestPermission().Result (remove await)
            var permissionResult = await this.book.RequestPermission();
            if (permissionResult)
            {
                if (!this.book.Any())
                {
                    Console.WriteLine("No contacts found");
                }

                foreach (Contact contact in book.OrderBy(c => c.LastName))
                {
                    contacts.Add(new Contacts() { FirstName = contact.FirstName, LastName = contact.LastName });
                }
            }

            return contacts;
        }
    }
}
