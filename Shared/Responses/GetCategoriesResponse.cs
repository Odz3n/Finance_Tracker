using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class GetCategoriesResponse : Response
    {
        public override ResponseType? Type => ResponseType.GetCategories;
        public List<CategoryDTO> Categories { get; set; }
    }
}
