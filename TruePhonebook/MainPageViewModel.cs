using System.Collections.Generic;
using System.ComponentModel;

namespace TruePhonebook
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        readonly ContactsProvider _contactsProvider = new ContactsProvider();

        IEnumerable<Contact> _contacts;
        public IEnumerable<Contact> Contacts
        {
            get { return _contacts;}
            private set
            {
                _contacts = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Contacts)));
            }
        }

        public void FilterContacts(string searchQuery = "")
        {
            Contacts = _contactsProvider.GetContacts(searchQuery);
        }
    }
}
