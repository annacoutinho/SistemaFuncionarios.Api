using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFuncionarios.Api.Models;
using SistemaFuncionarios.Data.Entities;
using SistemaFuncionarios.Data.Repositories;

namespace SistemaFuncionarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post(FuncionariosPostModel model)
        {
            try
            {
                var funcionario = new Funcionario();

                funcionario.Nome = model.Nome;
                funcionario.Cpf = model.Cpf;
                funcionario.Matricula = model.Matricula;
                funcionario.DataAdmissao = model.DataAdmissao;

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Inserir(funcionario);

                return StatusCode(201, new { mensagem = $"Funcionário{funcionario.Nome}, cadastrado com sucesso" });


            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}"});
               
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionariosPutModel model)
        {
            return Ok();
        }

        [HttpDelete]
        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(Guid idFuncionario)
        {
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FuncionariosGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var Lista = new List<FuncionariosGetModel>();
                var funcionarioRepository = new FuncionarioRepository();
                foreach (var item in funcionarioRepository.consultar())
                {
                    var model = new FuncionariosGetModel();
                    model.IdFuncionario = item.IdFuncionario;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Matricula = item.Matricula;
                    model.DataAdmissao = item.DataAdmissao;
                    model.DataCadastro = item.DataCadastro;
                    model.DataUltimaAlteracao = item.DataUltimaAlteracao;

                    Lista.Add(model);

                }
                return StatusCode(200, Lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idFuncionario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FuncionariosGetModel))]

        public IActionResult GetById(Guid idFuncionario)
        {
            return Ok();
        }
    }
}
