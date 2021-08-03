namespace Binarium.AppServices
{
    internal class BinaryStringService : IBinaryStringService
    {
        public bool CheckForBeingGood(string input)
        {
            // Empty string is not a binary string by definition
            if (string.IsNullOrEmpty(input))
                return false;

            // The number of 0's is definitely not equal to the number of 1's.
            if (input.Length % 2 == 1)
                return false;

            var numberBalance = 0;

            for (var i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '1': numberBalance++; break;
                    case '0': numberBalance--; break;
                    default: return false;
                }

                if (numberBalance < 0)
                    return false;
            }

            if (numberBalance != 0)
                return false;

            return true;
        }
    }
}
