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
            this.Text = "Guia do Computador - Menu Principal";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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

        private void btnAtalhosWindows_Click(object sender, EventArgs e)
        {
            using (FormDiscovery form = new FormDiscovery())
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