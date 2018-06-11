using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QuickTrade.Interfaces;
using QuickTrade.ModelsDTO;
using QuickTrade.Models;
using AutoMapper;
using System.Net.Http;

namespace QuickTrade.Controllers
{
    public class AccountController : ApiController, IAccount
    {

        private QuickTradeModelContainer context = new QuickTradeModelContainer();

        [HttpPost]
        [Route("addaccount")]
        public IHttpActionResult AddAccount(AccountDTO account)
        {
            var acc = context.AccountSet.FirstOrDefault((a) => a.Login == account.Login);

            if(acc != null || account.Password == null)
            {
                return BadRequest();
            }

            context.AccountSet.Add(new Account() {
                Login = account.Login,
                Password = account.Password
            });
            context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage LoginOnAccount(AccountDTO account)
        {
            var acc = context.AccountSet.FirstOrDefault((a) => a.Login == account.Login && a.Password == account.Password);
            if(acc != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, acc.Id);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        }
    }
}