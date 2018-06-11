using QuickTrade.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuickTrade.Interfaces
{
    interface IImages
    {
        //IHttpActionResult AddPhoto(int advertid, string image);
        IHttpActionResult UpdatePhotos(int userid, AdvertDTO advert);
        IHttpActionResult DeletePhoto(int userid, int advertid, int photoid);
        IHttpActionResult ShowAdvertPhoto(ImagesDTO image);
        IEnumerable<ImagesDTO> ShowAdvertPhotos(int userid, int advertid);
    }
}
