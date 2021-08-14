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
    public class CellPercentualConverterTests
    {
        [Fact]
        public void DeveRetornarPercentualQuandoMaiorQueZero()
        {
            var conversor = new CellPercentualConverter();

            var valor = conversor.Convert(0.8, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal("80%", valor);
        }

        [Fact]
        public void DeveRetornarTracoQuandoNulo()
        {
            var conversor = new CellPercentualConverter();

            var valor = conversor.Convert(null, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal("-", valor);
        }

        [Fact]
        public void DeveRetornarExceptionNaConversaoDeVolta()
        {
            var conversor = new CellPercentualConverter();

            Assert.Throws<NotImplementedException>(() => conversor.ConvertBack("-", typeof(int), null, CultureInfo.CurrentCulture));
        }
    }
}
