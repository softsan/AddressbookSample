using System;
using System.Collections.Generic;
using System.Linq;
using AddressbookSample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AddressBookInformation))]
namespace AddressbookSample.Droid
{
    using System.Threading.Tasks;

    using AddressbookSample.Model;

    using Xamarin.Contacts;
    using Xamarin.Forms;

    public class AddressBookInformation : IAddressBookInformation
    {
        /// <summary>
        /// The book.
        /// </summary>
        private AddressBook book = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookInformation"/> class.
        /// </summary>
        public AddressBookInformation()
        {
            this.book = new AddressBook(Forms.Context.ApplicationContext);
        }

        public async Task<List<Contacts>> GetContacts()
        {
            var contacts = new List<Contacts>();
            
            // Observation:
            // On device RequestPermission() returns false sometimes so you can use  this.book.RequestPermission().Result (remove await)
            var permissionResult = await this.book.RequestPermission();
            if (permissionResult)
            {
                if (!this.book.Any())
                {
                    Console.WriteLine("No contacts found");
                }

                foreach (Contact contact in book.OrderBy(c => c.LastName))
                {
                    // Note: on certain android device(Htc for example) it show name in DisplayName Field
                    contacts.Add(new Contacts() { FirstName = contact.FirstName, LastName = contact.LastName });
                }
            }

            return contacts;
        }
    }
}