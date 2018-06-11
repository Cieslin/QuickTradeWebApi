using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using QuickTrade.Interfaces;
using QuickTrade.Models;
using QuickTrade.ModelsDTO;
using PagedList;

namespace QuickTrade.Controllers
{
    public class AdvertController : ApiController, IAdvert
    {
        private readonly int PageSize = 3;
        private QuickTradeModelContainer context = new QuickTradeModelContainer();

        [HttpGet]
        [Route("alladverts")]
        public IEnumerable<AdvertDTO> GetAllAdverts()
        {
            List<AdvertDTO> advertslist = new List<AdvertDTO>();
            foreach (var adv in context.AdvertSet)
            {
                advertslist.Add(Mapper.Map<AdvertDTO>(adv));
            }
            return advertslist.AsEnumerable();

        }

        [HttpPost]
        [Route("myadverts")]
        public IEnumerable<AdvertDTO> GetMyAdverts(AdvertDTO advert)
        {
            List<AdvertDTO> advertslist = new List<AdvertDTO>();
            foreach (var adv in context.AdvertSet.Where(b => b.AccountId == advert.AccountId))
            {
                advertslist.Add(Mapper.Map<AdvertDTO>(adv));
            }
            return advertslist.AsEnumerable();
        }

        [HttpGet]
        [Route("adverts/{page}")]
        public IEnumerable<AdvertDTO> GetPaged(int page) // od 1
        {
            List<AdvertDTO> advertslist = new List<AdvertDTO>();
            var D = context.AdvertSet.OrderBy(a => a.Id).ToPagedList(page, PageSize);

            foreach (var adv in D)
            {
                advertslist.Add(Mapper.Map<AdvertDTO>(adv));
            }
            return advertslist.AsEnumerable();
        }

        [HttpPost]
        [Route("addadvert")]
        public IHttpActionResult AddAdvert(AdvertDTO advert)
        {
            var myNewAdvert = context.AdvertSet.FirstOrDefault((a) => a.Title == advert.Title);

            if (myNewAdvert != null)
            {
                return BadRequest();
            }

            Account acc = context.AccountSet.FirstOrDefault((a) => a.Id == advert.AccountId);

            if(acc == null)
            {
                return BadRequest();
            }

            myNewAdvert = Mapper.Map<Advert>(advert);
            myNewAdvert.Account = acc;
            myNewAdvert.AccountId = advert.AccountId;
            myNewAdvert.DateAdded = System.DateTime.Now;
            myNewAdvert.DateModified = System.DateTime.Now;
            context.AdvertSet.Add(myNewAdvert);
            if(advert.Images != null)
                context.ImagesSet.AddRange(myNewAdvert.Images);
            acc.Advert.Add(myNewAdvert);

            context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("updateadvert")]
        public IHttpActionResult UpdateAdvert(AdvertDTO advert)
        {
            var myAdvert = context.AdvertSet.FirstOrDefault((a) => a.AccountId == advert.AccountId && a.Id == advert.Id);
            if (myAdvert == null)
            {
                return BadRequest();
            }

            var myNewAdvert = Mapper.Map<Advert>(advert);
            if (advert != null)
            {
                if (advert.Title != null)
                    myAdvert.Title = myNewAdvert.Title;
                if (advert.Description != null)
                    myAdvert.Description = myNewAdvert.Description;
                myAdvert.DateModified = DateTime.Now;
                if (advert.Contact != null)
                    myAdvert.Contact = myNewAdvert.Contact;
                if (advert.Price >= 0.00)
                    myAdvert.Price = myNewAdvert.Price;
                if (advert.Category != null)
                    myAdvert.Category = myNewAdvert.Category;
            }
            if (advert.Images != null)
            {
                context.ImagesSet.RemoveRange(myAdvert.Images);
                context.ImagesSet.AddRange(myNewAdvert.Images);
            }
            myAdvert.Images = myNewAdvert.Images;

            context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteadvert")]
        public IHttpActionResult DeleteAdvert(AdvertDTO advert)
        {
            var myAdvert = context.AdvertSet.FirstOrDefault((a) => a.AccountId == advert.AccountId && a.Id == advert.Id);
            if (myAdvert == null)
            {
                return BadRequest();
            }

            myAdvert.Account.Advert.Remove(myAdvert);
            context.ImagesSet.RemoveRange(myAdvert.Images);
            context.AdvertSet.Remove(myAdvert);
        
            context.SaveChangesAsync();
            return Ok();
        }
    }
}