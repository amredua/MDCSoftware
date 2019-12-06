using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Aplicacao.Cartao;
using MDCSoftware.Aplicacao.ServicoAplicacao.Interface;
using MDCSoftware.Dominio.Cartao;
using MDCSoftware.Dominio.UnidadeTrabalho;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDCSoftware.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly Aplicacao.ServicoAplicacao.Interface.IServicoAplicacaoPessoa servicoAplicacao;
        private readonly IUnidadeTrabalho unidadeTrabalho;

        public CartaoController(Aplicacao.ServicoAplicacao.Interface.IServicoAplicacaoPessoa servicoAplicacao,
            IUnidadeTrabalho unidadeTrabalho)
        {
            this.servicoAplicacao = servicoAplicacao;
            this.unidadeTrabalho = unidadeTrabalho;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosPessoa>>> GetPessoa()
        {
            var listaPessoas = await servicoAplicacao.ObterTodos();
            return Ok(listaPessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DadosPessoa>> GetPessoa(int id)
        {
            var pessoa = await servicoAplicacao.ObterPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, DadosPessoa pessoa)
        {
            if (id != pessoa.IdPessoa)
            {
                return BadRequest();
            }

            try
            {
                servicoAplicacao.Atualizar(pessoa);
                await unidadeTrabalho.Commit();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(DadosPessoa dadosPessoa)
        {
            servicoAplicacao.Adicionar(dadosPessoa);
            await unidadeTrabalho.Commit();
            return CreatedAtAction("GetPessoa", new { id = dadosPessoa.IdPessoa }, dadosPessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DadosPessoa>> DeletePessoa(int id)
        {
            var pessoa = await servicoAplicacao.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            servicoAplicacao.Remover(pessoa);
            await unidadeTrabalho.Commit();

            return pessoa;
        }
    }
}