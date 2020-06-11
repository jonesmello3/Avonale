using System.Configuration;

namespace ProvaAvonale.Domain.Utils
{
    public class DiretorioVirtual
    {
        #region Variável
        private static readonly string dv = ConfigurationManager.AppSettings[nameof(DiretorioVirtual)];
        #endregion

        #region Output
        public static string ObterDiretorioVirtual(bool caminhoAbsoluto = true)
        {
            return (caminhoAbsoluto)
                ? System.Web.Hosting.HostingEnvironment.MapPath($"~{dv}/")
                : $"{dv}/";
        }
        #endregion
    }
}
