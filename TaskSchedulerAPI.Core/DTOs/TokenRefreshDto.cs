using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class TokenRefreshDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
