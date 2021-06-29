using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public string TransactionType { get; set; }
        public int? ClientSenderId { get; set; }
        public long? ClientSenderIdKey { get; set; }
        public int? ClientSenderAccountId { get; set; }
        public long? ClientSenderAccountIdKey { get; set; }
        public int? ClientReceiverId { get; set; }
        public long? ClientReceiverIdKey { get; set; }
        public int? ClientReceiverAccountId { get; set; }
        public long? ClientReceiverAccountIdKey { get; set; }
        public decimal Amount { get; set; }

        public virtual Account ClientReceiverAccountIdKeyNavigation { get; set; }
        public virtual Bankclient ClientReceiverIdKeyNavigation { get; set; }
        public virtual Account ClientSenderAccountIdKeyNavigation { get; set; }
        public virtual Bankclient ClientSenderIdKeyNavigation { get; set; }
    }
}
