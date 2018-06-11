using QuickTrade.Interfaces;
using QuickTrade.Models;
using QuickTrade.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;

namespace QuickTrade.Controllers
{
    public class ImagesController : ApiController, IImages
    {

        private QuickTradeModelContainer context = new QuickTradeModelContainer();

        [HttpPost]
        [Route("addphoto/{advertid}")]
        public IHttpActionResult AddPhoto(int advertid)
        {
            byte[] image = Request.Content.ReadAsByteArrayAsync().Result;
            var ad = context.AdvertSet.FirstOrDefault(((a) => a.Id == advertid));

            if (ad == null)
            {
                return BadRequest();
            }

            context.SaveChangesAsync();

            return Ok();
        }

        public IHttpActionResult DeletePhoto(int userid, int advertid, int photoid)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("showphoto")]
        public IHttpActionResult ShowAdvertPhoto(ImagesDTO image)
        {
            int id = Convert.ToInt32(Request.Content.ReadAsStringAsync().Result);
            var data = context.ImagesSet.Where(a => a.Id == id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        public IEnumerable<ImagesDTO> ShowAdvertPhotos(int userid, int advertid)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult UpdatePhotos(int userid, AdvertDTO advert)
        {
            throw new NotImplementedException();
        }
    }
}