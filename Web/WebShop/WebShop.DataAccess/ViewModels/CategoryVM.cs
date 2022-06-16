﻿using WebShop.Models;

namespace WebShop.DataAccess.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; } = new Category();

        public IEnumerable<Category> categories { get; set; } = new List<Category>();
    }
}
