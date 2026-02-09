using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppInterno
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            CustomizeForm();
        }

        private void CustomizeForm()
        {
            // Adicionar efeitos hover nos botões
            AddHoverEffect(btnPecasComputador, Color.FromArgb(76, 175, 80), Color.FromArgb(56, 142, 60));
            AddHoverEffect(btnDesempenho, Color.FromArgb(255, 152, 0), Color.FromArgb(245, 124, 0));
            AddHoverEffect(btnDrivers, Color.FromArgb(233, 30, 99), Color.FromArgb(194, 24, 91));
            AddHoverEffect(btnAtalhosWindows, Color.FromArgb(0, 120, 215), Color.FromArgb(0, 100, 190));
            AddHoverEffect(btnAppsNativos, Color.FromArgb(103, 58, 183), Color.FromArgb(81, 45, 168));
            AddHoverEffect(btnDicasTruques, Color.FromArgb(156, 39, 176), Color.FromArgb(123, 31, 162));
        }

        private void AddHoverEffect(Button btn, Color normalColor, Color hoverColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = normalColor;
        }

        private void btnPecasComputador_Click(object sender, EventArgs e)
        {
            using (FormHardware form = new FormHardware())
            {
                form.ShowDialog();
            }
        }

        private void btnDesempenho_Click(object sender, EventArgs e)
        {
            using (WindowsFormsApp1.Form1 form = new WindowsFormsApp1.Form1())
            {
                form.ShowDialog();
            }
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            using (FormDrivers form = new FormDrivers())
            {
                form.ShowDialog();
            }
        }

        private void btnAtalhosWindows_Click(object sender, EventArgs e)
        {
            using (FormSelecaoAtalhos form = new FormSelecaoAtalhos())
            {
                form.ShowDialog();
            }
        }

        private void btnAppsNativos_Click(object sender, EventArgs e)
        {
            using (FormAppsNativos form = new FormAppsNativos())
            {
                form.ShowDialog();
            }
        }

        private void btnDicasTruques_Click(object sender, EventArgs e)
        {
            using (FormDicasTruques form = new FormDicasTruques())
            {
                form.ShowDialog();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do programa?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}