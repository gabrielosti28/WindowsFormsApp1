using System.Windows.Forms;

namespace GuiaDoComputador
{
    partial class FormMaintenance
    {
        private System.ComponentModel.IContainer components = null;

        // Controles principais
        private Panel pnlTopo;
        private Panel pnlRodape;
        private Label lblStatus;
        private ProgressBar pbProgresso;
        private TabControl tabMain;

        // Controles da aba Check-up
        private Button btnCheckup;
        private Panel pnlCheckupResultados;

        // Controles da aba Limpeza
        private Button btnAnalisarLixo;
        private Button btnLimparLixo;
        private Panel pnlLixoResultados;

        // Controles da aba Inicialização
        private Button btnCarregarInicializacao;
        private ListView lvInicializacao;
        private Panel pnlDetalhePrograma;
        private Label lblDetalheProgramaNome;
        private Label lblDetalheProgramaDesc;
        private Label lblDetalheProgramaRec;
        private Button btnDesativarInicializacao;

        // Controles da aba Discos
        private Button btnAnalisarDiscos;
        private Panel pnlDiscosResultados;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // =================================================================
            // CONFIGURAÇÕES DO FORMULÁRIO
            // =================================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Text = "🔧  Manutenção do Computador  —  Guia do Computador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // =================================================================
            // PAINEL TOPO (Cabeçalho)
            // =================================================================
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Height = 85;
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.pnlTopo.Padding = new System.Windows.Forms.Padding(25, 15, 25, 0);

            var lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "🔧  Manutenção do Computador";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 15);
            lblTitulo.Size = new System.Drawing.Size(500, 35);

            var lblSubtitulo = new System.Windows.Forms.Label();
            lblSubtitulo.Text = "Check-up completo, limpeza de arquivos e otimização — tudo em português claro";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(210, 245, 220);
            lblSubtitulo.Location = new System.Drawing.Point(25, 50);
            lblSubtitulo.Size = new System.Drawing.Size(600, 22);

            var lblVersao = new System.Windows.Forms.Label();
            lblVersao.Text = "versão 1.0 • beta";
            lblVersao.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblVersao.ForeColor = System.Drawing.Color.FromArgb(200, 240, 210);
            lblVersao.Location = new System.Drawing.Point(950, 30);
            lblVersao.Size = new System.Drawing.Size(120, 20);
            lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblVersao.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.pnlTopo.Controls.Add(lblTitulo);
            this.pnlTopo.Controls.Add(lblSubtitulo);
            this.pnlTopo.Controls.Add(lblVersao);

            // =================================================================
            // PAINEL RODAPÉ (Status e Progresso)
            // =================================================================
            this.pnlRodape = new System.Windows.Forms.Panel();
            this.pnlRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRodape.Height = 45;
            this.pnlRodape.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlRodape.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);

            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.Text = "✨ Pronto para começar!";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pbProgresso = new System.Windows.Forms.ProgressBar();
            this.pbProgresso.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbProgresso.Width = 200;
            this.pbProgresso.Height = 25;
            this.pbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgresso.Visible = false;

            this.pnlRodape.Controls.Add(this.lblStatus);
            this.pnlRodape.Controls.Add(this.pbProgresso);

            // =================================================================
            // TAB CONTROL PRINCIPAL
            // =================================================================
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.tabMain.Padding = new System.Drawing.Point(15, 8);

            // =================================================================
            // ABA 1: CHECK-UP GERAL
            // =================================================================
            var tabCheckup = new System.Windows.Forms.TabPage("🏥  Check-up Geral");
            tabCheckup.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            tabCheckup.Padding = new System.Windows.Forms.Padding(20);

            var pnlCheckup = new System.Windows.Forms.Panel();
            pnlCheckup.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCheckup.AutoScroll = true;

            // Texto explicativo
            var lblCheckupExplica = new System.Windows.Forms.Label();
            lblCheckupExplica.Text = "🔍  O check-up analisa a saúde do seu computador e dá uma nota de 0 a 100.\n" +
                                     "Você verá o que está bom, o que precisa de atenção e o que fazer para melhorar.";
            lblCheckupExplica.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblCheckupExplica.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblCheckupExplica.Location = new System.Drawing.Point(20, 20);
            lblCheckupExplica.Size = new System.Drawing.Size(900, 45);

            // Botão de check-up
            this.btnCheckup = new System.Windows.Forms.Button();
            this.btnCheckup.Text = "🔍  FAZER CHECK-UP COMPLETO";
            this.btnCheckup.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.btnCheckup.ForeColor = System.Drawing.Color.White;
            this.btnCheckup.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCheckup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckup.FlatAppearance.BorderSize = 0;
            this.btnCheckup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckup.Location = new System.Drawing.Point(20, 80);
            this.btnCheckup.Size = new System.Drawing.Size(300, 55);
            this.btnCheckup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Efeito hover
            this.btnCheckup.MouseEnter += (s, e) => this.btnCheckup.BackColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnCheckup.MouseLeave += (s, e) => this.btnCheckup.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);

            // Painel de resultados do check-up
            this.pnlCheckupResultados = new System.Windows.Forms.Panel();
            this.pnlCheckupResultados.Location = new System.Drawing.Point(20, 150);
            this.pnlCheckupResultados.Size = new System.Drawing.Size(900, 500);
            this.pnlCheckupResultados.AutoScroll = true;

            pnlCheckup.Controls.Add(lblCheckupExplica);
            pnlCheckup.Controls.Add(this.btnCheckup);
            pnlCheckup.Controls.Add(this.pnlCheckupResultados);
            tabCheckup.Controls.Add(pnlCheckup);

            // =================================================================
            // ABA 2: LIMPEZA DE ARQUIVOS
            // =================================================================
            var tabLimpeza = new System.Windows.Forms.TabPage("🧹  Limpeza de Arquivos");
            tabLimpeza.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            tabLimpeza.Padding = new System.Windows.Forms.Padding(20);

            var pnlLimpeza = new System.Windows.Forms.Panel();
            pnlLimpeza.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLimpeza.AutoScroll = true;

            // Texto explicativo
            var lblLimpezaExplica = new System.Windows.Forms.Label();
            lblLimpezaExplica.Text = "🧹  Com o tempo, o Windows acumula arquivos temporários — como uma gaveta que vai enchendo.\n" +
                                     "A limpeza abaixo é 100% segura: remove apenas o que não é mais necessário.";
            lblLimpezaExplica.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblLimpezaExplica.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblLimpezaExplica.Location = new System.Drawing.Point(20, 20);
            lblLimpezaExplica.Size = new System.Drawing.Size(900, 45);

            // Botões de ação
            this.btnAnalisarLixo = new System.Windows.Forms.Button();
            this.btnAnalisarLixo.Text = "🔍  Analisar quanto espaço pode ser liberado";
            this.btnAnalisarLixo.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnAnalisarLixo.ForeColor = System.Drawing.Color.White;
            this.btnAnalisarLixo.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAnalisarLixo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalisarLixo.FlatAppearance.BorderSize = 0;
            this.btnAnalisarLixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalisarLixo.Location = new System.Drawing.Point(20, 80);
            this.btnAnalisarLixo.Size = new System.Drawing.Size(350, 45);

            this.btnLimparLixo = new System.Windows.Forms.Button();
            this.btnLimparLixo.Text = "🧹  Apagar arquivos e liberar espaço";
            this.btnLimparLixo.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnLimparLixo.ForeColor = System.Drawing.Color.White;
            this.btnLimparLixo.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnLimparLixo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparLixo.FlatAppearance.BorderSize = 0;
            this.btnLimparLixo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparLixo.Location = new System.Drawing.Point(390, 80);
            this.btnLimparLixo.Size = new System.Drawing.Size(350, 45);
            this.btnLimparLixo.Enabled = false;

            // Painel de resultados da limpeza
            this.pnlLixoResultados = new System.Windows.Forms.Panel();
            this.pnlLixoResultados.Location = new System.Drawing.Point(20, 140);
            this.pnlLixoResultados.Size = new System.Drawing.Size(900, 500);
            this.pnlLixoResultados.AutoScroll = true;

            pnlLimpeza.Controls.Add(lblLimpezaExplica);
            pnlLimpeza.Controls.Add(this.btnAnalisarLixo);
            pnlLimpeza.Controls.Add(this.btnLimparLixo);
            pnlLimpeza.Controls.Add(this.pnlLixoResultados);
            tabLimpeza.Controls.Add(pnlLimpeza);

            // =================================================================
            // ABA 3: INICIALIZAÇÃO
            // =================================================================
            var tabInicializacao = new System.Windows.Forms.TabPage("🚀  Inicialização");
            tabInicializacao.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            tabInicializacao.Padding = new System.Windows.Forms.Padding(20);

            var pnlInicializacao = new System.Windows.Forms.Panel();
            pnlInicializacao.Dock = System.Windows.Forms.DockStyle.Fill;

            // Texto explicativo
            var lblInicializacaoExplica = new System.Windows.Forms.Label();
            lblInicializacaoExplica.Text = "🚀  Programas que abrem sozinhos quando o Windows inicia.\n" +
                                           "Quanto mais programas, mais demora para o computador ficar pronto.";
            lblInicializacaoExplica.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblInicializacaoExplica.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblInicializacaoExplica.Location = new System.Drawing.Point(20, 20);
            lblInicializacaoExplica.Size = new System.Drawing.Size(900, 45);

            // Botão carregar
            this.btnCarregarInicializacao = new System.Windows.Forms.Button();
            this.btnCarregarInicializacao.Text = "🔄  Carregar programas da inicialização";
            this.btnCarregarInicializacao.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnCarregarInicializacao.ForeColor = System.Drawing.Color.White;
            this.btnCarregarInicializacao.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCarregarInicializacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarInicializacao.FlatAppearance.BorderSize = 0;
            this.btnCarregarInicializacao.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
           