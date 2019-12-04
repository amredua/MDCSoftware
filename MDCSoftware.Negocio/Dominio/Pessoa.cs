using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDCSoftware.Negocio.Dominio
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CarteiraIdentidade { get; set; }
        public byte[] Foto { get; set; }
    }
}
