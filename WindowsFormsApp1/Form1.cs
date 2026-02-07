using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace AppInterno
{
    public partial class Form1 : Form
    {
        private HardwareService hardwareService;
        private List<HardwareComponent> allComponents;

        public Form1()
        {
            InitializeComponent(); // Agora o Designer cria todos os controles
            hardwareService = new HardwareService();

            // Configurar eventos e lógica
            ConfigureEvents();
            LoadHardwareInfo();
        }

        private void ConfigureEvents()
        {
            // Configurar eventos dos botões
            driversButton.Click += (s, e) =>
            {
                FormDrivers formDrivers = new FormDrivers();
                formDrivers.ShowDialog(this);
            };

            refreshButton.Click += RefreshButton_Click;
            discoveryButton.Click += (s, e) =>
            {
                FormDiscovery formDiscovery = new FormDiscovery();
                formDiscovery.ShowDialog(this);
            };

            hardwareListView.DoubleClick += ListView_DoubleClick;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadHardwareInfo();
        }

        private void LoadHardwareInfo()
        {
            hardwareListView.Items.Clear();

            // Mostrar mensagem de carregamento
            ListViewItem loadingItem = new ListViewItem("Carregando...");
            loadingItem.SubItems.Add("Por favor, aguarde...");
            hardwareListView.Items.Add(loadingItem);

            // Desabilitar botão durante carregamento
            refreshButton.Enabled = false;

            // Usar Task para não travar a interface
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    allComponents = hardwareService.GetAllHardwareInfo();

                    // Atualizar UI na thread principal
                    this.Invoke((MethodInvoker)delegate
                    {
                        hardwareListView.Items.Clear();

                        foreach (var component in allComponents)
                        {
                            ListViewItem item = new ListViewItem(component.Category);
                            item.SubItems.Add(component.Name ?? "N/A");
                            item.SubItems.Add(component.Manufacturer ?? "N/A");
                            item.SubItems.Add(component.Details ?? "N/A");
                            item.SubItems.Add(component.Status ?? "N/A");
                            item.Tag = component;

                            // Colorir por status
                            if (component.Status == "Erro")
                                item.BackColor = Color.FromArgb(255, 230, 230);
                            else if (component.Status == "Resumo")
                                item.BackColor = Color.FromArgb(230, 240, 255);

                            hardwareListView.Items.Add(item);
                        }

                        refreshButton.Enabled = true;
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Erro ao carregar informações: {ex.Message}",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        refreshButton.Enabled = true;
                    });
                }
            });
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if (hardwareListView.SelectedItems.Count > 0)
            {
                HardwareComponent component = hardwareListView.SelectedItems[0].Tag as HardwareComponent;
                if (component != null)
                {
                    ShowComponentDetails(component);
                }
            }
        }

        private void ShowComponentDetails(HardwareComponent component)
        {
            Form detailForm = new Form
            {
                Text = $"Detalhes - {component.Category}",
                Size = new Size(600, 450),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Ícone da categoria
            Label iconLabel = new Label
            {
                Text = GetCategoryIcon(component.Category),
                Font = new Font("Segoe UI", 32),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            detailForm.Controls.Add(iconLabel);

            // Título
            Label titleLabel = new Label
            {
                Text = component.Name,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(480, 30),
                Location = new Point(80, 25)
            };
            detailForm.Controls.Add(titleLabel);

            // Categoria
            Label categoryLabel = new Label
            {
                Text = component.Category,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(80, 55)
            };
            detailForm.Controls.Add(categoryLabel);

            // Linha separadora
            Panel separator = new Panel
            {
                Height = 2,
                Width = 540,
                Location = new Point(20, 90),
                BackColor = Color.FromArgb(200, 200, 200)
            };
            detailForm.Controls.Add(separator);

            // Informações técnicas
            Label detailsLabel = new Label
            {
                Text = "📋 Informações Técnicas:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 105)
            };
            detailForm.Controls.Add(detailsLabel);

            TextBox detailsTextBox = new TextBox
            {
                Text = component.Details,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(20, 130),
                Size = new Size(540, 100),
                Font = new Font("Consolas", 9),
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(detailsTextBox);

            // Explicação amigável
            Label explanationLabel = new Label
            {
                Text = "💡 O que isso significa?",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 245)
            };
            detailForm.Controls.Add(explanationLabel);

            TextBox explanationTextBox = new TextBox
            {
                Text = component.FriendlyExplanation,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(20, 270),
                Size = new Size(540, 90),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.FromArgb(255, 255, 230),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(explanationTextBox);

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(100, 35),
                Location = new Point(460, 375),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => detailForm.Close();
            detailForm.Controls.Add(closeButton);

            detailForm.ShowDialog(this);
        }

        private string GetCategoryIcon(string category)
        {
            switch (category)
            {
                case "Processador (CPU)":
                    return "⚡";
                case "Memória RAM":
                    return "🧠";
                case "Armazenamento (Disco)":
                    return "💾";
                case "Placa de Vídeo (GPU)":
                    return "🎮";
                case "Placa-Mãe":
                    return "🔌";
                case "Adaptador de Rede":
                    return "🌐";
                default:
                    return "🖥️";
            }
        }
    }
}