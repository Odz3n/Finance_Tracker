using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class AddCategoryRequest : Request
    {
        public override RequestType? Type => RequestType.AddCategory;
        public string? Name { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
