using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GuiaDoComputador
{
    public class ComandoDoSistema
    {
        public string Id { get; set; }
        public string Emoji { get; set; }
        public string NomeAmigavel { get; set; }
        public string OQueEste { get; set; }
        public string ParaQueServe { get; set; }
        public string QuandoUsar { get; set; }
        public string Categoria { get; set; }
        public string ComandoTecnico { get; set; }         // o que realmente roda
        public string TipoExecucao { get; set; }           // "abrir", "cmd", "cmd_admin"
        public bool PrecisaAdmin { get; set; }
        public string NivelRisco { get; set; }             // "seguro", "medio", "cuidado"
        public string AvisoAntes { get; set; }
        public bool MostraResultado { get; set; }
    }

    public static class SystemCommandsService
    {
        public static List<ComandoDoSistema> ObterComandos()
        {
            return new List<ComandoDoSistema>
            {
                // ── FERRAMENTAS DO SISTEMA ──────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "msconfig",
                    Emoji           = "🚀",
                    NomeAmigavel    = "O que liga quando o computador inicia",
                    OQueEste        = "É a central de controle de como o Windows inicia — quais serviços e programas são ativados quando você liga o computador.",
                    ParaQueServe    = "Permite que você escolha o que vai rodar quando o Windows ligar, controlando a velocidade de inicialização.",
                    QuandoUsar      = "Quando o computador está demorando muito para ligar ou quando você quer remover programas desnecessários da inicialização.",
                    Categoria       = "Desempenho",
                    ComandoTecnico  = "msconfig",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    AvisoAntes      = "Cuidado ao desativar serviços. Em caso de dúvida, não desative o que não reconhece.",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "taskmgr",
                    Emoji           = "📊",
                    NomeAmigavel    = "Gerenciador de Tarefas (o que está usando o computador)",
                    OQueEste        = "É como um painel de controle ao vivo que mostra todos os programas abertos e quanto de memória e processamento cada um está usando.",
                    ParaQueServe    = "Permite ver qual programa está travando o computador, forçar o fechamento de programas que pararam de responder e monitorar o desempenho.",
                    QuandoUsar      = "Quando o computador estiver lento, quando um programa travar ou quando você quiser saber o que está consumindo recursos.",
                    Categoria       = "Desempenho",
                    ComandoTecnico  = "taskmgr",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "resmon",
                    Emoji           = "📈",
                    NomeAmigavel    = "Monitor de Recursos Detalhado",
                    OQueEste        = "É uma versão mais detalhada do Gerenciador de Tarefas, mostrando gráficos em tempo real do processador, memória, disco e rede.",
                    ParaQueServe    = "Permite investigar mais a fundo o que está consumindo recursos do computador, com informações bem detalhadas.",
                    QuandoUsar      = "Quando o Gerenciador de Tarefas não é suficiente para entender por que o computador está lento.",
                    Categoria       = "Desempenho",
                    ComandoTecnico  = "resmon",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "perfmon",
                    Emoji           = "📉",
                    NomeAmigavel    = "Histórico de Desempenho do Computador",
                    OQueEste        = "Cria gráficos e relatórios mostrando como estava o desempenho do computador ao longo do tempo.",
                    ParaQueServe    = "Ajuda a identificar padrões — por exemplo, descobrir que o computador fica lento sempre no mesmo horário.",
                    QuandoUsar      = "Quando você quer investigar problemas de desempenho que ocorrem periodicamente.",
                    Categoria       = "Desempenho",
                    ComandoTecnico  = "perfmon",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },

                // ── DISCOS E ARMAZENAMENTO ─────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "diskmgmt",
                    Emoji           = "💾",
                    NomeAmigavel    = "Gerenciador de Discos (HD e SSD)",
                    OQueEste        = "É o mapa visual de todos os seus discos — mostra como estão divididos, quais partições existem e quanto espaço tem cada uma.",
                    ParaQueServe    = "Permite ver e organizar seus discos, criar divisões ou formatar partes do disco com mais segurança.",
                    QuandoUsar      = "Quando você quer ver informações sobre seus discos, conectou um HD externo que não aparece ou quer organizar o armazenamento.",
                    Categoria       = "Armazenamento",
                    ComandoTecnico  = "diskmgmt.msc",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    AvisoAntes      = "Cuidado ao formatar ou criar partições — isso pode apagar dados.",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "cleanmgr",
                    Emoji           = "🧹",
                    NomeAmigavel    = "Limpador de Disco do Windows",
                    OQueEste        = "É a ferramenta oficial do Windows para limpar arquivos desnecessários e liberar espaço no disco.",
                    ParaQueServe    = "Remove arquivos temporários, cache do Windows Update e outros arquivos que podem ser apagados com segurança.",
                    QuandoUsar      = "Quando o disco estiver ficando cheio ou para manutenção preventiva periódica.",
                    Categoria       = "Armazenamento",
                    ComandoTecnico  = "cleanmgr",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "chkdsk",
                    Emoji           = "🔍",
                    NomeAmigavel    = "Verificação de Saúde do Disco",
                    OQueEste        = "É como um médico que examina seu disco em busca de problemas — setores com defeito, erros de arquivo ou corrupção de dados.",
                    ParaQueServe    = "Verifica a integridade do disco e tenta corrigir erros encontrados automaticamente.",
                    QuandoUsar      = "Quando o computador trava, arquivos somem do nada ou o Windows demora para carregar arquivos.",
                    Categoria       = "Armazenamento",
                    ComandoTecnico  = "chkdsk C: /f /r",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = true,
                    NivelRisco      = "seguro",
                    AvisoAntes      = "Este processo pode demorar bastante (horas em discos grandes). O computador pode precisar reiniciar para concluir. Salve todos os seus arquivos antes.",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "defrag",
                    Emoji           = "🗂️",
                    NomeAmigavel    = "Organizar o Disco (Desfragmentação)",
                    OQueEste        = "Reorganiza os arquivos do disco para que fiquem mais próximos uns dos outros, como organizar uma gaveta bagunçada.",
                    ParaQueServe    = "Melhora a velocidade de leitura de arquivos em HDs (discos antigos mecânicos). SSDs modernos não precisam.",
                    QuandoUsar      = "Apenas se você tiver um HD antigo mecânico (não SSD). O Windows geralmente faz isso automaticamente.",
                    Categoria       = "Armazenamento",
                    ComandoTecnico  = "dfrgui",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },

                // ── REDE E INTERNET ────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "ipconfig",
                    Emoji           = "🌐",
                    NomeAmigavel    = "Ver informações completas da minha internet",
                    OQueEste        = "Mostra todas as informações técnicas sobre como seu computador está conectado à internet.",
                    ParaQueServe    = "Exibe seu endereço IP, máscara de rede, endereço do roteador e informações de DNS.",
                    QuandoUsar      = "Quando precisar do endereço IP do computador ou para diagnosticar problemas de conexão.",
                    Categoria       = "Rede",
                    ComandoTecnico  = "ipconfig /all",
                    TipoExecucao    = "cmd",
                    NivelRisco      = "seguro",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "ipconfigrenew",
                    Emoji           = "🔄",
                    NomeAmigavel    = "Renovar conexão de internet (resolver problemas de Wi-Fi)",
                    OQueEste        = "Pede um novo endereço de internet para o roteador, como desligar e ligar o Wi-Fi.",
                    ParaQueServe    = "Resolve problemas de conexão onde o computador está conectado no Wi-Fi mas sem internet.",
                    QuandoUsar      = "Quando estiver conectado no Wi-Fi mas não conseguir acessar sites, ou após trocar de rede.",
                    Categoria       = "Rede",
                    ComandoTecnico  = "ipconfig /release && ipconfig /flushdns && ipconfig /renew",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = true,
                    NivelRisco      = "seguro",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "ping",
                    Emoji           = "📡",
                    NomeAmigavel    = "Testar se a internet está funcionando",
                    OQueEste        = "Envia uma mensagem para um servidor e mede quanto tempo leva para receber resposta — como gritar numa caverna e medir o eco.",
                    ParaQueServe    = "Verifica se sua internet está ativa e mede a velocidade de resposta (latência).",
                    QuandoUsar      = "Quando não sabe se é problema do seu computador ou da internet em geral.",
                    Categoria       = "Rede",
                    ComandoTecnico  = "ping google.com -n 4",
                    TipoExecucao    = "cmd",
                    NivelRisco      = "seguro",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "netstat",
                    Emoji           = "🔌",
                    NomeAmigavel    = "Ver quais programas estão usando a internet agora",
                    OQueEste        = "Mostra todas as conexões de internet ativas no seu computador — quais programas estão enviando ou recebendo dados.",
                    ParaQueServe    = "Permite identificar programas suspeitos que podem estar usando sua internet sem você saber.",
                    QuandoUsar      = "Quando a internet está lenta sem motivo aparente, ou se suspeitar que algo está usando dados em segundo plano.",
                    Categoria       = "Rede",
                    ComandoTecnico  = "netstat -b",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = true,
                    NivelRisco      = "seguro",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "ncpa",
                    Emoji           = "🔗",
                    NomeAmigavel    = "Configurações de Rede",
                    OQueEste        = "Mostra todas as formas de conexão do seu computador — Wi-Fi, cabo, Bluetooth, etc.",
                    ParaQueServe    = "Permite ativar, desativar ou configurar cada tipo de conexão de rede.",
                    QuandoUsar      = "Para desativar uma conexão específica, ver propriedades de rede ou solucionar problemas avançados.",
                    Categoria       = "Rede",
                    ComandoTecnico  = "ncpa.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    MostraResultado = false
                },

                // ── USUÁRIOS E CONTAS ──────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "netplwiz",
                    Emoji           = "👤",
                    NomeAmigavel    = "Gerenciar usuários do computador",
                    OQueEste        = "Mostra quem tem acesso ao computador e permite adicionar, remover ou alterar contas de usuário.",
                    ParaQueServe    = "Permite criar contas para outras pessoas, definir se precisam de senha para entrar e gerenciar permissões.",
                    QuandoUsar      = "Para criar um usuário para outra pessoa, remover uma conta antiga ou fazer o computador entrar automaticamente sem pedir senha.",
                    Categoria       = "Usuários",
                    ComandoTecnico  = "netplwiz",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "lusrmgr",
                    Emoji           = "👥",
                    NomeAmigavel    = "Gerenciador Avançado de Usuários",
                    OQueEste        = "Versão mais completa do gerenciador de contas — mostra usuários e grupos do sistema.",
                    ParaQueServe    = "Permite um controle mais detalhado sobre contas — bloqueá-las, definir senhas que não expiram, etc.",
                    QuandoUsar      = "Para gerenciamento avançado de contas em computadores compartilhados ou em ambientes de trabalho.",
                    Categoria       = "Usuários",
                    ComandoTecnico  = "lusrmgr.msc",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    MostraResultado = false
                },

                // ── SEGURANÇA ──────────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "windowsdefender",
                    Emoji           = "🛡️",
                    NomeAmigavel    = "Segurança do Windows (Antivírus)",
                    OQueEste        = "Abre o painel completo de segurança do Windows — antivírus, firewall e proteções.",
                    ParaQueServe    = "Ver o status da proteção, fazer varredura manual por vírus e configurar as defesas do sistema.",
                    QuandoUsar      = "Para verificar se o antivírus está funcionando, fazer uma verificação por vírus ou ver se há ameaças.",
                    Categoria       = "Segurança",
                    ComandoTecnico  = "windowsdefender:",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "firewall",
                    Emoji           = "🔥",
                    NomeAmigavel    = "Muro de Proteção (Firewall)",
                    OQueEste        = "Controla quais programas podem enviar e receber dados pela internet.",
                    ParaQueServe    = "Permite bloquear ou liberar programas, ver regras de segurança e proteger o computador de acessos não autorizados.",
                    QuandoUsar      = "Quando um programa não consegue acessar a internet ou para verificar regras de segurança.",
                    Categoria       = "Segurança",
                    ComandoTecnico  = "firewall.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    MostraResultado = false
                },

                // ── DISPOSITIVOS ───────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "devmgmt",
                    Emoji           = "🔌",
                    NomeAmigavel    = "Gerenciador de Dispositivos (todas as peças)",
                    OQueEste        = "Mostra todas as peças físicas do computador e se estão funcionando corretamente.",
                    ParaQueServe    = "Permite identificar peças com problema (marcadas com triângulo amarelo), atualizar drivers e verificar o hardware.",
                    QuandoUsar      = "Quando algum dispositivo para de funcionar, quando um novo dispositivo não é reconhecido ou para verificar drivers.",
                    Categoria       = "Dispositivos",
                    ComandoTecnico  = "devmgmt.msc",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "mmsys",
                    Emoji           = "🔊",
                    NomeAmigavel    = "Configurações de Som",
                    OQueEste        = "Painel completo de configuração de todos os dispositivos de som do computador.",
                    ParaQueServe    = "Selecionar caixas de som, configurar microfone, ajustar volumes de cada dispositivo.",
                    QuandoUsar      = "Quando não sai som por um dispositivo específico, quando o microfone não funciona ou para trocar o dispositivo de som padrão.",
                    Categoria       = "Dispositivos",
                    ComandoTecnico  = "mmsys.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },

                // ── DIAGNÓSTICO ────────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "sfc",
                    Emoji           = "🔧",
                    NomeAmigavel    = "Verificar e corrigir arquivos do Windows",
                    OQueEste        = "Verifica se os arquivos do Windows estão intactos e tenta recuperar automaticamente os que estiverem corrompidos.",
                    ParaQueServe    = "Corrige problemas causados por arquivos do sistema danificados — pode resolver crashes, lentidão e erros estranhos.",
                    QuandoUsar      = "Quando o Windows apresenta comportamentos estranhos, erros frequentes ou tela azul.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "sfc /scannow",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = true,
                    NivelRisco      = "seguro",
                    AvisoAntes      = "Este processo demora alguns minutos. Não feche a janela enquanto estiver rodando.",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "dism",
                    Emoji           = "🏥",
                    NomeAmigavel    = "Reparar o Windows (ferramenta avançada)",
                    OQueEste        = "É como uma cirurgia para o Windows — verifica e baixa da internet os arquivos corretos para substituir os danificados.",
                    ParaQueServe    = "Repara a imagem do Windows baixando componentes originais da Microsoft, resolvendo problemas que o SFC não conseguiu.",
                    QuandoUsar      = "Após rodar a verificação de arquivos e o problema persistir, ou quando o Windows está com problemas sérios.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "DISM /Online /Cleanup-Image /RestoreHealth",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = true,
                    NivelRisco      = "seguro",
                    AvisoAntes      = "Precisa de internet. Pode demorar 10-30 minutos. Não feche a janela.",
                    MostraResultado = true
                },
                new ComandoDoSistema
                {
                    Id              = "eventvwr",
                    Emoji           = "📜",
                    NomeAmigavel    = "Histórico de tudo que aconteceu no computador",
                    OQueEste        = "É o diário completo do Windows — registra todos os eventos: erros, avisos, logins e instalações.",
                    ParaQueServe    = "Permite investigar erros, ver quando o computador foi ligado/desligado e encontrar a causa de problemas.",
                    QuandoUsar      = "Para investigar por que o computador travou, quando ocorreu um erro ou para ver o histórico de uso.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "eventvwr",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "mdsched",
                    Emoji           = "🧠",
                    NomeAmigavel    = "Verificar a memória do computador",
                    OQueEste        = "Testa as memórias RAM do computador em busca de defeitos que possam causar travamentos e erros.",
                    ParaQueServe    = "Diagnostica problemas de memória que causam telas azuis, travamentos e comportamentos erráticos.",
                    QuandoUsar      = "Quando o computador trava aleatoriamente, apresenta telas azuis frequentes ou comportamento imprevisível.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "mdsched",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    AvisoAntes      = "O computador vai reiniciar para executar o teste. Salve todos os seus arquivos antes.",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "batteryreport",
                    Emoji           = "🔋",
                    NomeAmigavel    = "Relatório completo da bateria",
                    OQueEste        = "Gera um relatório detalhado mostrando o histórico de uso e a saúde atual da bateria do notebook.",
                    ParaQueServe    = "Mostra a capacidade real atual da bateria comparada com a capacidade original — indica se a bateria está desgastada.",
                    QuandoUsar      = "Para notebooks onde a bateria parece durar menos do que antes.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "powercfg /batteryreport /output \"%USERPROFILE%\\Desktop\\relatorio_bateria.html\" && start \"\" \"%USERPROFILE%\\Desktop\\relatorio_bateria.html\"",
                    TipoExecucao    = "cmd_admin",
                    PrecisaAdmin    = false,
                    NivelRisco      = "seguro",
                    AvisoAntes      = "O relatório será aberto no navegador e também salvo na Área de Trabalho.",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "systeminfo",
                    Emoji           = "ℹ️",
                    NomeAmigavel    = "Informações completas do sistema",
                    OQueEste        = "Exibe um resumo completo de todas as configurações e informações do seu computador.",
                    ParaQueServe    = "Mostra versão do Windows, data de instalação, memória, processador, hotfixes instalados e muito mais.",
                    QuandoUsar      = "Quando precisar de informações detalhadas sobre o computador para suporte técnico ou diagnóstico.",
                    Categoria       = "Diagnóstico",
                    ComandoTecnico  = "systeminfo",
                    TipoExecucao    = "cmd",
                    NivelRisco      = "seguro",
                    MostraResultado = true
                },

                // ── ENERGIA ─────────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "powercfg",
                    Emoji           = "⚡",
                    NomeAmigavel    = "Planos de Energia",
                    OQueEste        = "Controla como o computador usa energia — se prioriza velocidade ou economia.",
                    ParaQueServe    = "Permite escolher entre performance máxima, economia ou equilíbrio entre os dois.",
                    QuandoUsar      = "Para notebooks onde quer economizar bateria, ou em desktops onde quer máxima performance.",
                    Categoria       = "Energia",
                    ComandoTecnico  = "powercfg.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },

                // ── PERSONALIZAÇÃO ─────────────────────────────────────────────────
                new ComandoDoSistema
                {
                    Id              = "desk",
                    Emoji           = "🖥️",
                    NomeAmigavel    = "Configurações da Tela",
                    OQueEste        = "Controla tudo relacionado à aparência da tela — resolução, rotação, brilho e arranjo de monitores.",
                    ParaQueServe    = "Ajustar resolução, configurar múltiplos monitores e definir a orientação da tela.",
                    QuandoUsar      = "Quando a tela está com resolução errada, quando conectou um monitor externo ou quer ajustar configurações visuais.",
                    Categoria       = "Personalização",
                    ComandoTecnico  = "desk.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "timedate",
                    Emoji           = "🕐",
                    NomeAmigavel    = "Data e Hora",
                    OQueEste        = "Configurações de data, hora e fuso horário do computador.",
                    ParaQueServe    = "Acertar data e hora, mudar o fuso horário ou ativar/desativar sincronização automática.",
                    QuandoUsar      = "Quando o relógio do computador está errado.",
                    Categoria       = "Personalização",
                    ComandoTecnico  = "timedate.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "appwiz",
                    Emoji           = "📦",
                    NomeAmigavel    = "Desinstalar Programas",
                    OQueEste        = "Lista todos os programas instalados no computador com opção de desinstalar.",
                    ParaQueServe    = "Remover programas que não usa mais para liberar espaço e organizar o computador.",
                    QuandoUsar      = "Para desinstalar programas, ver o que está instalado ou liberar espaço no disco.",
                    Categoria       = "Personalização",
                    ComandoTecnico  = "appwiz.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "medio",
                    AvisoAntes      = "Desinstale apenas programas que você reconhece e tem certeza que não precisa.",
                    MostraResultado = false
                },
                new ComandoDoSistema
                {
                    Id              = "intl",
                    Emoji           = "🌍",
                    NomeAmigavel    = "Idioma e Formato Regional",
                    OQueEste        = "Define como datas, números e moedas são exibidos no computador.",
                    ParaQueServe    = "Configurar o formato de data (DD/MM/AAAA), separador de milhar e outros padrões regionais.",
                    QuandoUsar      = "Quando datas ou números aparecem em formato estranho, ou para ajustar configurações regionais.",
                    Categoria       = "Personalização",
                    ComandoTecnico  = "intl.cpl",
                    TipoExecucao    = "abrir",
                    NivelRisco      = "seguro",
                    MostraResultado = false
                },
            };
        }

        public static (bool Sucesso, string Saida, string MensagemErro) ExecutarComando(ComandoDoSistema cmd)
        {
            try
            {
                if (cmd.TipoExecucao == "abrir")
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = cmd.ComandoTecnico,
                        UseShellExecute = true
                    });
                    return (true, "Janela aberta com sucesso.", "");
                }
                else if (cmd.TipoExecucao == "cmd" || cmd.TipoExecucao == "cmd_admin")
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {cmd.ComandoTecnico}",
                        RedirectStandardOutput = cmd.MostraResultado,
                        RedirectStandardError = cmd.MostraResultado,
                        UseShellExecute = !cmd.MostraResultado,
                        CreateNoWindow = cmd.MostraResultado,
                        Verb = cmd.PrecisaAdmin ? "runas" : ""
                    };

                    using (var proc = Process.Start(psi))
                    {
                        if (cmd.MostraResultado && proc != null)
                        {
                            string saida = proc.StandardOutput.ReadToEnd();
                            string erro = proc.StandardError.ReadToEnd();
                            proc.WaitForExit(120000); // 2 minutos máximo
                            return (true, saida, erro);
                        }
                    }
                    return (true, "Comando executado.", "");
                }
                return (false, "", "Tipo de execução desconhecido.");
            }
            catch (Exception ex)
            {
                return (false, "", $"Não foi possível executar: {ex.Message}");
            }
        }

        public static List<string> ObterCategorias() => new List<string>
        {
            "Todos", "Desempenho", "Armazenamento", "Rede",
            "Segurança", "Diagnóstico", "Dispositivos",
            "Usuários", "Energia", "Personalização"
        };
    }
}