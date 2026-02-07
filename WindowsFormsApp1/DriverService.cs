using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;
using System.Drawing;

namespace AppInterno
{
    public class DriverService
    {
        public DriverAnalysisResult AnalyzeAllDrivers(List<DriverInfo> drivers)
        {
            var result = new DriverAnalysisResult
            {
                TotalDrivers = drivers.Count,
                DriversOK = drivers.Count(d => d.Status == "OK"),
                DriversOutdated = drivers.Count(d => d.Status == "Desatualizado"),
                DriversWithProblems = drivers.Count(d => d.Status == "Problema"),
                DriversMissing = drivers.Count(d => d.Status == "Ausente")
            };

            // Calcular saúde geral
            if (result.DriversWithProblems > 0 || result.DriversMissing > 0)
            {
                result.OverallHealth = "Crítico";
                result.HealthDescription = "Seu computador tem problemas que precisam de atenção urgente!";
                result.HealthColor = Color.FromArgb(220, 53, 69);
            }
            else if (result.DriversOutdated > 3)
            {
                result.OverallHealth = "Precisa Atenção";
                result.HealthDescription = "Alguns drivers estão desatualizados. Atualizar pode melhorar o desempenho.";
                result.HealthColor = Color.FromArgb(255, 193, 7);
            }
            else if (result.DriversOutdated > 0)
            {
                result.OverallHealth = "Bom";
                result.HealthDescription = "Tudo funcionando bem, mas há algumas atualizações disponíveis.";
                result.HealthColor = Color.FromArgb(40, 167, 69);
            }
            else
            {
                result.OverallHealth = "Excelente";
                result.HealthDescription = "Parabéns! Todos os drivers estão atualizados e funcionando perfeitamente.";
                result.HealthColor = Color.FromArgb(40, 167, 69);
            }

            return result;
        }

        public List<DriverInfo> GetAllDrivers()
        {
            var drivers = new List<DriverInfo>();

            try
            {
                // Buscar dispositivos PnP (Plug and Play)
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPSignedDriver");

                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        string deviceName = obj["DeviceName"]?.ToString();
                        string driverVersion = obj["DriverVersion"]?.ToString();

                        // Ignorar dispositivos sem nome ou driver
                        if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(driverVersion))
                            continue;

                        // Ignorar drivers do sistema que não precisam atualização
                        if (IsSystemDriver(deviceName))
                            continue;

                        DateTime? driverDate = null;
                        string driverDateStr = obj["DriverDate"]?.ToString();
                        if (!string.IsNullOrEmpty(driverDateStr) && driverDateStr.Length >= 8)
                        {
                            // Formato: 20231015000000.000000+000
                            string year = driverDateStr.Substring(0, 4);
                            string month = driverDateStr.Substring(4, 2);
                            string day = driverDateStr.Substring(6, 2);
                            driverDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                        }

                        var driver = new DriverInfo
                        {
                            DeviceName = deviceName,
                            Category = CategorizeDevice(deviceName),
                            DriverVersion = driverVersion,
                            DriverProvider = obj["DriverProviderName"]?.ToString() ?? "Desconhecido",
                            DriverDate = driverDate,
                            IsSigned = obj["IsSigned"]?.ToString() == "True",
                            Priority = GetDriverPriority(deviceName)
                        };

                        // Calcular idade do driver
                        if (driverDate.HasValue)
                        {
                            driver.DaysOld = (DateTime.Now - driverDate.Value).Days;
                        }

                        // Analisar status do driver
                        AnalyzeDriverStatus(driver);

                        // Adicionar URL de atualização
                        driver.UpdateUrl = GetUpdateUrl(driver);

                        drivers.Add(driver);
                    }
                    catch (Exception)
                    {
                        // Ignorar drivers com erro na leitura
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                drivers.Add(new DriverInfo
                {
                    DeviceName = "Erro ao coletar drivers",
                    Status = "Erro",
                    StatusDescription = ex.Message
                });
            }

            // Ordenar por prioridade e status
            return drivers.OrderBy(d => d.Priority)
                         .ThenBy(d => d.Status == "OK" ? 1 : 0)
                         .ToList();
        }

        private bool IsSystemDriver(string deviceName)
        {
            string[] systemDrivers = {
        "Microsoft", "Windows", "Generic", "Standard",
        "Composite", "Root", "System", "Plug and Play",
        "Impressora", "Printer", "HID", "Human Interface"
    };

            // CORREÇÃO: usar ToLower() e depois Contains normal
            string lowerName = deviceName.ToLower();
            return systemDrivers.Any(s => lowerName.Contains(s.ToLower()));
        }

        private string CategorizeDevice(string deviceName)
        {
            string name = deviceName.ToLower();

            // Placa de Vídeo
            if ((name.Contains("nvidia") || name.Contains("amd") || name.Contains("intel")) &&
                (name.Contains("graphics") || name.Contains("display") || name.Contains("video")))
                return "🎮 Placa de Vídeo";

            // Áudio
            if (name.Contains("audio") || name.Contains("sound") || name.Contains("realtek audio"))
                return "🔊 Áudio";

            // Rede
            if (name.Contains("network") || name.Contains("ethernet") || name.Contains("wi-fi") ||
                name.Contains("wifi") || name.Contains("wireless"))
                return "🌐 Rede";

            // Armazenamento
            if (name.Contains("storage") || name.Contains("sata") || name.Contains("nvme") ||
                name.Contains("disk") || name.Contains("ssd"))
                return "💾 Armazenamento";

            // Chipset
            if (name.Contains("chipset") || name.Contains("pci") || name.Contains("host bridge"))
                return "🔌 Chipset";

            // Controladores USB
            if (name.Contains("usb") || name.Contains("controller"))
                return "🔧 Controladores";

            // Bluetooth
            if (name.Contains("bluetooth"))
                return "📡 Bluetooth";

            // Câmera
            if (name.Contains("camera") || name.Contains("webcam"))
                return "📷 Câmera";

            return "⚙️ Outros";
        }

        private DriverPriority GetDriverPriority(string deviceName)
        {
            string name = deviceName.ToLower();

            // Críticos: GPU, Chipset, Storage
            if (name.Contains("nvidia") || name.Contains("amd radeon") ||
                name.Contains("intel graphics") || name.Contains("chipset") ||
                name.Contains("nvme") || name.Contains("sata"))
                return DriverPriority.Critical;

            // Importantes: Rede, Áudio
            if (name.Contains("network") || name.Contains("ethernet") ||
                name.Contains("wi-fi") || name.Contains("audio"))
                return DriverPriority.Important;

            return DriverPriority.Normal;
        }

        private void AnalyzeDriverStatus(DriverInfo driver)
        {
            // Verificar se está assinado
            if (!driver.IsSigned)
            {
                driver.Status = "Problema";
                driver.StatusDescription = "Driver não assinado digitalmente";
                driver.Recommendation = "⚠️ Este driver não possui assinatura digital. Recomendamos instalar um driver oficial do fabricante.";
                driver.FriendlyExplanation = "Um driver assinado é mais seguro e confiável. Drivers não assinados podem causar problemas.";
                return;
            }

            // Verificar idade do driver
            if (driver.DaysOld > 730) // Mais de 2 anos
            {
                driver.Status = "Desatualizado";
                driver.StatusDescription = $"Driver muito antigo ({driver.DaysOld / 365} anos)";
                driver.Recommendation = $"🔄 Este driver tem mais de 2 anos. Atualizar pode melhorar significativamente o desempenho e corrigir problemas.";
                driver.FriendlyExplanation = "Drivers antigos podem não funcionar bem com programas novos e podem estar mais lentos.";
                return;
            }
            else if (driver.DaysOld > 365) // Mais de 1 ano
            {
                driver.Status = "Desatualizado";
                driver.StatusDescription = $"Driver desatualizado ({driver.DaysOld} dias)";
                driver.Recommendation = $"📅 Recomendamos verificar se há uma versão mais nova disponível.";
                driver.FriendlyExplanation = "Uma atualização pode trazer melhorias de velocidade e novos recursos.";
                return;
            }

            // Driver OK
            driver.Status = "OK";
            driver.StatusDescription = "Funcionando corretamente";
            driver.Recommendation = "✅ Este driver está atualizado e funcionando bem.";
            driver.FriendlyExplanation = "Tudo certo! Este componente está funcionando perfeitamente.";
        }

        private string GetUpdateUrl(DriverInfo driver)
        {
            string name = driver.DeviceName.ToLower();
            string provider = driver.DriverProvider.ToLower();

            // NVIDIA
            if (name.Contains("nvidia") || provider.Contains("nvidia"))
                return "https://www.nvidia.com/Download/index.aspx";

            // AMD
            if (name.Contains("amd") || name.Contains("radeon") || provider.Contains("amd"))
                return "https://www.amd.com/pt/support";

            // Intel
            if (name.Contains("intel") || provider.Contains("intel"))
                return "https://www.intel.com/content/www/us/en/download-center/home.html";

            // Realtek (Audio e Rede)
            if (name.Contains("realtek") || provider.Contains("realtek"))
                return "https://www.realtek.com/en/downloads";

            // Broadcom (Rede)
            if (name.Contains("broadcom") || provider.Contains("broadcom"))
                return "https://www.broadcom.com/support/download-search";

            // Dell
            if (provider.Contains("dell"))
                return "https://www.dell.com/support/home/pt-br";

            // HP
            if (provider.Contains("hp") || provider.Contains("hewlett"))
                return "https://support.hp.com/br-pt/drivers";

            // Lenovo
            if (provider.Contains("lenovo"))
                return "https://support.lenovo.com/br/pt/";

            // Genérico - Windows Update
            return "ms-settings:windowsupdate";
        }
    }
}