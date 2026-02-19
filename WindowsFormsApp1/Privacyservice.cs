using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;

namespace GuiaDoComputador
{
    public class ConfiguracaoPrivacidade
    {
        public string Id { get; set; }
        public string Emoji { get; set; }
        public string Nome { get; set; }
        public string OQueEste { get; set; }
        public string ImpactoPrivacidade { get; set; }
        public string ImpactoEmoji { get; set; }
        public bool? EstadoAtual { get; set; }       // null = não foi possível verificar
        public string EstadoDescricao { get; set; }
        public string Recomendacao { get; set; }
        public string Categoria { get; set; }
        public bool PodeAlterar { get; set; }
        public string ChaveRegistro { get; set; }
        public string NomeValorRegistro { get; set; }
        public int ValorAtivado { get; set; }
        public int ValorDesativado { get; set; }
        public RegistryHive Hive { get; set; }
    }

    public class TweakRegistro
    {
        public string Id { get; set; }
        public string Emoji { get; set; }
        public string Nome { get; set; }
        public string OQueEste { get; set; }
        public string OQueMuda { get; set; }
        public string Categoria { get; set; }
        public string NivelRisco { get; set; }     // "seguro", "medio", "cuidado"
        public string Aviso { get; set; }
        public bool EstadoAtual { get; set; }
        public string ChaveRegistro { get; set; }
        public string NomeValor { get; set; }
        public string ValorAtivado { get; set; }
        public string ValorDesativado { get; set; }
        public RegistryValueKind TipoValor { get; set; }
        public RegistryHive Hive { get; set; }
    }

    public static class PrivacyService
    {
        // ─── CONFIGURAÇÕES DE PRIVACIDADE ─────────────────────────────────────

        public static List<ConfiguracaoPrivacidade> ObterConfiguracoesPrivacidade()
        {
            var lista = new List<ConfiguracaoPrivacidade>
            {
                // Telemetria
                new ConfiguracaoPrivacidade
                {
                    Id               = "telemetria",
                    Emoji            = "📊",
                    Nome             = "Envio de dados de uso para a Microsoft",
                    OQueEste         = "O Windows coleta informações sobre como você usa o computador e envia para a Microsoft para melhorar o sistema.",
                    ImpactoPrivacidade = "Médio — envia estatísticas de uso, erros e algumas informações do sistema",
                    ImpactoEmoji     = "🟡",
                    Recomendacao     = "Desativar não compromete o funcionamento. Boa opção para quem prefere mais privacidade.",
                    Categoria        = "Dados enviados à Microsoft",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    NomeValorRegistro= "AllowTelemetry",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },
                new ConfiguracaoPrivacidade
                {
                    Id               = "diagnosticoerros",
                    Emoji            = "🐛",
                    Nome             = "Enviar relatório quando programas travam",
                    OQueEste         = "Quando um programa fecha inesperadamente, o Windows pode enviar um relatório do erro para o fabricante do programa.",
                    ImpactoPrivacidade = "Baixo — envia informações técnicas do erro, útil para melhorar os programas",
                    ImpactoEmoji     = "🟢",
                    Recomendacao     = "Geralmente é seguro manter ativado — ajuda os fabricantes a corrigir problemas.",
                    Categoria        = "Dados enviados à Microsoft",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Microsoft\Windows\Windows Error Reporting",
                    NomeValorRegistro= "Disabled",
                    ValorAtivado     = 0,   // Disabled=0 significa habilitado
                    ValorDesativado  = 1
                },

                // Localização
                new ConfiguracaoPrivacidade
                {
                    Id               = "localizacao",
                    Emoji            = "📍",
                    Nome             = "Localização geográfica",
                    OQueEste         = "Permite que aplicativos saibam onde você está. Usado por aplicativos de mapa, clima e outros.",
                    ImpactoPrivacidade = "Alto — aplicativos podem saber exatamente onde você está",
                    ImpactoEmoji     = "🔴",
                    Recomendacao     = "Desativar se não usa aplicativos que precisam de localização.",
                    Categoria        = "Localização",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location",
                    NomeValorRegistro= "Value",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },

                // Câmera
                new ConfiguracaoPrivacidade
                {
                    Id               = "camera",
                    Emoji            = "📷",
                    Nome             = "Acesso à câmera por aplicativos",
                    OQueEste         = "Controla se aplicativos do Windows podem usar a câmera do computador.",
                    ImpactoPrivacidade = "Alto — controla quem pode te ver pela câmera",
                    ImpactoEmoji     = "🔴",
                    Recomendacao     = "Mantenha ativado apenas se usa aplicativos de videoconferência. Pode desativar e ativar quando precisar.",
                    Categoria        = "Câmera e Microfone",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam",
                    NomeValorRegistro= "Value",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },

                // Microfone
                new ConfiguracaoPrivacidade
                {
                    Id               = "microfone",
                    Emoji            = "🎤",
                    Nome             = "Acesso ao microfone por aplicativos",
                    OQueEste         = "Controla se aplicativos podem usar o microfone do computador.",
                    ImpactoPrivacidade = "Alto — controla quem pode te ouvir pelo microfone",
                    ImpactoEmoji     = "🔴",
                    Recomendacao     = "Desative se não usa chamadas de voz ou gravações. Pode reativar quando precisar.",
                    Categoria        = "Câmera e Microfone",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone",
                    NomeValorRegistro= "Value",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },

                // Anúncios personalizados
                new ConfiguracaoPrivacidade
                {
                    Id               = "anuncios",
                    Emoji            = "📢",
                    Nome             = "ID de publicidade (anúncios personalizados)",
                    OQueEste         = "O Windows cria um número de identificação para mostrar anúncios personalizados baseados no que você faz no computador.",
                    ImpactoPrivacidade = "Médio — usado para direcionar publicidade específica para você",
                    ImpactoEmoji     = "🟡",
                    Recomendacao     = "Sem impacto no funcionamento. Desativar impede anúncios direcionados.",
                    Categoria        = "Publicidade",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.CurrentUser,
                    ChaveRegistro    = @"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                    NomeValorRegistro= "Enabled",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },

                // Histórico de atividades
                new ConfiguracaoPrivacidade
                {
                    Id               = "historicoatividades",
                    Emoji            = "📋",
                    Nome             = "Histórico de atividades (Linha do Tempo)",
                    OQueEste         = "O Windows registra o que você fez — sites visitados, arquivos abertos, programas usados — para mostrar na Linha do Tempo.",
                    ImpactoPrivacidade = "Médio — alguém com acesso ao computador pode ver seu histórico",
                    ImpactoEmoji     = "🟡",
                    Recomendacao     = "Desativar se compartilha o computador ou prefere mais privacidade.",
                    Categoria        = "Histórico",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.LocalMachine,
                    ChaveRegistro    = @"SOFTWARE\Policies\Microsoft\Windows\System",
                    NomeValorRegistro= "EnableActivityFeed",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },

                // Sugestões na pesquisa
                new ConfiguracaoPrivacidade
                {
                    Id               = "pesquisanuvem",
                    Emoji            = "🔍",
                    Nome             = "Resultados da internet na pesquisa do Windows",
                    OQueEste         = "Quando você pesquisa algo no Windows (lupa da barra de tarefas), ele também busca na internet e envia o que você digitou para a Microsoft.",
                    ImpactoPrivacidade = "Baixo — o que você digita na pesquisa pode ser enviado para a Microsoft",
                    ImpactoEmoji     = "🟢",
                    Recomendacao     = "Desativar faz a pesquisa buscar apenas arquivos locais, sem enviar dados para a internet.",
                    Categoria        = "Pesquisa",
                    PodeAlterar      = true,
                    Hive             = RegistryHive.CurrentUser,
                    ChaveRegistro    = @"Software\Microsoft\Windows\CurrentVersion\Search",
                    NomeValorRegistro= "BingSearchEnabled",
                    ValorAtivado     = 1,
                    ValorDesativado  = 0
                },
            };

            // Ler estado atual de cada configuração
            foreach (var config in lista)
                config.EstadoAtual = LerEstadoPrivacidade(config);

            return lista;
        }

        private static bool? LerEstadoPrivacidade(ConfiguracaoPrivacidade config)
        {
            try
            {
                var raiz = config.Hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (var chave = raiz.OpenSubKey(config.ChaveRegistro, false))
                {
                    if (chave == null) return null;
                    var valor = chave.GetValue(config.NomeValorRegistro);
                    if (valor == null) return null;

                    if (valor is string s)
                        return s.Equals("Allow", StringComparison.OrdinalIgnoreCase) || s == "1";

                    int intVal = Convert.ToInt32(valor);
                    return intVal == config.ValorAtivado;
                }
            }
            catch { return null; }
        }

        public static (bool Sucesso, string Mensagem) AlterarPrivacidade(
            ConfiguracaoPrivacidade config, bool ativar)
        {
            try
            {
                var raiz = config.Hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (var chave = raiz.CreateSubKey(config.ChaveRegistro, true))
                {
                    if (chave == null)
                        return (false, "Sem permissão para alterar. Tente como Administrador.");

                    int novoValor = ativar ? config.ValorAtivado : config.ValorDesativado;
                    chave.SetValue(config.NomeValorRegistro, novoValor, RegistryValueKind.DWord);

                    string estado = ativar ? "ativado" : "desativado";
                    return (true, $"✅ '{config.Nome}' foi {estado} com sucesso!\n\nAlgumas mudanças podem precisar de reinicialização para ter efeito.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Erro: {ex.Message}\n\nTente executar como Administrador.");
            }
        }

        // ─── TWEAKS DE REGISTRO ───────────────────────────────────────────────

        public static List<TweakRegistro> ObterTweaks()
        {
            var lista = new List<TweakRegistro>
            {
                new TweakRegistro
                {
                    Id          = "menucontextoclassico",
                    Emoji       = "🖱️",
                    Nome        = "Menu do botão direito clássico (como no Windows 10)",
                    OQueEste    = "No Windows 11, o menu que aparece ao clicar com o botão direito foi redesenhado e ficou menor, escondendo algumas opções. Essa mudança traz de volta o menu completo do Windows 10.",
                    OQueMuda    = "O menu do botão direito volta a mostrar todas as opções de uma vez, sem precisar clicar em 'Mostrar mais opções'.",
                    Categoria   = "Conforto e Usabilidade",
                    NivelRisco  = "seguro",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32",
                    NomeValor   = "",
                    ValorAtivado= "",
                    TipoValor   = RegistryValueKind.String
                },
                new TweakRegistro
                {
                    Id          = "desativaranims",
                    Emoji       = "⚡",
                    Nome        = "Desativar animações visuais (Windows mais rápido)",
                    OQueEste    = "O Windows usa animações ao abrir janelas, minimizar programas e navegar menus. Em computadores mais antigos ou lentos, isso pode tornar tudo mais pesado.",
                    OQueMuda    = "Janelas e menus respondem instantaneamente sem aguardar animações. O computador parece mais rápido.",
                    Categoria   = "Desempenho",
                    NivelRisco  = "seguro",
                    Aviso       = "A aparência fica um pouco mais 'crua', sem animações suaves. Você pode reverter a qualquer momento.",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Control Panel\Desktop\WindowMetrics",
                    NomeValor   = "MinAnimate",
                    ValorAtivado= "0",   // 0 = sem animação
                    ValorDesativado = "1",
                    TipoValor   = RegistryValueKind.String
                },
                new TweakRegistro
                {
                    Id          = "paineltarefa",
                    Emoji       = "📌",
                    Nome        = "Barra de tarefas mais rápida (sem atraso ao passar o mouse)",
                    OQueEste    = "A barra de tarefas do Windows tem um atraso proposital ao mostrar as miniaturas quando você passa o mouse. Esta mudança elimina esse atraso.",
                    OQueMuda    = "Miniaturas aparecem imediatamente ao passar o mouse na barra de tarefas.",
                    Categoria   = "Conforto e Usabilidade",
                    NivelRisco  = "seguro",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    NomeValor   = "ExtendedUIHoverTime",
                    ValorAtivado= "1",
                    ValorDesativado = "400",
                    TipoValor   = RegistryValueKind.DWord
                },
                new TweakRegistro
                {
                    Id          = "desligarrapido",
                    Emoji       = "🔌",
                    Nome        = "Desligamento mais rápido do Windows",
                    OQueEste    = "O Windows aguarda até 5 segundos para serviços e programas fecharem ao desligar. Esta mudança reduz esse tempo.",
                    OQueMuda    = "O computador desliga mais rápido. Programas que não fecham a tempo são encerrados automaticamente.",
                    Categoria   = "Desempenho",
                    NivelRisco  = "medio",
                    Aviso       = "Programas que demoram para salvar dados podem ser fechados antes de terminar. Salve seus trabalhos antes de desligar.",
                    Hive        = RegistryHive.LocalMachine,
                    ChaveRegistro = @"SYSTEM\CurrentControlSet\Control",
                    NomeValor   = "WaitToKillServiceTimeout",
                    ValorAtivado= "2000",
                    ValorDesativado = "5000",
                    TipoValor   = RegistryValueKind.String
                },
                new TweakRegistro
                {
                    Id          = "mostrarextensoes",
                    Emoji       = "📄",
                    Nome        = "Mostrar o tipo de cada arquivo no nome",
                    OQueEste    = "Por padrão, o Windows esconde a extensão dos arquivos (.pdf, .docx, .mp3). Mostrar as extensões ajuda a identificar o tipo de arquivo e evitar abrir arquivos maliciosos.",
                    OQueMuda    = "Arquivos passam a mostrar o tipo no nome: 'documento.docx', 'foto.jpg', 'musica.mp3'.",
                    Categoria   = "Conforto e Usabilidade",
                    NivelRisco  = "seguro",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    NomeValor   = "HideFileExt",
                    ValorAtivado= "0",   // 0 = mostra extensões
                    ValorDesativado = "1",
                    TipoValor   = RegistryValueKind.DWord
                },
                new TweakRegistro
                {
                    Id          = "arquivosocultos",
                    Emoji       = "👁️",
                    Nome        = "Mostrar arquivos ocultos do sistema",
                    OQueEste    = "O Windows oculta arquivos importantes do sistema para evitar que sejam apagados acidentalmente. Ativar esta opção os torna visíveis.",
                    OQueMuda    = "Você verá arquivos que antes estavam invisíveis. Cuidado para não apagar arquivos do sistema.",
                    Categoria   = "Conforto e Usabilidade",
                    NivelRisco  = "medio",
                    Aviso       = "Não apague arquivos ocultos que você não reconhece — podem ser importantes para o sistema.",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    NomeValor   = "Hidden",
                    ValorAtivado= "1",
                    ValorDesativado = "2",
                    TipoValor   = RegistryValueKind.DWord
                },
                new TweakRegistro
                {
                    Id          = "lixeiranomenu",
                    Emoji       = "🗑️",
                    Nome        = "Confirmar antes de mover para a Lixeira",
                    OQueEste    = "Ativa uma caixa de confirmação que pergunta 'Tem certeza?' antes de mover um arquivo para a Lixeira.",
                    OQueMuda    = "Uma janela aparece pedindo confirmação antes de apagar qualquer arquivo.",
                    Categoria   = "Conforto e Usabilidade",
                    NivelRisco  = "seguro",
                    Hive        = RegistryHive.CurrentUser,
                    ChaveRegistro = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer",
                    NomeValor   = "ConfirmFileDelete",
                    ValorAtivado= "1",
                    ValorDesativado = "0",
                    TipoValor   = RegistryValueKind.DWord
                },
            };

            // Ler estado atual
            foreach (var tweak in lista)
                tweak.EstadoAtual = LerEstadoTweak(tweak);

            return lista;
        }

        private static bool LerEstadoTweak(TweakRegistro tweak)
        {
            try
            {
                var raiz = tweak.Hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (var chave = raiz.OpenSubKey(tweak.ChaveRegistro, false))
                {
                    if (chave == null) return false;
                    var valor = chave.GetValue(tweak.NomeValor);
                    if (valor == null) return false;
                    return valor.ToString() == tweak.ValorAtivado.ToString();
                }
            }
            catch { return false; }
        }

        public static (bool Sucesso, string Mensagem) AplicarTweak(TweakRegistro tweak, bool ativar)
        {
            try
            {
                // Criar ponto de restauração antes de mudanças de registro
                CriarPontoRestauracao($"Guia do Computador - Antes de aplicar: {tweak.Nome}");

                var raiz = tweak.Hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (var chave = raiz.CreateSubKey(tweak.ChaveRegistro, true))
                {
                    if (chave == null)
                        return (false, "Sem permissão. Tente como Administrador.");

                    string novoValor = ativar ? tweak.ValorAtivado : tweak.ValorDesativado;

                    if (tweak.TipoValor == RegistryValueKind.DWord)
                        chave.SetValue(tweak.NomeValor, int.Parse(novoValor), RegistryValueKind.DWord);
                    else
                        chave.SetValue(tweak.NomeValor, novoValor, RegistryValueKind.String);

                    return (true, $"✅ Configuração '{tweak.Nome}' {(ativar ? "ativada" : "desativada")} com sucesso!\n\nUm ponto de restauração foi criado antes da mudança, você pode desfazer se necessário.\n\nPode ser necessário reiniciar o computador para ver o efeito.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Erro: {ex.Message}");
            }
        }

        public static void CriarPontoRestauracao(string descricao)
        {
            try
            {
                // Usa PowerShell para criar ponto de restauração de forma silenciosa
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -WindowStyle Hidden -Command \"Checkpoint-Computer -Description '{descricao.Replace("'", "")}' -RestorePointType MODIFY_SETTINGS\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                });
            }
            catch { /* Não crítico — continua sem ponto de restauração */ }
        }

        public static void AbrirConfiguracaoPrivacidade() =>
            Process.Start(new ProcessStartInfo("ms-settings:privacy") { UseShellExecute = true });

        public static List<string> ObterCategorias() => new List<string>
        {
            "Todos", "Dados enviados à Microsoft", "Localização",
            "Câmera e Microfone", "Publicidade", "Histórico", "Pesquisa"
        };
    }
}