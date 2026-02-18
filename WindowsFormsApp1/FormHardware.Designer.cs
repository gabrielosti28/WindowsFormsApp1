namespace AppInterno
{
    partial class FormHardware
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDica = new System.Windows.Forms.Label();
            this.listViewHardware = new System.Windows.Forms.ListView();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblStatus);
            this.panelTop.Controls.Add(this.comboFiltro);
            this.panelTop.Controls.Add(this.lblFiltro);
            this.panelTop.Controls.Add(this.btnAtualizar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblDica);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 130);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🖥️ Todas as Peças do Meu Computador";
            // 
            // lblDica
            // 
            this.lblDica.AutoSize = true;
            this.lblDica.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDica.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDica.Location = new System.Drawing.Point(17, 40);
            this.lblDica.Name = "lblDica";
            this.lblDica.Size = new System.Drawing.Size(500, 15);
            this.lblDica.TabIndex = 5;
            this.lblDica.Text = "💡 Clique DUAS VEZES em qualquer peça para ver explicação completa e informações detalhadas.";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(17, 68);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(170, 38);
            this.btnAtualizar.TabIndex = 1;
            this.btnAtualizar.Text = "🔄 Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltro.Location = new System.Drawing.Point(205, 78);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(75, 19);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // comboFiltro
            // 
            this.comboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Items.AddRange(new object[] {
                "Todos os Componentes",
                "Processador",
                "Memória",
                "Disco",
                "Placa de Vídeo",
                "Rede",
                "Áudio",
                "Sistema"
            });
            this.comboFiltro.Location = new System.Drawing.Point(285, 75);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(220, 25);
            this.comboFiltro.TabIndex = 3;
            this.comboFiltro.SelectedIndexChanged += new System.EventHandler(this.comboFiltro_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(17, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Pronto";
            // 
            // listViewHardware
            // 
            this.listViewHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHardware.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listViewHardware.FullRowSelect = true;
            this.listViewHardware.GridLines = true;
            this.listViewHardware.HideSelection = false;
            this.listViewHardware.Location = new System.Drawing.Point(0, 130);
            this.listViewHardware.Name = "listViewHardware";
            this.listViewHardware.Size = new System.Drawing.Size(1200, 570);
            this.listViewHardware.TabIndex = 1;
            this.listViewHardware.UseCompatibleStateImageBehavior = false;
            this.listViewHardware.View = System.Windows.Forms.View.Details;
            this.listViewHardware.DoubleClick += new System.EventHandler(this.listViewHardware_DoubleClick);
            // 
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.listViewHardware);
            this.Controls.Add(this.panelTop);
            this.Name = "FormHardware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Peças do Meu Computador — Guia Completo";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDica;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView listViewHardware;
    }
}