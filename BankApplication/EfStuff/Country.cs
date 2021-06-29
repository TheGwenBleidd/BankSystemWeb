using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication
{
    public partial class Country
    {
        public Country()
        {
            Bankclients = new HashSet<Bankclient>();
        }

        public long Id { get; set; }
        public int CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Bankclient> Bankclients { get; set; }
    }
}
