using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POC.NetCore.Model
{
    [Serializable]
    public class Pessoa
    {
        public string Id { get; set; }
   
        public string PrimeiroNome { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Titulo { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
  
        public string Telefone { get; set; }
   
        public string Email { get; set; }
    }

  
}
