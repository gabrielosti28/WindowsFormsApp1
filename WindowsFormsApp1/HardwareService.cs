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

            return components;
        }

        private List<HardwareComponent> GetProcessorInfo()
        {
            var processors = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    processors.Add(new HardwareComponent
                    {
                        Category = "Processador (CPU)",
                        Name = obj["Name"]?.ToString(),
                        Manufacturer = obj["Manufacturer"]?.ToString(),
                        Details = $"Núcleos: {obj["NumberOfCores"]}, Threads: {obj["NumberOfLogicalProcessors"]}\n" +
                                 $"Velocidade: {obj["MaxClockSpeed"]} MHz",
                        FriendlyExplanation = "O processador é o 'cérebro' do computador. Quanto mais núcleos e maior a velocidade, mais tarefas ele consegue fazer ao mesmo tempo.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                processors.Add(CreateErrorComponent("Processador (CPU)", ex.Message));
            }

            return processors;
        }

        private List<HardwareComponent> GetMemoryInfo()
        {
            var memory = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                long totalMemory = 0;
                int moduleCount = 0;

                foreach (ManagementObject obj in searcher.Get())
                {
                    moduleCount++;
                    long capacity = Convert.ToInt64(obj["Capacity"]);
                    totalMemory += capacity;

                    memory.Add(new HardwareComponent
                    {
                        Category = "Memória RAM",
                        Name = $"Módulo {moduleCount}",
                        Manufacturer = obj["Manufacturer"]?.ToString(),
                        Details = $"Capacidade: {capacity / (1024 * 1024 * 1024)} GB\n" +
                                 $"Velocidade: {obj["Speed"]} MHz\n" +
                                 $"Tipo: {obj["MemoryType"]}",
                        FriendlyExplanation = "A memória RAM é onde o computador guarda temporariamente os programas que você está usando. Mais RAM = pode abrir mais programas ao mesmo tempo.",
                        Status = "Funcionando"
                    });
                }

                // Adiciona um resumo total
                if (moduleCount > 0)
                {
                    memory.Insert(0, new HardwareComponent
                    {
                        Category = "Memória RAM",
                        Name = "Total de Memória",
                        Details = $"Memória Total Instalada: {totalMemory / (1024 * 1024 * 1024)} GB\n" +
                                 $"Módulos instalados: {moduleCount}",
                        FriendlyExplanation = "Esta é a quantidade total de memória RAM no seu computador.",
                        Status = "Resumo"
                    });
                }
            }
            catch (Exception ex)
            {
                memory.Add(CreateErrorComponent("Memória RAM", ex.Message));
            }

            return memory;
        }

        private List<HardwareComponent> GetDiskInfo()
        {
            var disks = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject obj in searcher.Get())
                {
                    long size = Convert.ToInt64(obj["Size"]);
                    string model = obj["Model"]?.ToString();
                    string interfaceType = obj["InterfaceType"]?.ToString();

                    // Detectar se é SSD ou HDD (aproximação)
                    string diskType = model?.ToUpper().Contains("SSD") == true ? "SSD (Rápido)" : "HDD (Tradicional)";

                    disks.Add(new HardwareComponent
                    {
                        Category = "Armazenamento (Disco)",
                        Name = model,
                        Model = model,
                        Details = $"Tamanho: {size / (1024 * 1024 * 1024)} GB\n" +
                                 $"Interface: {interfaceType}\n" +
                                 $"Tipo: {diskType}",
                        FriendlyExplanation = "O disco é onde ficam guardados todos os seus arquivos, fotos, programas. SSD é mais rápido que HDD.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                disks.Add(CreateErrorComponent("Armazenamento", ex.Message));
            }

            return disks;
        }

        private List<HardwareComponent> GetGraphicsInfo()
        {
            var graphics = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

                foreach (ManagementObject obj in searcher.Get())
                {
                    graphics.Add(new HardwareComponent
                    {
                        Category = "Placa de Vídeo (GPU)",
                        Name = obj["Name"]?.ToString(),
                        Manufacturer = obj["AdapterCompatibility"]?.ToString(),
                        Details = $"Memória de Vídeo: {Convert.ToInt64(obj["AdapterRAM"]) / (1024 * 1024)} MB\n" +
                                 $"Resolução Atual: {obj["CurrentHorizontalResolution"]}x{obj["CurrentVerticalResolution"]}\n" +
                                 $"Driver: {obj["DriverVersion"]}",
                        FriendlyExplanation = "A placa de vídeo é responsável por mostrar imagens na tela. Importante para jogos e edição de vídeo.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                graphics.Add(CreateErrorComponent("Placa de Vídeo", ex.Message));
            }

            return graphics;
        }

        private List<HardwareComponent> GetMotherboardInfo()
        {
            var motherboard = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

                foreach (ManagementObject obj in searcher.Get())
                {
                    motherboard.Add(new HardwareComponent
                    {
                        Category = "Placa-Mãe",
                        Name = obj["Product"]?.ToString(),
                        Manufacturer = obj["Manufacturer"]?.ToString(),
                        Details = $"Modelo: {obj["Product"]}\n" +
                                 $"Fabricante: {obj["Manufacturer"]}\n" +
                                 $"Número de Série: {obj["SerialNumber"]}",
                        FriendlyExplanation = "A placa-mãe conecta todas as peças do computador. É como a 'espinha dorsal' do PC.",
                        Status = "Funcionando"
                    });
                }
            }
            catch (Exception ex)
            {
                motherboard.Add(CreateErrorComponent("Placa-Mãe", ex.Message));
            }

            return motherboard;
        }

        private List<HardwareComponent> GetNetworkAdapterInfo()
        {
            var adapters = new List<HardwareComponent>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionStatus=2");

                foreach (ManagementObject obj in searcher.Get())
                {
                    adapters.Add(new HardwareComponent
                    {
                        Category = "Adaptador de Rede",
                        Name = obj["Name"]?.ToString(),
                        Manufacturer = obj["Manufacturer"]?.ToString(),
                        Details = $"Velocidade: {obj["Speed"]}\n" +
                                 $"Endereço MAC: {obj["MACAddress"]}",
                        FriendlyExplanation = "O adaptador de rede permite que seu computador se conecte à internet (Wi-Fi ou cabo).",
                        Status = "Conectado"
                    });
                }
            }
            catch (Exception ex)
            {
                adapters.Add(CreateErrorComponent("Adaptador de Rede", ex.Message));
            }

            return adapters;
        }

        private HardwareComponent CreateErrorComponent(string category, string error)
        {
            return new HardwareComponent
            {
                Category = category,
                Name = "Erro ao obter informações",
                Details = $"Erro: {error}",
                Status = "Erro"
            };
        }
    }
}