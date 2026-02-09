using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AppInterno
{
    public partial class FormDicasTruques : Form
    {
        private DiscoveryService discoveryService;
        private List<WindowsTip> allTips;

        public FormDicasTruques()
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

            // Configurar evento do ListView
            tipsListView.DoubleClick += TipsListView_DoubleClick;
        }

        private void LoadData()
        {
            allTips = discoveryService.GetWindowsTips();
            DisplayTips(allTips);
        }

        private void DisplayTips(List<WindowsTip> tips)
        {
            tipsListView.Items.Clear();

            foreach (var tip in tips)
            {
                ListViewItem item = new ListViewItem(tip.IconEmoji ?? "💡");
                item.SubItems.Add(tip.Title);
                item.SubItems.Add(tip.ShortDescription);
                item.SubItems.Add(tip.Category);
                item.Tag = tip;

                // Cores alternadas por categoria
                switch (tip.Category)
                {
                    case "Produtividade":
                        item.BackColor = Color.FromArgb(227, 242, 253);
                        break;
                    case "Personalização":
                        item.BackColor = Color.FromArgb(255, 243, 224);
                        break;
                    case "Segurança":
                        item.BackColor = Color.FromArgb(255, 235, 238);
                        break;
                    default:
                        item.BackColor = Color.FromArgb(245, 245, 245);
                        break;
                }

                tipsListView.Items.Add(item);
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

            var filtered = discoveryService.SearchTips(query);
            DisplayTips(filtered);
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = categoryFilter.SelectedItem.ToString();

            if (category == "Todas as Categorias")
                DisplayTips(allTips);
            else
                DisplayTips(allTips.Where(t => t.Category == category).ToList());
        }

        private void TipsListView_DoubleClick(object sender, EventArgs e)
        {
            if (tipsListView.SelectedItems.Count > 0)
            {
                WindowsTip tip = tipsListView.SelectedItems[0].Tag as WindowsTip;
                if (tip != null)
                {
                    ShowTipDetails(tip);
                }
            }
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
                ForeColor = Color.FromArgb(156, 39, 176),
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
                    AutoSize = true,
                    MaximumSize = new Size(600, 0),
                    Location = new Point(10, stepY)
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