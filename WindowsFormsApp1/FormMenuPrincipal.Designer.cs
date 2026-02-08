namespace AppInterno
{
    partial class FormMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnPecasComputador = new System.Windows.Forms.Button();
            this.btnDesempenho = new System.Windows.Forms.Button();
            this.btnAtalhosWindows = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(884, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(40, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(427, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Escolha uma das opções abaixo para começar a explorar";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(35, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(575, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👋 Bem-vindo ao Seu Guia!";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnPecasComputador);
            this.panelMenu.Controls.Add(this.btnDesempenho);
            this.panelMenu.Controls.Add(this.btnAtalhosWindows);
            this.panelMenu.Controls.Add(this.btnDrivers);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 120);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.panelMenu.Size = new System.Drawing.Size(884, 438);
            this.panelMenu.TabIndex = 1;
            // 
            // btnPecasComputador
            // 
            this.btnPecasComputador.BackColor = System.Drawing.Color.White;
            this.btnPecasComputador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPecasComputador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnPecasComputador.FlatAppearance.BorderSize = 2;
            this.btnPecasComputador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.btnPecasComputador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPecasComputador.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnPecasComputador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            //this.btnPecasComputador.Image = global::WindowsFormsApp1.Properties.Resources.IconHardware;
            this.btnPecasComputador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPecasComputador.Location = new System.Drawing.Point(60, 50);
            this.btnPecasComputador.Name = "btnPecasComputador";
            this.btnPecasComputador.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPecasComputador.Size = new System.Drawing.Size(380, 90);
            this.btnPecasComputador.TabIndex = 0;
            this.btnPecasComputador.Text = "🖥️  Peças do Meu Computador\r\n       Ver processador, memória, discos...";
            this.btnPecasComputador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPecasComputador.UseVisualStyleBackColor = false;
            this.btnPecasComputador.Click += new System.EventHandler(this.btnPecasComputador_Click);
            // 
            // btnDesempenho
            // 
            this.btnDesempenho.BackColor = System.Drawing.Color.White;
            this.btnDesempenho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesempenho.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDesempenho.FlatAppearance.BorderSize = 2;
            this.btnDesempenho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.btnDesempenho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesempenho.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnDesempenho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDesempenho.Location = new System.Drawing.Point(460, 50);
            this.btnDesempenho.Name = "btnDesempenho";
            this.btnDesempenho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDesempenho.Size = new System.Drawing.Size(380, 90);
            this.btnDesempenho.TabIndex = 1;
            this.btnDesempenho.Text = "📊  Desempenho do Sistema\r\n       Memória, processos, arquivos...";
            this.btnDesempenho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesempenho.UseVisualStyleBackColor = false;
            this.btnDesempenho.Click += new System.EventHandler(this.btnDesempenho_Click);
            // 
            // btnAtalhosWindows
            // 
            this.btnAtalhosWindows.BackColor = System.Drawing.Color.White;
            this.btnAtalhosWindows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtalhosWindows.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAtalhosWindows.FlatAppearance.BorderSize = 2;
            this.btnAtalhosWindows.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.btnAtalhosWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtalhosWindows.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnAtalhosWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAtalhosWindows.Location = new System.Drawing.Point(60, 160);
            this.btnAtalhosWindows.Name = "btnAtalhosWindows";
            this.btnAtalhosWindows.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAtalhosWindows.Size = new System.Drawing.Size(380, 90);
            this.btnAtalhosWindows.TabIndex = 2;
            this.btnAtalhosWindows.Text = "⌨️  Atalhos e Dicas do Windows\r\n       Aprenda truques e atalhos úteis";
            this.btnAtalhosWindows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtalhosWindows.UseVisualStyleBackColor = false;
            this.btnAtalhosWindows.Click += new System.EventHandler(this.btnAtalhosWindows_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.BackColor = System.Drawing.Color.White;
            this.btnDrivers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDrivers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDrivers.FlatAppearance.BorderSize = 2;
            this.btnDrivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.btnDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrivers.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnDrivers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDrivers.Location = new System.Drawing.Point(460, 160);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDrivers.Size = new System.Drawing.Size(380, 90);
            this.btnDrivers.TabIndex = 3;
            this.btnDrivers.Text = "🔧  Meus Drivers\r\n       Verificar se estão atualizados";
            this.btnDrivers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrivers.UseVisualStyleBackColor = false;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelFooter.Controls.Add(this.btnSair);
            this.panelFooter.Controls.Add(this.lblVersao);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 558);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(884, 55);
            this.panelFooter.TabIndex = 2;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(754, 10);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(110, 35);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "✖ Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVersao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblVersao.Location = new System.Drawing.Point(20, 20);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(256, 15);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "Guia do Computador v2.0 - Feito com ❤️ para leigos";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 613);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormMenuPrincipal";
            this.Text = "Guia do Computador";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnPecasComputador;
        private System.Windows.Forms.Button btnDesempenho;
        private System.Windows.Forms.Button btnAtalhosWindows;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblVersao;
    }
}