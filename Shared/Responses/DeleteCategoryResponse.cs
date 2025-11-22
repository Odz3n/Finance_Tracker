using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class DeleteCategoryResponse : Response
    {
        public override ResponseType? Type => ResponseType.DeleteCategory;
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
