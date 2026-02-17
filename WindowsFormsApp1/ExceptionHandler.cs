using System;
using System.IO;
using System.Windows.Forms;

namespace AppInterno.Helpers
{
    public static class ExceptionHandler
    {
        private static readonly string LogPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "GuiaDoComputador",
            "error_log.txt"
        );

        public static void Initialize()
        {
            // Garantir que pasta existe
            Directory.CreateDirectory(Path.GetDirectoryName(LogPath));

            // Capturar exceções não tratadas
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        public static void HandleException(Exception ex, string context = null)
        {
            if (ex == null) return;

            // Log do erro
            LogError(ex, context);

            // Mostrar mensagem amigável ao usuário
            string userMessage = GetUserFriendlyMessage(ex);

            MessageBox.Show(
                userMessage,
                "Ops! Algo deu errado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private static void LogError(Exception ex, string context)
        {
            try
            {
                string logEntry = $@"
[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]
Contexto: {context ?? "N/A"}
Tipo: {ex.GetType().Name}
Mensagem: {ex.Message}
Stack Trace:
{ex.StackTrace}
------------------------
";
                File.AppendAllText(LogPath, logEntry);
            }
            catch
            {
                // Falhou ao logar - não fazer nada para evitar loop infinito
            }
        }

        private static string GetUserFriendlyMessage(Exception ex)
        {
            // Mensagens amigáveis baseadas no tipo de erro
            if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
            {
                return "Não conseguimos encontrar um arquivo necessário. Por favor, reinstale o programa.";
            }

            if (ex is UnauthorizedAccessException)
            {
                return "O programa não tem permissão para acessar este recurso. Tente executar como administrador.";
            }

            if (ex is System.Net.WebException)
            {
                return "Não foi possível conectar à internet. Verifique sua conexão.";
            }

            // Mensagem genérica
            return $"Ocorreu um erro inesperado. O erro foi registrado para análise.\n\nDetalhes técnicos: {ex.Message}";
        }
    }
}