﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShopMall.Models.ShopMallDBModels
{
    public class Good
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

        public Good()
        {
            Amount = 0;
            Images = new List<Image>();
            Categories = new List<Category>();
            Discounts = new List<Discount>();
            Shops = new List<RelShopGood>();
        }
    }
}