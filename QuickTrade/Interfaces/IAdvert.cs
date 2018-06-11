using QuickTrade.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuickTrade.Interfaces
{
    interface IAdvert
    {
        IEnumerable<AdvertDTO> GetAllAdverts(); //HttpGet
        IEnumerable<AdvertDTO> GetMyAdverts(AdvertDTO advert); //HttpPost
        IEnumerable<AdvertDTO> GetPaged(int page); //HttpGet
        IHttpActionResult AddAdvert(AdvertDTO advert); //HttpPost
        IHttpActionResult UpdateAdvert(AdvertDTO advert); //HttpPut
        IHttpActionResult DeleteAdvert(AdvertDTO advert); //HttpDelete
    }
}
