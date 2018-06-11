using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickTrade.ModelsDTO
{
    public class ImagesDTO
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public byte[] Image { get; set; }
    }
}