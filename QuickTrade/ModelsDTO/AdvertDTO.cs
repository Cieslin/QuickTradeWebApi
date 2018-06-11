using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickTrade.ModelsDTO
{
    public class AdvertDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Contact { get; set; }
        public string Category { get; set; }
        public System.DateTime DateAdded { get; set; }
        public System.DateTime DateModified { get; set; }

        public virtual ICollection<ImagesDTO> Images { get; set; }
    }
}