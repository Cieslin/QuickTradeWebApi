using QuickTrade.Models;
using QuickTrade.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickTrade.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Advert, AdvertDTO>();
                cfg.CreateMap<AdvertDTO, Advert>();
                cfg.CreateMap<Images, ImagesDTO>();
                cfg.CreateMap<ImagesDTO, Images>();
            });
        }
    }
}