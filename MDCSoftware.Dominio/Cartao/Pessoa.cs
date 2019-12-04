using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Dominio.Cartao
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
