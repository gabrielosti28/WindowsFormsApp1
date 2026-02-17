using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Linq;

namespace AppInterno
{
    /// <summary>
    /// Serviço centralizado e robusto para carregar dados JSON
    /// Suporta recursos embarcados E arquivos de disco (desenvolvimento)
    /// </summary>
    public static class DataService
    {
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
        private static readonly string DataFolderPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data");

        // Cache para evitar múltiplas leituras
        private static readonly Dictionary<string, object> Cache =
            new Dictionary<string, object>();

        /// <summary>
        /// Carrega dados JSON com suporte a cache
        /// </summary>
        public static List<T> LoadData<T>(string resourceName, bool useCache = true)
        {
            // Verificar cache
            if (useCache && Cache.ContainsKey(resourceName))
            {
                return Cache[resourceName] as List<T>;
            }

            try
            {
                List<T> data = LoadDataInternal<T>(resourceName);

                // Armazenar no cache
                if (useCache && data != null)
                {
                    Cache[resourceName] = data;
                }

                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                LogError($"Erro ao carregar {resourceName}", ex);
                return new List<T>();
            }
        }

        /// <summary>
        /// Carrega um único objeto JSON
        /// </summary>
        public static T LoadSingleObject<T>(string resourceName, bool useCache = true)
        {
            // Verificar cache
            if (useCache && Cache.ContainsKey(resourceName))
            {
                return (T)Cache[resourceName];
            }

            try
            {
                T data = LoadSingleObjectInternal<T>(resourceName);

                // Armazenar no cache
                if (useCache && data != null)
                {
                    Cache[resourceName] = data;
                }

                return data;
            }
            catch (Exception ex)
            {
                LogError($"Erro ao carregar {resourceName}", ex);
                return default(T);
            }
        }

        /// <summary>
        /// Limpa o cache (útil para recarregar dados)
        /// </summary>
        public static void ClearCache()
        {
            Cache.Clear();
        }

        /// <summary>
        /// Limpa item específico do cache
        /// </summary>
        public static void ClearCache(string resourceName)
        {
            if (Cache.ContainsKey(resourceName))
            {
                Cache.Remove(resourceName);
            }
        }

        // ===== MÉTODOS INTERNOS =====

        private static List<T> LoadDataInternal<T>(string resourceName)
        {
            string json = ReadJsonContent(resourceName);

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new FileNotFoundException(
                    $"Conteúdo vazio ou não encontrado: {resourceName}");
            }

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private static T LoadSingleObjectInternal<T>(string resourceName)
        {
            string json = ReadJsonContent(resourceName);

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new FileNotFoundException(
                    $"Conteúdo vazio ou não encontrado: {resourceName}");
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        private static string ReadJsonContent(string resourceName)
        {
            // PRIORIDADE 1: Tentar ler de arquivo (desenvolvimento)
            string filePath = Path.Combine(DataFolderPath, resourceName);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            // PRIORIDADE 2: Tentar ler de recurso embarcado (produção)
            string fullResourceName = $"AppInterno.Data.{resourceName}";
            using (Stream stream = Assembly.GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException(
                        $"Recurso não encontrado: {fullResourceName}");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Valida se um recurso existe
        /// </summary>
        public static bool ResourceExists(string resourceName)
        {
            // Verificar arquivo
            string filePath = Path.Combine(DataFolderPath, resourceName);
            if (File.Exists(filePath))
            {
                return true;
            }

            // Verificar recurso embarcado
            string fullResourceName = $"AppInterno.Data.{resourceName}";
            return Assembly.GetManifestResourceNames().Contains(fullResourceName);
        }

        /// <summary>
        /// Lista todos os recursos embarcados (debug)
        /// </summary>
        public static string[] GetAllEmbeddedResources()
        {
            return Assembly.GetManifestResourceNames();
        }

        /// <summary>
        /// Log de erros (pode ser expandido para arquivo futuramente)
        /// </summary>
        private static void LogError(string message, Exception ex)
        {
            string errorLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}: {ex.Message}";
            System.Diagnostics.Debug.WriteLine(errorLog);

            // TODO: Futuramente, salvar em arquivo de log
            // File.AppendAllText("error_log.txt", errorLog + Environment.NewLine);
        }
    }
}