using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Management;
using System.Linq;

namespace GuiaDoComputador
{
    public class ServicoDoWindows
    {
        public string NomeTecnico { get; set; }
        public string NomeAmigavel { get; set; }
        public string Emoji { get; set; }
        public string OQueEste { get; set; }
        public string ParaQueServe { get; set; }
        public string StatusAtual { get; set; }
        public string StatusEmoji { get; set; }
        public string TipoDeInicio { get; set; }
        public string Recomendacao { get; set; }
        public string OQueAconteceSeDesligar { get; set; }
        public bool PodeSerDesligado { get; set; }
        public bool EhCritico { get; set; }
        public string Categoria { get; set; }
        public string AcaoRapida { get; set; }
    }

    public static class WindowsServicesService
    {
        private static readonly Dictionary<string, (string NomeAmigavel, string Emoji, string OQueEste, string ParaQueServe, string OQueAconteceSeDesligar, bool PodeDesligar, bool EhCritico, string Categoria)> _descricoes
            = new Dictionary<string, (string, string, string, string, string, bool, bool, string)>(StringComparer.OrdinalIgnoreCase)
            {
                // IMPRESSÃO
                ["Spooler"] = ("Fila de Impressão", "🖨️",
                "É como um garçom que pega seus documentos e entrega para a impressora na ordem certa.",
                "Guarda os documentos que você mandou imprimir e os envia um por um para a impressora.",
                "A impressora para de funcionar completamente. Nenhum documento será impresso.",
                true, false, "Impressão"),

                // REDE E INTERNET
                ["Dhcp"] = ("Endereço de Internet Automático", "🌐",
                "É como um funcionário que distribui endereços numa repartição — dá um número único para o seu computador na rede.",
                "Pede automaticamente um endereço de internet para o seu roteador quando você conecta o computador.",
                "O computador não consegue se conectar ao Wi-Fi ou internet.",
                false, true, "Internet"),

                ["Dnscache"] = ("Memória de Sites Visitados", "🔖",
                "É como uma agenda de contatos — guarda os 'endereços reais' dos sites visitados para carregar mais rápido.",
                "Lembra o endereço real dos sites para não precisar procurar toda vez que você abre uma página.",
                "A internet pode ficar mais lenta porque o computador precisa buscar os endereços toda vez.",
                false, true, "Internet"),

                ["WlanSvc"] = ("Wi-Fi", "📶",
                "É o serviço que controla toda a conexão sem fio do seu computador.",
                "Gerencia a conexão Wi-Fi — detecta redes, conecta, mantém a conexão ativa.",
                "O Wi-Fi para de funcionar completamente.",
                false, true, "Internet"),

                ["LanmanWorkstation"] = ("Acesso a Arquivos em Rede", "📂",
                "Permite que você acesse arquivos e pastas de outros computadores conectados na mesma rede.",
                "Permite que seu computador acesse impressoras, pastas e arquivos de outros PCs na rede.",
                "Você não consegue mais acessar pastas ou impressoras de outros computadores.",
                true, false, "Rede"),

                ["Netlogon"] = ("Login em Rede de Empresa", "🏢",
                "Serviço usado principalmente em empresas para verificar se você tem permissão para usar o computador.",
                "Confirma sua identidade quando você faz login em redes corporativas.",
                "Pode ter dificuldade para fazer login em redes de empresa.",
                true, false, "Rede"),

                // SEGURANÇA
                ["WinDefend"] = ("Antivírus do Windows (Windows Defender)", "🛡️",
                "É o guarda de segurança do seu computador, que fica verificando se algo perigoso está tentando entrar.",
                "Protege seu computador contra vírus, programas maliciosos e ataques. É o antivírus gratuito que vem com o Windows.",
                "Seu computador fica sem proteção contra vírus e programas perigosos.",
                false, true, "Segurança"),

                ["MpsSvc"] = ("Muro de Proteção (Firewall)", "🔥",
                "É como uma portaria que controla quem pode entrar e sair do seu computador pela internet.",
                "Bloqueia conexões de internet não autorizadas — impede que programas perigosos se conectem sem sua permissão.",
                "Seu computador fica exposto a tentativas de invasão pela internet.",
                false, true, "Segurança"),

                ["SecurityHealthService"] = ("Central de Segurança", "🏥",
                "É o painel de controle da segurança do Windows — monitora se tudo está protegido.",
                "Verifica constantemente se o antivírus, firewall e atualizações estão funcionando corretamente.",
                "Você pode deixar de receber alertas importantes sobre problemas de segurança.",
                false, false, "Segurança"),

                ["RemoteRegistry"] = ("Acesso Remoto às Configurações", "⚠️",
                "Permite que outras pessoas na rede acessem configurações internas do seu computador remotamente.",
                "Usado por técnicos de TI em empresas para gerenciar computadores remotamente.",
                "Ninguém consegue mais acessar remotamente as configurações do sistema.",
                true, false, "Segurança"),

                ["CryptSvc"] = ("Proteção e Segurança de Dados", "🔐",
                "Cuida da segurança das suas informações, como um cofre que guarda senhas e certificados digitais.",
                "Gerencia certificados digitais e criptografia — necessário para sites seguros (cadeado verde).",
                "Sites seguros podem deixar de funcionar. Instalação de alguns programas pode ser afetada.",
                false, true, "Segurança"),

                // ATUALIZAÇÕES
                ["wuauserv"] = ("Atualizações do Windows", "🔄",
                "É o serviço que busca e instala as atualizações automáticas do Windows.",
                "Verifica periodicamente se há atualizações, baixa e instala automaticamente para manter o Windows seguro.",
                "O Windows para de receber atualizações de segurança. Não recomendado desativar.",
                false, true, "Atualizações"),

                ["UsoSvc"] = ("Coordenador de Atualizações", "📦",
                "Coordena quando e como as atualizações do Windows são baixadas e instaladas.",
                "Gerencia o processo de atualização — decide o melhor momento para baixar e instalar.",
                "As atualizações podem parar de funcionar corretamente.",
                false, false, "Atualizações"),

                // DESEMPENHO
                ["SysMain"] = ("Pré-carregamento de Programas", "⚡",
                "É como um assistente que adivinha quais programas você vai usar e os deixa carregados com antecedência.",
                "Aprende quais programas você usa com frequência e os pré-carrega na memória para abrir mais rápido.",
                "Programas podem demorar um pouco mais para abrir. Em PCs com pouca memória, desativar pode ajudar.",
                true, false, "Desempenho"),

                ["WSearch"] = ("Pesquisa Rápida de Arquivos", "🔍",
                "É como um índice de biblioteca — catalogou todos os seus arquivos para você encontrar qualquer coisa rapidamente.",
                "Fica em segundo plano catalogando seus arquivos para que a pesquisa do Windows seja instantânea.",
                "A pesquisa de arquivos no Windows fica muito mais lenta.",
                true, false, "Desempenho"),

                ["Schedule"] = ("Tarefas Programadas", "📅",
                "É como um alarme que dispara para o computador executar tarefas no horário certo.",
                "Executa tarefas automaticamente em horários definidos — limpezas, verificações e backups automáticos.",
                "Tarefas agendadas (limpeza, backup automático, etc.) param de funcionar.",
                false, true, "Desempenho"),

                // ÁUDIO
                ["AudioSrv"] = ("Som do Computador", "🔊",
                "É o serviço que controla todo o som do computador.",
                "Gerencia toda a saída e entrada de áudio — caixas de som, fones de ouvido, microfone.",
                "O computador fica completamente sem som.",
                false, true, "Áudio"),

                ["AudioEndpointBuilder"] = ("Reconhecimento de Dispositivos de Som", "🎵",
                "Detecta e configura automaticamente seus dispositivos de som quando conectados.",
                "Reconhece quando você conecta fones, caixas de som ou microfones e os configura automaticamente.",
                "Seus dispositivos de som podem parar de ser reconhecidos.",
                false, false, "Áudio"),

                // BLUETOOTH
                ["bthserv"] = ("Bluetooth", "🔵",
                "Controla as conexões sem fio de curta distância — fones, mouses, teclados sem fio.",
                "Gerencia todas as conexões Bluetooth — conectar, desconectar e manter pareados os dispositivos.",
                "Fones de ouvido, mouses e outros dispositivos Bluetooth param de funcionar.",
                true, false, "Dispositivos"),

                // DISPOSITIVOS
                ["DeviceInstall"] = ("Instalação de Novos Dispositivos", "🔌",
                "É como o assistente que te ajuda a configurar um produto novo quando você o conecta.",
                "Detecta quando você conecta algo novo (pen drive, mouse, impressora) e instala os drivers automaticamente.",
                "Novos dispositivos conectados não serão reconhecidos automaticamente.",
                false, true, "Dispositivos"),

                // ENERGIA
                ["Power"] = ("Gerenciamento de Energia", "🔋",
                "Controla como o computador usa e economiza energia.",
                "Gerencia o consumo de energia — brilho automático, suspensão, hibernação e planos de energia.",
                "O computador pode não suspender corretamente e a bateria pode durar menos.",
                false, true, "Energia"),

                // SISTEMA
                ["EventLog"] = ("Histórico de Eventos do Sistema", "📜",
                "É como um diário do computador — registra tudo que acontece para poder investigar problemas depois.",
                "Registra todos os eventos importantes: erros, avisos, logins, instalações e muito mais.",
                "O computador para de registrar eventos — fica impossível diagnosticar problemas.",
                false, true, "Sistema"),

                ["W32Time"] = ("Sincronização do Relógio", "🕐",
                "Mantém o horário do seu computador sempre correto, sincronizando com servidores de tempo na internet.",
                "Sincroniza automaticamente o relógio do computador com servidores de horário na internet.",
                "O relógio do computador pode ficar errado ao longo do tempo.",
                true, false, "Sistema"),

                ["VSS"] = ("Pontos de Restauração (Versões Anteriores)", "📸",
                "Tira 'fotos' do seu computador em momentos diferentes para você poder voltar no tempo se algo der errado.",
                "Cria pontos de restauração e permite recuperar versões anteriores de arquivos apagados ou modificados.",
                "Você não poderá restaurar arquivos para versões anteriores nem usar pontos de restauração.",
                false, true, "Backup"),

                ["SDRSVC"] = ("Backup do Windows", "💾",
                "Serviço responsável por fazer cópias de segurança dos seus arquivos.",
                "Executa o backup automático de arquivos e imagens do sistema para recuperação em caso de problemas.",
                "O backup automático do Windows para de funcionar.",
                true, false, "Backup"),

                // DIAGNÓSTICO
                ["DPS"] = ("Diagnóstico Automático de Problemas", "🔧",
                "É o técnico automático do Windows que detecta e tenta corrigir problemas por conta própria.",
                "Monitora o sistema em busca de problemas e oferece soluções automáticas quando algo dá errado.",
                "O Windows não vai mais oferecer soluções automáticas para problemas.",
                false, false, "Diagnóstico"),

                ["WerSvc"] = ("Relatório Quando Programas Travam", "📋",
                "Quando um programa fecha inesperadamente, este serviço registra o que aconteceu.",
                "Coleta informações quando programas travam e pode enviar relatórios para ajudar a corrigir problemas.",
                "Erros de programas não serão mais registrados para análise.",
                true, false, "Diagnóstico"),

                // LOCALIZAÇÃO
                ["lfsvc"] = ("Localização Geográfica", "📍",
                "Permite que aplicativos saibam onde você está geograficamente.",
                "Fornece dados de localização para aplicativos como mapas, previsão do tempo e outros.",
                "Aplicativos que usam localização (mapas, clima) param de funcionar corretamente.",
                true, false, "Localização"),

                // APARÊNCIA
                ["Themes"] = ("Aparência Visual do Windows", "🎨",
                "Controla toda a parte visual — cores, ícones e estilo das janelas.",
                "Responsável pela aparência bonita do Windows — transparências, animações, cores do tema.",
                "O Windows pode ficar com aparência bem básica e antiga.",
                false, false, "Aparência"),

                // IMPRESSÃO - notificações
                ["PrintNotify"] = ("Avisos de Impressão", "🖨️",
                "Envia mensagens para você quando a impressão termina ou quando algo dá errado.",
                "Avisa quando um documento terminou de imprimir ou quando ocorreu um erro na impressão.",
                "Você não recebe mais avisos sobre o status das impressões.",
                true, false, "Impressão"),
            };

        public static List<ServicoDoWindows> ObterServicos()
        {
            var lista = new List<ServicoDoWindows>();
            try
            {
                var servicos = ServiceController.GetServices();
                foreach (var servico in servicos.OrderBy(s => s.DisplayName))
                {
                    var item = new ServicoDoWindows { NomeTecnico = servico.ServiceName };

                    if (_descricoes.TryGetValue(servico.ServiceName, out var desc))
                    {
                        item.NomeAmigavel = desc.NomeAmigavel;
                        item.Emoji = desc.Emoji;
                        item.OQueEste = desc.OQueEste;
                        item.ParaQueServe = desc.ParaQueServe;
                        item.OQueAconteceSeDesligar = desc.OQueAconteceSeDesligar;
                        item.PodeSerDesligado = desc.PodeDesligar;
                        item.EhCritico = desc.EhCritico;
                        item.Categoria = desc.Categoria;
                    }
                    else
                    {
                        item.NomeAmigavel = servico.DisplayName;
                        item.Emoji = "⚙️";
                        item.OQueEste = "Serviço do sistema ou de um programa instalado.";
                        item.ParaQueServe = servico.DisplayName;
                        item.OQueAconteceSeDesligar = "Pode afetar o funcionamento de algum programa instalado.";
                        item.PodeSerDesligado = false;
                        item.EhCritico = false;
                        item.Categoria = "Outros";
                    }

                    item.StatusAtual = servico.Status switch
                    {
                        ServiceControllerStatus.Running => "Funcionando",
                        ServiceControllerStatus.Stopped => "Desligado",
                        ServiceControllerStatus.Paused => "Pausado",
                        ServiceControllerStatus.StartPending => "Iniciando...",
                        ServiceControllerStatus.StopPending => "Desligando...",
                        _ => "Desconhecido"
                    };
                    item.StatusEmoji = servico.Status switch
                    {
                        ServiceControllerStatus.Running => "🟢",
                        ServiceControllerStatus.Stopped => "🔴",
                        ServiceControllerStatus.Paused => "🟡",
                        _ => "🔵"
                    };

                    try
                    {
                        using (var searcher = new ManagementObjectSearcher(
                            $"SELECT StartMode FROM Win32_Service WHERE Name='{servico.ServiceName.Replace("'", "''")}'"))
                        {
                            foreach (ManagementObject obj in searcher.Get())
                            {
                                item.TipoDeInicio = (obj["StartMode"]?.ToString() ?? "") switch
                                {
                                    "Auto" => "Liga automático com o Windows",
                                    "Manual" => "Liga apenas quando necessário",
                                    "Disabled" => "Completamente desativado",
                                    var x => x
                                };
                            }
                        }
                    }
                    catch { item.TipoDeInicio = "Desconhecido"; }

                    if (item.EhCritico && item.StatusAtual == "Desligado")
                        item.Recomendacao = "⚠️ Este serviço é importante e está desligado! Recomendamos reativá-lo.";
                    else if (item.NomeTecnico.Equals("RemoteRegistry", StringComparison.OrdinalIgnoreCase) && item.StatusAtual == "Funcionando")
                        item.Recomendacao = "⚠️ Por segurança, considere desligar este serviço se não usa acesso remoto.";
                    else if (item.PodeSerDesligado && item.StatusAtual == "Funcionando")
                        item.Recomendacao = "💡 Pode ser desligado se você não usa essa função. Libera um pouco de memória.";
                    else
                        item.Recomendacao = "✅ Tudo normal.";

                    if (item.NomeTecnico.Equals("Spooler", StringComparison.OrdinalIgnoreCase))
                        item.AcaoRapida = "🖨️ Minha impressora travou — Corrigir agora";

                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                lista.Add(new ServicoDoWindows
                {
                    NomeTecnico = "Erro",
                    NomeAmigavel = "Não foi possível carregar os serviços",
                    Emoji = "❌",
                    StatusAtual = ex.Message,
                    StatusEmoji = "❌",
                    Categoria = "Erro",
                    Recomendacao = "Execute o programa como Administrador para ver os serviços do sistema."
                });
            }
            return lista;
        }

        public static (bool Sucesso, string Mensagem) ReiniciarServico(string nomeServico)
        {
            try
            {
                using (var sc = new ServiceController(nomeServico))
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                    }
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                    return (true, "✅ Serviço reiniciado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Não foi possível reiniciar.\n\n{ex.Message}\n\nDica: Execute o programa como Administrador.");
            }
        }

        public static (bool Sucesso, string Mensagem) PararServico(string nomeServico)
        {
            try
            {
                using (var sc = new ServiceController(nomeServico))
                {
                    if (sc.Status != ServiceControllerStatus.Running)
                        return (false, "Este serviço já está desligado.");
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                    return (true, "✅ Serviço desligado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Não foi possível desligar.\n\n{ex.Message}\n\nDica: Execute o programa como Administrador.");
            }
        }

        public static (bool Sucesso, string Mensagem) IniciarServico(string nomeServico)
        {
            try
            {
                using (var sc = new ServiceController(nomeServico))
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                        return (false, "Este serviço já está funcionando.");
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                    return (true, "✅ Serviço iniciado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Não foi possível iniciar.\n\n{ex.Message}\n\nDica: Execute o programa como Administrador.");
            }
        }

        public static List<string> ObterCategorias() => new List<string>
        {
            "Todos", "Impressão", "Internet", "Rede", "Segurança",
            "Atualizações", "Desempenho", "Áudio", "Dispositivos",
            "Energia", "Backup", "Sistema", "Diagnóstico", "Aparência",
            "Localização", "Outros"
        };
    }
}