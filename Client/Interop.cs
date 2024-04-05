using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
