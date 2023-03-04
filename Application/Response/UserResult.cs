using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class UserResult
    {
        public string? Nombres { get; set; }
        public string? UserName { get; set; }
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string? UserId { get; set; }
    }
}
