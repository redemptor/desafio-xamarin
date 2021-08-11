using System.Collections.Generic;
using System.Threading.Tasks;
using TesteXP.Models;

namespace TesteXP.Services
{
    public interface IServicoDeHistorico
    {
        IEnumerable<Ordem> ObterOrdens();
    }
}
