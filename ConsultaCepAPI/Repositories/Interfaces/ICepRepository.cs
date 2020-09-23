using ConsultaCepAPI.Models;
using System.Collections.Generic;

namespace ConsultaCepAPI.Repositories.Interfaces
{
    public interface ICepRepository
    {
        IEnumerable<CEP> Ceps { get; }
        CEP GetByID(int ID);
        void SalvarCep(CEP cep);
        void ExcluirCep(CEP Id);

    }
}
