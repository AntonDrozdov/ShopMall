using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ShopMall.Models.ShopMallDBModels
{
    public class Image
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public byte[] ImageContent { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public ICollection<Good> Goods { get; set; }

        public Image()
        {
            Goods = new List<Good>();
        }
    }
}
