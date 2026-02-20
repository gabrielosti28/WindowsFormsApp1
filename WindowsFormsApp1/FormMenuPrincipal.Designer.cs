// ============================================================
//  FormMenuPrincipal.Designer.cs  —  DESIGNER EDITÁVEL
//  VOCÊ PODE ALTERAR ESTE ARQUIVO PELO DESIGNER DO VISUAL STUDIO
// ============================================================

using System.Windows.Forms;

namespace AppInterno
{
    partial class FormMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private Panel sidebar;
        private Panel pnlLogo;
        private Panel pnlSys;
        private Button btnSair;
        private Panel mainPanel;
        private Panel headerPanel;
        private Label lblTitulo;
        private Label lblSubTitulo;
        private Panel boxBusca;
        private Label lblLupa;
        private System.Windows.Forms.TextBox txtBusca;
        public FlowLayoutPanel gridCards;
        private Label lblOS;
        private Label lblOSValor;
        private Label lblUsuario;
        private Label lblUsuarioValor;
        private Label lblMaquina;
        private Label lblMaquinaValor;
        private Panel separatorVertical;
        private Panel separatorHorizontal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.sidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlSys = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.separatorVertical = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.boxBusca = new System.Windows.Forms.Panel();
            this.lblLupa = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.gridCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblOSValor = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblUsuarioValor = new System.Windows.Forms.Label();
            this.lblMaquina = new System.Windows.Forms.Label();
            this.lblMaquinaValor = new System.Windows.Forms.Label();
            this.separatorHorizontal = new System.Windows.Forms.Panel();

            this.sidebar.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.boxBusca.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────
            // sidebar
            // ──────────────────────────────────────────
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(18, 21, 33);
            this.sidebar.Controls.Add(this.pnlLogo);
            this.sidebar.Controls.Add(this.pnlSys);
            this.sidebar.Controls.Add(this.separatorHorizontal);
            this.sidebar.Controls.Add(this.btnSair);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(230, 720);
            this.sidebar.TabIndex = 0;

            // ──────────────────────────────────────────
            // pnlLogo
            // ──────────────────────────────────────────
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(230, 100);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogo_Paint);

            // ──────────────────────────────────────────
            // pnlSys
            // ──────────────────────────────────────────
            this.pnlSys.BackColor = System.Drawing.Color.Transparent;
            this.pnlSys.Controls.Add(this.lblOS);
            this.pnlSys.Controls.Add(this.lblOSValor);
            this.pnlSys.Controls.Add(this.lblUsuario);
            this.pnlSys.Controls.Add(this.lblUsuarioValor);
            this.pnlSys.Controls.Add(this.lblMaquina);
            this.pnlSys.Controls.Add(this.lblMaquinaValor);
            this.pnlSys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSys.Location = new System.Drawing.Point(0, 563);
            this.pnlSys.Name = "pnlSys";
            this.pnlSys.Size = new System.Drawing.Size(230, 110);
            this.pnlSys.TabIndex = 1;
            this.pnlSys.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSys_Paint);

            // lblOS
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblOS.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            this.lblOS.Location = new System.Drawing.Point(12, 30);
            this.lblOS.Name = "lblOS";
            this.lblOS.TabIndex = 0;
            this.lblOS.Text = "OS:";

            // lblOSValor
            this.lblOSValor.AutoSize = true;
            this.lblOSValor.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblOSValor.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
            this.lblOSValor.Location = new System.Drawing.Point(78, 30);
            this.lblOSValor.Name = "lblOSValor";
            this.lblOSValor.TabIndex = 1;
            this.lblOSValor.Text = "Carregando…";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            this.lblUsuario.Location = new System.Drawing.Point(12, 48);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuário:";

            // lblUsuarioValor
            this.lblUsuarioValor.AutoSize = true;
            this.lblUsuarioValor.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioValor.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
            this.lblUsuarioValor.Location = new System.Drawing.Point(78, 48);
            this.lblUsuarioValor.Name = "lblUsuarioValor";
            this.lblUsuarioValor.TabIndex = 3;
            this.lblUsuarioValor.Text = "Carregando…";

            // lblMaquina
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblMaquina.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            this.lblMaquina.Location = new System.Drawing.Point(12, 66);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.TabIndex = 4;
            this.lblMaquina.Text = "Máquina:";

            // lblMaquinaValor
            this.lblMaquinaValor.AutoSize = true;
            this.lblMaquinaValor.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblMaquinaValor.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
            this.lblMaquinaValor.Location = new System.Drawing.Point(78, 66);
            this.lblMaquinaValor.Name = "lblMaquinaValor";
            this.lblMaquinaValor.TabIndex = 5;
            this.lblMaquinaValor.Text = "Carregando…";

            // ──────────────────────────────────────────
            // separatorHorizontal
            // ──────────────────────────────────────────
            this.separatorHorizontal.BackColor = System.Drawing.Color.FromArgb(40, 46, 68);
            this.separatorHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorHorizontal.Location = new System.Drawing.Point(0, 562);
            this.separatorHorizontal.Name = "separatorHorizontal";
            this.separatorHorizontal.Size = new System.Drawing.Size(230, 1);
            this.separatorHorizontal.TabIndex = 2;

            // ──────────────────────────────────────────
            // btnSair
            // ──────────────────────────────────────────
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 220, 60, 60);
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(220, 70, 70);
            this.btnSair.Location = new System.Drawing.Point(0, 673);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(230, 47);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "⏻   Sair do Programa";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            // ──────────────────────────────────────────
            // separatorVertical
            // ──────────────────────────────────────────
            this.separatorVertical.BackColor = System.Drawing.Color.FromArgb(40, 46, 68);
            this.separatorVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.separatorVertical.Location = new System.Drawing.Point(230, 0);
            this.separatorVertical.Name = "separatorVertical";
            this.separatorVertical.Size = new System.Drawing.Size(1, 720);
            this.separatorVertical.TabIndex = 1;

            // ──────────────────────────────────────────
            // mainPanel
            // ──────────────────────────────────────────
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.gridCards);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(231, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(26, 18, 18, 10);
            this.mainPanel.Size = new System.Drawing.Size(869, 720);
            this.mainPanel.TabIndex = 2;

            // ──────────────────────────────────────────
            // headerPanel
            // ──────────────────────────────────────────
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.boxBusca);
            this.headerPanel.Controls.Add(this.lblSubTitulo);
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(26, 18);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(825, 96);
            this.headerPanel.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Selecione um Módulo";

            // lblSubTitulo
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            this.lblSubTitulo.Location = new System.Drawing.Point(2, 34);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.TabIndex = 1;
            this.lblSubTitulo.Text = "Bem-vindo! Escolha um módulo abaixo.";

            // ──────────────────────────────────────────
            // boxBusca
            // ──────────────────────────────────────────
            this.boxBusca.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.boxBusca.Controls.Add(this.txtBusca);
            this.boxBusca.Controls.Add(this.lblLupa);
            this.boxBusca.Location = new System.Drawing.Point(0, 58);
            this.boxBusca.Name = "boxBusca";
            this.boxBusca.Size = new System.Drawing.Size(270, 33);
            this.boxBusca.TabIndex = 2;
            this.boxBusca.Paint += new System.Windows.Forms.PaintEventHandler(this.boxBusca_Paint);

            // lblLupa
            this.lblLupa.AutoSize = true;
            this.lblLupa.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.lblLupa.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            this.lblLupa.Location = new System.Drawing.Point(8, 7);
            this.lblLupa.Name = "lblLupa";
            this.lblLupa.TabIndex = 0;
            this.lblLupa.Text = "🔍";

            // txtBusca
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBusca.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
            this.txtBusca.Location = new System.Drawing.Point(32, 8);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(230, 17);
            this.txtBusca.TabIndex = 1;
            // FIX: placeholder visual via Enter/Leave
            this.txtBusca.Text = "Pesquisar módulo…";
            this.txtBusca.ForeColor = System.Drawing.Color.FromArgb(80, 90, 120);
            this.txtBusca.Enter += (s, e) => {
                if (this.txtBusca.Text == "Pesquisar módulo…")
                {
                    this.txtBusca.Text = "";
                    this.txtBusca.ForeColor = System.Drawing.Color.FromArgb(220, 225, 240);
                }
            };
            this.txtBusca.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(this.txtBusca.Text))
                {
                    this.txtBusca.Text = "Pesquisar módulo…";
                    this.txtBusca.ForeColor = System.Drawing.Color.FromArgb(80, 90, 120);
                }
            };
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);

            // ──────────────────────────────────────────
            // gridCards  (FIX: adicionado ANTES do headerPanel no mainPanel
            //              para que o Dock=Fill funcione corretamente)
            // ──────────────────────────────────────────
            this.gridCards.AutoScroll = true;
            this.gridCards.BackColor = System.Drawing.Color.Transparent;
            this.gridCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.gridCards.Location = new System.Drawing.Point(26, 114);
            this.gridCards.Name = "gridCards";
            this.gridCards.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.gridCards.Size = new System.Drawing.Size(825, 596);
            this.gridCards.TabIndex = 1;
            this.gridCards.WrapContents = true;

            // ──────────────────────────────────────────
            // FormMenuPrincipal
            // ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 17, 26);
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.separatorVertical);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1116, 759);  // FIX: compensar bordas do OS
            this.MinimumSize = new System.Drawing.Size(1116, 759);
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guia do Computador";

            this.sidebar.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.boxBusca.ResumeLayout(false);
            this.boxBusca.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}