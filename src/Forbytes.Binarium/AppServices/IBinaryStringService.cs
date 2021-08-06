using Forbytes.Binarium.Models;

namespace Forbytes.Binarium.AppServices
{
    public interface IBinaryStringService
    {
        CheckResultModel CheckForBeingGood(string input);
    }
}
