using Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserInsertModel : BaseModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Sobrenome { get; set; } = "";
        public int Role { get; set; } = 0;
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;


        public ModelValidated isValid()
        {
            bool valid = true;
            string message = "";

            isNullOrEmpty(this.Email, "Email", out valid, ref message);
            isNullOrEmpty(this.Password, "Password", out valid, ref message);
            isNullOrEmpty(this.Nome, "Password", out valid, ref message);
            isNullOrEmpty(this.Sobrenome, "Sobrenome", out valid, ref message);

            return new ModelValidated(){ Valid = valid, Message = message };
        }

    }
}
