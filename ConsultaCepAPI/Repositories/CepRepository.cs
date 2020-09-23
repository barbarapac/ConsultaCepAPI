using ConsultaCepAPI.DataBase;
using ConsultaCepAPI.Models;
using ConsultaCepAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCepAPI.Repositories
{
    public class CepRepository : ICepRepository
    {
        private readonly ConsultaCepAPIContext _Context;

        public CepRepository(ConsultaCepAPIContext context)
        {
            _Context = context;
        }

        public IEnumerable<CEP> Ceps => Context.Ceps.ToList();

        public ConsultaCepAPIContext Context => _Context;

        public void ExcluirCep(CEP cep)
        {
            try
            {
                Context.Ceps.Remove(cep);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir o CEP. Tente novamente.");
            }
        }

        public CEP GetByID(int ID)
        {
            try
            {
                return Context.Ceps.FirstOrDefault(e => e.Id == ID);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao listar o CEP. Tente novamente.");
            }
        }

        public void SalvarCep(CEP cep)
        {
            try
            {
                Context.Ceps.Add(cep);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao tentar salvar o CEP. Tente novamente.");
            }
        }
    }
}
