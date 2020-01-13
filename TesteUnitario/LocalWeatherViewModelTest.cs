using System;
using System.Threading.Tasks;
using ClimaTempo.Http;
using NUnit.Framework;

namespace TesteUnitario
{
    [TestFixture()]
    public class LocalWeatherViewModelTest
    {

        [Test()]
        public async Task Test_Return_City_isNotNull()
        {

            // Arrange
            var local = await ServiceHttp.GetCity(-23.620635, -46.607222).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(local);

        }

        [Test()]
        public async Task Test_Return_City_equals_sao_paulo()
        {

            // Arrange
            var local = await ServiceHttp.GetCity(-23.620635, -46.607222).ConfigureAwait(false);

            //Act
            var very_local = "São Paulo";

            // Assert
            Assert.AreSame(local, very_local);

        }
    }
}


