using MDCSoftware.Aplicacao.Aplicacao;
using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Dominio.Repositorio;
using MDCSoftware.Dominio.Servico;
using MDCSoftware.Infraestrutura.Repositorio;
using MDCSoftware.Negocio.Infraestrutura.Contexto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MDCSoftware.Dominio.UnidadeTrabalho;
using MDCSoftware.Aplicacao.ServicoAplicacao.Interface;

namespace MDCSoftware.Infraestrutura.IoC
{
    public class InjecaoNativa
    {
        public static void RegistrarServico(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IServicoPessoa, ServicoPessoa>();

            services.AddScoped<Aplicacao.ServicoAplicacao.Interface.IServicoAplicacaoPessoa, Aplicacao.ServicoAplicacao.ServicoAplicacaoPessoa>();

            services.AddScoped(typeof(IAplicacaoBase<>), typeof(AplicacaoBase<>));
            services.AddScoped<IAplicacaoPessoa, AplicacaoPessoa>();

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IRepositorioPessoa, RepositorioPessoa>();
            services.AddScoped<IUnidadeTrabalho, UnidadeTrabalho.UnidadeTrabalho>();

            services.AddScoped<ContextoInfraestrutura>();
        }
    }
}
