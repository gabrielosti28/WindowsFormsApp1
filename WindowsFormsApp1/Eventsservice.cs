using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GuiaDoComputador
{
    public class EventoDoSistema
    {
        public DateTime Data { get; set; }
        public string DataFormatada { get; set; }
        public string Tipo { get; set; }
        public string TipoEmoji { get; set; }
        public string FonteOriginal { get; set; }
        public string FonteAmigavel { get; set; }
        public string MensagemOriginal { get; set; }
        public string MensagemAmigavel { get; set; }
        public string OQueSignifica { get; set; }
        public string OQueFazer { get; set; }
        public long EventId { get; set; }
        public string Categoria { get; set; }
    }

    public class ResumoEventos
    {
        public int TotalErros { get; set; }
        public int TotalAvisos { get; set; }
        public int TotalInformacoes { get; set; }
        public DateTime? UltimoErro { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public DateTime? UltimoDesligamento { get; set; }
        public int DesligamentosInesperados { get; set; }
        public string AvaliaoGeral { get; set; }
        public string AvaliacaoEmoji { get; set; }
    }

    public static class EventsService
    {
        // Mapa de IDs de eventos conhecidos para explicações amigáveis
        private static readonly Dictionary<long, (string NomeAmigavel, string OQueSignifica, string OQueFazer, string Categoria)> _eventosConhecidos
            = new Dictionary<long, (string, string, string, string)>
            {
                // Segurança — Login/Logoff
                [4624] = ("Alguém entrou no computador",
                "Login bem-sucedido. Alguém usou a senha correta e entrou no sistema.",
                "Normal — é o registro de quando você entra no Windows.",
                "Login"),
                [4625] = ("Tentativa de login com senha errada",
                "Alguém tentou entrar no computador com uma senha incorreta.",
                "Uma ou duas ocorrências são normais. Muitas tentativas seguidas podem indicar alguém tentando adivinhar sua senha.",
                "Segurança"),
                [4634] = ("Saiu do computador (logoff)",
                "Um usuário saiu do Windows (desligou, reiniciou ou fez logoff).",
                "Normal — registro de saída do sistema.",
                "Login"),
                [4648] = ("Login com credenciais diferentes",
                "Alguém entrou usando credenciais de outra conta (Executar como Administrador, por exemplo).",
                "Normal se você usa 'Executar como Administrador'. Suspeito se ocorreu sem você saber.",
                "Segurança"),
                [4720] = ("Nova conta de usuário criada",
                "Uma nova conta de usuário foi criada no computador.",
                "Verifique se você ou alguém autorizado criou essa conta. Contas desconhecidas podem ser problema de segurança.",
                "Segurança"),
                [4726] = ("Conta de usuário apagada",
                "Uma conta de usuário foi removida do computador.",
                "Verifique se a exclusão foi intencional.",
                "Segurança"),

                // Sistema — Desligamento/Inicialização
                [6005] = ("Windows foi iniciado",
                "O serviço de eventos do Windows começou — indica que o Windows iniciou.",
                "Normal — é o registro de quando o Windows liga.",
                "Sistema"),
                [6006] = ("Windows foi desligado corretamente",
                "O Windows foi encerrado de forma normal — você clicou em Desligar.",
                "Normal — registro de desligamento normal.",
                "Sistema"),
                [6008] = ("Computador desligou de forma inesperada",
                "O Windows registrou que na última vez que ligou, ele não foi desligado corretamente — pode ter sido queda de energia, travamento ou tela azul.",
                "Verifique se houve queda de energia. Se acontece com frequência, pode indicar problema de hardware ou superaquecimento.",
                "Problema"),
                [41] = ("Sistema reiniciou sem desligar corretamente",
                "O computador reiniciou sem ter sido desligado pelo Windows — geralmente causado por tela azul ou falta de energia.",
                "Busque eventos de tela azul próximos. Se frequente, verifique a memória RAM e o sistema de refrigeração.",
                "Problema"),

                // Aplicativos com erro
                [1000] = ("Um programa parou de funcionar",
                "Um aplicativo travou ou fechou inesperadamente.",
                "Se acontece com frequência no mesmo programa, tente reinstalá-lo ou atualizá-lo.",
                "Problema"),
                [1001] = ("Relatório de erro de programa enviado",
                "Um relatório sobre o programa que travou foi enviado (ou ficou na fila para envio).",
                "Normal após um programa travar.",
                "Informação"),
                [1002] = ("Programa não respondeu e foi fechado",
                "Um aplicativo parou de responder e o Windows o encerrou forçadamente.",
                "Se frequente no mesmo programa, tente reinstalá-lo.",
                "Problema"),
                [7034] = ("Um serviço do sistema encerrou inesperadamente",
                "Um serviço em segundo plano parou de funcionar sem ser desligado corretamente.",
                "Verifique qual serviço foi afetado. Pode causar mau funcionamento de alguma função do Windows.",
                "Problema"),
                [7036] = ("Um serviço mudou de estado",
                "Um serviço em segundo plano foi ligado ou desligado.",
                "Normal — ocorre constantemente durante o uso do computador.",
                "Sistema"),

                // Disco
                [7] = ("Erro no disco de armazenamento",
                "O controlador de disco reportou um erro — pode indicar problema físico no HD ou SSD.",
                "⚠️ ATENÇÃO! Faça backup dos seus arquivos imediatamente. Este erro pode indicar que o disco está com defeito.",
                "Problema"),
                [51] = ("Erro ao acessar arquivo no disco",
                "O Windows encontrou um problema ao tentar ler ou escrever no disco.",
                "Pode indicar setores com defeito. Execute uma verificação de disco.",
                "Problema"),

                // Windows Update
                [19] = ("Atualização do Windows instalada",
                "Uma atualização de segurança ou melhoria do Windows foi instalada com sucesso.",
                "Normal — boas práticas manter o Windows atualizado.",
                "Atualização"),
                [20] = ("Falha ao instalar atualização do Windows",
                "O Windows tentou instalar uma atualização mas falhou.",
                "Tente atualizar manualmente pelo Windows Update. Erros frequentes podem indicar corrupção do sistema.",
                "Problema"),

                // Rede
                [4226] = ("Limite de conexões simultâneas atingido",
                "O Windows tem um limite de conexões simultâneas de saída e esse limite foi atingido.",
                "Normal em redes movimentadas. Se frequente, pode indicar um programa usando muitas conexões.",
                "Rede"),
            };

        private static readonly Dictionary<string, string> _fontesConhecidas
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Application Error"] = "Erro de Programa",
                ["Application Hang"] = "Programa Travado",
                ["Windows Error Reporting"] = "Relatório de Erro do Windows",
                ["Microsoft-Windows-Security-Auditing"] = "Auditoria de Segurança",
                ["Service Control Manager"] = "Gerenciador de Serviços",
                ["Microsoft-Windows-WindowsUpdateClient"] = "Windows Update",
                ["Microsoft-Windows-Kernel-Power"] = "Sistema de Energia do Kernel",
                ["Microsoft-Windows-Kernel-General"] = "Núcleo do Sistema",
                ["Disk"] = "Disco de Armazenamento",
                ["EventLog"] = "Registro de Eventos",
                ["USER32"] = "Interface do Usuário (Windows)",
                ["Print"] = "Impressora",
            };

        public static List<EventoDoSistema> ObterEventosRecentes(
            string log = "Application", int maxEventos = 50,
            EventLogEntryType? filtroTipo = null)
        {
            var lista = new List<EventoDoSistema>();
            try
            {
                using (var eventLog = new EventLog(log))
                {
                    var entradas = eventLog.Entries.Cast<EventLogEntry>()
                        .OrderByDescending(e => e.TimeGenerated)
                        .Where(e => filtroTipo == null || e.EntryType == filtroTipo)
                        .Take(maxEventos);

                    foreach (var entrada in entradas)
                    {
                        var ev = new EventoDoSistema
                        {
                            Data = entrada.TimeGenerated,
                            DataFormatada = entrada.TimeGenerated.ToString("dd/MM/yyyy HH:mm:ss"),
                            EventId = entrada.InstanceId & 0xFFFF,
                            FonteOriginal = entrada.Source,
                            MensagemOriginal = entrada.Message?.Length > 500
                                ? entrada.Message.Substring(0, 500) + "..."
                                : entrada.Message ?? ""
                        };

                        // Tipo
                        switch (entrada.EntryType)
                        {
                            case EventLogEntryType.Error:
                                ev.Tipo = "Erro"; ev.TipoEmoji = "🔴"; break;
                            case EventLogEntryType.Warning:
                                ev.Tipo = "Aviso"; ev.TipoEmoji = "🟡"; break;
                            default:
                                ev.Tipo = "Informação"; ev.TipoEmoji = "🔵"; break;
                        }

                        // Fonte amigável
                        ev.FonteAmigavel = _fontesConhecidas.TryGetValue(entrada.Source, out string fa)
                            ? fa : entrada.Source;

                        // Explicação do evento
                        if (_eventosConhecidos.TryGetValue(ev.EventId, out var info))
                        {
                            ev.MensagemAmigavel = info.NomeAmigavel;
                            ev.OQueSignifica = info.OQueSignifica;
                            ev.OQueFazer = info.OQueFazer;
                            ev.Categoria = info.Categoria;
                        }
                        else
                        {
                            ev.MensagemAmigavel = $"{ev.FonteAmigavel} — Evento #{ev.EventId}";
                            ev.OQueSignifica = "Evento de sistema não catalogado nesta versão do Guia.";
                            ev.OQueFazer = "Se o tipo for 'Erro' e ocorrer com frequência, pesquise o ID do evento para mais informações.";
                            ev.Categoria = "Sistema";
                        }

                        lista.Add(ev);
                    }
                }
            }
            catch (Exception ex)
            {
                lista.Add(new EventoDoSistema
                {
                    DataFormatada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Tipo = "Erro",
                    TipoEmoji = "❌",
                    MensagemAmigavel = "Não foi possível ler os eventos do sistema",
                    OQueSignifica = ex.Message,
                    OQueFazer = "Execute o programa como Administrador para ver o histórico de eventos.",
                    Categoria = "Erro"
                });
            }
            return lista;
        }

        public static List<EventoDoSistema> ObterTodosOsLogs(int maxPorLog = 30)
        {
            var todos = new List<EventoDoSistema>();
            foreach (string log in new[] { "Application", "System", "Security" })
            {
                try { todos.AddRange(ObterEventosRecentes(log, maxPorLog)); }
                catch { /* sem permissão para Security — ignora */ }
            }
            return todos.OrderByDescending(e => e.Data).ToList();
        }

        public static ResumoEventos ObterResumo()
        {
            var resumo = new ResumoEventos();
            try
            {
                var eventos = ObterTodosOsLogs(100);
                resumo.TotalErros = eventos.Count(e => e.Tipo == "Erro");
                resumo.TotalAvisos = eventos.Count(e => e.Tipo == "Aviso");
                resumo.TotalInformacoes = eventos.Count(e => e.Tipo == "Informação");

                resumo.UltimoErro = eventos.FirstOrDefault(e => e.Tipo == "Erro")?.Data;

                // Desligamentos inesperados (ID 6008 ou 41)
                resumo.DesligamentosInesperados = eventos.Count(e =>
                    e.EventId == 6008 || e.EventId == 41);

                // Avaliação geral
                if (resumo.TotalErros == 0 && resumo.DesligamentosInesperados == 0)
                {
                    resumo.AvaliaoGeral = "Sistema funcionando bem — nenhum erro recente";
                    resumo.AvaliacaoEmoji = "🟢";
                }
                else if (resumo.TotalErros < 5 && resumo.DesligamentosInesperados == 0)
                {
                    resumo.AvaliaoGeral = "Alguns erros encontrados — nada crítico";
                    resumo.AvaliacaoEmoji = "🟡";
                }
                else if (resumo.DesligamentosInesperados > 0)
                {
                    resumo.AvaliaoGeral = $"⚠️ {resumo.DesligamentosInesperados} desligamento(s) inesperado(s) — recomendamos investigar";
                    resumo.AvaliacaoEmoji = "🟠";
                }
                else
                {
                    resumo.AvaliaoGeral = "Vários erros encontrados — recomendamos verificar";
                    resumo.AvaliacaoEmoji = "🔴";
                }
            }
            catch (Exception ex)
            {
                resumo.AvaliaoGeral = "Não foi possível analisar: " + ex.Message;
                resumo.AvaliacaoEmoji = "❌";
            }
            return resumo;
        }

        public static List<string> ObterCategorias() => new List<string>
        {
            "Todos", "Problema", "Segurança", "Login",
            "Sistema", "Atualização", "Rede", "Informação"
        };

        public static List<string> ObterLogs() =>
            new List<string> { "Application (Programas)", "System (Sistema)", "Security (Segurança)" };
    }
}