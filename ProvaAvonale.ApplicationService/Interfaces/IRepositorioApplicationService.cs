using ProvaAvonale.Domain.Entities;
using ProvaAvonale.Domain.Entities.Auxiliar;
using System.Threading.Tasks;

namespace ProvaAvonale.ApplicationService.Interfaces
{
    public interface IRepositorioApplicationService : IApplicationServiceBase<Repositorio>
    {
        Task<Response> ListarRepositoriosPublicos();
        Task<Response> ListarRepositoriosUsuario(string userName);
        Task<Response> PesquisarRepositoriosPorNome(string nome);
        Task<Response> ObterRepositoriosPorId(int id);
    }
}
