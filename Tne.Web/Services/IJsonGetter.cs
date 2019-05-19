using System.Threading.Tasks;

namespace Tne.Web.Services
{
    public interface IJsonGetter
    {
        Task<string> GetAsync(string url);
    }
}