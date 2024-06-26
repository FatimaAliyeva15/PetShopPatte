using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class Category : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string? CategoryIcon { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }
}
