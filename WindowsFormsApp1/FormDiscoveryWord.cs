using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppInterno
{
    public partial class FormDiscoveryWord : Form
    {
        public FormDiscoveryWord()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form
            this.Text = "Atalhos do Microsoft Word - Em Breve!";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 250);

            // Header Panel
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(43, 87, 154) // Azul do Word
            };

            Label titleLabel = new Label
            {
                Text = "📝 Atalhos do Microsoft Word",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 20)
            };

            Label subtitleLabel = new Label
            {
                Text = "Em breve: atalhos para escrever documentos mais rápido!",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 230, 255),
                AutoSize = true,
                Location = new Point(30, 70)
            };

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);

            // Content Panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(50)
            };

            Label messageLabel = new Label
            {
                Text = "🚧 Em Desenvolvimento 🚧\n\n" +
                       "Os atalhos do Microsoft Word estão sendo preparados!\n\n" +
                       "Em breve você terá acesso a:\n\n" +
                       "• Atalhos de formatação (negrito, itálico, sublinhado...)\n" +
                       "• Atalhos de navegação (ir para página, início, fim...)\n" +
                       "• Atalhos de edição (copiar, colar, desfazer...)\n" +
                       "• Atalhos de tabelas e estilos\n" +
                       "• E muito mais!\n\n" +
                       "Por enquanto, experimente os atalhos do Windows e do Excel!",
                Font = new Font("Segoe UI", 13),
                AutoSize = false,
                Size = new Size(700, 400),
                Location = new Point(0, 50),
                TextAlign = ContentAlignment.TopCenter
            };

            contentPanel.Controls.Add(messageLabel);

            // Botão voltar
            Button btnVoltar = new Button
            {
                Text = "← Voltar",
                Size = new Size(130, 45),
                Location = new Point(335, 450),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            btnVoltar.FlatAppearance.BorderSize = 0;
            btnVoltar.Click += (s, e) => this.Close();

            contentPanel.Controls.Add(btnVoltar);

            this.Controls.Add(contentPanel);
            this.Controls.Add(headerPanel);

            this.ResumeLayout();
        }
    }
}