using System.Threading.Tasks;

namespace MCB.Mobile
{
    public interface IServerCommunication
    {
        Task<string> GetFromServerAsync(string URL);
    }
}
