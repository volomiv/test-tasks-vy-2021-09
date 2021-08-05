using Binarium.AppServices;
using Binarium.Models;
using Xunit;
using Xunit.Abstractions;

namespace Binarium.UnitTests
{
    public class BinaryStringServiceTests
    {
        private readonly BinaryStringService _binaryStringService = new();
        private readonly ITestOutputHelper _output;

        public BinaryStringServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("110010")]
        [InlineData("10")]
        [InlineData("1100")]
        [InlineData("1011011000")]
        [InlineData("11001011101000")]
        public void CheckForBeingGood_GoodInput_GoodResult(string binaryString)
        {
            // Act
            var result = _binaryStringService.CheckForBeingGood(binaryString);

            // Assert
            Assert.Equal((int)BinaryStringTypes.Good, result.Code);
        }

        [Theory]
        [InlineData("11010")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("101")]
        [InlineData("asdf")]
        [InlineData("10210010")]
        [InlineData("10110001")]
        [InlineData("1010011001")]
        [InlineData("101110010001")]
        public void CheckForBeingGood_BadInput_BadResult(string binaryString)
        {
            // Act
            var result = _binaryStringService.CheckForBeingGood(binaryString);

            _output.WriteLine($"Code: '{(BinaryStringTypes)result.Code}', Reason: '{result.Description}'");

            // Assert
            Assert.NotEqual((int)BinaryStringTypes.Good, result.Code);
        }
    }
}
