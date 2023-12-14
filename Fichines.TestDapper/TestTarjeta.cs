using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fichines.TestDapper
{
    public class TestTarjeta
    {
        [Theory]
        [InlineData(1, 12345678)]
        public void TraerTarjeta(smallint idTarjeta, uint DNI, decimal(5_2) saldo)
        {
            var Tarjeta = IAdo.TarjetaPordni(dni);

            Assert.NotNull(tarjeta);
            Assert.Equal<uint>(dni, tarjeta.dni);
        }

        [Theory]
        [InlineData(10, "NoExisto")]
        public void TarjetasNoExisten(uint dni)
        {
            var tarjeta = IAdo.TarjetaPorDNI(dni);

            Assert.Null(Tarjeta);
        }
        [Fact]
        public void AltaTarjeta()
        {
            uint dni = 12345678;
            decimal(5,2) saldo = null;

            var Tarjeta = IAdo.TarjetaPorDNI(dni);

            Assert.Null(Tarjeta);

            var mismaTarjeta = IAdo.TarjetaPorDNI(dni);
            
            Assert.NotNull(mismaTarjeta);
            Assert.Equal(dni, mismoTarjeta.DNi);
            Assert.Equal(saldo, mismaTarjeta.Saldo);
        }
    }
}