using System;
using System.Collections.Generic;
using System.Linq;

namespace AppInterno
{
    /// <summary>
    /// Orquestrador principal - delega para serviços especializados
    /// VERSÃO REFATORADA: De 1000+ linhas para ~50 linhas
    /// </summary>
    public class DiscoveryService
    {
        private readonly WindowsAppsService appsService;
        private readonly WindowsTipsService tipsService;
        private readonly WindowsShortcutsService windowsShortcutsService;
        private readonly ExcelShortcutsService excelShortcutsService;

        public DiscoveryService()
        {
            appsService = new WindowsAppsService();
            tipsService = new WindowsTipsService();
            windowsShortcutsService = new WindowsShortcutsService();
            excelShortcutsService = new ExcelShortcutsService();
        }

        // ===== APPS NATIVOS =====
        public List<WindowsApp> GetWindowsApps() => appsService.GetAllApps();
        public List<WindowsApp> SearchApps(string query) => appsService.SearchApps(query);

        // ===== DICAS E TRUQUES =====
        public List<WindowsTip> GetWindowsTips() => tipsService.GetAllTips();
        public List<WindowsTip> SearchTips(string query) => tipsService.SearchTips(query);

        // ===== ATALHOS DO WINDOWS =====
        public List<KeyboardShortcut> GetKeyboardShortcuts()
        {
            var shortcuts = windowsShortcutsService.GetAllShortcuts();
            return shortcuts.Select(s => new KeyboardShortcut
            {
                Title = s.Title,
                Description = s.Description,
                Keys = s.Keys,
                Category = s.Category,
                DetailedExplanation = s.DetailedExplanation,
                WhenToUse = s.WhenToUse,
                PopularityScore = s.PopularityScore
            }).ToList();
        }

        public List<KeyboardShortcut> SearchShortcuts(string query)
        {
            var shortcuts = windowsShortcutsService.SearchShortcuts(query);
            return shortcuts.Select(s => new KeyboardShortcut
            {
                Title = s.Title,
                Description = s.Description,
                Keys = s.Keys,
                Category = s.Category,
                DetailedExplanation = s.DetailedExplanation,
                WhenToUse = s.WhenToUse,
                PopularityScore = s.PopularityScore
            }).ToList();
        }

        // ===== ATALHOS DO EXCEL =====
        public List<ExcelShortcut> GetExcelShortcuts()
        {
            var shortcuts = excelShortcutsService.GetAllShortcuts();
            return shortcuts.Select(s => new ExcelShortcut
            {
                Title = s.Title,
                Description = s.Description,
                Keys = s.Keys,
                Category = s.Category,
                DetailedExplanation = s.DetailedExplanation,
                WhenToUse = s.WhenToUse,
                PracticalExample = s.PracticalExample,
                PopularityScore = s.PopularityScore,
                RequiresMouse = s.RequiresMouse
            }).ToList();
        }

        public List<ExcelShortcut> SearchExcelShortcuts(string query)
        {
            var shortcuts = excelShortcutsService.SearchShortcuts(query);
            return shortcuts.Select(s => new ExcelShortcut
            {
                Title = s.Title,
                Description = s.Description,
                Keys = s.Keys,
                Category = s.Category,
                DetailedExplanation = s.DetailedExplanation,
                WhenToUse = s.WhenToUse,
                PracticalExample = s.PracticalExample,
                PopularityScore = s.PopularityScore,
                RequiresMouse = s.RequiresMouse
            }).ToList();
        }
    }
}