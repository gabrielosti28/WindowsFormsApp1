using System.Collections.Generic;
using System.Linq;
using AppInterno.Services;

namespace AppInterno
{
    /// <summary>
    /// Serviço de atalhos do Windows - VERSÃO REFATORADA
    /// Usa JSON em vez de dados hardcoded
    /// </summary>
    public class WindowsShortcutsService : IShortcutsService
    {
        private List<ShortcutItem> shortcuts;
        private const string JSON_FILE = "windows_shortcuts.json";

        public WindowsShortcutsService()
        {
            LoadShortcuts();
        }

        private void LoadShortcuts()
        {
            shortcuts = DataService.LoadData<ShortcutItem>(JSON_FILE);

            // Garantir que Program está preenchido
            foreach (var shortcut in shortcuts)
            {
                if (string.IsNullOrEmpty(shortcut.Program))
                {
                    shortcut.Program = "Windows";
                }
            }
        }

        public List<ShortcutItem> GetAllShortcuts()
        {
            return shortcuts ?? new List<ShortcutItem>();
        }

        public List<ShortcutItem> SearchShortcuts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return GetAllShortcuts();
            }

            query = query.ToLower().Trim();

            return shortcuts.Where(s =>
                (s.Title?.ToLower().Contains(query) ?? false) ||
                (s.Description?.ToLower().Contains(query) ?? false) ||
                (s.Keys?.ToLower().Contains(query) ?? false) ||
                (s.Category?.ToLower().Contains(query) ?? false)
            ).ToList();
        }

        public List<ShortcutItem> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return GetAllShortcuts();
            }

            return shortcuts.Where(s =>
                s.Category?.Equals(category, System.StringComparison.OrdinalIgnoreCase) ?? false
            ).ToList();
        }

        public int GetTotalCount()
        {
            return shortcuts?.Count ?? 0;
        }

        public List<string> GetCategories()
        {
            return shortcuts
                .Where(s => !string.IsNullOrEmpty(s.Category))
                .Select(s => s.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public ProgramInfo GetProgramInfo()
        {
            return new ProgramInfo
            {
                Id = "windows",
                DisplayName = "Windows",
                Description = "Atalhos do sistema operacional",
                Icon = "⌨️",
                ColorHex = "#0078D4",
                TotalShortcuts = GetTotalCount(),
                IsAvailable = true,
                DisplayOrder = 1
            };
        }

        public string GetProgramName()
        {
            return "Windows";
        }

        /// <summary>
        /// Recarrega os atalhos do JSON (útil para atualizar dados)
        /// </summary>
        public void Reload()
        {
            DataService.ClearCache(JSON_FILE);
            LoadShortcuts();
        }
    }
}