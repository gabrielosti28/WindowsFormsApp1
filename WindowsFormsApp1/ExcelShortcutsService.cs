using System.Collections.Generic;
using System.Linq;
using AppInterno.Models;

namespace AppInterno.Services
{
    /// <summary>
    /// Serviço responsável por fornecer atalhos do Excel
    /// VERSÃO REFATORADA: Usa JSON ao invés de código hardcoded
    /// </summary>
    public class ExcelShortcutsService : IShortcutsService
    {
        private List<ShortcutItem> shortcuts;

        public ExcelShortcutsService()
        {
            // Carrega atalhos do arquivo JSON
            LoadShortcutsFromJson();
        }

        private void LoadShortcutsFromJson()
        {
            try
            {
                // Carrega do arquivo JSON embarcado
                shortcuts = DataService.LoadData<ShortcutItem>("excel_shortcuts.json");

                // Se não encontrou nenhum, usa fallback
                if (shortcuts == null || shortcuts.Count == 0)
                {
                    shortcuts = GetFallbackShortcuts();
                }
            }
            catch
            {
                // Em caso de erro, usa dados hardcoded como fallback
                shortcuts = GetFallbackShortcuts();
            }
        }

        public List<ShortcutItem> GetAllShortcuts()
        {
            return shortcuts;
        }

        public List<ShortcutItem> SearchShortcuts(string query)
        {
            query = query.ToLower();
            return shortcuts.Where(s =>
                s.Title.ToLower().Contains(query) ||
                s.Description.ToLower().Contains(query) ||
                s.Keys.ToLower().Contains(query) ||
                s.Category.ToLower().Contains(query)
            ).ToList();
        }

        public List<ShortcutItem> GetByCategory(string category)
        {
            return shortcuts.Where(s => s.Category == category).ToList();
        }

        public int GetTotalCount()
        {
            return shortcuts.Count;
        }

        public List<string> GetCategories()
        {
            return shortcuts.Select(s => s.Category).Distinct().OrderBy(c => c).ToList();
        }

        public ProgramInfo GetProgramInfo()
        {
            return new ProgramInfo
            {
                Id = "excel",
                DisplayName = "Excel",
                Description = "Atalhos para planilhas",
                Icon = "📊",
                ColorHex = "#217346",
                TotalShortcuts = GetTotalCount(),
                IsAvailable = true,
                DisplayOrder = 2
            };
        }

        public string GetProgramName()
        {
            return "Excel";
        }

        /// <summary>
        /// Dados de fallback caso o JSON não carregue
        /// Mantém alguns atalhos essenciais hardcoded
        /// </summary>
        private List<ShortcutItem> GetFallbackShortcuts()
        {
            return new List<ShortcutItem>
            {
                new ShortcutItem
                {
                    Id = "excel_tab",
                    Program = "Excel",
                    Title = "Mover para célula à direita",
                    Description = "Vai para a próxima célula à direita",
                    Keys = "Tab",
                    Category = "Navegação Básica",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_enter",
                    Program = "Excel",
                    Title = "Mover para baixo",
                    Description = "Vai para a célula abaixo",
                    Keys = "Enter",
                    Category = "Navegação Básica",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_c",
                    Program = "Excel",
                    Title = "Copiar",
                    Description = "Copia as células selecionadas",
                    Keys = "Ctrl + C",
                    Category = "Edição",
                    PopularityScore = 5,
                    RequiresMouse = false
                }
            };
        }
    }
}