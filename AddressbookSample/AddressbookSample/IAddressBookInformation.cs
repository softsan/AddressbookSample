using AddressbookSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookSample
{
    /// <summary>
    /// The Address Book Information interface.
    /// </summary>
    public interface IAddressBookInformation
    {
        Task<List<Contacts>> GetContacts();
    }
}
