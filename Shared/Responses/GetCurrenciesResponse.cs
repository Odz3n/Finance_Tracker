using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class GetCurrenciesResponse : Response
    {
        public override ResponseType? Type => ResponseType.GetCurrencies;
        public List<CurrencyDTO>? Currencies { get; set; }
    }
}
