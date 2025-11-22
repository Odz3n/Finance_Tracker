using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class GetTransactionTypesResponse : Response
    {
        public override ResponseType? Type => ResponseType.GetTransactionTypes;
        public List<TransactionTypeDTO> TransactionTypes { get; set; }
    }
}
