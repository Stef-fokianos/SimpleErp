using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleErp.Data
{
    public class User : Person
    {
        public bool IsAdmin { get; set; } = false;

    }
}
