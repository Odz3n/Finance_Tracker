using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class DeleteCategoryRequest : Request
    {
        public override RequestType? Type => RequestType.DeleteCategory;
        public string Name { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
