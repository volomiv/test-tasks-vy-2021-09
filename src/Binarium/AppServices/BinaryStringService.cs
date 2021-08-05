using Binarium.Models;

namespace Binarium.AppServices
{
    internal class BinaryStringService : IBinaryStringService
    {
        public CheckResultModel CheckForBeingGood(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new CheckResultModel
                {
                    Code = (int)BinaryStringTypes.Empty,
                    Description = "Empty string is not a binary string by definition."
                };

            if (input.Length % 2 == 1)
                return new CheckResultModel
                {
                    Code = (int)BinaryStringTypes.ZeroOneInequality,
                    Description = "The number of 0's is definitely not equal to the number of 1's."
                };

            var numberBalance = 0;

            for (var i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '1': numberBalance++; break;
                    case '0': numberBalance--; break;
                    default:
                        return new CheckResultModel
                        {
                            Code = (int)BinaryStringTypes.NotBinary,
                            Description = "String contains not only 0's and/or 1's."
                        };
                }

                if (numberBalance < 0)
                    return new CheckResultModel
                    {
                        Code = (int)BinaryStringTypes.PrefixWithOneLessZero,
                        Description = "Some prefix has the number of 1's less that the number of 0's."
                    };
            }

            if (numberBalance != 0)
                return new CheckResultModel
                {
                    Code = (int)BinaryStringTypes.ZeroOneInequality,
                    Description = "The number of 0's is not equal to the number of 1's."
                };

            return new CheckResultModel
            {
                Code = (int)BinaryStringTypes.Good,
                Description = "The string is good."
            };
        }
    }
}
