using System;
using System.Collections.Generic;

#nullable disable

namespace WorkShop.Web.Model
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public string Category { get; set; }


    }
}
