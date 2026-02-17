using System.Collections.Generic;
using System.Linq;

namespace AppInterno.Services
{
    /// <summary>
    /// Serviço de atalhos do Excel - VERSÃO REFATORADA
    /// </summary>
    public class ExcelShortcutsService : IShortcutsService
    {
        private List<ShortcutItem> shortcuts;
        private const string JSON_FILE = "excel_shortcuts.json";

        public ExcelShortcutsService()
        {
            LoadShortcuts();
        }

        private void LoadShortcuts()
        {
            shortcuts = DataService.LoadData<ShortcutItem>(JSON_FILE);

            foreach (var shortcut in shortcuts)
            {
                if (string.IsNullOrEmpty(shortcut.Program))
                {
                    shortcut.Program = "Excel";
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
                (s.Category?.ToLower().Contains(query) ?? false) ||
                (s.PracticalExample?.ToLower().Contains(query) ?? false)
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

        public void Reload()
        {
            DataService.ClearCache(JSON_FILE);
            LoadShortcuts();
        }
    }
}