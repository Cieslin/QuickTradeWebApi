using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using QuickTrade.ModelsDTO;
using System.Net.Http;

namespace QuickTrade.Interfaces
{
    interface IAccount
    {
        IHttpActionResult AddAccount(AccountDTO account); //HttpPost
        HttpResponseMessage LoginOnAccount(AccountDTO account); //HttpPost
    }
}
