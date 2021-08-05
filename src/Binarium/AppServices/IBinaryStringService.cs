using Binarium.Models;

namespace Binarium.AppServices
{
    public interface IBinaryStringService
    {
        CheckResultModel CheckForBeingGood(string input);
    }
}
