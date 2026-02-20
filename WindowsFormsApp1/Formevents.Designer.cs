using System.Windows.Forms;

namespace GuiaDoComputador
{
    partial class FormEvents
    {
        private System.ComponentModel.IContainer components = null;

        // Controles da interface
        private Panel panelTopo;
        private Panel panelFiltros;
        private FlowLayoutPanel panelCards;
        private Panel panelDetalhe;
        private Label lblDetalheNome;
        private Label lblDetalheData;
        private RichTextBox rtbDetalheDescricao;
        private Label lblCount;
        private Panel panelCarregando;
        private Label lblCarregando;
        private PictureBox pictureLogo;
        private Panel panelDicaRapida;
        private Label lblDicaRapida;

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
            this.components = new System.ComponentModel.Container();

            // =================================================================
            // CONFIGURAÇÕES DO FORMULÁRIO
            // =================================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Text = "📋 Central de Eventos - Guia do Computador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = null; // Adicione um ícone aqui se desejar

            // =================================================================
            // PAINEL TOPO - CABEÇALHO MODERNO
            // =================================================================
            this.panelTopo = new System.Windows.Forms.Panel();
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Height = 90;
            this.panelTopo.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.panelTopo.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);

            // Logo/Ícone do aplicativo
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.pictureLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureLogo.Location = new System.Drawing.Point(30, 20);
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.Image = null; // Adicione uma imagem aqui se desejar

            // Título principal
            var lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "📊 Central de Eventos";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(95, 18);
            lblTitulo.Size = new System.Drawing.Size(300, 35);
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Subtítulo educativo
            var lblSubtitulo = new System.Windows.Forms.Label();
            lblSubtitulo.Text = "Entenda o que acontece com seu computador, em português claro";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(221, 214, 254);
            lblSubtitulo.Location = new System.Drawing.Point(95, 50);
            lblSubtitulo.Size = new System.Drawing.Size(450, 22);
            lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Badge de versão
            var lblVersao = new System.Windows.Forms.Label();
            lblVersao.Text = "beta • v1.0";
            lblVersao.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lblVersao.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254);
            lblVersao.Location = new System.Drawing.Point(this.panelTopo.Width - 120, 35);
            lblVersao.Size = new System.Drawing.Size(80, 20);
            lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblVersao.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.panelTopo.Controls.Add(this.pictureLogo);
            this.panelTopo.Controls.Add(lblTitulo);
            this.panelTopo.Controls.Add(lblSubtitulo);
            this.panelTopo.Controls.Add(lblVersao);

            // =================================================================
            // PAINEL DE FILTROS
            // =================================================================
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 70;
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);

            // Label "Filtrar por:"
            var lblFiltro = new System.Windows.Forms.Label();
            lblFiltro.Text = "🔍 Filtrar eventos:";
            lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblFiltro.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblFiltro.Location = new System.Drawing.Point(30, 25);
            lblFiltro.Size = new System.Drawing.Size(100, 20);
            lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Botões de filtro com design moderno
            string[] categorias = new string[] { "Todos", "Erros Críticos", "Avisos", "Logins", "Instalações", "Desligamentos" };
            System.Drawing.Color[] coresCategorias = new System.Drawing.Color[]
            {
                System.Drawing.Color.FromArgb(79, 70, 229),    // Todos - Roxo
                System.Drawing.Color.FromArgb(239, 68, 68),    // Erros - Vermelho
                System.Drawing.Color.FromArgb(245, 158, 11),   // Avisos - Laranja
                System.Drawing.Color.FromArgb(59, 130, 246),   // Logins - Azul
                System.Drawing.Color.FromArgb(16, 185, 129),   // Instalações - Verde
                System.Drawing.Color.FromArgb(139, 92, 246)    // Desligamentos - Roxo claro
            };

            int xPos = 130;
            for (int i = 0; i < categorias.Length; i++)
            {
                var btn = new System.Windows.Forms.Button();
                btn.Text = categorias[i];
                btn.Tag = categorias[i];
                btn.Font = new System.Drawing.Font("Segoe UI", 9f);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = i == 0 ? System.Drawing.Color.FromArgb(79, 70, 229) : System.Drawing.Color.FromArgb(241, 245, 249);
                btn.ForeColor = i == 0 ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(51, 65, 85);
                btn.Location = new System.Drawing.Point(xPos, 18);
                btn.AutoSize = true;
                btn.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                // Adicionar bolinha colorida para categorias (exceto Todos)
                if (i > 0)
                {
                    btn.Text = "●  " + btn.Text;
                    btn.Text = btn.Text.Replace("●", "●"); // Mantém o caractere, mas a cor será aplicada
                }

                btn.Click += new System.EventHandler(this.FiltroBtn_Click);

                // Efeito hover
                btn.MouseEnter += (s, e) =>
                {
                    if (btn.BackColor != System.Drawing.Color.FromArgb(79, 70, 229))
                        btn.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
                };
                btn.MouseLeave += (s, e) =>
                {
                    if (btn.BackColor != System.Drawing.Color.FromArgb(79, 70, 229))
                        btn.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
                };

                this.panelFiltros.Controls.Add(btn);
                xPos += btn.Width + 8;
            }

            // Contador de eventos
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCount.Text = "0 eventos";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Italic);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(this.panelFiltros.Width - 150, 25);
            this.lblCount.Size = new System.Drawing.Size(120, 20);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.panelFiltros.Controls.Add(lblFiltro);
            this.panelFiltros.Controls.Add(this.lblCount);

            // =================================================================
            // PAINEL DE DETALHES (LADO DIREITO)
            // =================================================================
            this.panelDetalhe = new System.Windows.Forms.Panel();
            this.panelDetalhe.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetalhe.Width = 350;
            this.panelDetalhe.BackColor = System.Drawing.Color.White;
            this.panelDetalhe.Padding = new System.Windows.Forms.Padding(20);

            // Sombra sutil na borda esquerda
            this.panelDetalhe.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 0, 0, 0)))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, this.panelDetalhe.Height);
                }
            };

            // Cabeçalho do painel de detalhes
            var lblDetalheHeader = new System.Windows.Forms.Label();
            lblDetalheHeader.Text = "📌 DETALHES DO EVENTO";
            lblDetalheHeader.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblDetalheHeader.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDetalheHeader.Location = new System.Drawing.Point(20, 20);
            lblDetalheHeader.Size = new System.Drawing.Size(310, 20);

            // Nome do evento
            this.lblDetalheNome = new System.Windows.Forms.Label();
            this.lblDetalheNome.Text = "👆  Clique em um evento para ver detalhes";
            this.lblDetalheNome.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblDetalheNome.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDetalheNome.Location = new System.Drawing.Point(20, 45);
            this.lblDetalheNome.Size = new System.Drawing.Size(310, 50);
            this.lblDetalheNome.AutoSize = false;
            this.lblDetalheNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Data do evento
            this.lblDetalheData = new System.Windows.Forms.Label();
            this.lblDetalheData.Text = "";
            this.lblDetalheData.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDetalheData.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDetalheData.Location = new System.Drawing.Point(20, 95);
            this.lblDetalheData.Size = new System.Drawing.Size(310, 25);

            // Separador
            var separator = new System.Windows.Forms.Label();
            separator.Text = "────────────────";
            separator.Font = new System.Drawing.Font("Segoe UI", 8f);
            separator.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            separator.Location = new System.Drawing.Point(20, 125);
            separator.Size = new System.Drawing.Size(310, 15);

            // Descrição em linguagem simples
            this.rtbDetalheDescricao = new System.Windows.Forms.RichTextBox();
            this.rtbDetalheDescricao.Location = new System.Drawing.Point(20, 145);
            this.rtbDetalheDescricao.Size = new System.Drawing.Size(310, 550);
            this.rtbDetalheDescricao.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.rtbDetalheDescricao.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.rtbDetalheDescricao.BackColor = System.Drawing.Color.FromArgb(249, 250, 255);
            this.rtbDetalheDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetalheDescricao.ReadOnly = true;
            this.rtbDetalheDescricao.Text = "👈  Selecione um evento na lista ao lado\n\n" +
                                            "Você verá aqui uma explicação em português claro sobre:\n" +
                                            "• O que aconteceu\n" +
                                            "• Se você precisa se preocupar\n" +
                                            "• O que fazer (se for necessário)";

            this.panelDetalhe.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDetalheHeader,
                this.lblDetalheNome,
                this.lblDetalheData,
                separator,
                this.rtbDetalheDescricao
            });

            // =================================================================
            // PAINEL DE CARREGAMENTO
            // =================================================================
            this.panelCarregando = new System.Windows.Forms.Panel();
            this.panelCarregando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCarregando.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelCarregando.Visible = false;

            this.lblCarregando = new System.Windows.Forms.Label();
            this.lblCarregando.Text = "🔍  Analisando o histórico do seu computador...\n\n" +
                                      "Estamos traduzindo os eventos do sistema\n" +
                                      "para uma linguagem simples e fácil de entender.\n\n" +
                                      "⏳  Isso leva apenas alguns segundos.";
            this.lblCarregando.Font = new System.Drawing.Font("Segoe UI", 12f);
            this.lblCarregando.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCarregando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarregando.Dock = System.Windows.Forms.DockStyle.Fill;

            this.panelCarregando.Controls.Add(this.lblCarregando);

            // =================================================================
            // PAINEL DE DICA RÁPIDA (rodapé)
            // =================================================================
            this.panelDicaRapida = new System.Windows.Forms.Panel();
            this.panelDicaRapida.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDicaRapida.Height = 40;
            this.panelDicaRapida.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelDicaRapida.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);

            this.lblDicaRapida = new System.Windows.Forms.Label();
            this.lblDicaRapida.Text = "💡 Dica: Eventos em vermelho merecem atenção. Os demais são apenas informativos.";
            this.lblDicaRapida.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDicaRapida.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDicaRapida.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDicaRapida.AutoSize = true;
            this.lblDicaRapida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.panelDicaRapida.Controls.Add(this.lblDicaRapida);

            // =================================================================
            // PAINEL DE CARDS (LISTA DE EVENTOS)
            // =================================================================
            this.panelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelCards.WrapContents = false;
            this.panelCards.AutoScroll = true;
            this.panelCards.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panelCards.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            // =================================================================
            // ADICIONAR CONTROLES AO FORMULÁRIO
            // =================================================================
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.panelCarregando);
            this.Controls.Add(this.panelDetalhe);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTopo);
            this.Controls.Add(this.panelDicaRapida);

            // =================================================================
            // CONFIGURAÇÕES FINAIS
            // =================================================================
            this.Name = "FormEvents";
            this.ResumeLayout(false);
        }
    }
}