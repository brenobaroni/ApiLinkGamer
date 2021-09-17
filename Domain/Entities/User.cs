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

        public string? Password { get; set; } = "";

        public string Nome { get; set; } = "";

        public string Sobrenome { get; set; } = "";

        public int Role { get; set; }

        public bool Ativo { get; set; }

    }
}
