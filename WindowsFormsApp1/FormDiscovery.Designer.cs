namespace AppInterno
{
    partial class FormDiscovery
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageShortcuts = new System.Windows.Forms.TabPage();
            this.shortcutsListView = new System.Windows.Forms.ListView();
            this.colStars = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAtalho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategoriaShortcut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTeclas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuandoUsar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryFilterShortcuts = new System.Windows.Forms.ComboBox();
            this.infoPanelShortcuts = new System.Windows.Forms.Panel();
            this.infoLabelShortcuts = new System.Windows.Forms.Label();
            this.tabPageApps = new System.Windows.Forms.TabPage();
            this.appsListView = new System.Windows.Forms.ListView();
            this.colIconApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOQueFaz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategoriaApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstalado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.preInstalledCheck = new System.Windows.Forms.CheckBox();
            this.categoryFilterApps = new System.Windows.Forms.ComboBox();
            this.infoPanelApps = new System.Windows.Forms.Panel();
            this.infoLabelApps = new System.Windows.Forms.Label();
            this.tabPageTips = new System.Windows.Forms.TabPage();
            this.tipsListView = new System.Windows.Forms.ListView();
            this.colIconTip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDicaTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDicaDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategoriaTip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryFilterTips = new System.Windows.Forms.ComboBox();
            this.infoPanelTips = new System.Windows.Forms.Panel();
            this.infoLabelTips = new System.Windows.Forms.Label();
            this.tabPageExcel = new System.Windows.Forms.TabPage();
            this.excelShortcutsListView = new System.Windows.Forms.ListView();
            this.colStarsExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAtalhoExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescricaoExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategoriaExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTeclasExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMouseExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExemploExcel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryFilterExcel = new System.Windows.Forms.ComboBox();
            this.infoPanelExcel = new System.Windows.Forms.Panel();
            this.infoLabelExcel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.clearSearchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchIcon = new System.Windows.Forms.Label();
            this.mainTabControl.SuspendLayout();
            this.tabPageShortcuts.SuspendLayout();
            this.infoPanelShortcuts.SuspendLayout();
            this.tabPageApps.SuspendLayout();
            this.infoPanelApps.SuspendLayout();
            this.tabPageTips.SuspendLayout();
            this.infoPanelTips.SuspendLayout();
            this.tabPageExcel.SuspendLayout();
            this.infoPanelExcel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPageShortcuts);
            this.mainTabControl.Controls.Add(this.tabPageApps);
            this.mainTabControl.Controls.Add(this.tabPageTips);
            this.mainTabControl.Controls.Add(this.tabPageExcel);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mainTabControl.Location = new System.Drawing.Point(0, 165);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.Padding = new System.Drawing.Point(20, 5);
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1500, 742);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPageShortcuts
            // 
            this.tabPageShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPageShortcuts.Controls.Add(this.shortcutsListView);
            this.tabPageShortcuts.Controls.Add(this.categoryFilterShortcuts);
            this.tabPageShortcuts.Controls.Add(this.infoPanelShortcuts);
            this.tabPageShortcuts.Location = new System.Drawing.Point(4, 33);
            this.tabPageShortcuts.Name = "tabPageShortcuts";
            this.tabPageShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShortcuts.Size = new System.Drawing.Size(1492, 705);
            this.tabPageShortcuts.TabIndex = 0;
            this.tabPageShortcuts.Text = "⌨️ Atalhos de Teclado";
            // 
            // shortcutsListView
            // 
            this.shortcutsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStars,
            this.colAtalho,
            this.colDescricao,
            this.colCategoriaShortcut,
            this.colTeclas,
            this.colQuandoUsar});
            this.shortcutsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.shortcutsListView.FullRowSelect = true;
            this.shortcutsListView.GridLines = true;
            this.shortcutsListView.HideSelection = false;
            this.shortcutsListView.Location = new System.Drawing.Point(20, 120);
            this.shortcutsListView.Name = "shortcutsListView";
            this.shortcutsListView.Size = new System.Drawing.Size(1452, 572);
            this.shortcutsListView.TabIndex = 2;
            this.shortcutsListView.UseCompatibleStateImageBehavior = false;
            this.shortcutsListView.View = System.Windows.Forms.View.Details;
            // 
            // colStars
            // 
            this.colStars.Text = "⭐";
            this.colStars.Width = 50;
            // 
            // colAtalho
            // 
            this.colAtalho.Text = "Atalho";
            this.colAtalho.Width = 200;
            // 
            // colDescricao
            // 
            this.colDescricao.Text = "O que faz";
            this.colDescricao.Width = 450;
            // 
            // colCategoriaShortcut
            // 
            this.colCategoriaShortcut.Text = "Categoria";
            this.colCategoriaShortcut.Width = 150;
            // 
            // colTeclas
            // 
            this.colTeclas.Text = "Teclas";
            this.colTeclas.Width = 180;
            // 
            // colQuandoUsar
            // 
            this.colQuandoUsar.Text = "Quando usar";
            this.colQuandoUsar.Width = 200;
            // 
            // categoryFilterShortcuts
            // 
            this.categoryFilterShortcuts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterShortcuts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilterShortcuts.FormattingEnabled = true;
            this.categoryFilterShortcuts.Items.AddRange(new object[] {
            "Todas as Categorias",
            "Gerais",
            "Sistema Windows",
            "Navegação",
            "Produtividade"});
            this.categoryFilterShortcuts.Location = new System.Drawing.Point(22, 89);
            this.categoryFilterShortcuts.Name = "categoryFilterShortcuts";
            this.categoryFilterShortcuts.Size = new System.Drawing.Size(250, 25);
            this.categoryFilterShortcuts.TabIndex = 1;
            // 
            // infoPanelShortcuts
            // 
            this.infoPanelShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.infoPanelShortcuts.Controls.Add(this.infoLabelShortcuts);
            this.infoPanelShortcuts.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanelShortcuts.Location = new System.Drawing.Point(3, 3);
            this.infoPanelShortcuts.Name = "infoPanelShortcuts";
            this.infoPanelShortcuts.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanelShortcuts.Size = new System.Drawing.Size(1486, 60);
            this.infoPanelShortcuts.TabIndex = 0;
            // 
            // infoLabelShortcuts
            // 
            this.infoLabelShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabelShortcuts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoLabelShortcuts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.infoLabelShortcuts.Location = new System.Drawing.Point(15, 15);
            this.infoLabelShortcuts.Name = "infoLabelShortcuts";
            this.infoLabelShortcuts.Size = new System.Drawing.Size(1456, 30);
            this.infoLabelShortcuts.TabIndex = 0;
            this.infoLabelShortcuts.Text = "💡 Dica: Clique duas vezes em qualquer atalho para ver detalhes completos e saber" +
    " quando usar!";
            // 
            // tabPageApps
            // 
            this.tabPageApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPageApps.Controls.Add(this.appsListView);
            this.tabPageApps.Controls.Add(this.preInstalledCheck);
            this.tabPageApps.Controls.Add(this.categoryFilterApps);
            this.tabPageApps.Controls.Add(this.infoPanelApps);
            this.tabPageApps.Location = new System.Drawing.Point(4, 33);
            this.tabPageApps.Name = "tabPageApps";
            this.tabPageApps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApps.Size = new System.Drawing.Size(1492, 705);
            this.tabPageApps.TabIndex = 1;
            this.tabPageApps.Text = "📱 Aplicativos Nativos";
            // 
            // appsListView
            // 
            this.appsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIconApp,
            this.colOQueFaz,
            this.colCategoriaApp,
            this.colInstalado,
            this.colDica});
            this.appsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.appsListView.FullRowSelect = true;
            this.appsListView.GridLines = true;
            this.appsListView.HideSelection = false;
            this.appsListView.Location = new System.Drawing.Point(20, 135);
            this.appsListView.Name = "appsListView";
            this.appsListView.Size = new System.Drawing.Size(1452, 557);
            this.appsListView.TabIndex = 3;
            this.appsListView.UseCompatibleStateImageBehavior = false;
            this.appsListView.View = System.Windows.Forms.View.Details;
            // 
            // colIconApp
            // 
            this.colIconApp.Text = "";
            this.colIconApp.Width = 50;
            // 
            // colOQueFaz
            // 
            this.colOQueFaz.Text = "O QUE FAZ (clique 2x para ver o nome)";
            this.colOQueFaz.Width = 650;
            // 
            // colCategoriaApp
            // 
            this.colCategoriaApp.Text = "Categoria";
            this.colCategoriaApp.Width = 180;
            // 
            // colInstalado
            // 
            this.colInstalado.Text = "Já instalado?";
            this.colInstalado.Width = 120;
            // 
            // colDica
            // 
            this.colDica.Text = "Dica";
            this.colDica.Width = 230;
            // 
            // preInstalledCheck
            // 
            this.preInstalledCheck.AutoSize = true;
            this.preInstalledCheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.preInstalledCheck.Location = new System.Drawing.Point(290, 98);
            this.preInstalledCheck.Name = "preInstalledCheck";
            this.preInstalledCheck.Size = new System.Drawing.Size(185, 23);
            this.preInstalledCheck.TabIndex = 2;
            this.preInstalledCheck.Text = "Apenas apps já instalados";
            this.preInstalledCheck.UseVisualStyleBackColor = true;
            // 
            // categoryFilterApps
            // 
            this.categoryFilterApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterApps.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilterApps.FormattingEnabled = true;
            this.categoryFilterApps.Items.AddRange(new object[] {
            "Todas as Categorias",
            "Produtividade",
            "Criatividade",
            "Utilitários",
            "Sistema",
            "Acessibilidade",
            "Informação",
            "Educação"});
            this.categoryFilterApps.Location = new System.Drawing.Point(20, 95);
            this.categoryFilterApps.Name = "categoryFilterApps";
            this.categoryFilterApps.Size = new System.Drawing.Size(250, 25);
            this.categoryFilterApps.TabIndex = 1;
            // 
            // infoPanelApps
            // 
            this.infoPanelApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.infoPanelApps.Controls.Add(this.infoLabelApps);
            this.infoPanelApps.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanelApps.Location = new System.Drawing.Point(3, 3);
            this.infoPanelApps.Name = "infoPanelApps";
            this.infoPanelApps.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanelApps.Size = new System.Drawing.Size(1486, 80);
            this.infoPanelApps.TabIndex = 0;
            // 
            // infoLabelApps
            // 
            this.infoLabelApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabelApps.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoLabelApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.infoLabelApps.Location = new System.Drawing.Point(15, 15);
            this.infoLabelApps.Name = "infoLabelApps";
            this.infoLabelApps.Size = new System.Drawing.Size(1456, 50);
            this.infoLabelApps.TabIndex = 0;
            this.infoLabelApps.Text = "🎯 IMPORTANTE: Os aplicativos são mostrados primeiro pelo QUE FAZEM, não pelo nom" +
    "e!\r\nLeia a descrição, e se interessar, clique duas vezes para descobrir qual apl" +
    "icativo é e como abrir.";
            // 
            // tabPageTips
            // 
            this.tabPageTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPageTips.Controls.Add(this.tipsListView);
            this.tabPageTips.Controls.Add(this.categoryFilterTips);
            this.tabPageTips.Controls.Add(this.infoPanelTips);
            this.tabPageTips.Location = new System.Drawing.Point(4, 33);
            this.tabPageTips.Name = "tabPageTips";
            this.tabPageTips.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTips.Size = new System.Drawing.Size(1492, 705);
            this.tabPageTips.TabIndex = 2;
            this.tabPageTips.Text = "💡 Dicas e Truques";
            // 
            // tipsListView
            // 
            this.tipsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIconTip,
            this.colDicaTitulo,
            this.colDicaDescricao,
            this.colCategoriaTip});
            this.tipsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tipsListView.FullRowSelect = true;
            this.tipsListView.GridLines = true;
            this.tipsListView.HideSelection = false;
            this.tipsListView.Location = new System.Drawing.Point(20, 115);
            this.tipsListView.Name = "tipsListView";
            this.tipsListView.Size = new System.Drawing.Size(1452, 577);
            this.tipsListView.TabIndex = 2;
            this.tipsListView.UseCompatibleStateImageBehavior = false;
            this.tipsListView.View = System.Windows.Forms.View.Details;
            // 
            // colIconTip
            // 
            this.colIconTip.Text = "";
            this.colIconTip.Width = 50;
            // 
            // colDicaTitulo
            // 
            this.colDicaTitulo.Text = "Dica";
            this.colDicaTitulo.Width = 400;
            // 
            // colDicaDescricao
            // 
            this.colDicaDescricao.Text = "O que faz";
            this.colDicaDescricao.Width = 550;
            // 
            // colCategoriaTip
            // 
            this.colCategoriaTip.Text = "Categoria";
            this.colCategoriaTip.Width = 180;
            // 
            // categoryFilterTips
            // 
            this.categoryFilterTips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterTips.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilterTips.FormattingEnabled = true;
            this.categoryFilterTips.Items.AddRange(new object[] {
            "Todas as Categorias",
            "Desempenho",
            "Produtividade",
            "Segurança",
            "Personalização",
            "Bem-Estar",
            "Energia",
            "Manutenção",
            "Suporte"});
            this.categoryFilterTips.Location = new System.Drawing.Point(20, 75);
            this.categoryFilterTips.Name = "categoryFilterTips";
            this.categoryFilterTips.Size = new System.Drawing.Size(250, 25);
            this.categoryFilterTips.TabIndex = 1;
            // 
            // infoPanelTips
            // 
            this.infoPanelTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.infoPanelTips.Controls.Add(this.infoLabelTips);
            this.infoPanelTips.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanelTips.Location = new System.Drawing.Point(3, 3);
            this.infoPanelTips.Name = "infoPanelTips";
            this.infoPanelTips.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanelTips.Size = new System.Drawing.Size(1486, 60);
            this.infoPanelTips.TabIndex = 0;
            // 
            // infoLabelTips
            // 
            this.infoLabelTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabelTips.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoLabelTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.infoLabelTips.Location = new System.Drawing.Point(15, 15);
            this.infoLabelTips.Name = "infoLabelTips";
            this.infoLabelTips.Size = new System.Drawing.Size(1456, 30);
            this.infoLabelTips.TabIndex = 0;
            this.infoLabelTips.Text = "🔥 Funcionalidades escondidas que fazem MUITA diferença! Clique duas vezes para v" +
    "er o passo a passo.";
            // 
            // tabPageExcel
            // 
            this.tabPageExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPageExcel.Controls.Add(this.excelShortcutsListView);
            this.tabPageExcel.Controls.Add(this.categoryFilterExcel);
            this.tabPageExcel.Controls.Add(this.infoPanelExcel);
            this.tabPageExcel.Location = new System.Drawing.Point(4, 33);
            this.tabPageExcel.Name = "tabPageExcel";
            this.tabPageExcel.Size = new System.Drawing.Size(1492, 705);
            this.tabPageExcel.TabIndex = 3;
            this.tabPageExcel.Text = "📊 Atalhos do Excel";
            // 
            // excelShortcutsListView
            // 
            this.excelShortcutsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelShortcutsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStarsExcel,
            this.colAtalhoExcel,
            this.colDescricaoExcel,
            this.colCategoriaExcel,
            this.colTeclasExcel,
            this.colMouseExcel,
            this.colExemploExcel});
            this.excelShortcutsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.excelShortcutsListView.FullRowSelect = true;
            this.excelShortcutsListView.GridLines = true;
            this.excelShortcutsListView.HideSelection = false;
            this.excelShortcutsListView.Location = new System.Drawing.Point(20, 120);
            this.excelShortcutsListView.Name = "excelShortcutsListView";
            this.excelShortcutsListView.Size = new System.Drawing.Size(1452, 572);
            this.excelShortcutsListView.TabIndex = 2;
            this.excelShortcutsListView.UseCompatibleStateImageBehavior = false;
            this.excelShortcutsListView.View = System.Windows.Forms.View.Details;
            // 
            // colStarsExcel
            // 
            this.colStarsExcel.Text = "⭐";
            this.colStarsExcel.Width = 50;
            // 
            // colAtalhoExcel
            // 
            this.colAtalhoExcel.Text = "Atalho";
            this.colAtalhoExcel.Width = 200;
            // 
            // colDescricaoExcel
            // 
            this.colDescricaoExcel.Text = "O que faz";
            this.colDescricaoExcel.Width = 350;
            // 
            // colCategoriaExcel
            // 
            this.colCategoriaExcel.Text = "Categoria";
            this.colCategoriaExcel.Width = 150;
            // 
            // colTeclasExcel
            // 
            this.colTeclasExcel.Text = "Teclas";
            this.colTeclasExcel.Width = 200;
            // 
            // colMouseExcel
            // 
            this.colMouseExcel.Text = "Mouse (se necessário)";
            this.colMouseExcel.Width = 250;
            // 
            // colExemploExcel
            // 
            this.colExemploExcel.Text = "Exemplo Prático";
            this.colExemploExcel.Width = 250;
            // 
            // categoryFilterExcel
            // 
            this.categoryFilterExcel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilterExcel.FormattingEnabled = true;
            this.categoryFilterExcel.Items.AddRange(new object[] {
            "Todas as Categorias",
            "Navegação Básica",
            "Navegação Rápida",
            "Seleção",
            "Edição",
            "Formatação",
            "Fórmulas",
            "Linhas e Colunas",
            "Planilhas",
            "Busca e Filtros",
            "Arquivo",
            "Produtividade",
            "Gráficos",
            "Preenchimento",
            "Revisão"});
            this.categoryFilterExcel.Location = new System.Drawing.Point(22, 89);
            this.categoryFilterExcel.Name = "categoryFilterExcel";
            this.categoryFilterExcel.Size = new System.Drawing.Size(250, 25);
            this.categoryFilterExcel.TabIndex = 1;
            // 
            // infoPanelExcel
            // 
            this.infoPanelExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.infoPanelExcel.Controls.Add(this.infoLabelExcel);
            this.infoPanelExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanelExcel.Location = new System.Drawing.Point(3, 3);
            this.infoPanelExcel.Name = "infoPanelExcel";
            this.infoPanelExcel.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanelExcel.Size = new System.Drawing.Size(1486, 60);
            this.infoPanelExcel.TabIndex = 0;
            // 
            // infoLabelExcel
            // 
            this.infoLabelExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabelExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoLabelExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.infoLabelExcel.Location = new System.Drawing.Point(15, 15);
            this.infoLabelExcel.Name = "infoLabelExcel";
            this.infoLabelExcel.Size = new System.Drawing.Size(1456, 30);
            this.infoLabelExcel.TabIndex = 0;
            this.infoLabelExcel.Text = "📊 Domine o Excel! Clique duas vezes em qualquer atalho para ver explicação completa e exemplo prático!";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1500, 95);
            this.headerPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(30, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(420, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🎓 Central de Descobertas";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.subtitleLabel.Location = new System.Drawing.Point(30, 65);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(622, 20);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Aprenda tudo que seu Windows pode fazer! Atalhos, aplicativos escondidos e dicas " +
    "incríveis.";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.clearSearchButton);
            this.searchPanel.Controls.Add(this.searchBox);
            this.searchPanel.Controls.Add(this.searchIcon);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 95);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1500, 70);
            this.searchPanel.TabIndex = 2;
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.clearSearchButton.FlatAppearance.BorderSize = 0;
            this.clearSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearSearchButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clearSearchButton.ForeColor = System.Drawing.Color.White;
            this.clearSearchButton.Location = new System.Drawing.Point(590, 20);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(100, 35);
            this.clearSearchButton.TabIndex = 2;
            this.clearSearchButton.Text = "✖ Limpar";
            this.clearSearchButton.UseVisualStyleBackColor = false;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.searchBox.Location = new System.Drawing.Point(70, 20);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(500, 29);
            this.searchBox.TabIndex = 1;
            // 
            // searchIcon
            // 
            this.searchIcon.AutoSize = true;
            this.searchIcon.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.searchIcon.Location = new System.Drawing.Point(30, 20);
            this.searchIcon.Name = "searchIcon";
            this.searchIcon.Size = new System.Drawing.Size(47, 32);
            this.searchIcon.TabIndex = 0;
            this.searchIcon.Text = "🔍";
            // 
            // FormDiscovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1500, 907);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "FormDiscovery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Central de Descobertas - Domine seu Windows";
            this.mainTabControl.ResumeLayout(false);
            this.tabPageShortcuts.ResumeLayout(false);
            this.infoPanelShortcuts.ResumeLayout(false);
            this.tabPageApps.ResumeLayout(false);
            this.tabPageApps.PerformLayout();
            this.infoPanelApps.ResumeLayout(false);
            this.tabPageTips.ResumeLayout(false);
            this.infoPanelTips.ResumeLayout(false);
            this.tabPageExcel.ResumeLayout(false);
            this.infoPanelExcel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPageShortcuts;
        private System.Windows.Forms.ListView shortcutsListView;
        private System.Windows.Forms.ColumnHeader colStars;
        private System.Windows.Forms.ColumnHeader colAtalho;
        private System.Windows.Forms.ColumnHeader colDescricao;
        private System.Windows.Forms.ColumnHeader colCategoriaShortcut;
        private System.Windows.Forms.ColumnHeader colTeclas;
        private System.Windows.Forms.ColumnHeader colQuandoUsar;
        private System.Windows.Forms.ComboBox categoryFilterShortcuts;
        private System.Windows.Forms.Panel infoPanelShortcuts;
        private System.Windows.Forms.Label infoLabelShortcuts;
        private System.Windows.Forms.TabPage tabPageApps;
        private System.Windows.Forms.ListView appsListView;
        private System.Windows.Forms.ColumnHeader colIconApp;
        private System.Windows.Forms.ColumnHeader colOQueFaz;
        private System.Windows.Forms.ColumnHeader colCategoriaApp;
        private System.Windows.Forms.ColumnHeader colInstalado;
        private System.Windows.Forms.ColumnHeader colDica;
        private System.Windows.Forms.CheckBox preInstalledCheck;
        private System.Windows.Forms.ComboBox categoryFilterApps;
        private System.Windows.Forms.Panel infoPanelApps;
        private System.Windows.Forms.Label infoLabelApps;
        private System.Windows.Forms.TabPage tabPageTips;
        private System.Windows.Forms.ListView tipsListView;
        private System.Windows.Forms.ColumnHeader colIconTip;
        private System.Windows.Forms.ColumnHeader colDicaTitulo;
        private System.Windows.Forms.ColumnHeader colDicaDescricao;
        private System.Windows.Forms.ColumnHeader colCategoriaTip;
        private System.Windows.Forms.ComboBox categoryFilterTips;
        private System.Windows.Forms.Panel infoPanelTips;
        private System.Windows.Forms.Label infoLabelTips;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button clearSearchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchIcon;
        private System.Windows.Forms.TabPage tabPageExcel;
        private System.Windows.Forms.ListView excelShortcutsListView;
        private System.Windows.Forms.ColumnHeader colStarsExcel;
        private System.Windows.Forms.ColumnHeader colAtalhoExcel;
        private System.Windows.Forms.ColumnHeader colDescricaoExcel;
        private System.Windows.Forms.ColumnHeader colCategoriaExcel;
        private System.Windows.Forms.ColumnHeader colTeclasExcel;
        private System.Windows.Forms.ColumnHeader colMouseExcel;
        private System.Windows.Forms.ColumnHeader colExemploExcel;
        private System.Windows.Forms.ComboBox categoryFilterExcel;
        private System.Windows.Forms.Panel infoPanelExcel;
        private System.Windows.Forms.Label infoLabelExcel;
    }
}