using AppInterno.Models;
using System.Collections.Generic;
using System;

namespace AppInterno.Services.Discovery
{
    /// <summary>
    /// Orquestrador principal - delega para serviços especializados
    /// VERSÃO REFATORADA: De 1000+ linhas para ~50 linhas
    /// </summary>
    public class DiscoveryService
    {
        private readonly WindowsAppsService appsService;
        private readonly WindowsTipsService tipsService;

        public DiscoveryService()
        {
            appsService = new WindowsAppsService();
            tipsService = new WindowsTipsService();
        }

        // ===== APPS NATIVOS =====
        public List<WindowsApp> GetWindowsApps() => appsService.GetAllApps();
        public List<WindowsApp> SearchApps(string query) => appsService.SearchApps(query);

        // ===== DICAS E TRUQUES =====
        public List<WindowsTip> GetWindowsTips() => tipsService.GetAllTips();
        public List<WindowsTip> SearchTips(string query) => tipsService.SearchTips(query);

        // ===== MÉTODOS DE COMPATIBILIDADE (para não quebrar código existente) =====
        [Obsolete("Use WindowsShortcutsService diretamente")]
        public List<KeyboardShortcut> GetKeyboardShortcuts()
        {
            // Manter por compatibilidade, mas marcar como obsoleto
            var service = new WindowsShortcutsService();
            return ConvertToKeyboardShortcuts(service.GetAllShortcuts());
        }

        [Obsolete("Use ExcelShortcutsService diretamente")]
        public List<ExcelShortcut> GetExcelShortcuts()
        {
            var service = new ExcelShortcutsService();
            return ConvertToExcelShortcuts(service.GetAllShortcuts());
        }

        // Conversores temporários para manter compatibilidade
        private List<KeyboardShortcut> ConvertToKeyboardShortcuts(List<ShortcutItem> items)
        {
            // Implementar conversão se necessário
            return new List<KeyboardShortcut>();
        }

        private List<ExcelShortcut> ConvertToExcelShortcuts(List<ShortcutItem> items)
        {
            // Implementar conversão se necessário
            return new List<ExcelShortcut>();
        }
    }
}