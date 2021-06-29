using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication
{
    public partial class Bankclient
    {
        public Bankclient()
        {
            Accounts = new HashSet<Account>();
            TransactionClientReceiverIdKeyNavigations = new HashSet<Transaction>();
            TransactionClientSenderIdKeyNavigations = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string ClientFullName { get; set; }
        public int CountryId { get; set; }
        public long? CountryIdKey { get; set; }
        public int CityId { get; set; }
        public long? CityIdKey { get; set; }
        public string Address { get; set; }
        public string UniqueIdentityNumber { get; set; }
        public DateTime ClientBirthday { get; set; }

        public virtual City CityIdKeyNavigation { get; set; }
        public virtual Country CountryIdKeyNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Transaction> TransactionClientReceiverIdKeyNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionClientSenderIdKeyNavigations { get; set; }
    }
}
