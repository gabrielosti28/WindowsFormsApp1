namespace AppInterno
{
    partial class FormAppsNativos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.preInstalledCheck = new System.Windows.Forms.CheckBox();
            this.categoryFilter = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.clearSearchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchIcon = new System.Windows.Forms.Label();
            this.appsListView = new System.Windows.Forms.ListView();
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOQueFaz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDisponibilidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAcao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1400, 110);
            this.headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(30, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(531, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "📱 Aplicativos Nativos do Windows";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.subtitleLabel.Location = new System.Drawing.Point(30, 70);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(549, 20);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Descubra programas úteis que já vêm instalados no seu Windows!";
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.infoPanel.Controls.Add(this.infoLabel);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 110);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanel.Size = new System.Drawing.Size(1400, 70);
            this.infoPanel.TabIndex = 1;
            // 
            // infoLabel
            // 
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.infoLabel.Location = new System.Drawing.Point(15, 15);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(1370, 40);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "💡 DICA: Clique DUAS VEZES em qualquer app para ver detalhes completos e como abr" +
    "ir!\r\n🎯 Os apps mostram primeiro O QUE FAZEM, não o nome técnico - assim fica ma" +
    "is fácil de entender!";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.preInstalledCheck);
            this.searchPanel.Controls.Add(this.categoryFilter);
            this.searchPanel.Controls.Add(this.filterLabel);
            this.searchPanel.Controls.Add(this.clearSearchButton);
            this.searchPanel.Controls.Add(this.searchBox);
            this.searchPanel.Controls.Add(this.searchIcon);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 180);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1400, 70);
            this.searchPanel.TabIndex = 2;
            // 
            // preInstalledCheck
            // 
            this.preInstalledCheck.AutoSize = true;
            this.preInstalledCheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.preInstalledCheck.Location = new System.Drawing.Point(870, 27);
            this.preInstalledCheck.Name = "preInstalledCheck";
            this.preInstalledCheck.Size = new System.Drawing.Size(159, 23);
            this.preInstalledCheck.TabIndex = 5;
            this.preInstalledCheck.Text = "✅ Apenas pré-instalados";
            this.preInstalledCheck.UseVisualStyleBackColor = true;
            // 
            // categoryFilter
            // 
            this.categoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilter.FormattingEnabled = true;
            this.categoryFilter.Items.AddRange(new object[] {
            "Todas as Categorias",
            "Produtividade",
            "Multimídia",
            "Utilitários",
            "Segurança",
            "Acessibilidade"});
            this.categoryFilter.Location = new System.Drawing.Point(640, 25);
            this.categoryFilter.Name = "categoryFilter";
            this.categoryFilter.Size = new System.Drawing.Size(200, 25);
            this.categoryFilter.TabIndex = 4;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.filterLabel.Location = new System.Drawing.Point(560, 28);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(74, 19);
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Categoria:";
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.clearSearchButton.FlatAppearance.BorderSize = 0;
            this.clearSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearSearchButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clearSearchButton.ForeColor = System.Drawing.Color.White;
            this.clearSearchButton.Location = new System.Drawing.Point(430, 22);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(100, 35);
            this.clearSearchButton.TabIndex = 2;
            this.clearSearchButton.Text = "✖ Limpar";
            this.clearSearchButton.UseVisualStyleBackColor = false;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.searchBox.Location = new System.Drawing.Point(60, 25);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(350, 27);
            this.searchBox.TabIndex = 1;
            // 
            // searchIcon
            // 
            this.searchIcon.AutoSize = true;
            this.searchIcon.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.searchIcon.Location = new System.Drawing.Point(20, 22);
            this.searchIcon.Name = "searchIcon";
            this.searchIcon.Size = new System.Drawing.Size(34, 30);
            this.searchIcon.TabIndex = 0;
            this.searchIcon.Text = "🔍";
            // 
            // appsListView
            // 
            this.appsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colOQueFaz,
            this.colCategoria,
            this.colDisponibilidade,
            this.colAcao});
            this.appsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.appsListView.FullRowSelect = true;
            this.appsListView.GridLines = true;
            this.appsListView.Location = new System.Drawing.Point(0, 250);
            this.appsListView.Name = "appsListView";
            this.appsListView.Size = new System.Drawing.Size(1400, 600);
            this.appsListView.TabIndex = 3;
            this.appsListView.UseCompatibleStateImageBehavior = false;
            this.appsListView.View = System.Windows.Forms.View.Details;
            // 
            // colIcon
            // 
            this.colIcon.Text = "📱";
            this.colIcon.Width = 50;
            // 
            // colOQueFaz
            // 
            this.colOQueFaz.Text = "O que faz";
            this.colOQueFaz.Width = 450;
            // 
            // colCategoria
            // 
            this.colCategoria.Text = "Categoria";
            this.colCategoria.Width = 180;
            // 
            // colDisponibilidade
            // 
            this.colDisponibilidade.Text = "Disponibilidade";
            this.colDisponibilidade.Width = 180;
            // 
            // colAcao
            // 
            this.colAcao.Text = "Ação";
            this.colAcao.Width = 180;
            // 
            // FormAppsNativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.appsListView);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "FormAppsNativos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicativos Nativos do Windows";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.CheckBox preInstalledCheck;
        private System.Windows.Forms.ComboBox categoryFilter;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button clearSearchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchIcon;
        private System.Windows.Forms.ListView appsListView;
        private System.Windows.Forms.ColumnHeader colIcon;
        private System.Windows.Forms.ColumnHeader colOQueFaz;
        private System.Windows.Forms.ColumnHeader colCategoria;
        private System.Windows.Forms.ColumnHeader colDisponibilidade;
        private System.Windows.Forms.ColumnHeader colAcao;
    }
}