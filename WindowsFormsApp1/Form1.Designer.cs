namespace AppInterno
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.driversButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.hardwareListView = new System.Windows.Forms.ListView();
            this.colCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFabricante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetalhes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.discoveryButton = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(449, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🖥️ Componentes do Seu Computador";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.subtitleLabel.Location = new System.Drawing.Point(20, 55);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(399, 19);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Veja todas as peças e componentes que seu computador possui";
            // 
            // driversButton
            // 
            this.driversButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.driversButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.driversButton.FlatAppearance.BorderSize = 0;
            this.driversButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driversButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.driversButton.ForeColor = System.Drawing.Color.White;
            this.driversButton.Location = new System.Drawing.Point(723, 16);
            this.driversButton.Name = "driversButton";
            this.driversButton.Size = new System.Drawing.Size(180, 40);
            this.driversButton.TabIndex = 2;
            this.driversButton.Text = "🔧 Analisar Drivers";
            this.driversButton.UseVisualStyleBackColor = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Location = new System.Drawing.Point(909, 20);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(113, 32);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "🔄 Atualizar Informações";
            this.refreshButton.UseVisualStyleBackColor = false;
            // 
            // hardwareListView
            // 
            this.hardwareListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hardwareListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategoria,
            this.colNome,
            this.colFabricante,
            this.colDetalhes,
            this.colStatus});
            this.hardwareListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hardwareListView.FullRowSelect = true;
            this.hardwareListView.GridLines = true;
            this.hardwareListView.HideSelection = false;
            this.hardwareListView.Location = new System.Drawing.Point(20, 90);
            this.hardwareListView.Name = "hardwareListView";
            this.hardwareListView.Size = new System.Drawing.Size(1002, 520);
            this.hardwareListView.TabIndex = 4;
            this.hardwareListView.UseCompatibleStateImageBehavior = false;
            this.hardwareListView.View = System.Windows.Forms.View.Details;
            // 
            // colCategoria
            // 
            this.colCategoria.Text = "Categoria";
            this.colCategoria.Width = 180;
            // 
            // colNome
            // 
            this.colNome.Text = "Nome/Modelo";
            this.colNome.Width = 250;
            // 
            // colFabricante
            // 
            this.colFabricante.Text = "Fabricante";
            this.colFabricante.Width = 150;
            // 
            // colDetalhes
            // 
            this.colDetalhes.Text = "Detalhes";
            this.colDetalhes.Width = 300;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // discoveryButton
            // 
            this.discoveryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discoveryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.discoveryButton.FlatAppearance.BorderSize = 0;
            this.discoveryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discoveryButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.discoveryButton.ForeColor = System.Drawing.Color.White;
            this.discoveryButton.Location = new System.Drawing.Point(517, 16);
            this.discoveryButton.Name = "discoveryButton";
            this.discoveryButton.Size = new System.Drawing.Size(200, 40);
            this.discoveryButton.TabIndex = 5;
            this.discoveryButton.Text = "🎓 Central de Descobertas";
            this.discoveryButton.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContainer.Controls.Add(this.titleLabel);
            this.panelContainer.Controls.Add(this.discoveryButton);
            this.panelContainer.Controls.Add(this.subtitleLabel);
            this.panelContainer.Controls.Add(this.hardwareListView);
            this.panelContainer.Controls.Add(this.driversButton);
            this.panelContainer.Controls.Add(this.refreshButton);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1042, 630);
            this.panelContainer.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 630);
            this.Controls.Add(this.panelContainer);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meu Computador - Guia Fácil";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button driversButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ListView hardwareListView;
        private System.Windows.Forms.ColumnHeader colCategoria;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colFabricante;
        private System.Windows.Forms.ColumnHeader colDetalhes;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button discoveryButton;
        private System.Windows.Forms.Panel panelContainer;
    }
}