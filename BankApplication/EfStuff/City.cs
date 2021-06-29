using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication
{
    public partial class City
    {
        public City()
        {
            Bankclients = new HashSet<Bankclient>();
        }

        public long Id { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Bankclient> Bankclients { get; set; }
    }
}
