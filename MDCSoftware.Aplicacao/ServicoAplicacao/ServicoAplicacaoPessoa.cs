using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Aplicacao.Cartao;
using MDCSoftware.Aplicacao.ServicoAplicacao.Interface;
using MDCSoftware.Dominio.Cartao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Aplicacao.ServicoAplicacao
{
    class ServicoAplicacaoPessoa : IServicoAplicacaoPessoa
    {
        private readonly IAplicacaoPessoa aplicacao;

        public ServicoAplicacaoPessoa(IAplicacaoPessoa aplicacao)
        {
            this.aplicacao = aplicacao;
        }

        public void Adicionar(DadosPessoa entidade)
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = entidade.Nome,
                CarteiraIdentidade = entidade.CarteiraIdentidade,
                CPF = entidade.CPF,
                DataNascimento = entidade.DataNascimento,
                Foto = entidade.Foto
            };

            aplicacao.Adicionar(pessoa);
        }

        public async void Atualizar(DadosPessoa entidade)
        {
            try
            {
                Pessoa pessoa = await aplicacao.ObterPorId(entidade.IdPessoa);

                pessoa.Nome = entidade.Nome;
                pessoa.CarteiraIdentidade = entidade.CarteiraIdentidade;
                pessoa.CPF = entidade.CPF;
                pessoa.DataNascimento = entidade.DataNascimento;
                pessoa.Foto = entidade.Foto;

                aplicacao.Atualizar(pessoa);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(entidade.IdPessoa))
                {
                    throw new ArgumentException("Cadastro não encontrado");
                }
                else
                {
                    throw;
                }
            }
            //await RepositorioPessoa.SaveChangesAsync();
        }

        private bool PessoaExists(int id)
        {
            var pessoa = aplicacao.ObterPorId(id);
            return pessoa != null;
        }

        public async Task<DadosPessoa> ObterPorId(int id)
        {
            Pessoa pessoa = await aplicacao.ObterPorId(id);

            DadosPessoa dados = new DadosPessoa()
            {
                CarteiraIdentidade = pessoa.CarteiraIdentidade,
                CPF = pessoa.CPF,
                DataNascimento = pessoa.DataNascimento,
                Foto = pessoa.Foto,
                IdPessoa = pessoa.IdPessoa,
                Nome = pessoa.Nome
            };

            return dados;
        }

        public async Task<IEnumerable<DadosPessoa>> ObterTodos()
        {
            IEnumerable<Pessoa> listaPessoa = await aplicacao.ObterTodos();
            IList<DadosPessoa> listaDadosPessoa = new List<DadosPessoa>();

            foreach (var pessoa in listaPessoa)
            {
                DadosPessoa dados = new DadosPessoa()
                {
                    CarteiraIdentidade = pessoa.CarteiraIdentidade,
                    CPF = pessoa.CPF,
                    DataNascimento = pessoa.DataNascimento,
                    Foto = pessoa.Foto,
                    IdPessoa = pessoa.IdPessoa,
                    Nome = pessoa.Nome
                };

                listaDadosPessoa.Add(dados);
            }

            return listaDadosPessoa;
        }

        public void Remover(DadosPessoa entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
