using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace AppInterno
{
    public class HardwareService
    {
        public List<HardwareComponent> GetAllHardwareInfo()
        {
            var components = new List<HardwareComponent>();

            components.AddRange(GetProcessorInfo());
            components.AddRange(GetMemoryInfo());
            components.AddRange(GetDiskInfo());
            components.AddRange(GetGraphicsInfo());
            components.AddRange(GetMotherboardInfo());
            components.AddRange(GetNetworkAdapterInfo());
            components.AddRange(GetAudioInfo());
            components.AddRange(GetBiosInfo());
            components.AddRange(GetBatteryInfo());
            components.AddRange(GetMonitorInfo());
            components.AddRange(GetUsbControllersInfo());
            components.AddRange(GetOpticalDriveInfo());
            components.AddRange(GetCoolingInfo());
            components.AddRange(GetSystemInfo());

            return components;
        }

        // =============================================
        // PROCESSADOR - com detecção de geração
        // =============================================
        private List<HardwareComponent> GetProcessorInfo()
        {
            var processors = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string name = obj["Name"]?.ToString() ?? "";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "";
                    int cores = Convert.ToInt32(obj["NumberOfCores"]);
                    int threads = Convert.ToInt32(obj["NumberOfLogicalProcessors"]);
                    uint speed = Convert.ToUInt32(obj["MaxClockSpeed"]);
                    string architecture = GetArchitectureName(Convert.ToInt32(obj["Architecture"]));

                    // Detectar geração e família
                    string generationInfo = DetectProcessorGeneration(name);
                    string performanceClass = ClassifyProcessorPerformance(name, cores);

                    processors.Add(new HardwareComponent
                    {
                        Category = "⚙️ Processador (CPU)",
                        Name = name,
                        Manufacturer = manufacturer,
                        Model = name,
                        Details =
                            $"Núcleos físicos: {cores}\n" +
                            $"Threads (núcleos lógicos): {threads}\n" +
                            $"Velocidade máxima: {speed} MHz ({speed / 1000.0:F1} GHz)\n" +
                            $"Arquitetura: {architecture}\n" +
                            $"Geração detectada: {generationInfo}\n" +
                            $"Classe de desempenho: {performanceClass}",
                        FriendlyExplanation =
                            $"O processador é o 'cérebro' do seu computador — ele executa todos os cálculos e operações.\n\n" +
                            $"📌 SEU PROCESSADOR: {name}\n\n" +
                            $"🔢 O QUE É UMA GERAÇÃO DE PROCESSADOR?\n" +
                            $"Pense assim: assim como celulares lançam modelos novos todo ano (iPhone 13, 14, 15...), " +
                            $"os processadores também têm gerações. Quanto mais nova a geração, mais rápido, eficiente e " +
                            $"econômico é o processador. Uma geração mais nova geralmente significa melhor desempenho " +
                            $"e compatibilidade com tecnologias atuais.\n\n" +
                            $"📊 GERAÇÃO DO SEU PROCESSADOR: {generationInfo}\n\n" +
                            $"💡 O QUE SIGNIFICAM OS NÚCLEOS?\n" +
                            $"Imagine que cada núcleo é um trabalhador. Com {cores} núcleos, seu processador " +
                            $"pode fazer {cores} tarefas ao mesmo tempo. Com {threads} threads, ele consegue ser " +
                            $"ainda mais eficiente, dividindo melhor o trabalho.\n\n" +
                            $"🏆 DESEMPENHO: {performanceClass}",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                processors.Add(CreateErrorComponent("⚙️ Processador (CPU)", ex.Message));
            }

            return processors;
        }

        private string DetectProcessorGeneration(string name)
        {
            if (string.IsNullOrEmpty(name)) return "Não identificada";

            string upper = name.ToUpper();

            // ── INTEL ──────────────────────────────────────────────────────
            if (upper.Contains("INTEL"))
            {
                // Core Ultra (série 200 = Arrow Lake / 15ª gen)
                if (upper.Contains("CORE ULTRA") && (upper.Contains(" 2") || upper.Contains("200")))
                    return "Intel Core Ultra Série 200 (15ª geração, Arrow Lake — Muito recente, 2024)";

                // Core Ultra (série 100 = Meteor Lake / 14ª gen)
                if (upper.Contains("CORE ULTRA"))
                    return "Intel Core Ultra Série 100 (14ª geração, Meteor Lake — Muito recente, 2023-2024)";

                // 14ª geração (Raptor Lake Refresh — sufixo 14xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-1[4-9]\d{3}"))
                    return "Intel 14ª geração (Raptor Lake Refresh — Muito recente, 2023-2024)";

                // 13ª geração (Raptor Lake — sufixo 13xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-13\d{3}"))
                    return "Intel 13ª geração (Raptor Lake — Recente, 2022-2023)";

                // 12ª geração (Alder Lake — sufixo 12xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-12\d{3}"))
                    return "Intel 12ª geração (Alder Lake — Relativamente recente, 2021-2022)";

                // 11ª geração (Rocket Lake / Tiger Lake — sufixo 11xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-11\d{3}"))
                    return "Intel 11ª geração (Rocket Lake / Tiger Lake — 2020-2021)";

                // 10ª geração (Comet Lake / Ice Lake — sufixo 10xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-10\d{3}"))
                    return "Intel 10ª geração (Comet Lake / Ice Lake — 2019-2020)";

                // 9ª geração (Coffee Lake Refresh — sufixo 9xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-9\d{3}"))
                    return "Intel 9ª geração (Coffee Lake Refresh — 2018-2019, um pouco mais antiga)";

                // 8ª geração (Coffee Lake — sufixo 8xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-8\d{3}"))
                    return "Intel 8ª geração (Coffee Lake — 2017-2018, já um pouco datada)";

                // 7ª geração (Kaby Lake — sufixo 7xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-7\d{3}"))
                    return "Intel 7ª geração (Kaby Lake — 2016-2017, bastante antiga)";

                // 6ª geração (Skylake — sufixo 6xxx)
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-6\d{3}"))
                    return "Intel 6ª geração (Skylake — 2015-2016, antiga)";

                // 5ª geração ou mais antigas
                if (System.Text.RegularExpressions.Regex.IsMatch(upper, @"I[3579]-[2-5]\d{3}"))
                    return "Intel 2ª a 5ª geração — Muito antiga (2011-2015), considere atualizar";

                // Celeron / Pentium / Atom / Xeon
                if (upper.Contains("CELERON") || upper.Contains("PENTIUM"))
                    return "Intel Celeron / Pentium — Linha básica para tarefas simples";
                if (upper.Contains("ATOM"))
                    return "Intel Atom — Linha ultrabásica, para dispositivos de baixo consumo";
                if (upper.Contains("XEON"))
                    return "Intel Xeon — Linha profissional para servidores e estações de trabalho";

                return "Intel — Geração não identificada automaticamente";
            }

            // ── AMD ────────────────────────────────────────────────────────
            if (upper.Contains("AMD"))
            {
                // Ryzen 9000 (Granite Ridge / Strix — 2024)
                if (upper.Contains("RYZEN") && upper.Contains("9") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"9[0-9]{3}[A-Z]?"))
                    return "AMD Ryzen 9000 (Granite Ridge — Muito recente, 2024)";

                // Ryzen 7000 (Raphael / Phoenix — 2022-2023)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"7\d{3}[A-Z]?"))
                    return "AMD Ryzen 7000 (Raphael — Recente, 2022-2023)";

                // Ryzen 6000 (Rembrandt — mobile, 2022)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"6\d{3}[A-Z]?"))
                    return "AMD Ryzen 6000 (Rembrandt — Recente, 2022, linha mobile)";

                // Ryzen 5000 (Vermeer / Cezanne — 2020-2021)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"5\d{3}[A-Z]?"))
                    return "AMD Ryzen 5000 (Vermeer / Cezanne — 2020-2021, ainda muito bom)";

                // Ryzen 4000 (Renoir — 2020, mobile)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"4\d{3}[A-Z]?"))
                    return "AMD Ryzen 4000 (Renoir — 2020, linha mobile)";

                // Ryzen 3000 (Matisse / Picasso — 2019)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"3\d{3}[A-Z]?"))
                    return "AMD Ryzen 3000 (Matisse — 2019, um pouco mais antiga)";

                // Ryzen 2000 (Pinnacle Ridge / Raven Ridge — 2018)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"2\d{3}[A-Z]?"))
                    return "AMD Ryzen 2000 (Pinnacle Ridge — 2018, bastante antiga)";

                // Ryzen 1000 (Summit Ridge — 2017)
                if (upper.Contains("RYZEN") && System.Text.RegularExpressions.Regex.IsMatch(upper, @"1\d{3}[A-Z]?"))
                    return "AMD Ryzen 1000 (Summit Ridge — 2017, primeira geração Ryzen, já datada)";

                if (upper.Contains("A4") || upper.Contains("A6") || upper.Contains("A8") || upper.Contains("A10") || upper.Contains("A12"))
                    return "AMD Série A (APU antiga — anterior ao Ryzen, bastante defasada)";

                if (upper.Contains("ATHLON"))
                    return "AMD Athlon — Linha básica/econômica";

                if (upper.Contains("EPYC") || upper.Contains("THREADRIPPER"))
                    return "AMD EPYC / Threadripper — Linha profissional para servidores/workstations";

                return "AMD — Geração não identificada automaticamente";
            }

            // ── Apple Silicon ──────────────────────────────────────────────
            if (upper.Contains("APPLE") || upper.Contains(" M1") || upper.Contains(" M2") || upper.Contains(" M3") || upper.Contains(" M4"))
            {
                if (upper.Contains("M4")) return "Apple M4 — Muito recente (2024), altíssimo desempenho";
                if (upper.Contains("M3")) return "Apple M3 — Recente (2023), excelente desempenho";
                if (upper.Contains("M2")) return "Apple M2 — Relativamente recente (2022), ótimo desempenho";
                if (upper.Contains("M1")) return "Apple M1 — Primeira geração Apple Silicon (2020), ainda muito capaz";
            }

            // ── Qualcomm (ARM para Windows) ────────────────────────────────
            if (upper.Contains("SNAPDRAGON") || upper.Contains("QUALCOMM"))
                return "Qualcomm Snapdragon — Processador ARM para Windows (linha mais recente)";

            return "Fabricante/Geração não identificada automaticamente";
        }

        private string ClassifyProcessorPerformance(string name, int cores)
        {
            if (string.IsNullOrEmpty(name)) return "Não classificado";
            string upper = name.ToUpper();

            // High-end
            if (upper.Contains("I9") || upper.Contains("RYZEN 9") || upper.Contains("THREADRIPPER") ||
                upper.Contains("EPYC") || upper.Contains("XEON") || upper.Contains("CORE ULTRA 9") ||
                upper.Contains("M3 MAX") || upper.Contains("M3 ULTRA") || upper.Contains("M4 MAX"))
                return "🔴 Topo de linha — Ideal para edição de vídeo, jogos pesados e programação profissional";

            // Mid-high
            if (upper.Contains("I7") || upper.Contains("RYZEN 7") || upper.Contains("CORE ULTRA 7") ||
                upper.Contains("M2 PRO") || upper.Contains("M3 PRO") || upper.Contains("M4 PRO") ||
                (cores >= 8 && (upper.Contains("RYZEN") || upper.Contains("INTEL"))))
                return "🟠 Alto desempenho — Excelente para multitarefas, jogos e trabalhos pesados";

            // Mid
            if (upper.Contains("I5") || upper.Contains("RYZEN 5") || upper.Contains("CORE ULTRA 5") ||
                upper.Contains("M1") || upper.Contains("M2") || upper.Contains("M3") || upper.Contains("M4"))
                return "🟡 Intermediário — Bom para a maioria das tarefas do dia a dia";

            // Entry
            if (upper.Contains("I3") || upper.Contains("RYZEN 3") || upper.Contains("CORE ULTRA 3"))
                return "🟢 Básico intermediário — Adequado para tarefas simples e escritório";

            // Budget
            if (upper.Contains("CELERON") || upper.Contains("PENTIUM") || upper.Contains("ATHLON") ||
                upper.Contains("ATOM") || cores <= 2)
                return "⚪ Básico — Adequado apenas para navegação, texto e vídeos simples";

            return cores >= 6
                ? "🟡 Intermediário ou superior — baseado na quantidade de núcleos"
                : "🟢 Básico a intermediário — baseado na quantidade de núcleos";
        }

        private string GetArchitectureName(int arch)
        {
            switch (arch)
            {
                case 0: return "x86 (32 bits)";
                case 5: return "ARM";
                case 9: return "x64 (64 bits)";
                case 12: return "ARM64";
                default: return $"Código {arch}";
            }
        }

        // =============================================
        // MEMÓRIA RAM
        // =============================================
        private List<HardwareComponent> GetMemoryInfo()
        {
            var memory = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                long totalMemory = 0;
                int moduleCount = 0;
                var moduleList = new List<string>();

                foreach (ManagementObject obj in searcher.Get())
                {
                    moduleCount++;
                    long capacity = Convert.ToInt64(obj["Capacity"]);
                    totalMemory += capacity;
                    uint speed = Convert.ToUInt32(obj["Speed"]);
                    string memType = GetMemoryTypeName(Convert.ToInt32(obj["SMBIOSMemoryType"]));
                    string slot = obj["DeviceLocator"]?.ToString() ?? $"Slot {moduleCount}";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "Desconhecido";
                    string partNumber = obj["PartNumber"]?.ToString()?.Trim() ?? "N/A";
                    long capGb = capacity / (1024 * 1024 * 1024);

                    moduleList.Add($"Slot {moduleCount} ({slot}): {capGb} GB {memType} {speed} MHz");

                    memory.Add(new HardwareComponent
                    {
                        Category = "🧠 Memória RAM",
                        Name = $"Módulo {moduleCount} — {capGb} GB {memType}",
                        Manufacturer = manufacturer,
                        Model = partNumber,
                        Details =
                            $"Capacidade: {capGb} GB\n" +
                            $"Tipo: {memType}\n" +
                            $"Velocidade: {speed} MHz\n" +
                            $"Slot: {slot}\n" +
                            $"Fabricante: {manufacturer}\n" +
                            $"Número de Peça: {partNumber}",
                        FriendlyExplanation =
                            $"Este é um dos pentes de memória RAM instalados no seu computador.\n\n" +
                            $"A memória RAM é como a 'mesa de trabalho' do computador: quanto maior, mais " +
                            $"programas e abas do navegador você pode ter abertos ao mesmo tempo sem o PC travar.\n\n" +
                            $"O tipo {memType} indica a tecnologia da memória — DDR5 é o mais moderno, " +
                            $"DDR4 ainda é muito comum e eficiente, DDR3 já é mais antigo.\n\n" +
                            $"A velocidade de {speed} MHz indica quão rápido essa memória transfere dados.",
                        Status = "Funcionando"
                    });
                }

                if (moduleCount > 0)
                {
                    string totalGb = (totalMemory / (1024 * 1024 * 1024)).ToString();
                    string ramAssessment = AssessRamAmount(totalMemory);
                    memory.Insert(0, new HardwareComponent
                    {
                        Category = "🧠 Memória RAM",
                        Name = $"TOTAL: {totalGb} GB em {moduleCount} módulo(s)",
                        Details =
                            $"Total instalado: {totalGb} GB\n" +
                            $"Módulos instalados: {moduleCount}\n" +
                            $"Distribuição:\n  " + string.Join("\n  ", moduleList),
                        FriendlyExplanation =
                            $"Seu computador tem {totalGb} GB de memória RAM no total.\n\n" +
                            $"{ramAssessment}",
                        Status = "Resumo"
                    });
                }
            }
            catch (Exception ex)
            {
                memory.Add(CreateErrorComponent("🧠 Memória RAM", ex.Message));
            }

            return memory;
        }

        private string GetMemoryTypeName(int type)
        {
            switch (type)
            {
                case 20: return "DDR";
                case 21: return "DDR2";
                case 24: return "DDR3";
                case 26: return "DDR4";
                case 30: return "LPDDR4";
                case 34: return "DDR5";
                case 35: return "LPDDR5";
                default: return type > 0 ? $"Tipo {type}" : "Desconhecido";
            }
        }

        private string AssessRamAmount(long bytes)
        {
            long gb = bytes / (1024 * 1024 * 1024);
            if (gb <= 4)
                return "⚠️ 4 GB ou menos é considerado pouco pelos padrões atuais. O computador pode ficar lento ao abrir vários programas ao mesmo tempo. Considere ampliar a memória.";
            if (gb <= 8)
                return "🟡 8 GB é o mínimo recomendado hoje. Funciona bem para tarefas do dia a dia, mas pode ser limitado ao usar muitos programas pesados simultaneamente.";
            if (gb <= 16)
                return "🟢 16 GB é considerado confortável para a maioria dos usuários, incluindo jogos moderados e trabalhos de escritório.";
            if (gb <= 32)
                return "🟢 32 GB é excelente! Ideal para edição de vídeo, jogos pesados, programação e multitarefas intensas.";
            return "🔵 64 GB ou mais é configuração profissional, usada em edição de vídeo/foto de alta resolução, virtualização e servidores.";
        }

        // =============================================
        // DISCO / ARMAZENAMENTO
        // =============================================
        private List<HardwareComponent> GetDiskInfo()
        {
            var disks = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject obj in searcher.Get())
                {
                    long size = Convert.ToInt64(obj["Size"]);
                    string model = obj["Model"]?.ToString() ?? "Desconhecido";
                    string interfaceType = obj["InterfaceType"]?.ToString() ?? "N/A";
                    string mediaType = obj["MediaType"]?.ToString() ?? "";
                    uint sectorsPerTrack = Convert.ToUInt32(obj["SectorsPerTrack"]);

                    string diskType = DetectDiskType(model, mediaType, interfaceType);
                    string sizeText = FormatDiskSize(size);
                    string speedNote = GetDiskSpeedNote(diskType);

                    disks.Add(new HardwareComponent
                    {
                        Category = "💾 Armazenamento (Disco)",
                        Name = $"{model} — {sizeText} ({diskType})",
                        Model = model,
                        Details =
                            $"Modelo: {model}\n" +
                            $"Capacidade: {sizeText}\n" +
                            $"Tipo detectado: {diskType}\n" +
                            $"Interface: {interfaceType}\n" +
                            $"Tipo de mídia: {(string.IsNullOrEmpty(mediaType) ? "N/A" : mediaType)}",
                        FriendlyExplanation =
                            $"O disco é onde ficam guardados permanentemente seus arquivos, fotos, programas e o próprio Windows.\n\n" +
                            $"📌 SEU DISCO: {model}\n" +
                            $"📦 CAPACIDADE: {sizeText}\n" +
                            $"🔧 TIPO: {diskType}\n\n" +
                            $"{speedNote}\n\n" +
                            $"💡 Diferença entre SSD e HD:\n" +
                            $"• SSD = muito mais rápido (como um pen drive gigante), sem partes mecânicas\n" +
                            $"• HD (HDD) = mais lento, tem partes mecânicas girando, mais frágil a quedas\n" +
                            $"• NVMe = o tipo mais rápido de SSD, fica dentro da placa-mãe",
                        Status = "Funcionando"
                    });
                }

                // Informações de partições/volumes
                try
                {
                    ManagementObjectSearcher volSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType=3");
                    foreach (ManagementObject vol in volSearcher.Get())
                    {
                        string drive = vol["DeviceID"]?.ToString() ?? "";
                        long freeSpace = Convert.ToInt64(vol["FreeSpace"]);
                        long totalSize = Convert.ToInt64(vol["Size"]);
                        long usedSpace = totalSize - freeSpace;
                        double usedPercent = totalSize > 0 ? (double)usedSpace / totalSize * 100 : 0;
                        string volumeName = vol["VolumeName"]?.ToString() ?? "Sem nome";
                        string freeWarning = usedPercent > 90 ? "⚠️ ATENÇÃO: Disco quase cheio! Isso deixa o PC lento." :
                                            usedPercent > 75 ? "⚠️ Disco com bastante uso. Considere liberar espaço." : "✅ Espaço disponível adequado.";

                        disks.Add(new HardwareComponent
                        {
                            Category = "💾 Partição de Disco",
                            Name = $"Unidade {drive} ({volumeName}) — {FormatDiskSize(freeSpace)} livres de {FormatDiskSize(totalSize)}",
                            Details =
                                $"Letra da unidade: {drive}\n" +
                                $"Nome do volume: {volumeName}\n" +
                                $"Espaço total: {FormatDiskSize(totalSize)}\n" +
                                $"Espaço usado: {FormatDiskSize(usedSpace)} ({usedPercent:F1}%)\n" +
                                $"Espaço livre: {FormatDiskSize(freeSpace)}\n" +
                                $"Status: {freeWarning}",
                            FriendlyExplanation =
                                $"Esta é uma 'fatia' (partição) do seu disco. A unidade {drive} tem {FormatDiskSize(totalSize)} no total.\n\n" +
                                $"Atualmente {usedPercent:F1}% está sendo usado.\n\n" +
                                $"{freeWarning}\n\n" +
                                $"💡 Manter pelo menos 15-20% do disco livre ajuda o computador a funcionar melhor.",
                            Status = usedPercent > 90 ? "Atenção" : "Funcionando"
                        });
                    }
                }
                catch { /* ignora erros de volumes */ }
            }
            catch (Exception ex)
            {
                disks.Add(CreateErrorComponent("💾 Armazenamento", ex.Message));
            }

            return disks;
        }

        private string DetectDiskType(string model, string mediaType, string interfaceType)
        {
            string upper = model.ToUpper();
            if (upper.Contains("NVME") || upper.Contains("NVM EXPRESS") || upper.Contains("PCIE SSD"))
                return "SSD NVMe (Ultra-rápido)";
            if (upper.Contains("SSD") || mediaType.ToUpper().Contains("SSD"))
                return "SSD (Rápido)";
            if (interfaceType.ToUpper().Contains("SCSI") && !upper.Contains("HDD"))
                return "SSD ou Virtual (SCSI)";
            if (upper.Contains("HDD") || upper.Contains("WDC") || upper.Contains("SEAGATE") ||
                upper.Contains("TOSHIBA") || upper.Contains("HITACHI") || mediaType.ToUpper().Contains("FIXED"))
            {
                // Check se parece SSD mesmo sendo dessas marcas
                if (upper.Contains("SSD")) return "SSD (Rápido)";
                return "HD Mecânico (HDD — mais lento)";
            }
            if (upper.Contains("EMMC") || upper.Contains("MMC"))
                return "eMMC (Memória Flash — comum em notebooks básicos)";
            return "Tipo não identificado";
        }

        private string FormatDiskSize(long bytes)
        {
            if (bytes <= 0) return "0 B";
            double gb = bytes / (1024.0 * 1024.0 * 1024.0);
            if (gb >= 1000) return $"{gb / 1024.0:F1} TB ({gb:F0} GB)";
            return $"{gb:F1} GB";
        }

        private string GetDiskSpeedNote(string diskType)
        {
            if (diskType.Contains("NVMe"))
                return "🚀 NVMe é o tipo mais rápido disponível — o Windows inicia em segundos e programas abrem quase instantaneamente.";
            if (diskType.Contains("SSD"))
                return "⚡ SSD é bem mais rápido que HD mecânico — o Windows inicia rápido e programas abrem com agilidade.";
            if (diskType.Contains("HDD") || diskType.Contains("Mecânico"))
                return "🐢 HD Mecânico é mais lento que SSD. Se o PC demora para iniciar ou abrir programas, trocar para SSD faz uma grande diferença.";
            if (diskType.Contains("eMMC"))
                return "🐌 eMMC é um tipo básico de armazenamento, geralmente em notebooks simples. É mais lento que SSD.";
            return "";
        }

        // =============================================
        // PLACA DE VÍDEO
        // =============================================
        private List<HardwareComponent> GetGraphicsInfo()
        {
            var graphics = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string gpuName = obj["Name"]?.ToString() ?? "Desconhecido";
                    long vram = Convert.ToInt64(obj["AdapterRAM"]);
                    string vramText = vram > 0 ? $"{vram / (1024 * 1024)} MB ({vram / (1024 * 1024 * 1024.0):F1} GB)" : "Compartilhada com RAM";
                    string driverVer = obj["DriverVersion"]?.ToString() ?? "N/A";
                    string resH = obj["CurrentHorizontalResolution"]?.ToString() ?? "N/A";
                    string resV = obj["CurrentVerticalResolution"]?.ToString() ?? "N/A";
                    string gpuClass = ClassifyGPU(gpuName);

                    graphics.Add(new HardwareComponent
                    {
                        Category = "🎮 Placa de Vídeo (GPU)",
                        Name = gpuName,
                        Manufacturer = obj["AdapterCompatibility"]?.ToString(),
                        Details =
                            $"Nome: {gpuName}\n" +
                            $"Memória de Vídeo (VRAM): {vramText}\n" +
                            $"Resolução atual: {resH}x{resV}\n" +
                            $"Versão do Driver: {driverVer}\n" +
                            $"Classificação: {gpuClass}",
                        FriendlyExplanation =
                            $"A placa de vídeo (GPU) é responsável por processar e exibir tudo que você vê na tela.\n\n" +
                            $"📌 SUA GPU: {gpuName}\n" +
                            $"🏆 CLASSIFICAÇÃO: {gpuClass}\n\n" +
                            $"💡 TIPOS DE GPU:\n" +
                            $"• GPU Integrada (Intel UHD/Iris, AMD Radeon integrado): embutida no processador, " +
                            $"suficiente para tarefas do dia a dia mas limitada para jogos pesados.\n" +
                            $"• GPU Dedicada (NVIDIA GeForce, AMD Radeon RX): uma placa separada com memória própria, " +
                            $"muito mais poderosa para jogos, edição de vídeo e design.\n\n" +
                            $"A VRAM ({vramText}) é a memória exclusiva da placa de vídeo — quanto mais, melhor para jogos e edição.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                graphics.Add(CreateErrorComponent("🎮 Placa de Vídeo (GPU)", ex.Message));
            }

            return graphics;
        }

        private string ClassifyGPU(string name)
        {
            string upper = name.ToUpper();
            if (upper.Contains("RTX 40") || upper.Contains("RTX 40"))
                return "🔴 NVIDIA RTX 40xx — Topo de linha mais recente (2022-2024)";
            if (upper.Contains("RTX 30") || upper.Contains("RTX 3"))
                return "🔴 NVIDIA RTX 30xx — Topo/Alto desempenho (2020-2022)";
            if (upper.Contains("RTX 20") || upper.Contains("RTX 2"))
                return "🟠 NVIDIA RTX 20xx — Alto desempenho (2018-2020)";
            if (upper.Contains("GTX 16"))
                return "🟡 NVIDIA GTX 16xx — Intermediário (2019)";
            if (upper.Contains("GTX 10"))
                return "🟡 NVIDIA GTX 10xx — Intermediário (2016-2017), ainda competente";
            if (upper.Contains("GTX 9") || upper.Contains("GTX 8") || upper.Contains("GTX 7"))
                return "⚪ NVIDIA GTX antiga — Básica para jogos leves";
            if (upper.Contains("RX 7"))
                return "🔴 AMD Radeon RX 7xxx — Topo/Alto desempenho mais recente (2022-2024)";
            if (upper.Contains("RX 6"))
                return "🟠 AMD Radeon RX 6xxx — Alto desempenho (2020-2022)";
            if (upper.Contains("RX 5"))
                return "🟡 AMD Radeon RX 5xxx — Intermediário (2019-2020)";
            if (upper.Contains("RX 4") || upper.Contains("RX 3"))
                return "⚪ AMD Radeon RX antiga — Básica";
            if (upper.Contains("INTEL") && (upper.Contains("ARC") || upper.Contains("A7") || upper.Contains("A5") || upper.Contains("A3")))
                return "🟡 Intel Arc — GPU dedicada da Intel (2022+), intermediária";
            if (upper.Contains("UHD") || upper.Contains("IRIS") || upper.Contains("HD GRAPHICS"))
                return "⚪ Intel Integrada — Suficiente para o dia a dia e vídeos, limitada para jogos";
            if (upper.Contains("RADEON") && (upper.Contains("VEGA") || upper.Contains("GRAPHICS")))
                return "⚪ AMD Radeon Integrada — Suficiente para o dia a dia";
            return "Classificação não identificada automaticamente";
        }

        // =============================================
        // PLACA-MÃE
        // =============================================
        private List<HardwareComponent> GetMotherboardInfo()
        {
            var motherboard = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string product = obj["Product"]?.ToString() ?? "N/A";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";
                    string serial = obj["SerialNumber"]?.ToString() ?? "N/A";

                    motherboard.Add(new HardwareComponent
                    {
                        Category = "🖥️ Placa-Mãe",
                        Name = $"{manufacturer} {product}",
                        Manufacturer = manufacturer,
                        Model = product,
                        Details =
                            $"Fabricante: {manufacturer}\n" +
                            $"Modelo: {product}\n" +
                            $"Número de Série: {serial}",
                        FriendlyExplanation =
                            "A placa-mãe é a 'espinha dorsal' do computador — ela conecta e permite a comunicação " +
                            "entre todas as peças: processador, memória RAM, disco, placa de vídeo etc.\n\n" +
                            $"📌 SUA PLACA-MÃE: {manufacturer} {product}\n\n" +
                            "💡 A placa-mãe determina quais processadores e memórias você pode instalar, " +
                            "e quantos dispositivos extras (placas, discos) o computador suporta.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                motherboard.Add(CreateErrorComponent("🖥️ Placa-Mãe", ex.Message));
            }

            return motherboard;
        }

        // =============================================
        // REDE
        // =============================================
        private List<HardwareComponent> GetNetworkAdapterInfo()
        {
            var adapters = new List<HardwareComponent>();

            try
            {
                // Adaptadores ativos (conectados)
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionStatus IS NOT NULL AND PhysicalAdapter=True");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string adapterName = obj["Name"]?.ToString() ?? "Desconhecido";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";
                    string mac = obj["MACAddress"]?.ToString() ?? "N/A";
                    int status = Convert.ToInt32(obj["NetConnectionStatus"]);
                    string statusText = GetNetworkStatus(status);
                    string adapterType = GetNetworkAdapterType(adapterName);
                    string speed = obj["Speed"] != null ? FormatNetworkSpeed(Convert.ToInt64(obj["Speed"])) : "N/A";

                    adapters.Add(new HardwareComponent
                    {
                        Category = $"🌐 Rede — {adapterType}",
                        Name = adapterName,
                        Manufacturer = manufacturer,
                        Details =
                            $"Nome: {adapterName}\n" +
                            $"Tipo: {adapterType}\n" +
                            $"Fabricante: {manufacturer}\n" +
                            $"Endereço MAC: {mac}\n" +
                            $"Velocidade: {speed}\n" +
                            $"Status: {statusText}",
                        FriendlyExplanation =
                            $"Este é um adaptador de rede — ele permite que seu computador se conecte à internet e a outras redes.\n\n" +
                            $"📌 ADAPTADOR: {adapterName}\n" +
                            $"📡 TIPO: {adapterType}\n" +
                            $"🔌 STATUS: {statusText}\n\n" +
                            $"💡 Wi-Fi = conecta sem fio via roteador.\n" +
                            $"Ethernet (cabo) = conexão por cabo, geralmente mais estável e rápida.\n" +
                            $"Bluetooth = para conectar fones, teclados e outros acessórios sem fio.",
                        Status = status == 2 ? "Conectado" : "Desconectado"
                    });
                }
            }
            catch (Exception ex)
            {
                adapters.Add(CreateErrorComponent("🌐 Rede", ex.Message));
            }

            return adapters;
        }

        private string GetNetworkStatus(int status)
        {
            switch (status)
            {
                case 0: return "Desconectado";
                case 1: return "Conectando...";
                case 2: return "✅ Conectado";
                case 3: return "Desconectando...";
                case 4: return "Hardware não presente";
                case 5: return "Hardware desabilitado";
                case 7: return "Mídia desconectada";
                case 9: return "Autenticando...";
                case 10: return "Autenticação falhou";
                case 11: return "✅ Conectado com endereço inválido";
                default: return $"Status {status}";
            }
        }

        private string GetNetworkAdapterType(string name)
        {
            string upper = name.ToUpper();
            if (upper.Contains("WI-FI") || upper.Contains("WIFI") || upper.Contains("WIRELESS") || upper.Contains("802.11") || upper.Contains("WLAN"))
                return "Wi-Fi (Sem fio)";
            if (upper.Contains("BLUETOOTH"))
                return "Bluetooth";
            if (upper.Contains("ETHERNET") || upper.Contains("GIGABIT") || upper.Contains("LAN") || upper.Contains("REALTEK PCIe"))
                return "Ethernet (Cabo)";
            if (upper.Contains("VIRTUAL") || upper.Contains("VPN") || upper.Contains("TAP") || upper.Contains("TUN"))
                return "Virtual / VPN";
            if (upper.Contains("MOBILE") || upper.Contains("4G") || upper.Contains("5G") || upper.Contains("WWAN") || upper.Contains("LTE"))
                return "Mobile / Banda Larga Celular";
            return "Rede (Tipo não identificado)";
        }

        private string FormatNetworkSpeed(long bps)
        {
            if (bps <= 0) return "N/A";
            if (bps >= 1_000_000_000) return $"{bps / 1_000_000_000.0:F0} Gbps";
            if (bps >= 1_000_000) return $"{bps / 1_000_000.0:F0} Mbps";
            if (bps >= 1_000) return $"{bps / 1_000.0:F0} Kbps";
            return $"{bps} bps";
        }

        // =============================================
        // ÁUDIO
        // =============================================
        private List<HardwareComponent> GetAudioInfo()
        {
            var audio = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string deviceName = obj["Name"]?.ToString() ?? "Desconhecido";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";
                    string status = obj["StatusInfo"]?.ToString();

                    audio.Add(new HardwareComponent
                    {
                        Category = "🔊 Áudio",
                        Name = deviceName,
                        Manufacturer = manufacturer,
                        Details =
                            $"Nome: {deviceName}\n" +
                            $"Fabricante: {manufacturer}",
                        FriendlyExplanation =
                            $"Este é o dispositivo de áudio do seu computador — responsável pelo som que sai pelas caixas de som, fones e também pela entrada do microfone.\n\n" +
                            $"📌 DISPOSITIVO: {deviceName}\n\n" +
                            $"💡 A maioria dos computadores tem áudio integrado na placa-mãe (Realtek é o mais comum). " +
                            $"Alguns têm também áudio via HDMI (para TVs e monitores com caixas de som).",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                audio.Add(CreateErrorComponent("🔊 Áudio", ex.Message));
            }

            return audio;
        }

        // =============================================
        // BIOS / FIRMWARE
        // =============================================
        private List<HardwareComponent> GetBiosInfo()
        {
            var bios = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string biosName = obj["Name"]?.ToString() ?? "N/A";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";
                    string version = obj["SMBIOSBIOSVersion"]?.ToString() ?? "N/A";
                    string releaseDate = "N/A";

                    try
                    {
                        string rawDate = obj["ReleaseDate"]?.ToString() ?? "";
                        if (rawDate.Length >= 8)
                            releaseDate = $"{rawDate.Substring(6, 2)}/{rawDate.Substring(4, 2)}/{rawDate.Substring(0, 4)}";
                    }
                    catch { }

                    bios.Add(new HardwareComponent
                    {
                        Category = "⚡ BIOS / Firmware",
                        Name = $"{manufacturer} — Versão {version}",
                        Manufacturer = manufacturer,
                        Model = version,
                        Details =
                            $"Nome: {biosName}\n" +
                            $"Fabricante: {manufacturer}\n" +
                            $"Versão: {version}\n" +
                            $"Data de Lançamento: {releaseDate}",
                        FriendlyExplanation =
                            "O BIOS (ou UEFI nos computadores mais modernos) é o primeiro programa que roda quando você liga o computador, " +
                            "antes mesmo do Windows iniciar. Ele 'acorda' todas as peças do PC e prepara tudo para o sistema operacional.\n\n" +
                            $"📌 BIOS: {manufacturer} versão {version} (lançado em {releaseDate})\n\n" +
                            "💡 Em geral, leigos não precisam mexer no BIOS. Atualizar o BIOS pode melhorar compatibilidades, " +
                            "mas deve ser feito com cuidado — apenas se houver necessidade específica.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                bios.Add(CreateErrorComponent("⚡ BIOS / Firmware", ex.Message));
            }

            return bios;
        }

        // =============================================
        // BATERIA (para notebooks)
        // =============================================
        private List<HardwareComponent> GetBatteryInfo()
        {
            var batteries = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string batName = obj["Name"]?.ToString() ?? "Bateria";
                    string manufacturer = obj["DesignCapacity"]?.ToString() ?? "N/A";
                    uint chargePercent = 0;

                    try { chargePercent = Convert.ToUInt32(obj["EstimatedChargeRemaining"]); } catch { }

                    int statusCode = 0;
                    try { statusCode = Convert.ToInt32(obj["BatteryStatus"]); } catch { }
                    string batteryStatus = GetBatteryStatus(statusCode);

                    batteries.Add(new HardwareComponent
                    {
                        Category = "🔋 Bateria",
                        Name = $"{batName} — {chargePercent}% ({batteryStatus})",
                        Details =
                            $"Nome: {batName}\n" +
                            $"Carga Atual: {chargePercent}%\n" +
                            $"Status: {batteryStatus}",
                        FriendlyExplanation =
                            $"Esta é a bateria do seu notebook. Atualmente ela está com {chargePercent}% de carga.\n\n" +
                            $"📊 STATUS: {batteryStatus}\n\n" +
                            $"💡 Dicas para prolongar a vida da bateria:\n" +
                            $"• Evite deixar sempre em 100% plugado — isso desgasta a bateria\n" +
                            $"• Procure manter entre 20% e 80% quando possível\n" +
                            $"• Evite usar em locais muito quentes",
                        Status = chargePercent < 15 ? "Atenção" : "Funcionando"
                    });
                }
            }
            catch { /* Sem bateria (desktop) — ignora silenciosamente */ }

            return batteries;
        }

        private string GetBatteryStatus(int status)
        {
            switch (status)
            {
                case 1: return "🔌 Carregando";
                case 2: return "✅ Carga completa";
                case 3: return "🔋 Descarregando (no bateria)";
                case 4: return "⚠️ Baixo";
                case 5: return "🚨 Crítico";
                case 6: return "⚡ Carregando";
                case 7: return "🔌 Na tomada, não carregando";
                default: return "Status desconhecido";
            }
        }

        // =============================================
        // MONITOR
        // =============================================
        private List<HardwareComponent> GetMonitorInfo()
        {
            var monitors = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string monitorName = obj["Name"]?.ToString() ?? "Monitor";
                    string manufacturer = obj["MonitorManufacturer"]?.ToString() ?? "N/A";
                    string monitorType = obj["MonitorType"]?.ToString() ?? "N/A";
                    uint resH = 0, resV = 0;

                    try { resH = Convert.ToUInt32(obj["ScreenWidth"]); } catch { }
                    try { resV = Convert.ToUInt32(obj["ScreenHeight"]); } catch { }

                    string resText = (resH > 0 && resV > 0) ? $"{resH}x{resV}" : "N/A";

                    monitors.Add(new HardwareComponent
                    {
                        Category = "🖥️ Monitor",
                        Name = monitorName,
                        Manufacturer = manufacturer,
                        Details =
                            $"Nome: {monitorName}\n" +
                            $"Fabricante: {manufacturer}\n" +
                            $"Tipo: {monitorType}\n" +
                            $"Resolução: {resText}",
                        FriendlyExplanation =
                            $"Este é o monitor conectado ao seu computador — a tela onde você vê tudo.\n\n" +
                            $"📌 MONITOR: {monitorName}\n" +
                            $"📐 RESOLUÇÃO: {resText}\n\n" +
                            $"💡 A resolução indica quantos pontinhos (pixels) formam a imagem:\n" +
                            $"• 1920x1080 (Full HD) = padrão atual muito comum\n" +
                            $"• 2560x1440 (2K/QHD) = mais nítido, bom para design\n" +
                            $"• 3840x2160 (4K/UHD) = altíssima definição",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                monitors.Add(CreateErrorComponent("🖥️ Monitor", ex.Message));
            }

            return monitors;
        }

        // =============================================
        // CONTROLADORES USB
        // =============================================
        private List<HardwareComponent> GetUsbControllersInfo()
        {
            var usb = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBController");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string usbName = obj["Name"]?.ToString() ?? "Controlador USB";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";

                    usb.Add(new HardwareComponent
                    {
                        Category = "🔌 Controlador USB",
                        Name = usbName,
                        Manufacturer = manufacturer,
                        Details =
                            $"Nome: {usbName}\n" +
                            $"Fabricante: {manufacturer}",
                        FriendlyExplanation =
                            "O controlador USB gerencia as portas USB do computador — onde você conecta pen drives, " +
                            "teclados, mouses, carregadores e outros dispositivos.\n\n" +
                            $"📌 CONTROLADOR: {usbName}\n\n" +
                            "💡 USB 3.0/3.1/3.2 são mais rápidos (geralmente têm o símbolo azul na porta). " +
                            "USB 2.0 é mais antigo e lento, mas ainda funciona para a maioria dos acessórios.",
                        Status = "Funcionando"
                    });
                }
            }
            catch { /* Ignora silenciosamente */ }

            return usb;
        }

        // =============================================
        // DRIVE ÓPTICO (CD/DVD)
        // =============================================
        private List<HardwareComponent> GetOpticalDriveInfo()
        {
            var optical = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CDROMDrive");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string driveName = obj["Name"]?.ToString() ?? "Drive Óptico";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";

                    optical.Add(new HardwareComponent
                    {
                        Category = "💿 Drive Óptico (CD/DVD)",
                        Name = driveName,
                        Manufacturer = manufacturer,
                        Details = $"Nome: {driveName}\nFabricante: {manufacturer}",
                        FriendlyExplanation =
                            "Este é o leitor/gravador de CD, DVD ou Blu-ray do seu computador.\n\n" +
                            "💡 Cada vez menos usados, os drives ópticos servem para ler e gravar CDs e DVDs. " +
                            "Muitos computadores modernos já não vêm com este componente.",
                        Status = "Funcionando"
                    });
                }
            }
            catch { /* Ignora silenciosamente */ }

            return optical;
        }

        // =============================================
        // SISTEMA DE REFRIGERAÇÃO
        // =============================================
        private List<HardwareComponent> GetCoolingInfo()
        {
            var cooling = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher fanSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Fan");

                foreach (ManagementObject obj in fanSearcher.Get())
                {
                    string fanName = obj["Name"]?.ToString() ?? "Ventoinha";
                    bool isActive = false;
                    try { isActive = Convert.ToBoolean(obj["ActiveCooling"]); } catch { }

                    cooling.Add(new HardwareComponent
                    {
                        Category = "❄️ Refrigeração",
                        Name = fanName,
                        Details = $"Nome: {fanName}\nResfriamento ativo: {(isActive ? "Sim" : "N/A")}",
                        FriendlyExplanation =
                            "Este é um sistema de refrigeração (ventoinha/cooler) do computador.\n\n" +
                            "💡 O cooler é essencial para manter o processador e outros componentes em temperatura segura. " +
                            "Se o computador estiver fazendo muito barulho ou ficando quente, pode ser sinal de que " +
                            "o cooler precisa de limpeza ou substituição.",
                        Status = "Funcionando"
                    });
                }
            }
            catch { /* Ignora silenciosamente */ }

            return cooling;
        }

        // =============================================
        // INFORMAÇÕES GERAIS DO SISTEMA
        // =============================================
        private List<HardwareComponent> GetSystemInfo()
        {
            var sys = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string pcName = obj["Name"]?.ToString() ?? "N/A";
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "N/A";
                    string model = obj["Model"]?.ToString() ?? "N/A";
                    string systemType = obj["SystemType"]?.ToString() ?? "N/A";
                    string pcType = GetPcTypeName(obj["PCSystemType"]);
                    long totalRam = Convert.ToInt64(obj["TotalPhysicalMemory"]);

                    sys.Add(new HardwareComponent
                    {
                        Category = "💻 Sistema / Computador",
                        Name = $"{manufacturer} {model}",
                        Manufacturer = manufacturer,
                        Model = model,
                        Details =
                            $"Nome do Computador: {pcName}\n" +
                            $"Fabricante: {manufacturer}\n" +
                            $"Modelo: {model}\n" +
                            $"Tipo de Sistema: {systemType}\n" +
                            $"Tipo de PC: {pcType}\n" +
                            $"RAM Total Detectada: {totalRam / (1024.0 * 1024.0 * 1024.0):F1} GB",
                        FriendlyExplanation =
                            $"Estas são as informações gerais do seu computador.\n\n" +
                            $"📌 SEU COMPUTADOR: {manufacturer} {model}\n" +
                            $"💻 TIPO: {pcType}\n\n" +
                            "💡 O nome do modelo é útil quando você precisa buscar drivers específicos, " +
                            "manual do usuário ou fazer upgrade de peças compatíveis.",
                        Status = "Resumo"
                    });
                }
            }
            catch (Exception ex)
            {
                sys.Add(CreateErrorComponent("💻 Sistema", ex.Message));
            }

            return sys;
        }

        private string GetPcTypeName(object pcTypeObj)
        {
            if (pcTypeObj == null) return "Desconhecido";
            try
            {
                int type = Convert.ToInt32(pcTypeObj);
                switch (type)
                {
                    case 1: return "Desktop";
                    case 2: return "Notebook / Laptop";
                    case 3: return "Workstation";
                    case 4: return "Servidor";
                    case 5: return "SOHO Server";
                    case 6: return "Appliance PC";
                    case 7: return "Performance Server";
                    case 8: return "All-in-One";
                    case 9: return "Sub Notebook";
                    default: return $"Tipo {type}";
                }
            }
            catch { return "Desconhecido"; }
        }

        // =============================================
        // UTILITÁRIOS
        // =============================================
        private HardwareComponent CreateErrorComponent(string category, string error)
        {
            return new HardwareComponent
            {
                Category = category,
                Name = "Não foi possível obter informações",
                Details = $"Motivo técnico: {error}",
                FriendlyExplanation = "Ocorreu um problema ao tentar ler as informações desta peça. " +
                                     "Isso pode acontecer por restrições de permissão do Windows ou incompatibilidade de hardware.",
                Status = "Erro"
            };
        }
    }
}