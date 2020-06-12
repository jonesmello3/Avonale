using ProvaAvonale.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaAvonale.Domain.Interfaces.Service
{
    public interface IRepositorioService : IServiceBase<Repositorio>
    {
        Task<List<Repositorio>> ListarRepositoriosPublicos();
        Task<IEnumerable<Repositorio>> PesquisarRepositoriosPorNome(string nome);
        Task<IEnumerable<Repositorio>> ListarRepositoriosUsuario(string userName);
        Task<Repositorio> ObterRepositorioPorId(int id);
        Task<Repositorio> AdicionarRepositorioAosFavoritos(int id);
        IEnumerable<Repositorio> MostrarFavoritos();
        void RemoverFavoritos(int id);
    }
}
