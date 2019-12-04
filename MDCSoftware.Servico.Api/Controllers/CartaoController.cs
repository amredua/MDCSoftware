using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Aplicacao.Cartao;
using MDCSoftware.Aplicacao.ServicoAplicacao.Interface;
using MDCSoftware.Dominio.Cartao;
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
        private readonly IServicoAplicacaoPessoa servicoAplicacao;

        public CartaoController(IServicoAplicacaoPessoa servicoAplicacao)
        {
            this.servicoAplicacao = servicoAplicacao;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosPessoa>>> GetPessoa()
        {
            var listaPessoas = await servicoAplicacao.ObterTodos();
            return Ok(listaPessoas);
        }

        // GET: api/Pessoas/5
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

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(DadosPessoa dadosPessoa)
        {
            servicoAplicacao.Adicionar(dadosPessoa);
            //await _context.SaveChangesAsync();
            return CreatedAtAction("GetPessoa", new { id = dadosPessoa.IdPessoa }, dadosPessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DadosPessoa>> DeletePessoa(int id)
        {
            var pessoa = await servicoAplicacao.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            servicoAplicacao.Remover(pessoa);
            //await _context.SaveChangesAsync();

            return pessoa;
        }
    }
}