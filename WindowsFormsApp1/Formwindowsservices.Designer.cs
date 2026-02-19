using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    partial class FormWindowsServices
    {
        private System.ComponentModel.IContainer components = null;

        // Controles principais
        private Panel pnlTopo;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlFiltros;
        private TextBox txtBusca;
        private ComboBox cmbCategoria;
        private ComboBox cmbStatus;
        private Button btnAtualizar;
        private Label lblContagem;
        private Label lblStatus;
        private Panel pnlAvisoImpressora;
        private Label lblAvisoImpressora;
        private SplitContainer splitMain;

        // Lista de serviços
        private ListView lvServicos;

        // Painel de detalhes
        private Panel pnlDetalhes;
        private Label lblNomeServico;
        private Label lblNomeTecnico;
        private Label lblStatusServico;
        private Label lblTipoInicio;
        private Label lblSecaoOQueE;
        private RichTextBox txtOQueEste;
        private Label lblSecaoParaQue;
        private RichTextBox txtParaQueServe;
        private Label lblSecaoSeDesligar;
        private RichTextBox txtSeDesligar;
        private Label lblRecomendacao;
        private Panel pnlBotoes;
        private Button btnIniciar;
        private Button btnParar;
        private Button btnReiniciar;
        private Button btnAcaoRapida;
        private Label lblAvisoCritico;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "⚙️ O que está rodando por baixo do computador";
            this.Size = new Size(1200, 750);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9f);
            this.Load += FormWindowsServices_Load;

            // ── PAINEL DO TOPO ───────────────────────────────────────────────
            pnlTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(41, 128, 185),
                Padding = new Padding(15, 0, 15, 0)
            };

            lblTitulo = new Label
            {
                Text = "⚙️ O que está rodando por baixo do computador",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 8),
                AutoSize = true
            };

            lblSubtitulo = new Label
            {
                Text = "Veja e controle os serviços que funcionam em segundo plano — explicados em linguagem simples",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(200, 230, 255),
                Location = new Point(17, 42),
                AutoSize = true
            };

            pnlTopo.Controls.Add(lblTitulo);
            pnlTopo.Controls.Add(lblSubtitulo);

            // ── PAINEL DE AVISO IMPRESSORA ────────────────────────────────────
            pnlAvisoImpressora = new Panel
            {
                Dock = DockStyle.Top,
                Height = 36,
                BackColor = Color.FromArgb(255, 243, 205),
                Visible = false,
                Padding = new Padding(10, 0, 10, 0)
            };

            lblAvisoImpressora = new Label
            {
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(133, 100, 4),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlAvisoImpressora.Controls.Add(lblAvisoImpressora);

            // ── PAINEL DE FILTROS ─────────────────────────────────────────────
            pnlFiltros = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 8)
            };
            pnlFiltros.Controls.AddRange(CriarFiltros());

            // ── SPLIT PRINCIPAL ───────────────────────────────────────────────
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 550,
                Panel1MinSize = 350,
                Panel2MinSize = 350,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(200, 210, 220)
            };

            // LISTA
            lvServicos = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = false,
                MultiSelect = false,
                Font = new Font("Segoe UI", 9f),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            lvServicos.Columns.Add("Serviço", 280);
            lvServicos.Columns.Add("Status", 120);
            lvServicos.Columns.Add("Categoria", 120);
            lvServicos.Columns.Add("Tipo de Início", 160);
            lvServicos.SelectedIndexChanged += lvServicos_SelectedIndexChanged;
            splitMain.Panel1.Controls.Add(lvServicos);

            // DETALHES
            splitMain.Panel2.Controls.Add(CriarPainelDetalhes());
            splitMain.Panel2.BackColor = Color.White;

            // ── BARRA DE RODAPÉ ────────────────────────────────────────────────
            var pnlRodape = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(236, 240, 241),
                Padding = new Padding(10, 0, 10, 0)
            };

            lblContagem = new Label
            {
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(127, 140, 141),
                Dock = DockStyle.Left,
                Width = 200,
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblStatus = new Label
            {
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
                Dock = DockStyle.Right,
                Width = 350,
                TextAlign = ContentAlignment.MiddleRight
            };

            pnlRodape.Controls.Add(lblContagem);
            pnlRodape.Controls.Add(lblStatus);

            // ── MONTAR FORM ────────────────────────────────────────────────────
            this.Controls.Add(splitMain);
            this.Controls.Add(pnlFiltros);
            this.Controls.Add(pnlAvisoImpressora);
            this.Controls.Add(pnlTopo);
            this.Controls.Add(pnlRodape);
        }

        private Control[] CriarFiltros()
        {
            var lblBusca = new Label
            {
                Text = "Buscar:",
                Font = new Font("Segoe UI", 8.5f),
                Location = new Point(10, 16),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            txtBusca = new TextBox
            {
                Location = new Point(60, 13),
                Width = 180,
                Font = new Font("Segoe UI", 9f),
                BorderStyle = BorderStyle.FixedSingle,
                //PlaceholderText = "🔍 Digite para filtrar..."
            };
            txtBusca.TextChanged += txtBusca_TextChanged;

            var lblCat = new Label
            {
                Text = "Categoria:",
                Font = new Font("Segoe UI", 8.5f),
                Location = new Point(255, 16),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            cmbCategoria = new ComboBox
            {
                Location = new Point(320, 13),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9f)
            };
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            var lblStatus2 = new Label
            {
                Text = "Mostrar:",
                Font = new Font("Segoe UI", 8.5f),
                Location = new Point(495, 16),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            cmbStatus = new ComboBox
            {
                Location = new Point(554, 13),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9f)
            };
            cmbStatus.Items.AddRange(new object[]
            {
                "Todos", "Funcionando", "Desligado", "Importantes", "Pode Desligar"
            });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;

            btnAtualizar = new Button
            {
                Text = "🔄 Atualizar",
                Location = new Point(730, 10),
                Size = new Size(110, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f),
                Cursor = Cursors.Hand
            };
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.Click += btnAtualizar_Click;

            return new Control[] { lblBusca, txtBusca, lblCat, cmbCategoria,
                                   lblStatus2, cmbStatus, btnAtualizar };
        }

        private Panel CriarPainelDetalhes()
        {
            pnlDetalhes = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            int y = 10;

            // Nome do serviço
            lblNomeServico = new Label
            {
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(10, y),
                Size = new Size(560, 30),
                Text = "Selecione um serviço para ver detalhes"
            };
            y += 32;

            lblNomeTecnico = new Label
            {
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(10, y),
                Size = new Size(560, 18),
                Text = ""
            };
            y += 22;

            // Status e tipo de início
            var pnlStatusTipo = new Panel { Location = new Point(10, y), Size = new Size(560, 22) };
            lblStatusServico = new Label
            {
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(0, 0),
                AutoSize = true
            };
            lblTipoInicio = new Label
            {
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(200, 0),
                AutoSize = true
            };
            pnlStatusTipo.Controls.Add(lblStatusServico);
            pnlStatusTipo.Controls.Add(lblTipoInicio);
            y += 28;

            // Aviso crítico
            lblAvisoCritico = new Label
            {
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(133, 100, 4),
                BackColor = Color.FromArgb(255, 243, 205),
                Location = new Point(10, y),
                Size = new Size(560, 30),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0),
                Visible = false
            };
            y += 36;

            // Seção: O que é este serviço?
            lblSecaoOQueE = CriarLabelSecao("🤔 O que é este serviço?", y);
            y += 22;
            txtOQueEste = CriarRichTextBox(y, 60);
            y += 66;

            // Seção: Para que serve?
            lblSecaoParaQue = CriarLabelSecao("✅ Para que serve?", y);
            y += 22;
            txtParaQueServe = CriarRichTextBox(y, 45);
            y += 51;

            // Seção: O que acontece se desligar?
            lblSecaoSeDesligar = CriarLabelSecao("⚠️ O que acontece se eu desligar?", y);
            y += 22;
            txtSeDesligar = CriarRichTextBox(y, 45);
            y += 51;

            // Recomendação
            lblRecomendacao = new Label
            {
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
                Location = new Point(10, y),
                Size = new Size(560, 40),
                Text = ""
            };
            y += 46;

            // Botões de controle
            pnlBotoes = new Panel { Location = new Point(10, y), Size = new Size(560, 40) };

            btnIniciar = CriarBotaoAcao("▶ Ligar", 0, Color.FromArgb(39, 174, 96));
            btnIniciar.Click += btnIniciar_Click;

            btnParar = CriarBotaoAcao("⏹ Desligar", 130, Color.FromArgb(192, 57, 43));
            btnParar.Click += btnParar_Click;

            btnReiniciar = CriarBotaoAcao("🔄 Reiniciar", 260, Color.FromArgb(41, 128, 185));
            btnReiniciar.Click += btnReiniciar_Click;

            btnIniciar.Enabled = btnParar.Enabled = btnReiniciar.Enabled = false;
            pnlBotoes.Controls.AddRange(new Control[] { btnIniciar, btnParar, btnReiniciar });
            y += 46;

            // Ação rápida
            btnAcaoRapida = new Button
            {
                Location = new Point(10, y),
                Size = new Size(400, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(243, 156, 18),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Visible = false
            };
            btnAcaoRapida.FlatAppearance.BorderSize = 0;
            btnAcaoRapida.Click += btnAcaoRapida_Click;

            pnlDetalhes.Controls.AddRange(new Control[]
            {
                lblNomeServico, lblNomeTecnico, pnlStatusTipo, lblAvisoCritico,
                lblSecaoOQueE, txtOQueEste,
                lblSecaoParaQue, txtParaQueServe,
                lblSecaoSeDesligar, txtSeDesligar,
                lblRecomendacao, pnlBotoes, btnAcaoRapida
            });

            return pnlDetalhes;
        }

        private Label CriarLabelSecao(string texto, int y) => new Label
        {
            Text = texto,
            Font = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(44, 62, 80),
            Location = new Point(10, y),
            AutoSize = true
        };

        private RichTextBox CriarRichTextBox(int y, int altura) => new RichTextBox
        {
            Location = new Point(10, y),
            Size = new Size(560, altura),
            ReadOnly = true,
            BorderStyle = BorderStyle.None,
            BackColor = Color.FromArgb(248, 249, 250),
            Font = new Font("Segoe UI", 9f),
            ForeColor = Color.FromArgb(44, 62, 80),
            ScrollBars = RichTextBoxScrollBars.None
        };

        private Button CriarBotaoAcao(string texto, int x, Color cor) => new Button
        {
            Text = texto,
            Location = new Point(x, 0),
            Size = new Size(120, 34),
            FlatStyle = FlatStyle.Flat,
            BackColor = cor,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9f),
            Cursor = Cursors.Hand
        };
    }
}