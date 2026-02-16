using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace AppInterno.Services
{
    /// <summary>
    /// Serviço central para carregar dados de arquivos JSON embarcados
    /// </summary>
    public class DataService
    {
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        /// <summary>
        /// Carrega dados JSON de um recurso embarcado
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a deserializar</typeparam>
        /// <param name="resourceName">Nome do arquivo JSON (ex: "excel_shortcuts.json")</param>
        /// <returns>Lista de objetos deserializados</returns>
        public static List<T> LoadData<T>(string resourceName)
        {
            try
            {
                // Caminho completo do recurso embarcado
                string fullResourceName = $"AppInterno.Data.{resourceName}";

                // Tenta ler do recurso embarcado
                using (Stream stream = Assembly.GetManifestResourceStream(fullResourceName))
                {
                    if (stream == null)
                    {
                        // Se não encontrou embarcado, tenta ler do disco (modo desenvolvimento)
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", resourceName);

                        if (File.Exists(filePath))
                        {
                            string json = File.ReadAllText(filePath);
                            return JsonConvert.DeserializeObject<List<T>>(json);
                        }

                        throw new FileNotFoundException($"Recurso não encontrado: {fullResourceName}");
                    }

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<T>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar dados de {resourceName}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Carrega um único objeto JSON
        /// </summary>
        public static T LoadSingleObject<T>(string resourceName)
        {
            try
            {
                string fullResourceName = $"AppInterno.Data.{resourceName}";

                using (Stream stream = Assembly.GetManifestResourceStream(fullResourceName))
                {
                    if (stream == null)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", resourceName);

                        if (File.Exists(filePath))
                        {
                            string json = File.ReadAllText(filePath);
                            return JsonConvert.DeserializeObject<T>(json);
                        }

                        throw new FileNotFoundException($"Recurso não encontrado: {fullResourceName}");
                    }

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar objeto de {resourceName}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Valida se um recurso existe
        /// </summary>
        public static bool ResourceExists(string resourceName)
        {
            string fullResourceName = $"AppInterno.Data.{resourceName}";
            var resourceNames = Assembly.GetManifestResourceNames();
            return resourceNames.Contains(fullResourceName);
        }

        /// <summary>
        /// Lista todos os recursos embarcados (útil para debug)
        /// </summary>
        public static string[] GetAllEmbeddedResources()
        {
            return Assembly.GetManifestResourceNames();
        }
    }
}