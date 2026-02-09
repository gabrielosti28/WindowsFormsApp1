using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AppInterno
{
    public partial class FormAppsNativos : Form
    {
        private DiscoveryService discoveryService;
        private List<WindowsApp> allApps;

        public FormAppsNativos()
        {
            InitializeComponent(); // Agora usa o Designer gerado
            discoveryService = new DiscoveryService();

            // Configurar eventos
            ConfigureEvents();
            LoadData();
        }

        private void ConfigureEvents()
        {
            // Configurar eventos da busca
            searchBox.TextChanged += SearchBox_TextChanged;
            clearSearchButton.Click += (s, e) =>
            {
                searchBox.Clear();
                LoadData();
            };

            // Configurar eventos dos filtros
            categoryFilter.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;
            preInstalledCheck.CheckedChanged += PreInstalledCheck_CheckedChanged;

            // Configurar evento do ListView
            appsListView.DoubleClick += AppsListView_DoubleClick;
        }

        private void LoadData()
        {
            allApps = discoveryService.GetWindowsApps();
            DisplayApps(allApps);
        }

        private void DisplayApps(List<WindowsApp> apps)
        {
            appsListView.Items.Clear();

            foreach (var app in apps)
            {
                ListViewItem item = new ListViewItem(app.IconEmoji ?? "📱");
                item.SubItems.Add(app.WhatItDoes);
                item.SubItems.Add(app.Category);
                item.SubItems.Add(app.IsPreInstalled ? "✅ Pré-instalado" : "📦 Microsoft Store");
                item.SubItems.Add("Clique 2x para detalhes");
                item.Tag = app;

                if (app.IsPreInstalled)
                    item.BackColor = Color.FromArgb(232, 245, 233);
                else
                    item.BackColor = Color.FromArgb(255, 248, 225);

                appsListView.Items.Add(item);
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

            var filtered = discoveryService.SearchApps(query);
            DisplayApps(filtered);
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = categoryFilter.SelectedItem.ToString();

            if (category == "Todas as Categorias")
                DisplayApps(allApps);
            else
                DisplayApps(allApps.Where(a => a.Category == category).ToList());
        }

        private void PreInstalledCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (preInstalledCheck.Checked)
                DisplayApps(allApps.Where(a => a.IsPreInstalled).ToList());
            else
                DisplayApps(allApps);
        }

        private void AppsListView_DoubleClick(object sender, EventArgs e)
        {
            if (appsListView.SelectedItems.Count > 0)
            {
                WindowsApp app = appsListView.SelectedItems[0].Tag as WindowsApp;
                if (app != null)
                {
                    ShowAppDetails(app);
                }
            }
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

            // Ícone e Nome do App
            Label appNameLabel = new Label
            {
                Text = $"{app.IconEmoji} {app.AppName}",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
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
            detailForm.Controls.Add(openPanel);
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

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(550, 580),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10)
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