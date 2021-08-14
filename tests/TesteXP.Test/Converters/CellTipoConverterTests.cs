using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXP.Converters;
using TesteXP.Enums;
using Xunit;

namespace TesteXP.Test.Converters
{
    public class CellTipoConverterTests
    {
        [Fact]
        public void DeveRetornarInicialQuandoEnumTipo()
        {
            var conversor = new CellTipoConverter();

            var valor = conversor.Convert(EnumTipo.Venda, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal("V", valor);
        }

        [Fact]
        public void DeveRetornarTracoQuantoNaoEnumTipo()
        {
            var conversor = new CellTipoConverter();

            var valor = conversor.Convert(null, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.Equal("-", valor);
        }

        [Fact]
        public void DeveRetornarExceptionNaConversaoDeVolta()
        {
            var conversor = new CellTipoConverter();

            Assert.Throws<NotImplementedException>(() => conversor.ConvertBack("-", typeof(int), null, CultureInfo.CurrentCulture));
        }
    }
}
