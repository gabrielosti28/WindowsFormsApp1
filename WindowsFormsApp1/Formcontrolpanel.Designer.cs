using System.Windows.Forms;

namespace GuiaDoComputador
{
    partial class FormControlPanel
    {
        private System.ComponentModel.IContainer components = null;

        // Controles principais
        private Panel pnlTopo;
        private Panel panelMenu;
        private Panel panelConteudo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // =================================================================
            // CONFIGURAÇÕES DO FORMULÁRIO
            // =================================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Text = "🎛️  Painel de Controle Simplificado  —  Guia do Computador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // =================================================================
            // PAINEL TOPO (Cabeçalho)
            // =================================================================
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Height = 80;
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlTopo.Padding = new System.Windows.Forms.Padding(25, 15, 25, 0);

            var lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "🎛️  Painel de Controle Simplificado";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 15);
            lblTitulo.Size = new System.Drawing.Size(500, 35);

            var lblSubtitulo = new System.Windows.Forms.Label();
            lblSubtitulo.Text = "Configurações do Windows explicadas em português claro";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(210, 245, 235);
            lblSubtitulo.Location = new System.Drawing.Point(25, 50);
            lblSubtitulo.Size = new System.Drawing.Size(500, 22);

            var lblVersao = new System.Windows.Forms.Label();
            lblVersao.Text = "beta • v1.0";
            lblVersao.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblVersao.ForeColor = System.Drawing.Color.FromArgb(210, 245, 235);
            lblVersao.Location = new System.Drawing.Point(950, 30);
            lblVersao.Size = new System.Drawing.Size(100, 20);
            lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblVersao.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.pnlTopo.Controls.Add(lblTitulo);
            this.pnlTopo.Controls.Add(lblSubtitulo);
            this.pnlTopo.Controls.Add(lblVersao);

            // =================================================================
            // MENU LATERAL ESQUERDO
            // =================================================================
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 220;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelMenu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            // Adicionar título do menu
            var lblMenuTitle = new System.Windows.Forms.Label();
            lblMenuTitle.Text = "📌  O QUE VOCÊ QUER VER?";
            lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblMenuTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblMenuTitle.Location = new System.Drawing.Point(20, 15);
            lblMenuTitle.Size = new System.Drawing.Size(180, 20);
            this.panelMenu.Controls.Add(lblMenuTitle);

            // Botões do menu
            int y = 45;
            var menuItens = new[]
            {
                ("🖥️  Minha Tela", "Resolução e monitores", FormControlPanel.Secao.Tela),
                ("⚡  Energia", "Desempenho e bateria", FormControlPanel.Secao.Energia),
                ("🌐  Rede", "Internet e conexões", FormControlPanel.Secao.Rede),
                ("👤  Usuários", "Contas e permissões", FormControlPanel.Secao.Usuarios),
                ("🚀  Inicialização", "Programas que abrem sozinhos", FormControlPanel.Secao.Inicializacao),
            };

            foreach (var (titulo, descricao, secao) in menuItens)
            {
                var btn = CriarBotaoMenu(titulo, descricao, secao);
                btn.Location = new System.Drawing.Point(0, y);
                this.panelMenu.Controls.Add(btn);
                y += 80;
            }

            // Rodapé do menu
            var lblMenuFooter = new System.Windows.Forms.Label();
            lblMenuFooter.Text = "✨ Clique em uma opção\npara ver detalhes";
            lblMenuFooter.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Italic);
            lblMenuFooter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblMenuFooter.Location = new System.Drawing.Point(20, 500);
            lblMenuFooter.Size = new System.Drawing.Size(180, 40);
            lblMenuFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelMenu.Controls.Add(lblMenuFooter);

            // =================================================================
            // PAINEL DE CONTEÚDO (Área principal)
            // =================================================================
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConteudo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelConteudo.AutoScroll = true;

            // =================================================================
            // ADICIONAR CONTROLES AO FORMULÁRIO
            // =================================================================
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pnlTopo);

            // =================================================================
            // CONFIGURAÇÕES FINAIS
            // =================================================================
            this.Name = "FormControlPanel";
            this.ResumeLayout(false);
        }

        // Método auxiliar para criar botões do menu (chamado pelo InitializeComponent)
        private Button CriarBotaoMenu(string titulo, string descricao, Secao secao)
        {
            var btn = new Button
            {
                Text = titulo + "\n" + descricao,
                Font = new System.Drawing.Font("Segoe UI", 9f),
                ForeColor = System.Drawing.Color.FromArgb(156, 163, 175),
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Size = new System.Drawing.Size(220, 75),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new System.Windows.Forms.Padding(25, 0, 0, 0),
                Cursor = System.Windows.Forms.Cursors.Hand,
                Tag = secao
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 55, 72);

            // Evento de clique (será conectado na lógica)
            btn.Click += (s, e) => CarregarSecao((Secao)btn.Tag);

            return btn;
        }
    }
}