using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AppInterno
{
    public partial class FormDiscoveryWindows : Form
    {
        private DiscoveryService discoveryService;
        private List<KeyboardShortcut> allShortcuts;

        // Controles da UI
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Panel searchPanel;
        private TextBox searchBox;
        private Button clearSearchButton;
        private ComboBox categoryFilter;
        private ListView shortcutsListView;
        private Panel infoPanel;

        public FormDiscoveryWindows()
        {
            InitializeComponent();
            discoveryService = new DiscoveryService();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form
            this.Text = "Atalhos do Windows - Guia Completo";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 250);

            // Header Panel
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(0, 120, 215) // Azul do Windows
            };

            titleLabel = new Label
            {
                Text = "⌨️ Atalhos do Windows",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 20)
            };

            subtitleLabel = new Label
            {
                Text = "Aprenda a usar o Windows de forma MUITO mais rápida!",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 230, 255),
                AutoSize = true,
                Location = new Point(30, 70)
            };

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);

            // Info Panel
            infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(227, 242, 253),
                Padding = new Padding(15)
            };

            Label infoLabel = new Label
            {
                Text = "💡 DICA: Clique DUAS VEZES em qualquer atalho para ver explicação completa!\n" +
                       "⭐ Estrelas indicam o quanto o atalho é útil (5 estrelas = ESSENCIAL!)",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(0, 100, 180)
            };
            infoPanel.Controls.Add(infoLabel);

            // Search Panel
            searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label searchIcon = new Label
            {
                Text = "🔍",
                Font = new Font("Segoe UI", 16),
                AutoSize = true,
                Location = new Point(20, 22)
            };

            searchBox = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = new Point(60, 25),
                Size = new Size(400, 30)
            };
            searchBox.TextChanged += SearchBox_TextChanged;

            clearSearchButton = new Button
            {
                Text = "✖ Limpar",
                Location = new Point(480, 22),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10)
            };
            clearSearchButton.FlatAppearance.BorderSize = 0;
            clearSearchButton.Click += (s, e) =>
            {
                searchBox.Clear();
                LoadData();
            };

            Label filterLabel = new Label
            {
                Text = "Filtrar por categoria:",
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(620, 28)
            };

            categoryFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(770, 25),
                Size = new Size(250, 30)
            };
            categoryFilter.Items.AddRange(new object[] {
                "Todas as Categorias",
                "Gerais",
                "Sistema Windows",
                "Navegação",
                "Produtividade"
            });
            categoryFilter.SelectedIndex = 0;
            categoryFilter.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;

            searchPanel.Controls.Add(searchIcon);
            searchPanel.Controls.Add(searchBox);
            searchPanel.Controls.Add(clearSearchButton);
            searchPanel.Controls.Add(filterLabel);
            searchPanel.Controls.Add(categoryFilter);

            // ListView
            shortcutsListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10)
            };

            shortcutsListView.Columns.Add("⭐", 50);
            shortcutsListView.Columns.Add("Atalho", 250);
            shortcutsListView.Columns.Add("O que faz", 400);
            shortcutsListView.Columns.Add("Categoria", 180);
            shortcutsListView.Columns.Add("Teclas", 200);
            shortcutsListView.Columns.Add("Quando usar", 300);

            shortcutsListView.DoubleClick += ShortcutsListView_DoubleClick;

            // Add controls to form
            this.Controls.Add(shortcutsListView);
            this.Controls.Add(searchPanel);
            this.Controls.Add(infoPanel);
            this.Controls.Add(headerPanel);

            this.ResumeLayout();
        }

        private void LoadData()
        {
            allShortcuts = discoveryService.GetKeyboardShortcuts();
            DisplayShortcuts(allShortcuts);
        }

        private void DisplayShortcuts(List<KeyboardShortcut> shortcuts)
        {
            shortcutsListView.Items.Clear();

            foreach (var shortcut in shortcuts.OrderByDescending(s => s.PopularityScore))
            {
                string stars = new string('⭐', shortcut.PopularityScore);

                ListViewItem item = new ListViewItem(stars);
                item.SubItems.Add(shortcut.Title);
                item.SubItems.Add(shortcut.Description);
                item.SubItems.Add(shortcut.Category);
                item.SubItems.Add(shortcut.Keys);
                item.SubItems.Add(shortcut.WhenToUse.Length > 50 ?
                    shortcut.WhenToUse.Substring(0, 47) + "..." : shortcut.WhenToUse);
                item.Tag = shortcut;

                // Colorir por popularidade
                if (shortcut.PopularityScore == 5)
                    item.BackColor = Color.FromArgb(255, 249, 196);
                else if (shortcut.PopularityScore >= 4)
                    item.BackColor = Color.FromArgb(255, 253, 231);

                shortcutsListView.Items.Add(item);
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

            var filtered = discoveryService.SearchShortcuts(query);
            DisplayShortcuts(filtered);
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = categoryFilter.SelectedItem.ToString();

            if (category == "Todas as Categorias")
                DisplayShortcuts(allShortcuts);
            else
                DisplayShortcuts(allShortcuts.Where(s => s.Category == category).ToList());
        }

        private void ShortcutsListView_DoubleClick(object sender, EventArgs e)
        {
            if (shortcutsListView.SelectedItems.Count > 0)
            {
                KeyboardShortcut shortcut = shortcutsListView.SelectedItems[0].Tag as KeyboardShortcut;
                if (shortcut != null)
                {
                    ShowShortcutDetails(shortcut);
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
                BackColor = Color.FromArgb(0, 120, 215),
                BorderStyle = BorderStyle.FixedSingle
            };

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
            detailForm.Controls.Add(keysPanel);
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
                Size = new Size(590, height),
                Font = new Font("Segoe UI", 10),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle
            };
            form.Controls.Add(textBox);
            yPos += height + 20;
        }
    }
}