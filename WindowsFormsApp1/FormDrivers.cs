using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace AppInterno
{
    public partial class FormDrivers : Form
    {
        private DriverService driverService;
        private List<DriverInfo> allDrivers;
        private DriverAnalysisResult analysisResult;

        public FormDrivers()
        {
            InitializeComponent(); // Agora o Designer cria todos os controles
            driverService = new DriverService();

            // Configurar eventos e lógica
            ConfigureEvents();
            LoadDrivers();
        }

        private void ConfigureEvents()
        {
            // Configurar eventos dos botões
            refreshButton.Click += (s, e) => LoadDrivers();
            helpButton.Click += HelpButton_Click;

            // Configurar eventos dos filtros
            filterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged;

            // Configurar evento do ListView
            driversListView.DoubleClick += DriversListView_DoubleClick;
        }

        private void LoadDrivers()
        {
            driversListView.Items.Clear();
            summaryPanel.Controls.Clear();

            // Mostrar loading
            ListViewItem loadingItem = new ListViewItem("Analisando...");
            loadingItem.SubItems.Add("Por favor aguarde, isso pode levar alguns segundos...");
            driversListView.Items.Add(loadingItem);

            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    allDrivers = driverService.GetAllDrivers();
                    analysisResult = driverService.AnalyzeAllDrivers(allDrivers);

                    this.Invoke((MethodInvoker)delegate
                    {
                        DisplaySummary();
                        DisplayDrivers(allDrivers);
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Erro ao analisar drivers: {ex.Message}",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
        }

        private void DisplaySummary()
        {
            summaryPanel.Controls.Clear();

            // Card de saúde geral
            Panel healthCard = CreateSummaryCard(
                analysisResult.OverallHealth,
                analysisResult.HealthDescription,
                analysisResult.HealthColor,
                0
            );
            summaryPanel.Controls.Add(healthCard);

            // Card de total
            Panel totalCard = CreateSummaryCard(
                analysisResult.TotalDrivers.ToString(),
                "Total de Drivers",
                Color.FromArgb(108, 117, 125),
                280
            );
            summaryPanel.Controls.Add(totalCard);

            // Card OK
            Panel okCard = CreateSummaryCard(
                analysisResult.DriversOK.ToString(),
                "✅ Funcionando",
                Color.FromArgb(40, 167, 69),
                480
            );
            summaryPanel.Controls.Add(okCard);

            // Card Desatualizados
            Panel outdatedCard = CreateSummaryCard(
                analysisResult.DriversOutdated.ToString(),
                "⚠️ Desatualizados",
                Color.FromArgb(255, 193, 7),
                680
            );
            summaryPanel.Controls.Add(outdatedCard);

            // Card Problemas
            Panel problemCard = CreateSummaryCard(
                analysisResult.DriversWithProblems.ToString(),
                "❌ Problemas",
                Color.FromArgb(220, 53, 69),
                880
            );
            summaryPanel.Controls.Add(problemCard);
        }

        private Panel CreateSummaryCard(string value, string label, Color color, int x)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 70),
                Location = new Point(x, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = color,
                AutoSize = true,
                Location = new Point(15, 10)
            };
            card.Controls.Add(valueLabel);

            Label labelLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(15, 40)
            };
            card.Controls.Add(labelLabel);

            return card;
        }

        private void DisplayDrivers(List<DriverInfo> drivers)
        {
            driversListView.Items.Clear();

            foreach (var driver in drivers)
            {
                string statusIcon = GetStatusIcon(driver.Status);
                string priorityText = GetPriorityText(driver.Priority);

                ListViewItem item = new ListViewItem(statusIcon);
                item.SubItems.Add(driver.Category);
                item.SubItems.Add(driver.DeviceName);
                item.SubItems.Add(driver.DriverVersion ?? "N/A");
                item.SubItems.Add(driver.DriverDate?.ToString("dd/MM/yyyy") ?? "N/A");
                item.SubItems.Add(driver.DriverProvider);
                item.SubItems.Add(driver.DaysOld > 0 ? $"{driver.DaysOld} dias" : "N/A");
                item.SubItems.Add(priorityText);
                item.Tag = driver;

                // Colorir por status
                item.BackColor = GetStatusColor(driver.Status);

                if (driver.Priority == DriverPriority.Critical)
                    item.Font = new Font(driversListView.Font, FontStyle.Bold);

                driversListView.Items.Add(item);
            }
        }

        private string GetStatusIcon(string status)
        {
            switch (status)
            {
                case "OK": return "✅";
                case "Desatualizado": return "⚠️";
                case "Problema": return "❌";
                default: return "❓";
            }
        }

        private string GetPriorityText(DriverPriority priority)
        {
            switch (priority)
            {
                case DriverPriority.Critical: return "🔴 Crítico";
                case DriverPriority.Important: return "🟡 Importante";
                default: return "🟢 Normal";
            }
        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "OK": return Color.FromArgb(230, 255, 230);
                case "Desatualizado": return Color.FromArgb(255, 250, 220);
                case "Problema": return Color.FromArgb(255, 230, 230);
                default: return Color.White;
            }
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allDrivers == null) return;

            List<DriverInfo> filtered;
            string filter = filterComboBox.SelectedItem.ToString();

            if (filter.Contains("Problemas"))
                filtered = allDrivers.Where(d => d.Status == "Problema").ToList();
            else if (filter.Contains("Desatualizados"))
                filtered = allDrivers.Where(d => d.Status == "Desatualizado").ToList();
            else if (filter.Contains("OK"))
                filtered = allDrivers.Where(d => d.Status == "OK").ToList();
            else if (filter.Contains("Vídeo"))
                filtered = allDrivers.Where(d => d.Category.Contains("Vídeo")).ToList();
            else if (filter.Contains("Rede"))
                filtered = allDrivers.Where(d => d.Category.Contains("Rede")).ToList();
            else if (filter.Contains("Áudio"))
                filtered = allDrivers.Where(d => d.Category.Contains("Áudio")).ToList();
            else
                filtered = allDrivers;

            DisplayDrivers(filtered);
        }

        private void DriversListView_DoubleClick(object sender, EventArgs e)
        {
            if (driversListView.SelectedItems.Count > 0)
            {
                DriverInfo driver = driversListView.SelectedItems[0].Tag as DriverInfo;
                if (driver != null)
                {
                    ShowDriverDetails(driver);
                }
            }
        }

        private void ShowDriverDetails(DriverInfo driver)
        {
            Form detailForm = new Form
            {
                Text = $"Detalhes do Driver - {driver.DeviceName}",
                Size = new Size(700, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 20;

            // Status grande
            Label statusLabel = new Label
            {
                Text = $"{GetStatusIcon(driver.Status)} {driver.Status}",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = driver.Status == "OK" ? Color.Green :
                           driver.Status == "Desatualizado" ? Color.Orange : Color.Red,
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(statusLabel);
            yPos += 50;

            // Nome do dispositivo
            AddDetailLabel(detailForm, "Dispositivo:", driver.DeviceName, ref yPos, true);

            // Categoria
            AddDetailLabel(detailForm, "Categoria:", driver.Category, ref yPos);

            // Versão
            AddDetailLabel(detailForm, "Versão do Driver:", driver.DriverVersion ?? "N/A", ref yPos);

            // Data
            AddDetailLabel(detailForm, "Data do Driver:",
                driver.DriverDate?.ToString("dd/MM/yyyy") ?? "N/A", ref yPos);

            // Fornecedor
            AddDetailLabel(detailForm, "Fornecedor:", driver.DriverProvider, ref yPos);

            // Idade
            AddDetailLabel(detailForm, "Idade:",
                driver.DaysOld > 0 ? $"{driver.DaysOld} dias ({driver.DaysOld / 30} meses)" : "N/A", ref yPos);

            yPos += 10;

            // Linha separadora
            Panel separator = new Panel
            {
                Height = 2,
                Width = 640,
                Location = new Point(30, yPos),
                BackColor = Color.FromArgb(200, 200, 200)
            };
            detailForm.Controls.Add(separator);
            yPos += 15;

            // Explicação amigável
            Label explanationTitle = new Label
            {
                Text = "💡 O que isso significa?",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(explanationTitle);
            yPos += 30;

            TextBox explanationBox = new TextBox
            {
                Text = driver.FriendlyExplanation,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(30, yPos),
                Size = new Size(640, 60),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(255, 255, 230),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(explanationBox);
            yPos += 70;

            // Recomendação
            Label recommendationTitle = new Label
            {
                Text = "📋 Recomendação:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(recommendationTitle);
            yPos += 30;

            TextBox recommendationBox = new TextBox
            {
                Text = driver.Recommendation,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(30, yPos),
                Size = new Size(640, 80),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle
            };
            detailForm.Controls.Add(recommendationBox);
            yPos += 90;

            // Botões
            if (driver.Status != "OK" && !string.IsNullOrEmpty(driver.UpdateUrl))
            {
                Button updateButton = new Button
                {
                    Text = "🔗 Abrir Site de Atualização",
                    Size = new Size(220, 40),
                    Location = new Point(30, yPos),
                    BackColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                updateButton.FlatAppearance.BorderSize = 0;
                updateButton.Click += (s, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = driver.UpdateUrl,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao abrir link: {ex.Message}",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                detailForm.Controls.Add(updateButton);
            }

            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(550, yPos),
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

        private void AddDetailLabel(Form form, string title, string value, ref int yPos, bool bold = false)
        {
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            form.Controls.Add(titleLabel);

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 10, bold ? FontStyle.Bold : FontStyle.Regular),
                AutoSize = true,
                Location = new Point(200, yPos),
                MaximumSize = new Size(470, 0)
            };
            form.Controls.Add(valueLabel);

            yPos += 30;
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string helpMessage = @"📖 GUIA DE AJUDA - DRIVERS

O que são Drivers?
Drivers são pequenos programas que permitem que o Windows se comunique com as peças do seu computador (placa de vídeo, som, rede, etc).

🟢 Status dos Drivers:

✅ OK - Driver funcionando perfeitamente
⚠️ Desatualizado - Driver antigo, recomenda-se atualizar
❌ Problema - Driver com falha, precisa atenção urgente

🔴 Prioridade:

- Crítico - Drivers essenciais (GPU, Chipset)
  Problemas aqui afetam muito o desempenho!

- Importante - Drivers para rede e áudio
  Problemas podem afetar internet e som

- Normal - Outros drivers
  Menos críticos para o funcionamento

💡 Dicas:

1. Sempre baixe drivers dos sites oficiais dos fabricantes
2. Crie um ponto de restauração antes de atualizar
3. Se algo der errado após atualizar, reverta o driver
4. Atualize drivers críticos primeiro

❓ Precisa de mais ajuda?
Clique duas vezes em qualquer driver para ver detalhes e recomendações específicas!";

            MessageBox.Show(helpMessage, "Ajuda - Drivers",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}