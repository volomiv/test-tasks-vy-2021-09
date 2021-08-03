using Binarium.AppServices;
using Xunit;

namespace Binarium.UnitTests
{
    public class BinaryStringServiceTests
    {
        private readonly BinaryStringService _binaryStringService = new();

        [Theory]
        [InlineData("110010")]
        [InlineData("10")]
        [InlineData("1100")]
        public void CheckForBeingGood_GoodInput_GoodResult(string binaryString)
        {
            // Act
            var result = _binaryStringService.CheckForBeingGood(binaryString);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("11010")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("101")]
        [InlineData("10210010")]
        [InlineData("10110001")]
        public void CheckForBeingGood_BadInput_BadResult(string binaryString)
        {
            // Act
            var result = _binaryStringService.CheckForBeingGood(binaryString);

            // Assert
            Assert.False(result);
        }
    }
}
