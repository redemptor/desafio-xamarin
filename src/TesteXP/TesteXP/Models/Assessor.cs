namespace TesteXP.Models
{
    public class Assessor
    {
        public Assessor(uint codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public uint Codigo { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"[{Codigo:000}] {Nome}";
        }
    }
}
