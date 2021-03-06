﻿using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopMall.Models.ShopMallDBModels;

namespace ShopMall.ViewModels.Manage
{
    public class CreateEditGoodViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара (от 3 до 100 символов)")]
        [StringLength(100, ErrorMessage = "Введите название товара (от 3 до 100 символов)", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание (от 6 до 3000 символов)")]
        [StringLength(3000, ErrorMessage = "Введите описание (от 6 до 3000 символов)", MinimumLength = 6)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберете категорию")]
        [StringLength(100, ErrorMessage = "Выберете категорию", MinimumLength = 5)]
        public string Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Image> Images { get; set; }
        public byte[] Image { get; set; } 
    }
}
