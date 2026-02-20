using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GuiaDoComputador
{
    public partial class FormControlPanel : Form
    {
        // =====================================================================
        // APIs NATIVAS DO WINDOWS
        // =====================================================================
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // =====================================================================
        // SEÇÕES DO PAINEL
        // =====================================================================
        private enum Secao { Tela, Energia, Rede, Usuarios, Inicializacao }

        private Secao _secaoAtiva = Secao.Tela;

        public FormControlPanel()
        {
            InitializeComponent();
            CarregarSecao(Secao.Tela);
        }

        private void AtualizarMenuAtivo(Secao ativa)
        {
            foreach (Control c in panelMenu.Controls)
            {
                if (c is Button btn)
                {
                    bool selecionado = (Secao)btn.Tag == ativa;
                    btn.BackColor = selecionado ? Color.FromArgb(16, 185, 129) : Color.Transparent;
                    btn.ForeColor = selecionado ? Color.White : Color.FromArgb(156, 163, 175);

                    // Efeito de barra lateral para item ativo
                    if (selecionado)
                    {
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        btn.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                    }
                }
            }
        }

        private void CarregarSecao(Secao secao)
        {
            _secaoAtiva = secao;
            AtualizarMenuAtivo(secao);
            panelConteudo.Controls.Clear();

            switch (secao)
            {
                case Secao.Tela: CarregarSecaoTela(); break;
                case Secao.Energia: CarregarSecaoEnergia(); break;
                case Secao.Rede: CarregarSecaoRede(); break;
                case Secao.Usuarios: CarregarSecaoUsuarios(); break;
                case Secao.Inicializacao: CarregarSecaoInicializacao(); break;
            }
        }

        // =====================================================================
        // SEÇÃO: TELA
        // =====================================================================
        private void CarregarSecaoTela()
        {
            var painel = CriarPainelSecao(
                "🖥️  Como minha tela está configurada?",
                "Resolução, monitores e qualidade de imagem — tudo explicado."
            );

            // Detectar resolução atual
            var largura = Screen.PrimaryScreen.Bounds.Width;
            var altura = Screen.PrimaryScreen.Bounds.Height;
            var larguraTrab = Screen.PrimaryScreen.WorkingArea.Width;
            var alturaTrab = Screen.PrimaryScreen.WorkingArea.Height;
            var monitores = Screen.AllScreens.Length;

            // Card 1: Resolução
            AdicionarInfoCard(painel,
                "📐  Resolução da tela",
                $"{largura} × {altura} pixels",
                largura >= 1920 ?
                    "✅ **Full HD ou superior** — Excelente qualidade! Imagem nítida e espaço suficiente para trabalhar.\n\n" +
                    "Resolução é a quantidade de pontos (pixels) na tela. Quanto maior, mais detalhes você vê." :
                    "ℹ️ **Resolução padrão** — Funciona bem, mas se quiser mais nitidez, pode aumentar nas configurações.\n\n" +
                    "Resolução maior = mais espaço para janelas e imagens mais nítidas.");

            // Card 2: Monitores
            AdicionarInfoCard(painel,
                "🖥️  Monitores conectados",
                monitores == 1 ? "1 monitor" : $"{monitores} monitores",
                monitores == 1 ?
                    "Você tem **um monitor** conectado. Isso é o suficiente para uso geral.\n\n" +
                    "💡 **Dica:** Com dois monitores, você pode arrastar janelas de um para o outro e aumentar sua produtividade!" :
                    $"✅ Você tem **{monitores} monitores** conectados. Isso permite trabalhar com vários programas ao mesmo tempo, arrastando janelas entre as telas.");

            // Card 3: Área de trabalho
            AdicionarInfoCard(painel,
                "📏  Área de trabalho disponível",
                $"{larguraTrab} × {alturaTrab} pixels",
                "É o espaço que sobra para suas janelas, descontando a barra de tarefas.\n\n" +
                "💡 **Curiosidade:** Se você esconder a barra de tarefas automaticamente, ganha um pouquinho mais de espaço vertical!");

            // Botões de ação
            painel.Controls.Add(CriarBotaoAcao("Abrir Configurações de Tela",
                "ms-settings:display",
                "Abre as configurações oficiais do Windows para ajustar resolução e orientação da tela."));

            painel.Controls.Add(CriarBotaoAcao("Abrir Painel de Controle → Tela",
                "control desk.cpl",
                "Abre as opções clássicas do Painel de Controle para configurações de vídeo."));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: ENERGIA
        // =====================================================================
        private void CarregarSecaoEnergia()
        {
            var painel = CriarPainelSecao(
                "⚡  Como meu computador lida com energia?",
                "Planos de energia, desempenho e duração da bateria — entenda as diferenças."
            );

            // Ler plano de energia atual
            string planoAtual = "Equilibrado";
            string descricaoPlano = "⚖️ Modo padrão que equilibra desempenho e economia de energia.";

            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo("powercfg", "/getactivescheme")
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                var saida = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                if (saida.Contains("Balanced") || saida.Contains("Balanceado"))
                {
                    planoAtual = "⚖️ Equilibrado";
                    descricaoPlano = "Modo padrão — o computador ajusta automaticamente o desempenho conforme a necessidade. Ideal para uso geral.";
                }
                else if (saida.Contains("High performance") || saida.Contains("Alto desempenho"))
                {
                    planoAtual = "🏎️ Alto Desempenho";
                    descricaoPlano = "Modo 'acelerador no fundo' — máximo desempenho o tempo todo, mas consome mais energia. Recomendado para jogos e edição de vídeo quando conectado à tomada.";
                }
                else if (saida.Contains("Power saver") || saida.Contains("Economia"))
                {
                    planoAtual = "🐢 Economia de Energia";
                    descricaoPlano = "Modo econômico — reduz o desempenho para economizar bateria. Ideal para notebooks longe da tomada.";
                }
                else if (saida.Contains("Ultimate"))
                {
                    planoAtual = "🔥 Desempenho Máximo";
                    descricaoPlano = "Máximo desempenho possível — para computadores de estação de trabalho. Consome muita energia.";
                }
            }
            catch { }

            // Card: Plano atual
            AdicionarInfoCard(painel,
                "🔋  Plano de Energia Ativo",
                planoAtual,
                descricaoPlano);

            // Card: Guia rápido
            AdicionarInfoCard(painel,
                "📖  Guia rápido: qual plano escolher?",
                "Entenda as diferenças",
                "🐢 **Economia de energia**\n" +
                "→ Use quando estiver longe da tomada e precisar que a bateria dure mais.\n\n" +
                "⚖️ **Equilibrado**\n" +
                "→ Use no dia a dia, para navegação, office e estudos.\n\n" +
                "🏎️ **Alto Desempenho**\n" +
                "→ Use quando estiver jogando, editando vídeos ou precisando de máxima potência (de preferência, conectado à tomada).");

            // Botões dos planos
            var lblTrocar = new Label
            {
                Text = "🔄  Trocar plano de energia agora:",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Size = new Size(700, 30),
                Margin = new Padding(10, 15, 0, 5)
            };
            painel.Controls.Add(lblTrocar);

            var flowPlanos = new FlowLayoutPanel
            {
                Size = new Size(700, 70),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(10, 0, 0, 15)
            };

            var planos = new[]
            {
                ("🐢  Economia", "a1841308-3541-4fab-bc81-f71556f20b4a", Color.FromArgb(34, 197, 94)),
                ("⚖️  Equilibrado", "381b4222-f694-41f0-9685-ff5bb260df2e", Color.FromArgb(59, 130, 246)),
                ("🏎️  Alto Desempenho", "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c", Color.FromArgb(239, 68, 68)),
            };

            foreach (var (nome, guid, cor) in planos)
            {
                var btn = new Button
                {
                    Text = nome,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    BackColor = cor,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(150, 50),
                    Margin = new Padding(0, 0, 10, 0),
                    Cursor = Cursors.Hand,
                    Tag = guid
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) =>
                {
                    try
                    {
                        var guidBtn = (string)((Button)s).Tag;
                        Process.Start("powercfg", $"/setactive {guidBtn}")?.WaitForExit();

                        MessageBox.Show(
                            "✅  Plano alterado com sucesso!\n\n" +
                            "A mudança já está ativa — você pode sentir a diferença imediatamente.\n\n" +
                            "💡 Dica: Se estiver no notebook, o Windows pode alternar automaticamente entre planos quando você conecta/desconecta da tomada.",
                            "Plano alterado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CarregarSecao(Secao.Energia);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erro ao alterar plano: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                flowPlanos.Controls.Add(btn);
            }
            painel.Controls.Add(flowPlanos);

            // Botões de ação
            painel.Controls.Add(CriarBotaoAcao("Abrir Opções de Energia (Painel de Controle)",
                "control powercfg.cpl",
                "Abre as configurações avançadas de energia do Windows."));

            painel.Controls.Add(CriarBotaoAcao("Gerar Relatório da Bateria (notebooks)",
                "batteryreport",
                "Cria um relatório completo da saúde da bateria e salva na área de trabalho."));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: REDE
        // =====================================================================
        private void CarregarSecaoRede()
        {
            var painel = CriarPainelSecao(
                "🌐  Como meu computador se conecta à internet?",
                "IP, DNS, gateway e velocidade — entenda sua conexão."
            );

            try
            {
                var nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up &&
                           n.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                    .ToList();

                if (!nics.Any())
                {
                    AdicionarInfoCard(painel,
                        "⚠️  Nenhuma conexão ativa",
                        "Seu computador não está conectado à internet",
                        "Verifique:\n" +
                        "• Se o cabo de rede está conectado\n" +
                        "• Se o Wi-Fi está ligado e conectado à rede certa\n" +
                        "• Se o modo Avião está desativado");
                }
                else
                {
                    foreach (var nic in nics.Take(3))
                    {
                        var props = nic.GetIPProperties();
                        var ip = props.UnicastAddresses
                            .FirstOrDefault(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                            .Address?.ToString() ?? "Não conectado";

                        var dns = props.DnsAddresses
                            .FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                            .ToString() ?? "Automático";

                        var gateway = props.GatewayAddresses
                            .FirstOrDefault()?.Address?.ToString() ?? "Nenhum";

                        var velocidade = nic.Speed > 0 ? $"{nic.Speed / 1_000_000} Mbps" : "N/A";
                        var tipo = nic.NetworkInterfaceType.ToString().Contains("Wireless") ? "📶 Wi-Fi" : "🔌 Cabo Ethernet";

                        AdicionarInfoCard(painel,
                            $"{tipo} — {nic.Name}",
                            $"IP: {ip}  |  Velocidade: {velocidade}",
                            $"📌 **O que significam esses números?**\n\n" +
                            $"• **IP {ip}** — É o 'endereço' do seu computador na rede, como o número da sua casa.\n\n" +
                            $"• **Gateway {gateway}** — É o 'portão de entrada' para a internet (geralmente seu roteador).\n\n" +
                            $"• **DNS {dns}** — É a 'lista telefônica' da internet, que traduz nomes de sites em números.\n\n" +
                            $"• **Velocidade {velocidade}** — Capacidade máxima da sua placa de rede.");
                    }
                }
            }
            catch (Exception ex)
            {
                AdicionarInfoCard(painel,
                    "❌  Erro ao ler informações",
                    "Não foi possível acessar os dados de rede",
                    $"Detalhe técnico: {ex.Message}\n\nTente executar como administrador.");
            }

            // Botões de ação
            painel.Controls.Add(CriarBotaoAcao("Abrir Configurações de Rede (Windows)",
                "ms-settings:network",
                "Abre as configurações modernas de rede do Windows 10/11."));

            painel.Controls.Add(CriarBotaoAcao("Abrir Adaptadores de Rede (avançado)",
                "ncpa.cpl",
                "Abre a lista de conexões de rede para configurar IP fixo e DNS."));

            painel.Controls.Add(CriarBotaoAcao("Renovar IP (ipconfig /renew)",
                "ipconfig_renew",
                "Libera e renova o endereço IP — resolve muitos problemas de conexão."));

            painel.Controls.Add(CriarBotaoAcao("Limpar Cache DNS (ipconfig /flushdns)",
                "ipconfig_flushdns",
                "Limpa a 'lista telefônica' da internet — resolve problemas de sites que não abrem."));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: USUÁRIOS
        // =====================================================================
        private void CarregarSecaoUsuarios()
        {
            var painel = CriarPainelSecao(
                "👤  Quem tem acesso ao meu computador?",
                "Contas de usuário, permissões e segurança."
            );

            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount WHERE LocalAccount = True");
                var usuarios = searcher.Get().Cast<ManagementObject>().ToList();

                if (!usuarios.Any())
                {
                    AdicionarInfoCard(painel,
                        "ℹ️  Informação restrita",
                        "Execute como administrador para ver usuários",
                        "Para visualizar a lista completa de usuários, execute o programa como administrador:\n\n" +
                        "1. Feche o programa\n" +
                        "2. Clique com botão direito no atalho\n" +
                        "3. Escolha 'Executar como administrador'");
                }
                else
                {
                    foreach (var user in usuarios)
                    {
                        var nome = user["Name"]?.ToString() ?? "?";
                        var tipo = user["AccountType"]?.ToString();
                        var ativo = (bool)(user["Disabled"] ?? false) ? "Desativada" : "Ativa";
                        var tipoLegivel = tipo == "512" || tipo == "66048" ? "Administrador" : "Usuário Padrão";

                        AdicionarInfoCard(painel,
                            $"👤  {nome}",
                            $"{tipoLegivel}  •  {ativo}",
                            $"**Conta: {nome}**\n\n" +
                            $"🔑 **Tipo:** {tipoLegivel}\n" +
                            (tipoLegivel == "Administrador" ?
                                "→ Pode instalar programas, alterar configurações do sistema e gerenciar outros usuários. Use com responsabilidade!" :
                                "→ Pode usar o computador normalmente, mas precisa de autorização para instalar programas ou mudar configurações do sistema.") +
                            $"\n\n⚡ **Status:** {ativo}");
                    }
                }
            }
            catch
            {
                AdicionarInfoCard(painel,
                    "⚠️  Sem permissão",
                    "Execute como administrador para ver usuários",
                    "Para acessar informações de usuários, é necessário executar o programa como administrador.");
            }

            // Botões de ação
            painel.Controls.Add(CriarBotaoAcao("Gerenciar Usuários (netplwiz)",
                "netplwiz",
                "Abre o gerenciador de usuários para adicionar/remover contas e configurar login automático."));

            painel.Controls.Add(CriarBotaoAcao("Configurações de Contas (Windows)",
                "ms-settings:accounts",
                "Abre as configurações modernas de contas do Windows."));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: INICIALIZAÇÃO
        // =====================================================================
        private void CarregarSecaoInicializacao()
        {
            var painel = CriarPainelSecao(
                "🚀  Como meu computador inicia?",
                "Programas que abrem sozinhos quando o Windows liga."
            );

            AdicionarInfoCard(painel,
                "⏱️  O que afeta a velocidade de inicialização?",
                "Cada programa na inicialização adiciona tempo ao boot",
                "Quando você liga o computador, o Windows precisa carregar:\n\n" +
                "• **O sistema operacional** (inevitável)\n" +
                "• **Programas configurados para iniciar automaticamente** (você pode controlar)\n\n" +
                "💡 **Dica:** Remover programas desnecessários da inicialização pode fazer o PC ligar MUITO mais rápido e liberar memória RAM.");

            // Ler programas de inicialização
            try
            {
                var startupItems = new List<(string nome, string caminho, string local)>();

                void LerChave(RegistryKey raiz, string subChave, string local)
                {
                    try
                    {
                        using var k = raiz.OpenSubKey(subChave);
                        if (k == null) return;
                        foreach (var nome in k.GetValueNames())
                        {
                            startupItems.Add((nome, k.GetValue(nome)?.ToString() ?? "?", local));
                        }
                    }
                    catch { }
                }

                LerChave(Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Seu usuário");
                LerChave(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Todos os usuários");

                if (startupItems.Any())
                {
                    var listaProgramas = string.Join("\n", startupItems
                        .Take(10)
                        .Select(i => $"• **{i.nome}** ({i.local})"));

                    if (startupItems.Count > 10)
                        listaProgramas += $"\n\n... e mais {startupItems.Count - 10} programa(s).";

                    AdicionarInfoCard(painel,
                        $"📋  {startupItems.Count} programa(s) na inicialização",
                        "Veja o que abre automaticamente:",
                        listaProgramas);
                }
                else
                {
                    AdicionarInfoCard(painel,
                        "✅  Inicialização limpa",
                        "Nenhum programa encontrado",
                        "Ótima notícia! Seu computador não tem programas desnecessários abrindo sozinhos. Isso contribui para uma inicialização mais rápida.");
                }
            }
            catch
            {
                AdicionarInfoCard(painel,
                    "ℹ️  Programas de inicialização",
                    "Não foi possível listar",
                    "Execute como administrador para ver a lista completa de programas de inicialização.");
            }

            // Botões de ação
            painel.Controls.Add(CriarBotaoAcao("Gerenciar Inicialização (Gerenciador de Tarefas)",
                "taskmgr startup",
                "Abre o Gerenciador de Tarefas na aba 'Inicializar' para desativar programas facilmente."));

            painel.Controls.Add(CriarBotaoAcao("Configuração do Sistema (msconfig)",
                "msconfig",
                "Abre ferramenta avançada para configurar serviços e inicialização."));

            painel.Controls.Add(CriarBotaoAcao("Configurações de Aplicativos de Inicialização (Windows)",
                "ms-settings:startupapps",
                "Abre as configurações modernas para gerenciar apps de inicialização."));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // HELPERS DE UI
        // =====================================================================
        private FlowLayoutPanel CriarPainelSecao(string titulo, string subtitulo)
        {
            var painel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10, 5, 20, 20),
                BackColor = Color.FromArgb(248, 250, 252)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = false,
                Size = new Size(700, 40),
                Margin = new Padding(10, 5, 0, 0)
            };

            var lblSubtitulo = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = false,
                Size = new Size(700, 25),
                Margin = new Padding(10, 0, 0, 15)
            };

            painel.Controls.Add(lblTitulo);
            painel.Controls.Add(lblSubtitulo);

            return painel;
        }

        private void AdicionarInfoCard(FlowLayoutPanel painel, string titulo, string resumo, string detalhe)
        {
            var card = new Panel
            {
                Size = new Size(700, 0),
                BackColor = Color.White,
                Margin = new Padding(10, 0, 0, 12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(15)
            };

            // Borda e sombra
            card.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 185, 129),
                Location = new Point(15, 12),
                Size = new Size(650, 22)
            };

            var lblResumo = new Label
            {
                Text = resumo,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(15, 38),
                Size = new Size(650, 20)
            };

            var lblDetalhe = new Label
            {
                Text = detalhe,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(15, 65),
                Size = new Size(650, 0),
                AutoSize = true
            };

            // Ajustar altura baseada no conteúdo
            lblDetalhe.Size = new Size(650, lblDetalhe.PreferredHeight);

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblResumo);
            card.Controls.Add(lblDetalhe);

            painel.Controls.Add(card);
        }

        private Button CriarBotaoAcao(string texto, string comando, string dica)
        {
            var btn = new Button
            {
                Text = $"  {texto}",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(500, 45),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Margin = new Padding(10, 5, 0, 5),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };

            // Tooltip explicativo
            var tooltip = new ToolTip();
            tooltip.SetToolTip(btn, dica);

            btn.Click += (s, e) =>
            {
                try
                {
                    switch (comando)
                    {
                        case "ipconfig_renew":
                            ExecutarComoAdmin("cmd.exe", "/K ipconfig /release && ipconfig /renew");
                            break;
                        case "ipconfig_flushdns":
                            ExecutarComoAdmin("cmd.exe", "/K ipconfig /flushdns");
                            break;
                        case "taskmgr startup":
                            Process.Start("taskmgr");
                            MessageBox.Show(
                                "✅ Gerenciador de Tarefas aberto!\n\n" +
                                "👉 Vá na aba 'Inicializar' para ver e desativar programas que abrem automaticamente.",
                                "Dica",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        case "batteryreport":
                            var caminho = System.IO.Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                $"relatorio_bateria_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                            var psi = new ProcessStartInfo("powercfg", $"/batteryreport /output \"{caminho}\"")
                            {
                                UseShellExecute = false,
                                CreateNoWindow = true
                            };
                            Process.Start(psi)?.WaitForExit(10000);

                            if (System.IO.File.Exists(caminho))
                            {
                                Process.Start(caminho);
                                MessageBox.Show(
                                    $"✅ Relatório gerado e salvo na área de trabalho!\n\n" +
                                    $"📄 Nome: {System.IO.Path.GetFileName(caminho)}",
                                    "Relatório de Bateria",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("❌ Erro ao gerar relatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            if (comando.StartsWith("ms-settings:") || comando == "msconfig" || comando == "netplwiz" || comando.StartsWith("control"))
                            {
                                Process.Start(new ProcessStartInfo(comando) { UseShellExecute = true });
                            }
                            else
                            {
                                ExecutarComoAdmin(comando, "");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erro ao executar comando: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Efeito hover
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(5, 150, 105);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(16, 185, 129);

            return btn;
        }

        private void ExecutarComoAdmin(string arquivo, string args)
        {
            try
            {
                var psi = new ProcessStartInfo(arquivo, args)
                {
                    Verb = "runas",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show(
                    "⚠️  Operação cancelada ou permissão negada.\n\n" +
                    "Este comando requer privilégios de administrador.",
                    "Permissão necessária",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}