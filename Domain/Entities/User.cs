using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string Name { get; set; } = "";

        public string LastName { get; set; } = "";

        public int Role { get; set; }

        public bool Ativo { get; set; }

        User()
        {
            if (Email == null)
                throw new Exception("seta essa porra");
        }
    }
}
