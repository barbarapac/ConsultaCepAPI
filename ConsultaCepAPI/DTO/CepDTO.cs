namespace ConsultaCepAPI.DTO
{
    public partial class CepDTO
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public long ibge { get; set; }
        public string gia { get; set; }
        public long ddd { get; set; }
        public long siafi { get; set; }
    }
}
