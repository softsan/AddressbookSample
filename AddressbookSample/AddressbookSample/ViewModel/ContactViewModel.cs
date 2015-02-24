using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookSample.ViewModel
{
    using AddressbookSample.Model;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ContactViewModel : BaseViewModel
    {
        public ObservableCollection<Contacts> ContactList { get; set; }

        public ContactViewModel()
        {
            ContactList = new ObservableCollection<Contacts>();
        }

        public async Task BindContcts()
        {
            var addressBook = DependencyService.Get<IAddressBookInformation>();
            if (addressBook != null)
            {
                var allAddress = await addressBook.GetContacts();
                foreach (var c in allAddress)
                {
                    var name = c.FirstName + " " + c.LastName;
                }

                this.ContactList = new ObservableCollection<Contacts>(allAddress);
                //foreach (var c in allAddress)
                //{
                //    var name = c.FirstName + " " + c.LastName;
                //}
            }
        }
    }
}
