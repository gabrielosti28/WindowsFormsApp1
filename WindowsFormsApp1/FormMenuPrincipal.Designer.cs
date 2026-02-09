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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnPecasComputador = new System.Windows.Forms.Button();
            this.btnDesempenho = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnAtalhosWindows = new System.Windows.Forms.Button();
            this.btnAppsNativos = new System.Windows.Forms.Button();
            this.btnDicasTruques = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1034, 104);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(459, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💻 Guia do Computador";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(31, 69);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(492, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Aprenda a usar melhor seu computador - Escolha o que quer explorar";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSair);
            this.panelButtons.Controls.Add(this.btnPecasComputador);
            this.panelButtons.Controls.Add(this.btnDesempenho);
            this.panelButtons.Controls.Add(this.btnDrivers);
            this.panelButtons.Controls.Add(this.btnAtalhosWindows);
            this.panelButtons.Controls.Add(this.btnAppsNativos);
            this.panelButtons.Controls.Add(this.btnDicasTruques);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 104);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(26, 26, 26, 26);
            this.panelButtons.Size = new System.Drawing.Size(1034, 553);
            this.panelButtons.TabIndex = 1;
            // 
            // btnPecasComputador
            // 
            this.btnPecasComputador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnPecasComputador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPecasComputador.FlatAppearance.BorderSize = 0;
            this.btnPecasComputador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPecasComputador.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnPecasComputador.ForeColor = System.Drawing.Color.White;
            this.btnPecasComputador.Location = new System.Drawing.Point(29, 29);
            this.btnPecasComputador.Name = "btnPecasComputador";
            this.btnPecasComputador.Size = new System.Drawing.Size(384, 100);
            this.btnPecasComputador.TabIndex = 0;
            this.btnPecasComputador.Text = "🔧 Peças do Computador\r\nConheça o hardware do seu PC";
            this.btnPecasComputador.UseVisualStyleBackColor = false;
            this.btnPecasComputador.Click += new System.EventHandler(this.btnPecasComputador_Click);
            // 
            // btnDesempenho
            // 
            this.btnDesempenho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnDesempenho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesempenho.FlatAppearance.BorderSize = 0;
            this.btnDesempenho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesempenho.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnDesempenho.ForeColor = System.Drawing.Color.White;
            this.btnDesempenho.Location = new System.Drawing.Point(598, 17);
            this.btnDesempenho.Name = "btnDesempenho";
            this.btnDesempenho.Size = new System.Drawing.Size(382, 97);
            this.btnDesempenho.TabIndex = 1;
            this.btnDesempenho.Text = "📊 Desempenho do Sistema\r\nMemória, disco e processos";
            this.btnDesempenho.UseVisualStyleBackColor = false;
            this.btnDesempenho.Click += new System.EventHandler(this.btnDesempenho_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnDrivers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDrivers.FlatAppearance.BorderSize = 0;
            this.btnDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrivers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnDrivers.ForeColor = System.Drawing.Color.White;
            this.btnDrivers.Location = new System.Drawing.Point(29, 144);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(384, 97);
            this.btnDrivers.TabIndex = 2;
            this.btnDrivers.Text = "🔌 Drivers do Sistema\r\nVerifique se estão atualizados";
            this.btnDrivers.UseVisualStyleBackColor = false;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnAtalhosWindows
            // 
            this.btnAtalhosWindows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAtalhosWindows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtalhosWindows.FlatAppearance.BorderSize = 0;
            this.btnAtalhosWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtalhosWindows.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAtalhosWindows.ForeColor = System.Drawing.Color.White;
            this.btnAtalhosWindows.Location = new System.Drawing.Point(598, 135);
            this.btnAtalhosWindows.Name = "btnAtalhosWindows";
            this.btnAtalhosWindows.Size = new System.Drawing.Size(382, 89);
            this.btnAtalhosWindows.TabIndex = 3;
            this.btnAtalhosWindows.Text = "⌨️ Atalhos de Teclado\r\nWindows, Excel, Word e mais";
            this.btnAtalhosWindows.UseVisualStyleBackColor = false;
            this.btnAtalhosWindows.Click += new System.EventHandler(this.btnAtalhosWindows_Click);
            // 
            // btnAppsNativos
            // 
            this.btnAppsNativos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnAppsNativos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppsNativos.FlatAppearance.BorderSize = 0;
            this.btnAppsNativos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppsNativos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAppsNativos.ForeColor = System.Drawing.Color.White;
            this.btnAppsNativos.Location = new System.Drawing.Point(35, 258);
            this.btnAppsNativos.Name = "btnAppsNativos";
            this.btnAppsNativos.Size = new System.Drawing.Size(378, 86);
            this.btnAppsNativos.TabIndex = 4;
            this.btnAppsNativos.Text = "📱 Apps Nativos do Windows\r\nDescubra programas já instalados";
            this.btnAppsNativos.UseVisualStyleBackColor = false;
            this.btnAppsNativos.Click += new System.EventHandler(this.btnAppsNativos_Click);
            // 
            // btnDicasTruques
            // 
            this.btnDicasTruques.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnDicasTruques.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDicasTruques.FlatAppearance.BorderSize = 0;
            this.btnDicasTruques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDicasTruques.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnDicasTruques.ForeColor = System.Drawing.Color.White;
            this.btnDicasTruques.Location = new System.Drawing.Point(598, 258);
            this.btnDicasTruques.Name = "btnDicasTruques";
            this.btnDicasTruques.Size = new System.Drawing.Size(382, 86);
            this.btnDicasTruques.TabIndex = 5;
            this.btnDicasTruques.Text = "💡 Dicas e Truques\r\nAprenda truques úteis do Windows";
            this.btnDicasTruques.UseVisualStyleBackColor = false;
            this.btnDicasTruques.Click += new System.EventHandler(this.btnDicasTruques_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(444, 159);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(137, 43);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "❌ Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1034, 657);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guia do Computador - Menu Principal";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnPecasComputador;
        private System.Windows.Forms.Button btnDesempenho;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnAtalhosWindows;
        private System.Windows.Forms.Button btnAppsNativos;
        private System.Windows.Forms.Button btnDicasTruques;
        private System.Windows.Forms.Button btnSair;
    }
}