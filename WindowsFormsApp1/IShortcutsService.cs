using System.Collections.Generic;

namespace AppInterno
{
    /// <summary>
    /// Interface comum para todos os serviços de atalhos
    /// Cada programa (Windows, Excel, Word) implementa esta interface
    /// </summary>
    public interface IShortcutsService
    {
        /// <summary>
        /// Retorna todos os atalhos do programa
        /// </summary>
        List<ShortcutItem> GetAllShortcuts();

        /// <summary>
        /// Busca atalhos por termo de pesquisa
        /// </summary>
        /// <param name="query">Termo de busca</param>
        List<ShortcutItem> SearchShortcuts(string query);

        /// <summary>
        /// Filtra atalhos por categoria
        /// </summary>
        /// <param name="category">Nome da categoria</param>
        List<ShortcutItem> GetByCategory(string category);

        /// <summary>
        /// Retorna total de atalhos disponíveis
        /// </summary>
        int GetTotalCount();

        /// <summary>
        /// Retorna lista de categorias disponíveis
        /// </summary>
        List<string> GetCategories();

        /// <summary>
        /// Retorna informações sobre o programa
        /// </summary>
        ProgramInfo GetProgramInfo();

        /// <summary>
        /// Retorna nome do programa (ex: "Windows", "Excel")
        /// </summary>
        string GetProgramName();
    }
}