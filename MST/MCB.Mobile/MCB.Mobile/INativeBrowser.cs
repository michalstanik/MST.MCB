using System.Threading.Tasks;

namespace MCB.Mobile
{
    public interface INativeBrowser
    {
        Task<string> LaunchBrowserAsync(string url);
    }
}
