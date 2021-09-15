using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Base
{
    public class ModelValidated
    {
        public bool Valid { get; set; }
        public string Message { get; set; } = "";
    }
}
