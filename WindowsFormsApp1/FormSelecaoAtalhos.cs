using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppInterno
{
    public partial class FormSelecaoAtalhos : Form
    {
        public FormSelecaoAtalhos()
        {
            InitializeComponent();
            CustomizeButtons();
        }

        private void CustomizeButtons()
        {
            // Adicionar efeitos de hover nos botões
            AddHoverEffect(btnWindows, Color.FromArgb(0, 120, 215), Color.FromArgb(0, 100, 190));
            AddHoverEffect(btnExcel, Color.FromArgb(33, 115, 70), Color.FromArgb(25, 95, 55));
            AddHoverEffect(btnWord, Color.FromArgb(43, 87, 154), Color.FromArgb(33, 70, 130));
        }

        private void AddHoverEffect(Button btn, Color normalColor, Color hoverColor)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = hoverColor;
                btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size, FontStyle.Bold);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = normalColor;
            };
        }

        private void btnWindows_Click(object sender, EventArgs e)
        {
            // Abre o FormDiscovery na aba de Atalhos do Windows
            using (FormDiscovery form = new FormDiscovery())
            {
                // O FormDiscovery já tem a aba de atalhos do Windows
                // Vamos garantir que ela seja a primeira aba selecionada
                form.ShowDialog();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Abre o FormDiscovery na aba de Atalhos do Excel
            using (FormDiscoveryExcel form = new FormDiscoveryExcel())
            {
                form.ShowDialog();
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            // Abre o FormDiscovery na aba de Atalhos do Word
            using (FormDiscoveryWord form = new FormDiscoveryWord())
            {
                form.ShowDialog();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}