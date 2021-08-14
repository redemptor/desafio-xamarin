using System.Collections.Generic;
using System.Threading.Tasks;
using TesteXP.Models;

namespace TesteXP.Services
{
    public interface IServicoDeHistorico
    {
        /// <summary>
        /// Obtem ordens ainda não processadas pela aplicação;
        /// </summary>
        /// <returns>Lista de novas ordens ou ordens atualizadas desde a ultama busca.</returns>
        IEnumerable<Ordem> ObterOrdensNaoProcessadas();

        /// <summary>
        /// Obtem todas as ordens.
        /// </summary>
        /// <returns>Lista de ordens.</returns>
        IEnumerable<Ordem> ObterTodasAsOrdens();
    }
}
