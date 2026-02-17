using System.Collections.Generic;
using System.Linq;

namespace AppInterno
{
    /// <summary>
    /// Serviço especializado para aplicativos nativos do Windows
    /// </summary>
    public class WindowsAppsService
    {
        private List<WindowsApp> apps;
        private const string JSON_FILE = "windows_apps.json";

        public WindowsAppsService()
        {
            LoadApps();
        }

        private void LoadApps()
        {
            apps = DataService.LoadData<WindowsApp>(JSON_FILE);
        }

        public List<WindowsApp> GetAllApps()
        {
            return apps ?? new List<WindowsApp>();
        }

        public List<WindowsApp> SearchApps(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return GetAllApps();
            }

            query = query.ToLower().Trim();

            return apps.Where(a =>
                (a.WhatItDoes?.ToLower().Contains(query) ?? false) ||
                (a.AppName?.ToLower().Contains(query) ?? false) ||
                (a.Category?.ToLower().Contains(query) ?? false)
            ).ToList();
        }

        public List<WindowsApp> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return GetAllApps();
            }

            return apps.Where(a =>
                a.Category?.Equals(category, System.StringComparison.OrdinalIgnoreCase) ?? false
            ).ToList();
        }

        public List<WindowsApp> GetPreInstalledOnly()
        {
            return apps.Where(a => a.IsPreInstalled).ToList();
        }

        public void Reload()
        {
            DataService.ClearCache(JSON_FILE);
            LoadApps();
        }
    }
}