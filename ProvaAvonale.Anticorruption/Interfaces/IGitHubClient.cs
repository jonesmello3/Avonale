using ProvaAvonale.Domain.Entities;
using RestEase;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProvaAvonale.Anticorruption.Interfaces
{
    [Header("User-Agent", "TeamScreen")]//GitHub requires user-agent
    public interface IGitHubClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("/repos/{owner}/{repo}/commits")]
        Task<Repositorio> ObterRepositorioPorUsuario([Path] string owner, [Path] string repo);

        [Get("/repos/{owner}/{repo}/branches")]
        Task<List<Repositorio>[]> ListarTodosRepositoriosPublicos([Path] string owner, [Path] string repo);
    }
}
