using System.Collections.Generic;
using System.Linq;
using AppInterno.Models;

namespace AppInterno.Services.Discovery
{
    /// <summary>
    /// Serviço especializado para dicas e truques do Windows
    /// </summary>
    public class WindowsTipsService
    {
        private List<WindowsTip> tips;
        private const string JSON_FILE = "windows_tips.json";

        public WindowsTipsService()
        {
            LoadTips();
        }

        private void LoadTips()
        {
            tips = DataService.LoadData<WindowsTip>(JSON_FILE);
        }

        public List<WindowsTip> GetAllTips()
        {
            return tips ?? new List<WindowsTip>();
        }

        public List<WindowsTip> SearchTips(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return GetAllTips();
            }

            query = query.ToLower().Trim();

            return tips.Where(t =>
                (t.Title?.ToLower().Contains(query) ?? false) ||
                (t.ShortDescription?.ToLower().Contains(query) ?? false) ||
                (t.Category?.ToLower().Contains(query) ?? false) ||
                (t.WhyUseful?.ToLower().Contains(query) ?? false)
            ).ToList();
        }

        public List<WindowsTip> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return GetAllTips();
            }

            return tips.Where(t =>
                t.Category?.Equals(category, System.StringComparison.OrdinalIgnoreCase) ?? false
            ).ToList();
        }

        public void Reload()
        {
            DataService.ClearCache(JSON_FILE);
            LoadTips();
        }
    }
}