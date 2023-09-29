using System.Collections.Generic;
using System;

namespace CRM
{
    public class AddressBook
    {
        #region private attributes
        private List<Contact> _contacts = new List<Contact>();
        #endregion private attibutes

        #region public methods
        public void AddContact(Contact contactToAdd)
        {
            if (!DoesExist(contactToAdd))
            {
                _contacts.Add(contactToAdd);
            }
            else
            {
                throw new ContactAlreadyExist();
            }
        }

        public void AddContacts(List<Contact> contactsToAdd)
        {
            foreach (Contact contactToAdd in contactsToAdd)
            {
                if (!DoesExist(contactToAdd))
                {
                    _contacts.Add(contactToAdd);
                }
                else
                {
                    throw new ContactAlreadyExist();
                }
            }
        }

        public bool DoesExist(Contact contactToCheck)
        {
            return _contacts.Contains(contactToCheck);
        }

        public void Remove(Contact contactToRemove)
        {
            if (DoesExist(contactToRemove))
            {
                _contacts.Remove(contactToRemove);
            }
            else
            {
                throw new RemoveFailedException();
            }
            
        }

        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        public class ContactAlreadyExist : Exception { };
        public class ContactNotExist : Exception { };
        public class RemoveFailedException : Exception { };

        #endregion public methods
    }
}
