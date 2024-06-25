using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.SubcategoryDTO
{
    public class SubcategoryGetDTO
    {
        public int Id { get; set; }
        
        public string SubcategoryName { get; set; }
    }
}
