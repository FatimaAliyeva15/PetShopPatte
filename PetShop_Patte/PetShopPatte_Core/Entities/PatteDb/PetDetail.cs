using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class PetDetail: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Age { get; set; }
        public decimal Price { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }
        public int? PetId { get; set; }
        public Pet Pet { get; set; }
        public string? ImgUrl { get; set; }
    }
}
