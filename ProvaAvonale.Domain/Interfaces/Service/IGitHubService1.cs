using ProvaAvonale.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaAvonale.Domain.Interfaces.Service
{
    public interface IGitHubService1
    {
        Task<string> ListarRepositoriosPublicos();
        IEnumerable<Repositorio> ListarRepositoriosUsuario(Usuario usuario);
        Repositorio ObterRepositorioUsuario(Usuario usuario);
        IEnumerable<Contribuidor> ObterCollaboradoresRepositorio(Usuario usuario);
    }
}
