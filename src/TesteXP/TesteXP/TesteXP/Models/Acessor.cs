namespace TesteXP.Models
{
    public class Acessor
    {
        public Acessor(uint codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public uint Codigo { get; set; }
        public string Nome { get; set; }
    }
}
