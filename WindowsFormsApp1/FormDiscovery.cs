using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AppInterno
{
    public partial class FormDiscovery : Form
    {
        private DiscoveryService discoveryService;
        private TabControl mainTabControl;
        private TextBox searchBox;
        private List<KeyboardShortcut> allShortcuts;
        private List<WindowsApp> allApps;
        private List<WindowsTip> allTips;

        public FormDiscovery()
        {
            InitializeComponent();
            discoveryService = new DiscoveryService();
            SetupInterface();
            LoadData();
        }

        private void SetupInterface()
        {
            this.Text = "Central de Descobertas - Domine seu Windows";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // ====== CABEÇALHO ======
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(25, 118, 210)
            };
            this.Controls.Add(headerPanel);

            Label titleLabel = new Label
            {
                Text = "🎓 Central de Descobertas",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 20)
            };
            headerPanel.Controls.Add(titleLabel);

            Label subtitleLabel = new Label
            {
                Text = "Aprenda tudo que seu Windows pode fazer! Atalhos, aplicativos escondidos e dicas incríveis.",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 230, 255),
                AutoSize = true,
                Location = new Point(30, 65)
            };
            headerPanel.Controls.Add(subtitleLabel);

            // ====== BARRA DE BUSCA ======
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White
            };
            this.Controls.Add(searchPanel);

            Label searchIcon = new Label
            {
                Text = "🔍",
                Font = new Font("Segoe UI", 18),
                AutoSize = true,
                Location = new Point(30, 20)
            };
            searchPanel.Controls.Add(searchIcon);

            searchBox = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                Size = new Size(500, 35),
                Location = new Point(70, 20),
                PlaceholderText = "Buscar atalhos, aplicativos ou dicas... (Ex: captura de tela, copiar, etc)"
            };
            searchBox.TextChanged += SearchBox_TextChanged;
            searchPanel.Controls.Add(searchBox);

            Button clearSearchButton = new Button
            {
                Text = "✖ Limpar",
                Font = new Font("Segoe UI", 10),
                Size = new Size(100, 35),
                Location = new Point(590, 20),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            clearSearchButton.FlatAppearance.BorderSize = 0;
            clearSearchButton.Click += (s, e) =>
            {
                searchBox.Clear();
                LoadData();
            };
            searchPanel.Controls.Add(clearSearchButton);

            // ====== ABAS PRINCIPAIS ======
            mainTabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Point(20, 5)
            };
            this.Controls.Add(mainTabControl);

            // Criar as abas
            mainTabControl.TabPages.Add(CreateShortcutsTab());
            mainTabControl.TabPages.Add(CreateAppsTab());
            mainTabControl.TabPages.Add(CreateTipsTab());
        }

        private TabPage CreateShortcutsTab()
        {
            TabPage tab = new TabPage("⌨️ Atalhos de Teclado");
            tab.BackColor = Color.FromArgb(250, 250, 250);

            Panel infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(232, 245, 233),
                Padding = new Padding(15)
            };
            tab.Controls.Add(infoPanel);

            Label infoLabel = new Label
            {
                Text = "💡 Dica: Clique duas vezes em qualquer atalho para ver detalhes completos e saber quando usar!",
                Font = new Font("Segoe UI", 10),
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(46, 125, 50)
            };
            infoPanel.Controls.Add(infoLabel);

            // ComboBox de filtro de categoria
            ComboBox categoryFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Size = new Size(250, 30),
                Location = new Point(20, 75),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            categoryFilter.Items.AddRange(new object[] {
                "Todas as Categorias",
                "Gerais",
                "Sistema Windows",
                "Navegação",
                "Produtividade"
            });
            categoryFilter.SelectedIndex = 0;
            categoryFilter.SelectedIndexChanged += (s, e) => FilterShortcutsByCategory(categoryFilter.SelectedItem.ToString());
            tab.Controls.Add(categoryFilter);

            // ListView para atalhos
            ListView shortcutsListView = new ListView
            {
                Name = "shortcutsListView",
                Location = new Point(20, 115),
                Size = new Size(1230, 620),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            shortcutsListView.Columns.Add("⭐", 50);
            shortcutsListView.Columns.Add("Atalho", 200);
            shortcutsListView.Columns.Add("O que faz", 450);
            shortcutsListView.Columns.Add("Categoria", 150);
            shortcutsListView.Columns.Add("Teclas", 180);
            shortcutsListView.Columns.Add("Quando usar", 200);

            shortcutsListView.DoubleClick += ShortcutsListView_DoubleClick;
            tab.Controls.Add(shortcutsListView);

            return tab;
        }

        private TabPage CreateAppsTab()
        {
            TabPage tab = new TabPage("📱 Aplicativos Nativos");
            tab.BackColor = Color.FromArgb(250, 250, 250);

            Panel infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(227, 242, 253),
                Padding = new Padding(15)
            };
            tab.Controls.Add(infoPanel);

            Label infoLabel = new Label
            {
                Text = "🎯 IMPORTANTE: Os aplicativos são mostrados primeiro pelo QUE FAZEM, não pelo nome!\n" +
                       "Leia a descrição, e se interessar, clique duas vezes para descobrir qual aplicativo é e como abrir.",
                Font = new Font("Segoe UI", 10),
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(1, 87, 155)
            };
            infoPanel.Controls.Add(infoLabel);

            // ComboBox de filtro de categoria
            ComboBox categoryFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Size = new Size(250, 30),
                Location = new Point(20, 95),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            categoryFilter.Items.AddRange(new object[] {
                "Todas as Categorias",
                "Produtividade",
                "Criatividade",
                "Utilitários",
                "Sistema",
                "Acessibilidade",
                "Informação",
                "Educação"
            });
            categoryFilter.SelectedIndex = 0;
            categoryFilter.SelectedIndexChanged += (s, e) => FilterAppsByCategory(categoryFilter.SelectedItem.ToString());
            tab.Controls.Add(categoryFilter);

            // Checkbox para mostrar apenas pré-instalados
            CheckBox preInstalledCheck = new CheckBox
            {
                Text = "Apenas apps já instalados",
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(290, 98),
                Checked = false
            };
            preInstalledCheck.CheckedChanged += (s, e) => FilterAppsByPreInstalled(preInstalledCheck.Checked);
            tab.Controls.Add(preInstalledCheck);

            // ListView para apps
            ListView appsListView = new ListView
            {
                Name = "appsListView",
                Location = new Point(20, 135),
                Size = new Size(1230, 600),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            appsListView.Columns.Add("", 50);
            appsListView.Columns.Add("O QUE FAZ (clique 2x para ver o nome)", 650);
            appsListView.Columns.Add("Categoria", 180);
            appsListView.Columns.Add("Já instalado?", 120);
            appsListView.Columns.Add("Dica", 230);

            appsListView.DoubleClick += AppsListView_DoubleClick;
            tab.Controls.Add(appsListView);

            return tab;
        }

        private TabPage CreateTipsTab()
        {
            TabPage tab = new TabPage("💡 Dicas e Truques");
            tab.BackColor = Color.FromArgb(250, 250, 250);

            Panel infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(255, 243, 224),
                Padding = new Padding(15)
            };
            tab.Controls.Add(infoPanel);

            Label infoLabel = new Label
            {
                Text = "🔥 Funcionalidades escondidas que fazem MUITA diferença! Clique duas vezes para ver o passo a passo.",
                Font = new Font("Segoe UI", 10),
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(191, 97, 0)
            };
            infoPanel.Controls.Add(infoLabel);

            // ComboBox de filtro de categoria
            ComboBox categoryFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Size = new Size(250, 30),
                Location = new Point(20, 75),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            categoryFilter.Items.AddRange(new object[] {
                "Todas as Categorias",
                "Desempenho",
                "Produtividade",
                "Segurança",
                "Personalização",
                "Bem-Estar",
                "Energia",
                "Manutenção",
                "Suporte"
            });
            categoryFilter.SelectedIndex = 0;
            categoryFilter.SelectedIndexChanged += (s, e) => FilterTipsByCategory(categoryFilter.SelectedItem.ToString());
            tab.Controls.Add(categoryFilter);

            // ListView para dicas
            ListView tipsListView = new ListView
            {
                Name = "tipsListView",
                Location = new Point(20, 115),
                Size = new Size(1230, 620),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            tipsListView.Columns.Add("", 50);
            tipsListView.Columns.Add("Dica", 400);
            tipsListView.Columns.Add("O que faz", 550);
            tipsListView.Columns.Add("Categoria", 180);

            tipsListView.DoubleClick += TipsListView_DoubleClick;
            tab.Controls.Add(tipsListView);

            return tab;
        }

        private void LoadData()
        {
            allShortcuts = discoveryService.GetKeyboardShortcuts();
            allApps = discoveryService.GetWindowsApps();
            allTips = discoveryService.GetWindowsTips();

            DisplayShortcuts(allShortcuts);
            DisplayApps(allApps);
            DisplayTips(allTips);
        }

        private void DisplayShortcuts(List<KeyboardShortcut> shortcuts)
        {
            ListView listView = mainTabControl.TabPages[0].Controls.Find("shortcutsListView", false)[0] as ListView;
            listView.Items.Clear();

            foreach (var shortcut in shortcuts.OrderByDescending(s => s.PopularityScore))
            {
                string stars = new string('⭐', shortcut.PopularityScore);

                ListViewItem item = new ListViewItem(stars);
                item.SubItems.Add(shortcut.Title);
                item.SubItems.Add(shortcut.Description);
                item.SubItems.Add(shortcut.Category);
                item.SubItems.Add(shortcut.Keys);
                item.SubItems.Add(shortcut.WhenToUse.Length > 40 ?
                    shortcut.WhenToUse.Substring(0, 37) + "..." : shortcut.WhenToUse);
                item.Tag = shortcut;

                // Colorir por popularidade
                if (shortcut.PopularityScore == 5)
                    item.BackColor = Color.FromArgb(255, 249, 196);
                else if (shortcut.PopularityScore >= 4)
                    item.BackColor = Color.FromArgb(255, 253, 231);

                listView.Items.Add(item);
            }
        }

        private void DisplayApps(List<WindowsApp> apps)
        {
            ListView listView = mainTabControl.TabPages[1].Controls.Find("appsListView", false)[0] as ListView;
            listView.Items.Clear();

            foreach (var app in apps)
            {
                ListViewItem item = new ListViewItem(app.IconEmoji);
                item.SubItems.Add(app.WhatItDoes);
                item.SubItems.Add(app.Category);
                item.SubItems.Add(app.IsPreInstalled ? "✅ Sim" : "📦 Precisa instalar");
                item.SubItems.Add("Clique 2x para detalhes");
                item.Tag = app;

                if (app.IsPreInstalled)
                    item.BackColor = Color.FromArgb(232, 245, 233);

                listView.Items.Add(item);
            }
        }

        private void DisplayTips(List<WindowsTip> tips)
        {
            ListView listView = mainTabControl.TabPages[2].Controls.Find("tipsListView", false)[0] as ListView;
            listView.Items.Clear();

            foreach (var tip in tips)
            {
                ListViewItem item = new ListViewItem(tip.IconEmoji);
                item.SubItems.Add(tip.Title);
                item.SubItems.Add(tip.ShortDescription);
                item.SubItems.Add(tip.Category);
                item.Tag = tip;

                listView.Items.Add(item);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = searchBox.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                LoadData();
                return;
            }

            var filteredShortcuts = discoveryService.SearchShortcuts(query);
            var filteredApps = discoveryService.SearchApps(query);
            var filteredTips = discoveryService.SearchTips(query);

            DisplayShortcuts(filteredShortcuts);
            DisplayApps(filteredApps);
            DisplayTips(filteredTips);
        }

        private void FilterShortcutsByCategory(string category)
        {
            if (category == "Todas as Categorias")
                DisplayShortcuts(allShortcuts);
            else
                DisplayShortcuts(allShortcuts.Where(s => s.Category == category).ToList());
        }

        private void FilterAppsByCategory(string category)
        {
            if (category == "Todas as Categorias")
                DisplayApps(allApps);
            else
                DisplayApps(allApps.Where(a => a.Category == category).ToList());
        }

        private void FilterAppsByPreInstalled(bool preInstalledOnly)
        {
            if (preInstalledOnly)
                DisplayApps(allApps.Where(a => a.IsPreInstalled).ToList());
            else
                DisplayApps(allApps);
        }

        private void FilterTipsByCategory(string category)
        {
            if (category == "Todas as Categorias")
                DisplayTips(allTips);
            else
                DisplayTips(allTips.Where(t => t.Category == category).ToList());
        }

        private void ShortcutsListView_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                KeyboardShortcut shortcut = listView.SelectedItems[0].Tag as KeyboardShortcut;
                if (shortcut != null)
                {
                    ShowShortcutDetails(shortcut);
                }
            }
        }

        private void AppsListView_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                WindowsApp app = listView.SelectedItems[0].Tag as WindowsApp;
                if (app != null)
                {
                    ShowAppDetails(app);
                }
            }
        }

        private void TipsListView_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                WindowsTip tip = listView.SelectedItems[0].Tag as WindowsTip;
                if (tip != null)
                {
                    ShowTipDetails(tip);
                }
            }
        }

        private void ShowShortcutDetails(KeyboardShortcut shortcut)
        {
            Form detailForm = new Form
            {
                Text = $"Atalho: {shortcut.Title}",
                Size = new Size(650, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 30;

            // Título e estrelas
            string stars = new string('⭐', shortcut.PopularityScore);
            Label titleLabel = new Label
            {
                Text = $"{shortcut.Title} {stars}",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(titleLabel);
            yPos += 50;

            // Teclas em destaque
            Panel keysPanel = new Panel
            {
                Size = new Size(590, 70),
                Location = new Point(30, yPos),
                BackColor = Color.FromArgb(25, 118, 210),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(keysPanel);

            Label keysLabel = new Label
            {
                Text = shortcut.Keys,
                Font = new Font("Consolas", 28, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(590, 70)
            };
            keysPanel.Controls.Add(keysLabel);
            yPos += 90;

            // Descrição
            AddSectionTitle(detailForm, "O que faz:", ref yPos);
            AddTextBox(detailForm, shortcut.Description, ref yPos, 60, Color.FromArgb(232, 245, 233));

            // Explicação detalhada
            AddSectionTitle(detailForm, "Explicação detalhada:", ref yPos);
            AddTextBox(detailForm, shortcut.DetailedExplanation, ref yPos, 80, Color.FromArgb(227, 242, 253));

            // Quando usar
            AddSectionTitle(detailForm, "💡 Quando usar:", ref yPos);
            AddTextBox(detailForm, shortcut.WhenToUse, ref yPos, 70, Color.FromArgb(255, 243, 224));

            // Categoria
            Label categoryLabel = new Label
            {
                Text = $"Categoria: {shortcut.Category}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(categoryLabel);

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(500, 470),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => detailForm.Close();
            detailForm.Controls.Add(closeButton);

            detailForm.ShowDialog(this);
        }

        private void ShowAppDetails(WindowsApp app)
        {
            Form detailForm = new Form
            {
                Text = $"Aplicativo: {app.AppName}",
                Size = new Size(700, 650),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 30;

            // Ícone e Nome do App (REVELAÇÃO!)
            Label appNameLabel = new Label
            {
                Text = $"{app.IconEmoji} {app.AppName}",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 118, 210),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(appNameLabel);
            yPos += 50;

            // Status de instalação
            Label statusLabel = new Label
            {
                Text = app.IsPreInstalled ? "✅ Já vem instalado no Windows!" : "📦 Disponível na Microsoft Store",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = app.IsPreInstalled ? Color.Green : Color.Orange,
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(statusLabel);
            yPos += 40;

            // O que faz
            AddSectionTitle(detailForm, "O que este aplicativo faz:", ref yPos);
            AddTextBox(detailForm, app.WhatItDoes, ref yPos, 60, Color.FromArgb(232, 245, 233));

            // Como abrir
            AddSectionTitle(detailForm, "🔑 Como abrir:", ref yPos);
            Panel openPanel = new Panel
            {
                Size = new Size(640, 50),
                Location = new Point(30, yPos),
                BackColor = Color.FromArgb(255, 249, 196),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(openPanel);

            Label openLabel = new Label
            {
                Text = app.HowToOpen,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(620, 50),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };
            openPanel.Controls.Add(openLabel);
            yPos += 70;

            // Descrição detalhada
            AddSectionTitle(detailForm, "Descrição completa:", ref yPos);
            AddTextBox(detailForm, app.DetailedDescription, ref yPos, 80, Color.FromArgb(245, 245, 245));

            // Recursos principais
            if (app.KeyFeatures != null && app.KeyFeatures.Count > 0)
            {
                AddSectionTitle(detailForm, "⭐ Principais recursos:", ref yPos);

                TextBox featuresBox = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(30, yPos),
                    Size = new Size(640, 120),
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(227, 242, 253),
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = string.Join("\r\n\r\n", app.KeyFeatures.Select((f, i) => $"{i + 1}. {f}"))
                };
                detailForm.Controls.Add(featuresBox);
                yPos += 130;
            }

            // Categoria
            Label categoryLabel = new Label
            {
                Text = $"Categoria: {app.Category}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(categoryLabel);

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(550, 570),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => detailForm.Close();
            detailForm.Controls.Add(closeButton);

            detailForm.ShowDialog(this);
        }

        private void ShowTipDetails(WindowsTip tip)
        {
            Form detailForm = new Form
            {
                Text = $"Dica: {tip.Title}",
                Size = new Size(700, 650),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 30;

            // Título
            Label titleLabel = new Label
            {
                Text = $"{tip.IconEmoji} {tip.Title}",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(titleLabel);
            yPos += 50;

            // Descrição curta
            AddSectionTitle(detailForm, "O que faz:", ref yPos);
            AddTextBox(detailForm, tip.ShortDescription, ref yPos, 60, Color.FromArgb(232, 245, 233));

            // Passo a passo
            AddSectionTitle(detailForm, "📋 Como fazer (Passo a Passo):", ref yPos);

            Panel stepsPanel = new Panel
            {
                Size = new Size(640, 200),
                Location = new Point(30, yPos),
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            detailForm.Controls.Add(stepsPanel);

            int stepY = 10;
            for (int i = 0; i < tip.Steps.Count; i++)
            {
                Label stepLabel = new Label
                {
                    Text = $"{i + 1}. {tip.Steps[i]}",
                    Font = new Font("Segoe UI", 10),
                    AutoSize = false,
                    Size = new Size(600, 0),
                    Location = new Point(10, stepY),
                    MaximumSize = new Size(600, 0),
                    AutoSize = true
                };
                stepsPanel.Controls.Add(stepLabel);
                stepY += stepLabel.Height + 10;
            }
            yPos += 220;

            // Por que é útil
            AddSectionTitle(detailForm, "💡 Por que isso é útil:", ref yPos);
            AddTextBox(detailForm, tip.WhyUseful, ref yPos, 120, Color.FromArgb(255, 243, 224));

            // Categoria
            Label categoryLabel = new Label
            {
                Text = $"Categoria: {tip.Category}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(categoryLabel);

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(550, 570),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => detailForm.Close();
            detailForm.Controls.Add(closeButton);

            detailForm.ShowDialog(this);
        }

        private void AddSectionTitle(Form form, string title, ref int yPos)
        {
            Label label = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            form.Controls.Add(label);
            yPos += 30;
        }

        private void AddTextBox(Form form, string text, ref int yPos, int height, Color backColor)
        {
            TextBox textBox = new TextBox
            {
                Text = text,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(30, yPos),
                Size = new Size(640, height),
                Font = new Font("Segoe UI", 10),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle
            };
            form.Controls.Add(textBox);
            yPos += height + 20;
        }
    }
}