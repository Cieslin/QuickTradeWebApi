using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickTrade.ModelsDTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AdvertDTO> Advert { get; set; }
    }
}