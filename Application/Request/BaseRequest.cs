using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class BaseRequest
    {
        public BaseRequest()
        {
            Page = new PagedRequest();
        }

        public PagedRequest Page { get; set; }
    }
}
