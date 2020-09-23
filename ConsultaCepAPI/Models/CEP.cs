using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCepAPI.Models
{
    public class CEP
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public long Ibge { get; set; }
        public string Gia { get; set; }
        public long Ddd { get; set; }
        public long Siafi { get; set; }
    }
}
