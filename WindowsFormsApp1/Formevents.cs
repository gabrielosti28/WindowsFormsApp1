using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormEvents : Form
    {
        // =====================================================================
        // MODELOS
        // =====================================================================
        private class EventoTraduzido
        {
            public string Icone { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string DetalhesTecnicos { get; set; }
            public DateTime DataHora { get; set; }
            public string Categoria { get; set; }
            public EventLogEntryType Tipo { get; set; }
            public string Fonte { get; set; }
            public int EventId { get; set; }
        }

        // =====================================================================
        // ESTADO
        // =====================================================================
        private List<EventoTraduzido> _todosEventos = new List<EventoTraduzido>();
        private string _categoriaAtiva = "Todos";

        // =====================================================================
        // CONTROLES
        // =====================================================================
        private Panel panelTopo;
        private Panel panelFiltros;
        private FlowLayoutPanel panelCards;
        private Panel panelDetalhe;
        private Label lblDetalheNome;
        private Label lblDetalheData;
        private RichTextBox rtbDetalheDescricao;
        private Label lblCount;
        private Panel panelCarregando;
        private Label lblCarregando;

        public FormEvents()
        {
            InitializeComponent();
            ConstruirInterface();
            CarregarEventos();
        }

        private void ConstruirInterface()
        {
            this.Text = "Central de Eventos e Histórico";
            this.Size = new Size(1050, 720);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 9.5f);

            // Cabeçalho
            panelTopo = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(142, 68, 173), Padding = new Padding(20, 0, 20, 0) };
            var lblTit = new Label { Text = "📊  Central de Eventos e Histórico", Font = new Font("Segoe UI", 14f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Left, Width = 450, TextAlign = ContentAlignment.MiddleLeft };
            var lblSub = new Label { Text = "Veja o que aconteceu no seu computador, em português", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(220, 200, 240), Dock = DockStyle.Right, Width = 380, TextAlign = ContentAlignment.MiddleRight };
            panelTopo.Controls.Add(lblTit);
            panelTopo.Controls.Add(lblSub);

            // Painel de carregando
            panelCarregando = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 246, 250), Visible = true };
            lblCarregando = new Label { Text = "⏳  Lendo o histórico do sistema...\n\nIsso pode levar alguns segundos.", Font = new Font("Segoe UI", 13f), ForeColor = Color.DimGray, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            panelCarregando.Controls.Add(lblCarregando);

            // Filtros de categoria
            panelFiltros = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White, Padding = new Padding(10, 8, 10, 8) };
            panelFiltros.Paint += (s, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 222, 230)), 0, panelFiltros.Height - 1, panelFiltros.Width, panelFiltros.Height - 1);

            var categorias = new[] { "Todos", "Erros Críticos", "Avisos", "Logins", "Instalações", "Desligamentos" };
            int x = 10;
            foreach (var cat in categorias)
            {
                var btn = new Button
                {
                    Text = cat,
                    Tag = cat,
                    Font = new Font("Segoe UI", 9f),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = cat == "Todos" ? Color.FromArgb(142, 68, 173) : Color.FromArgb(240, 240, 248),
                    ForeColor = cat == "Todos" ? Color.White : Color.FromArgb(80, 80, 110),
                    Location = new Point(x, 8),
                    AutoSize = true,
                    Padding = new Padding(8, 2, 8, 2),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(200, 180, 220);
                btn.Click += FiltroBtn_Click;
                panelFiltros.Controls.Add(btn);
                x += btn.Width + 8;
            }

            lblCount = new Label { Text = "", Font = new Font("Segoe UI", 8.5f, FontStyle.Italic), ForeColor = Color.Gray, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleRight, Width = 200 };
            panelFiltros.Controls.Add(lblCount);

            // Painel detalhe (direita)
            panelDetalhe = new Panel { Dock = DockStyle.Right, Width = 320, BackColor = Color.White, Padding = new Padding(15) };
            panelDetalhe.Paint += (s, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 230)), 0, 0, 0, panelDetalhe.Height);

            lblDetalheNome = new Label { Text = "Clique em um evento para ver detalhes", Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(15, 15), Size = new Size(290, 50), AutoSize = false };
            lblDetalheData = new Label { Text = "", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(15, 68), Size = new Size(290, 20), AutoSize = false };

            var lblExplicacao = new Label { Text = "O que isso significa:", Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(100, 110, 130), Location = new Point(15, 98), AutoSize = true };

            rtbDetalheDescricao = new RichTextBox
            {
                Location = new Point(15, 118),
                Size = new Size(290, 450),
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(60, 70, 90),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Text = "Selecione um evento para ler uma explicação em linguagem simples sobre o que aconteceu e se você precisa se preocupar."
            };

            panelDetalhe.Controls.AddRange(new Control[] { lblDetalheNome, lblDetalheData, lblExplicacao, rtbDetalheDescricao });

            // Área de cards (lista de eventos)
            panelCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            this.Controls.Add(panelCarregando);
            this.Controls.Add(panelDetalhe);
            this.Controls.Add(panelCards);
            this.Controls.Add(panelFiltros);
            this.Controls.Add(panelTopo);
        }

        private async void CarregarEventos()
        {
            panelCarregando.BringToFront();
            panelCarregando.Visible = true;

            _todosEventos = await Task.Run(() => LerEventos());

            panelCarregando.Visible = false;
            ExibirEventos("Todos");
        }

        private List<EventoTraduzido> LerEventos()
        {
            var lista = new List<EventoTraduzido>();

            // Erros e Avisos do Sistema
            lista.AddRange(LerLog("System", 150));
            lista.AddRange(LerLog("Application", 100));

            // Login History (Security log)
            lista.AddRange(LerEventosLogin());

            lista = lista.OrderByDescending(e => e.DataHora).ToList();
            return lista;
        }

        private List<EventoTraduzido> LerLog(string logNome, int maxItens)
        {
            var lista = new List<EventoTraduzido>();
            try
            {
                using (var log = new EventLog(logNome))
                {
                    var entries = log.Entries.Cast<EventLogEntry>()
                        .Where(e => e.EntryType == EventLogEntryType.Error || e.EntryType == EventLogEntryType.Warning)
                        .OrderByDescending(e => e.TimeGenerated)
                        .Take(maxItens);

                    foreach (var entry in entries)
                    {
                        lista.Add(TraduzirEvento(entry, logNome));
                    }
                }
            }
            catch { /* sem acesso ao log */ }
            return lista;
        }

        private List<EventoTraduzido> LerEventosLogin()
        {
            var lista = new List<EventoTraduzido>();
            try
            {
                using (var log = new EventLog("Security"))
                {
                    var logins = log.Entries.Cast<EventLogEntry>()
                        .Where(e => e.InstanceId == 4624 || e.InstanceId == 4634 || e.InstanceId == 4647 || e.InstanceId == 6006 || e.InstanceId == 41)
                        .OrderByDescending(e => e.TimeGenerated)
                        .Take(100);

                    foreach (var entry in logins)
                    {
                        lista.Add(TraduzirEventoSeguranca(entry));
                    }
                }
            }
            catch { /* sem acesso ao log de segurança */ }
            return lista;
        }

        private EventoTraduzido TraduzirEvento(EventLogEntry entry, string logNome)
        {
            var ev = new EventoTraduzido
            {
                DataHora = entry.TimeGenerated,
                Tipo = entry.EntryType,
                Fonte = entry.Source,
                EventId = (int)(entry.InstanceId & 0xFFFF),
                DetalhesTecnicos = $"Fonte: {entry.Source} | ID: {entry.InstanceId} | Log: {logNome}"
            };

            // Tradução de eventos comuns
            var id = (int)(entry.InstanceId & 0xFFFF);
            var fonte = entry.Source?.ToLower() ?? "";

            if (fonte.Contains("disk") || fonte.Contains("ntfs"))
            {
                ev.Categoria = "Erros Críticos"; ev.Icone = "💾";
                ev.Titulo = "Problema com o disco rígido";
                ev.Descricao = "O Windows detectou um problema no seu disco rígido ou SSD. Isso pode indicar que seu disco está começando a falhar. Recomendamos fazer backup imediatamente e verificar o disco.";
            }
            else if (fonte.Contains("kernel-power") || fonte.Contains("eventlog"))
            {
                ev.Categoria = "Desligamentos"; ev.Icone = "⚡";
                ev.Titulo = "Desligamento inesperado";
                ev.Descricao = "O computador foi desligado de forma anormal — possivelmente por queda de energia, superaquecimento, ou travamento grave (tela azul). Se isso acontece com frequência, pode indicar problema de hardware.";
            }
            else if (fonte.Contains("winlogon") || fonte.Contains("user") || fonte.Contains("session"))
            {
                ev.Categoria = "Logins"; ev.Icone = "👤";
                ev.Titulo = "Atividade de usuário";
                ev.Descricao = "Evento relacionado ao login ou logout de um usuário no sistema.";
            }
            else if (fonte.Contains("msiinstaller") || fonte.Contains("application"))
            {
                ev.Categoria = "Instalações"; ev.Icone = "📦";
                ev.Titulo = "Instalação ou desinstalação de programa";
                ev.Descricao = $"O programa '{entry.Source}' foi instalado, atualizado ou desinstalado no seu computador.";
            }
            else if (entry.EntryType == EventLogEntryType.Error)
            {
                ev.Categoria = "Erros Críticos"; ev.Icone = "❌";
                ev.Titulo = $"Erro: {entry.Source}";
                ev.Descricao = TraduzirMensagemGenerica(entry.Message, entry.Source);
            }
            else
            {
                ev.Categoria = "Avisos"; ev.Icone = "⚠️";
                ev.Titulo = $"Aviso: {entry.Source}";
                ev.Descricao = TraduzirMensagemGenerica(entry.Message, entry.Source);
            }

            return ev;
        }

        private string TraduzirMensagemGenerica(string mensagem, string fonte)
        {
            if (string.IsNullOrWhiteSpace(mensagem)) return $"O componente '{fonte}' registrou um evento no sistema. Para mais detalhes, consulte o Visualizador de Eventos do Windows.";

            var resumo = mensagem.Length > 200 ? mensagem.Substring(0, 200) + "..." : mensagem;
            return $"O Windows registrou uma ocorrência no componente '{fonte}'.\n\n" +
                   $"Mensagem técnica:\n{resumo}\n\n" +
                   $"Este tipo de aviso é geralmente inofensivo se ocorrer esporadicamente. Se for frequente, pode indicar um problema que merece atenção.";
        }

        private EventoTraduzido TraduzirEventoSeguranca(EventLogEntry entry)
        {
            var id = (int)(entry.InstanceId & 0xFFFF);

            if (id == 4624)
                return new EventoTraduzido { Categoria = "Logins", Icone = "🔓", Titulo = "Login realizado com sucesso", Descricao = "Um usuário fez login no computador com sucesso. Verifique a data e hora — se não foi você, pode indicar acesso não autorizado.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 4634 || id == 4647)
                return new EventoTraduzido { Categoria = "Logins", Icone = "🔒", Titulo = "Logout realizado", Descricao = "Um usuário saiu da sessão do Windows (logout ou bloqueio de tela).", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 6006)
                return new EventoTraduzido { Categoria = "Desligamentos", Icone = "🔌", Titulo = "Desligamento normal do sistema", Descricao = "O Windows foi desligado normalmente através do menu Iniciar > Desligar.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 41)
                return new EventoTraduzido { Categoria = "Desligamentos", Icone = "⚡", Titulo = "Desligamento inesperado (Kernel Power)", Descricao = "O computador foi desligado sem passar pelo processo normal de encerramento. Causas comuns: queda de energia, pressão acidental do botão de desligar, ou travamento grave (tela azul). Se frequente, verifique a fonte de alimentação e o sistema de refrigeração.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };

            return new EventoTraduzido { Categoria = "Logins", Icone = "🛡️", Titulo = $"Evento de segurança (ID {id})", Descricao = "Evento de segurança registrado pelo Windows.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
        }

        private void FiltroBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var categoria = btn.Tag as string;

            foreach (Control c in panelFiltros.Controls)
            {
                if (c is Button b)
                {
                    b.BackColor = Color.FromArgb(240, 240, 248);
                    b.ForeColor = Color.FromArgb(80, 80, 110);
                }
            }
            btn.BackColor = Color.FromArgb(142, 68, 173);
            btn.ForeColor = Color.White;

            _categoriaAtiva = categoria;
            ExibirEventos(categoria);
        }

        private void ExibirEventos(string categoria)
        {
            panelCards.Controls.Clear();

            var filtrados = categoria == "Todos"
                ? _todosEventos
                : _todosEventos.Where(e => e.Categoria == categoria).ToList();

            lblCount.Text = $"{filtrados.Count} eventos";

            if (filtrados.Count == 0)
            {
                var lblVazio = new Label
                {
                    Text = "✔  Nenhum evento encontrado nesta categoria.\n\nBoa notícia — seu sistema parece estar saudável!",
                    Font = new Font("Segoe UI", 11f),
                    ForeColor = Color.FromArgb(39, 174, 96),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(550, 120),
                    AutoSize = false
                };
                panelCards.Controls.Add(lblVazio);
                return;
            }

            foreach (var ev in filtrados.Take(200))
            {
                panelCards.Controls.Add(CriarCardEvento(ev));
            }
        }

        private Panel CriarCardEvento(EventoTraduzido ev)
        {
            var corBorda = ev.Categoria == "Erros Críticos" ? Color.FromArgb(231, 76, 60) :
                           ev.Categoria == "Avisos" ? Color.FromArgb(243, 156, 18) :
                           ev.Categoria == "Logins" ? Color.FromArgb(52, 152, 219) :
                           ev.Categoria == "Instalações" ? Color.FromArgb(39, 174, 96) :
                           Color.FromArgb(155, 89, 182);

            var card = new Panel
            {
                Size = new Size(680, 60),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 6),
                Cursor = Cursors.Hand,
                Tag = ev
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(corBorda), 0, 0, 4, card.Height);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(225, 228, 235)), 0, 0, card.Width - 1, card.Height - 1);
            };

            var lblIco = new Label { Text = ev.Icone, Font = new Font("Segoe UI", 14f), Location = new Point(12, 10), Size = new Size(35, 35), TextAlign = ContentAlignment.MiddleCenter };
            var lblTit = new Label { Text = ev.Titulo, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(55, 8), Size = new Size(500, 20), AutoEllipsis = true };
            var lblDat = new Label { Text = ev.DataHora.ToString("dd/MM/yyyy  HH:mm") + "  |  " + ev.Categoria, Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, Location = new Point(55, 30), Size = new Size(500, 18) };

            card.Controls.AddRange(new Control[] { lblIco, lblTit, lblDat });

            Action<bool> hover = (h) =>
            {
                card.BackColor = h ? Color.FromArgb(250, 248, 255) : Color.White;
                foreach (Control c in card.Controls) c.BackColor = card.BackColor;
            };

            foreach (Control c in card.Controls) { c.MouseEnter += (s, e) => hover(true); c.MouseLeave += (s, e) => hover(false); c.Click += (s, e) => MostrarDetalhe(ev); }
            card.MouseEnter += (s, e) => hover(true);
            card.MouseLeave += (s, e) => hover(false);
            card.Click += (s, e) => MostrarDetalhe(ev);

            return card;
        }

        private void MostrarDetalhe(EventoTraduzido ev)
        {
            lblDetalheNome.Text = ev.Icone + "  " + ev.Titulo;
            lblDetalheData.Text = ev.DataHora.ToString("dddd, dd/MM/yyyy  HH:mm:ss");
            rtbDetalheDescricao.Text = ev.Descricao;

            if (!string.IsNullOrEmpty(ev.DetalhesTecnicos))
                rtbDetalheDescricao.Text += $"\n\n────────────────\n📋 Detalhes técnicos:\n{ev.DetalhesTecnicos}";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 720);
            this.Name = "FormEvents";
            this.ResumeLayout(false);
        }
    }
}