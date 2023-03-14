using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Repositories.Data;

namespace RouletteService.Repositories
{
    public interface ISpinRepository
    {
        Task<int> Insert(Spin spin);

    }
}