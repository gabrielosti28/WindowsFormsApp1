using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AppInterno
{
    public partial class FormHardware : Form
    {
        private HardwareService hardwareService;
        private List<HardwareComponent> allComponents;

        public FormHardware()
        {
            InitializeComponent();
            hardwareService = new HardwareService();
            ConfigureListView();
            LoadHardwareInfo();
        }

        private void ConfigureListView()
        {
            // Adicionar coluna extra para explicação resumida
            listViewHardware.Columns.Clear();
            listViewHardware.Columns.Add("Categoria", 220);
            listViewHardware.Columns.Add("Nome / Modelo", 380);
            listViewHardware.Columns.Add("Fabricante", 160);
            listViewHardware.Columns.Add("Status", 110);
            listViewHardware.Columns.Add("Dica Rápida", 350);

            listViewHardware.FullRowSelect = true;
            listViewHardware.GridLines = true;
            listViewHardware.View = View.Details;
        }

        private void LoadHardwareInfo()
        {
            listViewHardware.Items.Clear();
            lblStatus.Text = "🔍 Analisando hardware... Aguarde alguns segundos.";
            lblStatus.ForeColor = Color.Orange;

            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    allComponents = hardwareService.GetAllHardwareInfo();

                    this.Invoke((MethodInvoker)delegate
                    {
                        DisplayComponents(allComponents);
                        lblStatus.Text = $"✅ {allComponents.Count} componentes encontrados. Clique duas vezes para ver detalhes completos.";
                        lblStatus.ForeColor = Color.Green;
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblStatus.Text = $"❌ Erro: {ex.Message}";
                        lblStatus.ForeColor = Color.Red;
                    });
                }
            });
        }

        private void DisplayComponents(List<HardwareComponent> components)
        {
            listViewHardware.Items.Clear();

            foreach (var component in components)
            {
                ListViewItem item = new ListViewItem(component.Category);
                item.SubItems.Add(component.Name ?? "N/A");
                item.SubItems.Add(component.Manufacturer ?? "N/A");
                item.SubItems.Add(component.Status ?? "N/A");

                // Extrair primeira linha da explicação como dica rápida
                string quickTip = "";
                if (!string.IsNullOrEmpty(component.FriendlyExplanation))
                {
                    // Pega a primeira frase significativa
                    string[] lines = component.FriendlyExplanation.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    quickTip = lines.Length > 0 ? lines[0].Trim() : "";
                    if (quickTip.Length > 80) quickTip = quickTip.Substring(0, 77) + "...";
                }
                item.SubItems.Add(quickTip);
                item.Tag = component;

                // Cores por tipo de status e categoria
                ApplyItemColor(item, component);

                listViewHardware.Items.Add(item);
            }
        }

        private void ApplyItemColor(ListViewItem item, HardwareComponent component)
        {
            string status = component.Status ?? "";
            string category = component.Category ?? "";

            switch (status)
            {
                case "Resumo":
                    item.BackColor = Color.FromArgb(220, 235, 255); // azul claro
                    item.Font = new Font(listViewHardware.Font, FontStyle.Bold);
                    break;
                case "Conectado":
                    item.BackColor = Color.FromArgb(230, 255, 230); // verde claro
                    break;
                case "Atenção":
                    item.BackColor = Color.FromArgb(255, 245, 180); // amarelo
                    break;
                case "Erro":
                    item.BackColor = Color.FromArgb(255, 220, 220); // vermelho claro
                    break;
                case "Desconectado":
                    item.BackColor = Color.FromArgb(245, 245, 245);
                    item.ForeColor = Color.Gray;
                    break;
                default:
                    // Colorir por categoria para facilitar leitura
                    if (category.Contains("Processador"))
                        item.BackColor = Color.FromArgb(255, 245, 225);
                    else if (category.Contains("Memória"))
                        item.BackColor = Color.FromArgb(225, 245, 255);
                    else if (category.Contains("Armazenamento") || category.Contains("Partição"))
                        item.BackColor = Color.FromArgb(245, 255, 225);
                    else if (category.Contains("Vídeo") || category.Contains("GPU"))
                        item.BackColor = Color.FromArgb(255, 225, 245);
                    else if (category.Contains("Placa-Mãe"))
                        item.BackColor = Color.FromArgb(240, 230, 255);
                    else if (category.Contains("Rede"))
                        item.BackColor = Color.FromArgb(225, 255, 245);
                    else if (category.Contains("Áudio"))
                        item.BackColor = Color.FromArgb(255, 240, 225);
                    else if (category.Contains("Bateria"))
                        item.BackColor = Color.FromArgb(230, 255, 230);
                    else
                        item.BackColor = Color.White;
                    break;
            }
        }

        private void listViewHardware_DoubleClick(object sender, EventArgs e)
        {
            if (listViewHardware.SelectedItems.Count > 0)
            {
                HardwareComponent component = listViewHardware.SelectedItems[0].Tag as HardwareComponent;
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
                Text = $"Detalhes — {component.Category}",
                Size = new Size(750, 620),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 20;

            // ── Categoria / Título ─────────────────────────────────────────
            Label categoryLabel = new Label
            {
                Text = component.Category,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 118, 210),
                AutoSize = true,
                Location = new Point(20, yPos)
            };
            detailForm.Controls.Add(categoryLabel);
            yPos += 45;

            // ── Nome do componente ─────────────────────────────────────────
            if (!string.IsNullOrEmpty(component.Name))
            {
                Label nameLabel = new Label
                {
                    Text = component.Name,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(60, 60, 60),
                    AutoSize = false,
                    Size = new Size(700, 40),
                    Location = new Point(20, yPos),
                    MaximumSize = new Size(700, 0)
                };
                detailForm.Controls.Add(nameLabel);
                yPos += 45;
            }

            // ── Linha separadora ───────────────────────────────────────────
            Panel separator1 = new Panel { Height = 2, Width = 710, Location = new Point(20, yPos), BackColor = Color.FromArgb(200, 200, 200) };
            detailForm.Controls.Add(separator1);
            yPos += 10;

            // ── Detalhes técnicos ──────────────────────────────────────────
            if (!string.IsNullOrEmpty(component.Details))
            {
                Label detailsTitle = new Label
                {
                    Text = "📋 Informações Técnicas:",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, yPos)
                };
                detailForm.Controls.Add(detailsTitle);
                yPos += 28;

                // Calcular altura necessária
                int detailLines = component.Details.Split('\n').Length;
                int detailHeight = Math.Max(70, Math.Min(detailLines * 18 + 16, 160));

                TextBox detailsBox = new TextBox
                {
                    Text = component.Details,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(20, yPos),
                    Size = new Size(700, detailHeight),
                    Font = new Font("Consolas", 9),
                    BackColor = Color.FromArgb(245, 247, 250),
                    BorderStyle = BorderStyle.FixedSingle
                };
                detailForm.Controls.Add(detailsBox);
                yPos += detailHeight + 15;
            }

            // ── Linha separadora ───────────────────────────────────────────
            Panel separator2 = new Panel { Height = 2, Width = 710, Location = new Point(20, yPos), BackColor = Color.FromArgb(200, 200, 200) };
            detailForm.Controls.Add(separator2);
            yPos += 10;

            // ── Explicação amigável ────────────────────────────────────────
            if (!string.IsNullOrEmpty(component.FriendlyExplanation))
            {
                Label explanationTitle = new Label
                {
                    Text = "💡 Explicação em linguagem simples:",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, yPos)
                };
                detailForm.Controls.Add(explanationTitle);
                yPos += 28;

                int expLines = component.FriendlyExplanation.Split('\n').Length;
                int expHeight = Math.Max(120, Math.Min(expLines * 18 + 16, 280));

                TextBox explanationBox = new TextBox
                {
                    Text = component.FriendlyExplanation,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(20, yPos),
                    Size = new Size(700, expHeight),
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(255, 252, 230),
                    BorderStyle = BorderStyle.FixedSingle
                };
                detailForm.Controls.Add(explanationBox);
                yPos += expHeight + 15;
            }

            // ── Botão fechar ───────────────────────────────────────────────
            int formNeededHeight = yPos + 80;
            if (formNeededHeight > 580) formNeededHeight = 580;
            detailForm.ClientSize = new Size(750, formNeededHeight);

            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(130, 42),
                Location = new Point(600, formNeededHeight - 58),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, ev) => detailForm.Close();
            detailForm.Controls.Add(closeButton);

            detailForm.ShowDialog(this);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            LoadHardwareInfo();
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allComponents == null) return;

            string filter = comboFiltro.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(filter) || filter == "Todos os Componentes")
            {
                DisplayComponents(allComponents);
                return;
            }

            List<HardwareComponent> filtered;

            switch (filter)
            {
                case "Processador":
                    filtered = allComponents.Where(c => c.Category.Contains("Processador")).ToList();
                    break;
                case "Memória":
                    filtered = allComponents.Where(c => c.Category.Contains("Memória")).ToList();
                    break;
                case "Disco":
                    filtered = allComponents.Where(c => c.Category.Contains("Armazenamento") || c.Category.Contains("Partição")).ToList();
                    break;
                case "Placa de Vídeo":
                    filtered = allComponents.Where(c => c.Category.Contains("Vídeo") || c.Category.Contains("GPU")).ToList();
                    break;
                case "Rede":
                    filtered = allComponents.Where(c => c.Category.Contains("Rede")).ToList();
                    break;
                case "Áudio":
                    filtered = allComponents.Where(c => c.Category.Contains("Áudio")).ToList();
                    break;
                case "Sistema":
                    filtered = allComponents.Where(c => c.Category.Contains("Sistema") || c.Category.Contains("BIOS") || c.Category.Contains("Placa-Mãe")).ToList();
                    break;
                default:
                    filtered = allComponents.Where(c => c.Category.Contains(filter)).ToList();
                    break;
            }

            DisplayComponents(filtered);

            if (filtered.Count == 0)
            {
                lblStatus.Text = "Nenhum componente encontrado para este filtro.";
                lblStatus.ForeColor = Color.Gray;
            }
            else
            {
                lblStatus.Text = $"{filtered.Count} componentes exibidos. Clique duas vezes para ver detalhes.";
                lblStatus.ForeColor = Color.DarkBlue;
            }
        }
    }
}