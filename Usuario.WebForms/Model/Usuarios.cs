using System;

namespace Usuario.WebForms.Model
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}