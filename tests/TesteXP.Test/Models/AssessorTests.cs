using TesteXP.Models;
using Xunit;

namespace TesteXP.Test.Models
{
    public class AssessorTests
    {
        [Fact]
        public void DeveTerToStringValido()
        {
            var codigo = 10u;
            var nome = "João Silva";
            var toStringEsperado = $"[{codigo:000}] {nome}";

            var assessor = new Assessor(codigo, nome);

            Assert.Equal(toStringEsperado, assessor.ToString());
        }
    }
}
