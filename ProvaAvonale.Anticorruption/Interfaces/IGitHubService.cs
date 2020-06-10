using ProvaAvonale.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaAvonale.Anticorruption.Interfaces
{
    public interface IGitHubService
    {
        Task<IEnumerable<Repositorio>> ListarRepositoriosPublicos();
        IEnumerable<Repositorio> ListarRepositoriosUsuario(Usuario usuario);
        Repositorio ObterRepositorioUsuario(Usuario usuario);
        IEnumerable<Contribuidor> ObterCollaboradoresRepositorio(Usuario usuario);
    }
}
