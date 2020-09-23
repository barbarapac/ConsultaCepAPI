using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsultaCepAPI.DTO;
using ConsultaCepAPI.Models;
using ConsultaCepAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConsultaCepAPI.Controllers
{
    [Produces("application/json", "text/plain")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaCepController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICepRepository _repository;

        public ConsultaCepController(IConfiguration config, ICepRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        /// <summary>
        /// Retona o endereço conforme CEP da pesquisa.
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("BuscaCep/{parm}")]
        public async Task<IActionResult> BuscaCep(string parm)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri urlRequisicao = new Uri(_config.GetSection("Urls").GetSection("ApiCep").Value + parm + "/json");
                HttpResponseMessage responseMessage = await client.GetAsync(urlRequisicao);
                string response = await responseMessage.Content.ReadAsStringAsync();


                List<CepDTO> listaCep = new List<CepDTO>();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    CepDTO cep = JsonConvert.DeserializeObject<CepDTO>(response);

                    if (cep.cep != null)
                    {
                        listaCep.Add(cep);
                        
                        return Ok(listaCep);
                    }
                        return NoContent();
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Litas todos os CEPs salvos na base.
        /// </summary>
        /// <returns></returns>
        [HttpGet("CepsSalvos")]
        public async Task<IActionResult> ListaCeps()
        {
            try
            {
                List<CEP> ceps = (List<CEP>)_repository.Ceps;

                if (ceps != null && ceps.Count > 0)
                    return Ok(ceps);

                return NoContent();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Adiciona CEP a lista de CEPs favoritos.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> RegistrarCepFavorito([FromBody] CEP cep)
        {
            try
            {
                bool cadastrado = false;
                List<CEP> ceps = (List<CEP>)_repository.Ceps;

                foreach (var item in ceps)
                {
                    if (item.Cep.Equals(cep.Cep))
                    {
                        cadastrado = true;
                        break;
                    }
                }

                if (!cadastrado)
                {
                    _repository.SalvarCep(cep);
                    
                    return Ok();
                }

                return UnprocessableEntity("CEP já favoritado!");
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Remove CEP da lista de CEPs da lista de favoritos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCep(int id)
        {
            try
            {

                CEP cEP = _repository.GetByID(id);
                _repository.ExcluirCep(cEP);

                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
