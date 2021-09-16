using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Base
{
    public class BaseModel
    {
        public void isNullOrEmpty(string text, string propName, out bool valid, ref string message)
        {
            valid = !string.IsNullOrEmpty(text);

            if (!valid)
                message = message + $"É obrigatorio informar {propName}.";
        }

        public static bool isNotNull(dynamic propOrObject)
        {
            return propOrObject != null;
        }
    }
}
