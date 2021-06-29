using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication
{
    public partial class Account
    {
        public Account()
        {
            TransactionClientReceiverAccountIdKeyNavigations = new HashSet<Transaction>();
            TransactionClientSenderAccountIdKeyNavigations = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public int BankClientId { get; set; }
        public long? BankClientIdKey { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public virtual Bankclient BankClientIdKeyNavigation { get; set; }
        public virtual ICollection<Transaction> TransactionClientReceiverAccountIdKeyNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionClientSenderAccountIdKeyNavigations { get; set; }
    }
}
