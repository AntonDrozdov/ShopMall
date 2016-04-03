using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.ViewModels.Manage
{
    public class CreateGoodViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [StringLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000)]
        public int? Amount { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public List<RelShopGood> Shops { get; set; }

        public CreateGoodViewModel()
        {
            Amount = 0;
            Images = new List<Image>();
            Categories = new List<Category>();
            Discounts = new List<Discount>();
            Shops = new List<RelShopGood>();
        }
    }
}
