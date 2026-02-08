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
            this.listViewHardware = new System.Windows.Forms.ListView();
            this.colCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFabricante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1084, 110);
            this.panelTop.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(25, 85);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Pronto";
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
            "Rede"});
            this.comboFiltro.Location = new System.Drawing.Point(310, 52);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(220, 25);
            this.comboFiltro.TabIndex = 3;
            this.comboFiltro.SelectedIndexChanged += new System.EventHandler(this.comboFiltro_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltro.Location = new System.Drawing.Point(230, 55);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(74, 19);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(25, 47);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(180, 35);
            this.btnAtualizar.TabIndex = 1;
            this.btnAtualizar.Text = "🔄 Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitulo.Location = new System.Drawing.Point(22, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(323, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🖥️ Peças do Meu Computador";
            // 
            // listViewHardware
            // 
            this.listViewHardware.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategoria,
            this.colNome,
            this.colFabricante,
            this.colStatus});
            this.listViewHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHardware.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listViewHardware.FullRowSelect = true;
            this.listViewHardware.GridLines = true;
            this.listViewHardware.HideSelection = false;
            this.listViewHardware.Location = new System.Drawing.Point(0, 110);
            this.listViewHardware.Name = "listViewHardware";
            this.listViewHardware.Size = new System.Drawing.Size(1084, 551);
            this.listViewHardware.TabIndex = 1;
            this.listViewHardware.UseCompatibleStateImageBehavior = false;
            this.listViewHardware.View = System.Windows.Forms.View.Details;
            this.listViewHardware.DoubleClick += new System.EventHandler(this.listViewHardware_DoubleClick);
            // 
            // colCategoria
            // 
            this.colCategoria.Text = "Categoria";
            this.colCategoria.Width = 250;
            // 
            // colNome
            // 
            this.colNome.Text = "Nome / Modelo";
            this.colNome.Width = 400;
            // 
            // colFabricante
            // 
            this.colFabricante.Text = "Fabricante";
            this.colFabricante.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 150;
            // 
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.listViewHardware);
            this.Controls.Add(this.panelTop);
            this.Name = "FormHardware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Peças do Meu Computador";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView listViewHardware;
        private System.Windows.Forms.ColumnHeader colCategoria;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colFabricante;
        private System.Windows.Forms.ColumnHeader colStatus;
    }
}