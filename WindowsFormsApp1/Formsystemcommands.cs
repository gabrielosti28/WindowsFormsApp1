using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormSystemCommands : Form
    {
        // =====================================================================
        // DADOS DOS COMANDOS
        // =====================================================================
        private class CommandItem
        {
            public string Nome { get; set; }
            public string Comando { get; set; }
            public string Descricao { get; set; }
            public string Categoria { get; set; }
            public bool UsaCmd { get; set; }
            public bool RequereAdmin { get; set; }
            public string Icone { get; set; }
        }

        private readonly List<CommandItem> _comandos = new List<CommandItem>
        {
            // --- Menu Executar (Win+R) ---
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Configuração de Inicialização", Comando = "msconfig", Descricao = "Controla o que roda quando o PC liga — programas, serviços e opções de boot. Ótimo para diagnosticar lentidão na inicialização.", Icone = "⚙️" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Gerenciador de Dispositivos", Comando = "devmgmt.msc", Descricao = "Lista todas as peças físicas do computador (placa de vídeo, som, rede). Aqui você vê se algum componente está com problema (ícone amarelo).", Icone = "🔌" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Gerenciador de Discos", Comando = "diskmgmt.msc", Descricao = "Mostra todos os HDs e SSDs conectados, suas partições e espaço livre. Usado para formatar, particionar ou verificar discos.", Icone = "💾" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Limpeza de Disco", Comando = "cleanmgr", Descricao = "Ferramenta oficial do Windows para remover arquivos temporários, cache e lixo que ocupa espaço sem necessidade.", Icone = "🧹" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Monitor de Recursos", Comando = "resmon", Descricao = "Versão avançada do Gerenciador de Tarefas — mostra exatamente quem está usando CPU, memória, disco e rede em tempo real.", Icone = "📊" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Monitor de Desempenho", Comando = "perfmon", Descricao = "Gráficos detalhados do desempenho do sistema ao longo do tempo. Ótimo para identificar gargalos e lentidão.", Icone = "📈" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Visualizador de Eventos", Comando = "eventvwr", Descricao = "Histórico de tudo que aconteceu no seu PC — erros, avisos, logins. É como o \"diário\" do Windows.", Icone = "📋" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Gerenciador de Usuários", Comando = "netplwiz", Descricao = "Controla quem tem acesso ao computador, senhas e permissões de cada conta de usuário.", Icone = "👤" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Políticas do Sistema", Comando = "gpedit.msc", Descricao = "Configurações avançadas de segurança e comportamento do Windows. Requer cuidado — alterações afetam todo o sistema.", RequereAdmin = true, Icone = "🔐" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Editor do Registro", Comando = "regedit", Descricao = "O \"DNA\" do Windows — guarda todas as configurações do sistema. Extremamente poderoso, mas altere somente se souber o que está fazendo.", RequereAdmin = true, Icone = "⚠️" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Informações do Sistema", Comando = "msinfo32", Descricao = "Relatório completo do hardware e software instalado — útil para suporte técnico e diagnósticos.", Icone = "ℹ️" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Configurações de IP", Comando = "ncpa.cpl", Descricao = "Acesso direto às configurações de adaptadores de rede (Wi-Fi e cabo). Útil para configurar IP fixo ou DNS.", Icone = "🌐" },
            new CommandItem { Categoria = "Executar (Win+R)", Nome = "Serviços do Windows", Comando = "services.msc", Descricao = "Lista todos os serviços rodando em segundo plano. Permite iniciar, parar ou desabilitar cada um.", Icone = "🔧" },

            // --- Comandos CMD ---
            new CommandItem { Categoria = "Comandos CMD", Nome = "Verificar Arquivos do Windows", Comando = "sfc /scannow", Descricao = "Verifica e corrige automaticamente arquivos corrompidos do Windows. Rode quando o PC estiver com comportamento estranho. Pode demorar 10-15 min.", UsaCmd = true, RequereAdmin = true, Icone = "🛡️" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Reparar o Windows (DISM)", Comando = "DISM /Online /Cleanup-Image /RestoreHealth", Descricao = "Reparo mais profundo do Windows — verifica e restaura a imagem do sistema operacional. Use junto com o SFC quando houver erros persistentes.", UsaCmd = true, RequereAdmin = true, Icone = "🔨" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Informações de Rede", Comando = "ipconfig /all", Descricao = "Mostra todas as informações de rede: IP, DNS, gateway, MAC address. Essencial para diagnóstico de problemas de internet.", UsaCmd = true, Icone = "📡" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Renovar Conexão de Rede", Comando = "ipconfig /release && ipconfig /renew", Descricao = "Libera e renova o endereço IP — resolve muitos problemas de conexão sem precisar reiniciar o computador.", UsaCmd = true, RequereAdmin = true, Icone = "🔄" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Limpar Cache DNS", Comando = "ipconfig /flushdns", Descricao = "Limpa a lista telefônica de internet do Windows. Resolve problemas de sites que não abrem mesmo com internet funcionando.", UsaCmd = true, RequereAdmin = true, Icone = "🧽" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Verificar Disco (C:)", Comando = "chkdsk C: /f /r", Descricao = "Verifica o disco principal em busca de erros e setores danificados. Precisa reiniciar para executar no disco do sistema.", UsaCmd = true, RequereAdmin = true, Icone = "🔍" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Conexões de Internet Ativas", Comando = "netstat -an", Descricao = "Mostra todas as conexões de internet abertas no momento — útil para detectar programas se comunicando com a internet.", UsaCmd = true, Icone = "🕸️" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Relatório de Bateria", Comando = "powercfg /batteryreport /output \"%USERPROFILE%\\Desktop\\relatorio_bateria.html\"", Descricao = "Gera um relatório completo da bateria em HTML na sua área de trabalho, mostrando capacidade atual vs original e histórico de uso.", UsaCmd = true, Icone = "🔋" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Informações Completas do Sistema", Comando = "systeminfo", Descricao = "Exibe detalhes completos do sistema: Windows, hardware, hotfixes instalados, configurações de rede — tudo em um só lugar.", UsaCmd = true, Icone = "🖥️" },
            new CommandItem { Categoria = "Comandos CMD", Nome = "Teste de Conectividade (Ping)", Comando = "ping google.com -n 4", Descricao = "Testa se o computador consegue se comunicar com a internet. Se falhar, o problema está na sua conexão ou no DNS.", UsaCmd = true, Icone = "🏓" },
        };

        // =====================================================================
        // CONTROLES DA INTERFACE
        // =====================================================================
        private TabControl tabCategorias;
        private Panel panelDetalhe;
        private Label lblComandoSelecionado;
        private Label lblDescricaoDetalhe;
        private Label lblComandoBruto;
        private Button btnExecutar;
        private Button btnCopiar;
        private RichTextBox rtbSaida;
        private Label lblStatusExecucao;
        private Panel panelTopo;

        public FormSystemCommands()
        {
            InitializeComponent();
            ConstruirInterface();
            PopularCategorias();
        }

        private void ConstruirInterface()
        {
            this.Text = "Central de Comandos Ocultos";
            this.Size = new Size(980, 700);
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 9.5f);

            // --- Cabeçalho ---
            panelTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(41, 128, 185),
                Padding = new Padding(20, 0, 20, 0)
            };
            var lblTitulo = new Label
            {
                Text = "⌨️  Central de Comandos Ocultos do Windows",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Left,
                Width = 500,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var lblSubtitulo = new Label
            {
                Text = "Execute ferramentas poderosas do Windows com um clique",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(200, 230, 255),
                AutoSize = false,
                Dock = DockStyle.Right,
                Width = 380,
                TextAlign = ContentAlignment.MiddleRight
            };
            panelTopo.Controls.Add(lblTitulo);
            panelTopo.Controls.Add(lblSubtitulo);

            // --- Painel de detalhe (direita) ---
            panelDetalhe = new Panel
            {
                Dock = DockStyle.Right,
                Width = 340,
                BackColor = Color.White,
                Padding = new Padding(15)
            };
            panelDetalhe.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 230), 1), 0, 0, 0, panelDetalhe.Height);
            };

            lblComandoSelecionado = new Label
            {
                Text = "Selecione um comando à esquerda",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(15, 15),
                Size = new Size(310, 50),
                AutoEllipsis = true
            };

            lblDescricaoDetalhe = new Label
            {
                Text = "Clique em qualquer comando para ver uma explicação detalhada e executá-lo com segurança.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(100, 110, 130),
                Location = new Point(15, 75),
                Size = new Size(310, 100),
                AutoSize = false
            };

            var lblComandoLabel = new Label
            {
                Text = "Comando técnico:",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(150, 160, 180),
                Location = new Point(15, 180),
                AutoSize = true
            };

            lblComandoBruto = new Label
            {
                Text = "—",
                Font = new Font("Consolas", 8.5f),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(15, 198),
                Size = new Size(310, 35),
                AutoSize = false,
                AutoEllipsis = true,
                BackColor = Color.FromArgb(245, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            btnExecutar = new Button
            {
                Text = "▶  Executar Agora",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, 248),
                Size = new Size(155, 40),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnExecutar.FlatAppearance.BorderSize = 0;
            btnExecutar.Click += BtnExecutar_Click;

            btnCopiar = new Button
            {
                Text = "📋  Copiar Comando",
                Font = new Font("Segoe UI", 10f),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(178, 248),
                Size = new Size(147, 40),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnCopiar.FlatAppearance.BorderSize = 0;
            btnCopiar.Click += (s, e) =>
            {
                if (lblComandoBruto.Text != "—")
                {
                    Clipboard.SetText(lblComandoBruto.Text);
                    var t = btnCopiar.Text;
                    btnCopiar.Text = "✔  Copiado!";
                    Task.Delay(1500).ContinueWith(_ => this.Invoke((Action)(() => btnCopiar.Text = t)));
                }
            };

            lblStatusExecucao = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
                ForeColor = Color.DimGray,
                Location = new Point(15, 298),
                Size = new Size(310, 20),
                AutoSize = false
            };

            var lblSaidaLabel = new Label
            {
                Text = "Resultado da execução:",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 110, 130),
                Location = new Point(15, 328),
                AutoSize = true
            };

            rtbSaida = new RichTextBox
            {
                Location = new Point(15, 348),
                Size = new Size(310, 290),
                Font = new Font("Consolas", 8.5f),
                BackColor = Color.FromArgb(30, 35, 45),
                ForeColor = Color.FromArgb(180, 220, 180),
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                BorderStyle = BorderStyle.None,
                Text = "A saída dos comandos aparecerá aqui...",
                ForeColor = Color.FromArgb(100, 120, 140)
            };

            panelDetalhe.Controls.AddRange(new Control[] {
                lblComandoSelecionado, lblDescricaoDetalhe, lblComandoLabel,
                lblComandoBruto, btnExecutar, btnCopiar, lblStatusExecucao,
                lblSaidaLabel, rtbSaida
            });

            // --- TabControl para categorias (esquerda) ---
            tabCategorias = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f),
                Padding = new Point(12, 6)
            };

            this.Controls.Add(tabCategorias);
            this.Controls.Add(panelDetalhe);
            this.Controls.Add(panelTopo);
        }

        private void PopularCategorias()
        {
            var grupos = new Dictionary<string, List<CommandItem>>();
            foreach (var cmd in _comandos)
            {
                if (!grupos.ContainsKey(cmd.Categoria))
                    grupos[cmd.Categoria] = new List<CommandItem>();
                grupos[cmd.Categoria].Add(cmd);
            }

            foreach (var kvp in grupos)
            {
                var tab = new TabPage(kvp.Key) { BackColor = Color.FromArgb(245, 246, 250), Padding = new Padding(10) };
                var flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoScroll = true,
                    Padding = new Padding(5)
                };

                foreach (var cmd in kvp.Value)
                {
                    var card = CriarCardComando(cmd);
                    flowPanel.Controls.Add(card);
                }

                tab.Controls.Add(flowPanel);
                tabCategorias.TabPages.Add(tab);
            }
        }

        private Panel CriarCardComando(CommandItem cmd)
        {
            var card = new Panel
            {
                Size = new Size(560, 68),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 8),
                Cursor = Cursors.Hand,
                Tag = cmd
            };
            card.Paint += (s, e) =>
            {
                var p = s as Panel;
                var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 225, 235)), rect);
            };

            var lblIcone = new Label
            {
                Text = cmd.Icone,
                Font = new Font("Segoe UI", 16f),
                Location = new Point(12, 12),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lblNome = new Label
            {
                Text = cmd.Nome,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(58, 10),
                Size = new Size(380, 22),
                AutoEllipsis = true
            };
            var lblDesc = new Label
            {
                Text = cmd.Descricao.Length > 90 ? cmd.Descricao.Substring(0, 90) + "..." : cmd.Descricao,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(120, 130, 150),
                Location = new Point(58, 32),
                Size = new Size(390, 28),
                AutoEllipsis = true
            };

            Panel badgeAdmin = null;
            if (cmd.RequereAdmin)
            {
                badgeAdmin = new Panel
                {
                    BackColor = Color.FromArgb(231, 76, 60),
                    Location = new Point(card.Width - 85, 18),
                    Size = new Size(72, 20),
                    Cursor = Cursors.Hand
                };
                var lblBadge = new Label
                {
                    Text = "Admin",
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    ForeColor = Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                badgeAdmin.Controls.Add(lblBadge);
                card.Controls.Add(badgeAdmin);
            }

            card.Controls.AddRange(new Control[] { lblIcone, lblNome, lblDesc });

            // Efeito hover
            Action<Control, bool> setHover = null;
            setHover = (ctrl, hover) =>
            {
                card.BackColor = hover ? Color.FromArgb(240, 248, 255) : Color.White;
                foreach (Control c in card.Controls)
                    c.BackColor = card.BackColor;
                if (badgeAdmin != null) badgeAdmin.BackColor = Color.FromArgb(231, 76, 60);
            };

            foreach (Control ctrl in card.Controls)
            {
                ctrl.MouseEnter += (s, e) => setHover(ctrl, true);
                ctrl.MouseLeave += (s, e) => setHover(ctrl, false);
                ctrl.Click += (s, e) => SelecionarComando(cmd);
            }
            card.MouseEnter += (s, e) => setHover(card, true);
            card.MouseLeave += (s, e) => setHover(card, false);
            card.Click += (s, e) => SelecionarComando(cmd);

            return card;
        }

        private CommandItem _comandoAtual;

        private void SelecionarComando(CommandItem cmd)
        {
            _comandoAtual = cmd;
            lblComandoSelecionado.Text = cmd.Icone + "  " + cmd.Nome;
            lblDescricaoDetalhe.Text = cmd.Descricao;
            lblComandoBruto.Text = cmd.Comando;
            btnExecutar.Enabled = true;
            btnCopiar.Enabled = true;
            lblStatusExecucao.Text = "";
            rtbSaida.Text = "Pressione ▶ Executar para rodar este comando.";
            rtbSaida.ForeColor = Color.FromArgb(100, 120, 140);

            if (cmd.RequereAdmin)
            {
                btnExecutar.BackColor = Color.FromArgb(231, 76, 60);
                lblStatusExecucao.Text = "⚠️ Requer privilégios de Administrador";
                lblStatusExecucao.ForeColor = Color.FromArgb(192, 57, 43);
            }
            else
            {
                btnExecutar.BackColor = Color.FromArgb(39, 174, 96);
                lblStatusExecucao.ForeColor = Color.DimGray;
            }
        }

        private async void BtnExecutar_Click(object sender, EventArgs e)
        {
            if (_comandoAtual == null) return;

            btnExecutar.Enabled = false;
            btnExecutar.Text = "⏳  Executando...";
            rtbSaida.Text = "";
            rtbSaida.ForeColor = Color.FromArgb(180, 220, 180);

            try
            {
                if (_comandoAtual.UsaCmd)
                {
                    // Executar via CMD e capturar saída
                    var resultado = await Task.Run(() => ExecutarCmd(_comandoAtual.Comando, _comandoAtual.RequereAdmin));
                    rtbSaida.Text = resultado;
                    lblStatusExecucao.Text = "✔  Comando executado com sucesso";
                    lblStatusExecucao.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    // Abrir programa via Executar
                    var psi = new ProcessStartInfo(_comandoAtual.Comando)
                    {
                        UseShellExecute = true,
                        Verb = _comandoAtual.RequereAdmin ? "runas" : ""
                    };
                    Process.Start(psi);
                    rtbSaida.Text = $"✔ Programa aberto com sucesso!\n\nO Windows abriu: {_comandoAtual.Nome}";
                    lblStatusExecucao.Text = "✔  Aberto com sucesso";
                    lblStatusExecucao.ForeColor = Color.FromArgb(39, 174, 96);
                }
            }
            catch (Exception ex)
            {
                rtbSaida.ForeColor = Color.FromArgb(255, 150, 150);
                if (ex.Message.Contains("cancel") || ex.Message.Contains("denied"))
                    rtbSaida.Text = "⚠️ Operação cancelada ou permissão negada.\n\nVocê clicou em 'Não' na janela de confirmação, ou não tem permissão de administrador.";
                else
                    rtbSaida.Text = $"Erro ao executar: {ex.Message}";
                lblStatusExecucao.Text = "✖  Erro na execução";
                lblStatusExecucao.ForeColor = Color.FromArgb(192, 57, 43);
            }
            finally
            {
                btnExecutar.Enabled = true;
                btnExecutar.Text = "▶  Executar Agora";
            }
        }

        private string ExecutarCmd(string comando, bool admin)
        {
            try
            {
                var psi = new ProcessStartInfo("cmd.exe", $"/C {comando}")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = System.Text.Encoding.GetEncoding(850)
                };

                if (admin)
                {
                    psi.UseShellExecute = true;
                    psi.RedirectStandardOutput = false;
                    psi.RedirectStandardError = false;
                    psi.Verb = "runas";
                    psi.WindowStyle = ProcessWindowStyle.Normal;
                    Process.Start(psi)?.WaitForExit();
                    return "✔ Comando enviado ao terminal de administrador.\n\nUma janela de CMD se abriu para executar o comando com privilégios elevados.";
                }

                var proc = Process.Start(psi);
                var saida = proc.StandardOutput.ReadToEnd();
                var erro = proc.StandardError.ReadToEnd();
                proc.WaitForExit(30000);

                var resultado = "";
                if (!string.IsNullOrWhiteSpace(saida)) resultado += saida;
                if (!string.IsNullOrWhiteSpace(erro)) resultado += "\n\n⚠️ Avisos/Erros:\n" + erro;
                return string.IsNullOrWhiteSpace(resultado) ? "(Nenhuma saída retornada pelo comando)" : resultado.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao executar CMD: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(980, 700);
            this.Name = "FormSystemCommands";
            this.ResumeLayout(false);
        }
    }
}