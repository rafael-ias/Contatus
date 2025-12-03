using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Requests
{
    public abstract class PagedRequest : Request
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
