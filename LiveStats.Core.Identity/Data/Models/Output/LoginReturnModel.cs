using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Identity.Data.Models.Output
{
    public class LoginReturnModel
    {
        public bool Success { get; set; }

        public string? Token { get; set; }
    }
}
