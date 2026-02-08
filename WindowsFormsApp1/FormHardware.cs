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
            LoadHardwareInfo();
        }

        private void LoadHardwareInfo()
        {
            listViewHardware.Items.Clear();
            lblStatus.Text = "Carregando informações do hardware...";
            lblStatus.ForeColor = Color.Orange;

            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    allComponents = hardwareService.GetAllHardwareInfo();

                    this.Invoke((MethodInvoker)delegate
                    {
                        DisplayComponents(allComponents);
                        lblStatus.Text = $"✅ {allComponents.Count} componentes encontrados";
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
                item.Tag = component;

                // Cor por status
                if (component.Status == "Funcionando" || component.Status == "Conectado")
                {
                    item.BackColor = Color.FromArgb(230, 255, 230);
                }
                else if (component.Status == "Resumo")
                {
                    item.BackColor = Color.FromArgb(240, 248, 255);
                    item.Font = new Font(listViewHardware.Font, FontStyle.Bold);
                }
                else if (component.Status == "Erro")
                {
                    item.BackColor = Color.FromArgb(255, 230, 230);
                }

                listViewHardware.Items.Add(item);
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
                Text = $"Detalhes - {component.Category}",
                Size = new Size(650, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            int yPos = 20;

            // Categoria
            Label categoryLabel = new Label
            {
                Text = component.Category,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 118, 210),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            detailForm.Controls.Add(categoryLabel);
            yPos += 50;

            // Nome
            AddDetailRow(detailForm, "Nome:", component.Name ?? "N/A", ref yPos);

            // Fabricante
            if (!string.IsNullOrEmpty(component.Manufacturer))
            {
                AddDetailRow(detailForm, "Fabricante:", component.Manufacturer, ref yPos);
            }

            // Modelo
            if (!string.IsNullOrEmpty(component.Model))
            {
                AddDetailRow(detailForm, "Modelo:", component.Model, ref yPos);
            }

            yPos += 10;

            // Detalhes técnicos
            if (!string.IsNullOrEmpty(component.Details))
            {
                Label detailsTitle = new Label
                {
                    Text = "📋 Detalhes Técnicos:",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(30, yPos)
                };
                detailForm.Controls.Add(detailsTitle);
                yPos += 30;

                TextBox detailsBox = new TextBox
                {
                    Text = component.Details,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(30, yPos),
                    Size = new Size(590, 80),
                    Font = new Font("Segoe UI", 9),
                    BackColor = Color.FromArgb(245, 245, 245),
                    BorderStyle = BorderStyle.FixedSingle
                };
                detailForm.Controls.Add(detailsBox);
                yPos += 90;
            }

            // Explicação amigável
            if (!string.IsNullOrEmpty(component.FriendlyExplanation))
            {
                Label explanationTitle = new Label
                {
                    Text = "💡 O que isso significa?",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(30, yPos)
                };
                detailForm.Controls.Add(explanationTitle);
                yPos += 30;

                TextBox explanationBox = new TextBox
                {
                    Text = component.FriendlyExplanation,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(30, yPos),
                    Size = new Size(590, 90),
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(255, 249, 196),
                    BorderStyle = BorderStyle.FixedSingle
                };
                detailForm.Controls.Add(explanationBox);
                yPos += 100;
            }

            // Botão fechar
            Button closeButton = new Button
            {
                Text = "Fechar",
                Size = new Size(120, 40),
                Location = new Point(500, 420),
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

        private void AddDetailRow(Form form, string label, string value, ref int yPos)
        {
            Label lblLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            form.Controls.Add(lblLabel);

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(180, yPos),
                MaximumSize = new Size(440, 0)
            };
            form.Controls.Add(lblValue);

            yPos += 30;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            LoadHardwareInfo();
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allComponents == null) return;

            string filter = comboFiltro.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(filter) || filter == "Todos os Componentes")
            {
                DisplayComponents(allComponents);
                return;
            }

            var filtered = allComponents.Where(c => c.Category.Contains(filter)).ToList();
            DisplayComponents(filtered);
        }
    }
}