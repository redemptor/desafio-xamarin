using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXP.Converters;
using Xunit;

namespace TesteXP.Test.Converters
{
    public class CellNumericaConverterTests
    {
        [Fact]
        public void DeveRetornarProprioValorQuandoMaiorQueZero()
        {
            var conversor = new CellNumericaConverter();
            var valorEsperado = 15;

            var valor = conversor.Convert(valorEsperado, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal(valorEsperado, valor);
        }

        [Fact]
        public void DeveRetornarTracoQuantoZero()
        {
            var conversor = new CellNumericaConverter();

            var valor = conversor.Convert(0, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal("-", valor);
        }

        [Fact]
        public void DeveRetornarZeroQuandoTraco()
        {
            var conversor = new CellNumericaConverter();

            var value = conversor.ConvertBack("-", typeof(int), null, CultureInfo.CurrentCulture);

            Assert.Equal(0, value);
        }
    }
}
