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

        // =====================================================================
        // CONTROLES
        // =====================================================================
        private Panel panelMenu;
        private Panel panelConteudo;
        private Secao _secaoAtiva = Secao.Tela;

        public FormControlPanel()
        {
            InitializeComponent();
            ConstruirInterface();
            CarregarSecao(Secao.Tela);
        }

        private void ConstruirInterface()
        {
            this.Text = "Painel de Controle Simplificado";
            this.Size = new Size(1050, 700);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 9.5f);

            // Cabeçalho
            var panelTopo = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(22, 160, 133), Padding = new Padding(20, 0, 20, 0) };
            panelTopo.Controls.Add(new Label { Text = "🎛️  Painel de Controle Simplificado", Font = new Font("Segoe UI", 14f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Left, Width = 470, TextAlign = ContentAlignment.MiddleLeft });
            panelTopo.Controls.Add(new Label { Text = "Configurações do Windows explicadas para todos", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(180, 240, 230), Dock = DockStyle.Right, Width = 370, TextAlign = ContentAlignment.MiddleRight });

            // Menu lateral esquerdo
            panelMenu = new Panel { Dock = DockStyle.Left, Width = 200, BackColor = Color.FromArgb(44, 62, 80) };

            var menuItens = new[]
            {
                ("🖥️", "Como minha tela\nestá configurada?", Secao.Tela),
                ("⚡", "Como meu PC lida\ncom energia?", Secao.Energia),
                ("🌐", "Como me conecto\nà internet?", Secao.Rede),
                ("👤", "Quem tem acesso\nao meu PC?", Secao.Usuarios),
                ("🚀", "Como meu PC\ninicia?", Secao.Inicializacao),
            };

            int y = 10;
            foreach (var (icone, texto, secao) in menuItens)
            {
                var btn = CriarBotaoMenu(icone, texto, secao);
                btn.Location = new Point(0, y);
                panelMenu.Controls.Add(btn);
                y += btn.Height + 4;
            }

            // Área de conteúdo
            panelConteudo = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 246, 250), AutoScroll = true, Padding = new Padding(20) };

            this.Controls.Add(panelConteudo);
            this.Controls.Add(panelMenu);
            this.Controls.Add(panelTopo);
        }

        private Button CriarBotaoMenu(string icone, string texto, Secao secao)
        {
            var btn = new Button
            {
                Text = icone + "\n" + texto,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(180, 195, 210),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(200, 70),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0),
                Cursor = Cursors.Hand,
                Tag = secao
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 80, 100);
            btn.Click += (s, e) => CarregarSecao((Secao)btn.Tag);
            return btn;
        }

        private void AtualizarMenuAtivo(Secao ativa)
        {
            foreach (Control c in panelMenu.Controls)
            {
                if (c is Button btn)
                {
                    bool selecionado = (Secao)btn.Tag == ativa;
                    btn.BackColor = selecionado ? Color.FromArgb(22, 160, 133) : Color.Transparent;
                    btn.ForeColor = selecionado ? Color.White : Color.FromArgb(180, 195, 210);
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
            var painel = CriarPainelSecao("🖥️ Como minha tela está configurada?", "Veja e entenda as configurações da sua tela em linguagem simples.");

            // Detectar resolução atual
            var largura = Screen.PrimaryScreen.Bounds.Width;
            var altura = Screen.PrimaryScreen.Bounds.Height;
            var larguraTrab = Screen.PrimaryScreen.WorkingArea.Width;
            var alturaTrab = Screen.PrimaryScreen.WorkingArea.Height;
            var monitores = Screen.AllScreens.Length;

            AdicionarInfoCard(painel, "📐 Resolução Atual", $"{largura} × {altura} pixels",
                $"Resolução é a quantidade de pontos (pixels) na sua tela. {largura}×{altura} significa {largura} pontos na horizontal e {altura} na vertical. " +
                $"Resolução maior = imagem mais nítida, mas ícones menores. " +
                (largura >= 1920 ? "✔ Você está usando Full HD ou superior — ótima qualidade!" : "ℹ️ Uma resolução mais alta pode melhorar a nitidez da imagem."));

            AdicionarInfoCard(painel, "🖥️ Monitores conectados", $"{monitores} monitor{(monitores > 1 ? "es" : "")}",
                monitores > 1 ? $"Você tem {monitores} monitores conectados ao computador. Isso é útil para trabalhar com mais programas ao mesmo tempo." : "Você tem apenas um monitor conectado. Se quiser usar dois monitores, basta conectar um segundo e o Windows irá detectá-lo.");

            AdicionarInfoCard(painel, "📏 Área de trabalho disponível", $"{larguraTrab} × {alturaTrab} pixels",
                "É o espaço disponível para suas janelas, descontando a barra de tarefas. Quanto maior, mais janelas cabem na tela ao mesmo tempo.");

            var btnAbrirTela = CriarBotaoAcao("Abrir Configurações de Tela do Windows", () =>
            {
                Process.Start("ms-settings:display");
            });
            painel.Controls.Add(btnAbrirTela);

            var btnAbrirResolucao = CriarBotaoAcao("Abrir Painel de Controle → Tela", () =>
            {
                Process.Start("control", "desk.cpl");
            });
            painel.Controls.Add(btnAbrirResolucao);

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: ENERGIA
        // =====================================================================
        private void CarregarSecaoEnergia()
        {
            var painel = CriarPainelSecao("⚡ Como meu computador lida com energia?", "Entenda os planos de energia e como eles afetam o desempenho e a bateria.");

            // Ler plano de energia atual
            string planoAtual = "Desconhecido";
            try
            {
                var proc = new Process { StartInfo = new ProcessStartInfo("powercfg", "/getactivescheme") { UseShellExecute = false, RedirectStandardOutput = true, CreateNoWindow = true } };
                proc.Start();
                var saida = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                if (saida.Contains("Balanced") || saida.Contains("Balanceado")) planoAtual = "Equilibrado";
                else if (saida.Contains("High performance") || saida.Contains("Alto desempenho")) planoAtual = "Alto Desempenho";
                else if (saida.Contains("Power saver") || saida.Contains("Economia")) planoAtual = "Economia de energia";
                else if (saida.Contains("Ultimate")) planoAtual = "Desempenho Máximo";
                else planoAtual = saida.Length > 5 ? saida.Substring(saida.LastIndexOf('(') + 1).Replace(")", "").Trim() : "Personalizado";
            }
            catch { }

            AdicionarInfoCard(painel, "🔋 Plano de Energia Atual", planoAtual,
                "Planos de energia são como modos de dirigir o carro:\n\n" +
                "🐢 Economia de energia = Modo econômico: o PC vai mais devagar para gastar menos energia. Ideal para notebook na bateria.\n\n" +
                "⚖️ Equilibrado = Modo padrão: o PC ajusta automaticamente o desempenho conforme necessário. Ótimo para uso geral.\n\n" +
                "🏎️ Alto Desempenho = Acelerador no fundo: máxima velocidade o tempo todo, mas consome mais energia.");

            // Botões dos planos
            var planLabel = new Label { Text = "Trocar plano de energia:", Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 70, 90), Size = new Size(700, 25), AutoSize = false };
            painel.Controls.Add(planLabel);

            var flowPlanos = new FlowLayoutPanel { Size = new Size(700, 60), FlowDirection = FlowDirection.LeftToRight, WrapContents = false, AutoSize = false };

            var planos = new[]
            {
                ("🐢 Economia", "a0ac2d38-3938-444d-a2a0-3e821314svhs", Color.FromArgb(39, 174, 96)),
                ("⚖️ Equilibrado", "381b4222-f694-41f0-9685-ff5bb260df2e", Color.FromArgb(52, 152, 219)),
                ("🏎️ Alto Desempenho", "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c", Color.FromArgb(192, 57, 43)),
            };

            foreach (var (nome, guid, cor) in planos)
            {
                var g = guid;
                var btn = new Button
                {
                    Text = nome,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    BackColor = cor,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(168, 44),
                    Margin = new Padding(0, 0, 10, 0),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) =>
                {
                    try { Process.Start("powercfg", $"/setactive {g}")?.WaitForExit(); MessageBox.Show("✔ Plano alterado!\n\nA mudança já está ativa — não precisa reiniciar.", "Plano alterado", MessageBoxButtons.OK, MessageBoxIcon.Information); CarregarSecao(Secao.Energia); }
                    catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
                };
                flowPlanos.Controls.Add(btn);
            }
            painel.Controls.Add(flowPlanos);

            painel.Controls.Add(CriarBotaoAcao("Abrir Opções de Energia do Windows", () => Process.Start("control", "powercfg.cpl")));
            painel.Controls.Add(CriarBotaoAcao("Gerar Relatório da Bateria", () =>
            {
                var caminho = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "relatorio_bateria.html");
                Process.Start("powercfg", $"/batteryreport /output \"{caminho}\"")?.WaitForExit();
                System.Threading.Thread.Sleep(2000);
                if (System.IO.File.Exists(caminho)) Process.Start(caminho);
                else MessageBox.Show("Relatório gerado. Verifique sua área de trabalho.", "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: REDE
        // =====================================================================
        private void CarregarSecaoRede()
        {
            var painel = CriarPainelSecao("🌐 Como meu computador se conecta à internet?", "Entenda sua conexão de rede em linguagem simples.");

            // Detectar adaptadores ativos
            try
            {
                var nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && n.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                    .ToList();

                if (!nics.Any())
                {
                    AdicionarInfoCard(painel, "⚠️ Sem conexão ativa", "Nenhum adaptador de rede detectado", "Seu computador parece não estar conectado à internet ou rede local. Verifique o cabo de rede ou o Wi-Fi.");
                }
                else
                {
                    foreach (var nic in nics.Take(3))
                    {
                        var props = nic.GetIPProperties();
                        var ip = props.UnicastAddresses.FirstOrDefault(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address?.ToString() ?? "N/A";
                        var dns = props.DnsAddresses.FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString() ?? "N/A";
                        var gateway = props.GatewayAddresses.FirstOrDefault()?.Address?.ToString() ?? "N/A";
                        var velocidade = nic.Speed > 0 ? $"{nic.Speed / 1_000_000} Mbps" : "N/A";
                        var tipo = nic.NetworkInterfaceType.ToString().Contains("Wireless") || nic.Name.ToLower().Contains("wi") ? "📶 Wi-Fi" : "🔌 Cabo (Ethernet)";

                        AdicionarInfoCard(painel, $"{tipo} — {nic.Name}",
                            $"IP: {ip}  |  Velocidade: {velocidade}",
                            $"IP (endereço): {ip} — É o 'endereço' do seu computador na rede, como um número de casa.\n\n" +
                            $"Gateway: {gateway} — É o 'portão de entrada' para a internet (geralmente o seu roteador).\n\n" +
                            $"DNS: {dns} — É a 'lista telefônica' da internet — converte nomes de sites (www.google.com) em endereços numéricos.\n\n" +
                            $"Velocidade do adaptador: {velocidade}");
                    }
                }
            }
            catch (Exception ex)
            {
                AdicionarInfoCard(painel, "Erro", "Não foi possível ler as informações de rede", ex.Message);
            }

            painel.Controls.Add(CriarBotaoAcao("Abrir Configurações de Rede", () => Process.Start("ms-settings:network")));
            painel.Controls.Add(CriarBotaoAcao("Abrir Adaptadores de Rede (avançado)", () => Process.Start("ncpa.cpl")));
            painel.Controls.Add(CriarBotaoAcao("Renovar Conexão (ipconfig /renew)", () =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo("cmd.exe", "/K ipconfig /release && ipconfig /renew") { Verb = "runas" });
                }
                catch { MessageBox.Show("Requer privilégios de administrador.", "Permissão", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }));
            painel.Controls.Add(CriarBotaoAcao("Limpar Cache DNS (ipconfig /flushdns)", () =>
            {
                try { Process.Start(new ProcessStartInfo("cmd.exe", "/K ipconfig /flushdns") { Verb = "runas" }); }
                catch { MessageBox.Show("Requer privilégios de administrador.", "Permissão", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }));

            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: USUÁRIOS
        // =====================================================================
        private void CarregarSecaoUsuarios()
        {
            var painel = CriarPainelSecao("👤 Quem tem acesso ao meu computador?", "Veja as contas de usuário existentes e entenda seus tipos.");

            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount WHERE LocalAccount = True");
                var usuarios = searcher.Get().Cast<ManagementObject>().ToList();

                if (!usuarios.Any())
                {
                    AdicionarInfoCard(painel, "ℹ️ Usuários", "Não foi possível listar usuários", "Tente executar o programa como administrador para ver os usuários.");
                }
                else
                {
                    foreach (var user in usuarios)
                    {
                        var nome = user["Name"]?.ToString() ?? "?";
                        var tipo = user["AccountType"]?.ToString();
                        var ativo = (bool)(user["Disabled"] ?? false) ? "Desativado" : "Ativo";
                        var tipoLegivel = tipo == "512" || tipo == "66048" ? "Administrador" : "Usuário Padrão";

                        AdicionarInfoCard(painel, $"👤 {nome}", $"Tipo: {tipoLegivel}  |  Status: {ativo}",
                            $"Nome da conta: {nome}\n\n" +
                            $"Tipo: {tipoLegivel}\n" +
                            (tipoLegivel == "Administrador" ?
                                "Conta de administrador — pode instalar programas, alterar configurações do sistema e criar/remover outros usuários. Deve ser protegida por senha forte." :
                                "Conta padrão — pode usar o computador normalmente, mas não pode instalar programas ou alterar configurações do sistema sem permissão de administrador. Ideal para uso cotidiano.") +
                            $"\n\nStatus: {ativo}");
                    }
                }
            }
            catch
            {
                AdicionarInfoCard(painel, "⚠️ Sem acesso", "Execute como administrador", "Para ver a lista de usuários, execute o Guia do Computador como administrador (botão direito > 'Executar como administrador').");
            }

            painel.Controls.Add(CriarBotaoAcao("Abrir Gerenciador de Usuários (netplwiz)", () => Process.Start("netplwiz")));
            painel.Controls.Add(CriarBotaoAcao("Abrir Configurações de Contas do Windows", () => Process.Start("ms-settings:accounts")));
            panelConteudo.Controls.Add(painel);
        }

        // =====================================================================
        // SEÇÃO: INICIALIZAÇÃO
        // =====================================================================
        private void CarregarSecaoInicializacao()
        {
            var painel = CriarPainelSecao("🚀 Como meu computador inicia?", "Veja o que é carregado quando o Windows liga e entenda o impacto de cada programa.");

            AdicionarInfoCard(painel, "⏱️ Tempo de inicialização", "Verificar via Visualizador de Eventos",
                "O tempo de inicialização do Windows depende principalmente de quantos programas são carregados automaticamente quando o PC liga. Cada programa na inicialização adiciona tempo de boot e consome memória RAM mesmo quando não está sendo usado.\n\nDica: Remover programas desnecessários da inicialização pode fazer o PC ligar MUITO mais rápido.");

            // Ler programas de inicialização do registro
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
                            startupItems.Add((nome, k.GetValue(nome)?.ToString() ?? "?", local));
                    }
                    catch { }
                }

                LerChave(Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Usuário atual");
                LerChave(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Todos os usuários");

                if (startupItems.Any())
                {
                    AdicionarInfoCard(painel, $"📋 {startupItems.Count} programa(s) na inicialização", "Carregados automaticamente quando o PC liga",
                        "Estes programas iniciam automaticamente quando o Windows é ligado:\n\n" +
                        string.Join("\n", startupItems.Take(15).Select(i => $"• {i.nome} ({i.local})")));
                }
                else
                {
                    AdicionarInfoCard(painel, "✔ Inicialização limpa", "Poucos programas na inicialização", "Seu computador tem poucos (ou nenhum) programa configurado para iniciar automaticamente. Isso contribui para uma inicialização mais rápida!");
                }
            }
            catch
            {
                AdicionarInfoCard(painel, "ℹ️ Programas de inicialização", "Não foi possível listar", "Não foi possível ler os programas de inicialização do registro.");
            }

            painel.Controls.Add(CriarBotaoAcao("Gerenciar Inicialização no Gerenciador de Tarefas", () =>
            {
                Process.Start(new ProcessStartInfo("taskmgr") { UseShellExecute = true });
                MessageBox.Show("O Gerenciador de Tarefas foi aberto.\n\nVá na aba 'Inicializar' para ver e desativar programas da inicialização.", "Dica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
            painel.Controls.Add(CriarBotaoAcao("Abrir Configuração do Sistema (msconfig)", () => Process.Start("msconfig")));
            painel.Controls.Add(CriarBotaoAcao("Abrir Configurações de Aplicativos de Inicialização", () => Process.Start("ms-settings:startupapps")));

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
                Padding = new Padding(5)
            };

            var lblTit = new Label { Text = titulo, Font = new Font("Segoe UI", 15f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = false, Size = new Size(760, 35) };
            var lblSub = new Label { Text = subtitulo, Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = false, Size = new Size(760, 22), Margin = new Padding(0, 0, 0, 15) };

            painel.Controls.Add(lblTit);
            painel.Controls.Add(lblSub);
            return painel;
        }

        private void AdicionarInfoCard(FlowLayoutPanel painel, string titulo, string resumo, string detalhe)
        {
            var card = new Panel
            {
                Size = new Size(760, 0),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(15)
            };
            card.Paint += (s, e) => e.Graphics.DrawRectangle(new Pen(Color.FromArgb(218, 222, 232)), 0, 0, card.Width - 1, card.Height - 1);

            var lblTit = new Label { Text = titulo, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(22, 160, 133), Location = new Point(15, 12), Size = new Size(720, 22), AutoEllipsis = true };
            var lblRes = new Label { Text = resumo, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(15, 35), Size = new Size(720, 20) };
            var lblDet = new Label
            {
                Text = detalhe,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(90, 100, 120),
                Location = new Point(15, 60),
                Size = new Size(720, 0),
                AutoSize = false
            };
            // Calcular altura do texto
            var g = lblDet.CreateGraphics();
            var size = g.MeasureString(detalhe, lblDet.Font, 720);
            lblDet.Height = (int)size.Height + 10;
            g.Dispose();

            card.Controls.AddRange(new Control[] { lblTit, lblRes, lblDet });
            painel.Controls.Add(card);
        }

        private Button CriarBotaoAcao(string texto, Action acao)
        {
            var btn = new Button
            {
                Text = "▶  " + texto,
                Font = new Font("Segoe UI", 9.5f),
                BackColor = Color.FromArgb(22, 160, 133),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(500, 36),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 8),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) =>
            {
                try { acao(); }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            };
            return btn;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 700);
            this.Name = "FormControlPanel";
            this.ResumeLayout(false);
        }
    }
}