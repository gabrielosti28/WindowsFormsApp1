using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormDiscoveryWord : Form
    {
        // =====================================================================
        // MODELO DE ATALHO
        // =====================================================================
        private class AtalhoWord
        {
            public string Teclas { get; set; }
            public string Acao { get; set; }
            public string Dica { get; set; }
            public string Categoria { get; set; }
        }

        private readonly List<AtalhoWord> _atalhos = new List<AtalhoWord>
        {
            // Essenciais
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + S", Acao = "Salvar o documento", Dica = "Use sempre! Salve frequentemente para não perder seu trabalho. Dica: acostume-se a apertar Ctrl+S a cada parágrafo que terminar." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + Z", Acao = "Desfazer a última ação", Dica = "Errou? Não se preocupe! Ctrl+Z desfaz o que você acabou de fazer. Pode apertar várias vezes para desfazer várias ações." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + Y", Acao = "Refazer (repetir ação)", Dica = "O oposto do Ctrl+Z — refaz algo que você acabou de desfazer. Também funciona para repetir a última formatação aplicada." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + P", Acao = "Imprimir documento", Dica = "Abre a janela de impressão. Dica: antes de imprimir, use Ctrl+F2 para visualizar como ficará na folha." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + N", Acao = "Novo documento em branco", Dica = "Cria um documento novo rapidamente, sem precisar ir em 'Arquivo > Novo'." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + W", Acao = "Fechar o documento", Dica = "Fecha o documento atual. Se houver alterações não salvas, o Word perguntará se deseja salvar." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + O", Acao = "Abrir documento existente", Dica = "Abre a janela para escolher um arquivo do seu computador." },
            new AtalhoWord { Categoria = "Essenciais", Teclas = "Ctrl + A", Acao = "Selecionar tudo", Dica = "Seleciona todo o texto do documento de uma vez. Útil para mudar a fonte ou o tamanho de todo o texto." },

            // Formatação de Texto
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + B", Acao = "Negrito (Bold)", Dica = "Deixa o texto selecionado em negrito (mais grosso). Aplique antes de digitar ou selecione o texto e aplique depois." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + I", Acao = "Itálico", Dica = "Inclina o texto — útil para títulos de livros, palavras em outro idioma ou ênfases." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + U", Acao = "Sublinhado", Dica = "Adiciona uma linha embaixo do texto. Use com moderação em documentos formais." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + Shift + D", Acao = "Sublinhado duplo", Dica = "Adiciona duas linhas embaixo do texto — útil em planilhas e documentos contábeis." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + =", Acao = "Subscrito", Dica = "Texto menor abaixo da linha — usado em fórmulas químicas como H₂O (o 2 é subscrito)." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + Shift + =", Acao = "Sobrescrito", Dica = "Texto menor acima da linha — usado para expoentes matemáticos como m² ou km³." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + E", Acao = "Centralizar texto", Dica = "Centraliza o texto ou parágrafo selecionado na página. Ótimo para títulos." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + L", Acao = "Alinhar à esquerda", Dica = "Alinha o texto ao lado esquerdo da página — o padrão para texto comum." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + R", Acao = "Alinhar à direita", Dica = "Alinha o texto ao lado direito — usado para datas, assinaturas e cabeçalhos específicos." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + J", Acao = "Justificar texto", Dica = "Alinha o texto dos dois lados, como em jornais e livros — deixa o documento mais profissional." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + Shift + C", Acao = "Copiar formatação", Dica = "Copia apenas o estilo (fonte, cor, tamanho) de um texto. Combine com Ctrl+Shift+V para colar a formatação em outro trecho." },
            new AtalhoWord { Categoria = "Formatação de Texto", Teclas = "Ctrl + Space", Acao = "Remover toda formatação", Dica = "Remove negrito, itálico, cores e outros estilos do texto selecionado, voltando ao padrão." },

            // Copiar e Colar
            new AtalhoWord { Categoria = "Copiar e Colar", Teclas = "Ctrl + C", Acao = "Copiar", Dica = "Copia o texto ou imagem selecionada para a área de transferência. O original permanece onde está." },
            new AtalhoWord { Categoria = "Copiar e Colar", Teclas = "Ctrl + X", Acao = "Recortar (cortar)", Dica = "Remove o texto selecionado e o coloca na área de transferência — para mover de lugar." },
            new AtalhoWord { Categoria = "Copiar e Colar", Teclas = "Ctrl + V", Acao = "Colar", Dica = "Cola o que foi copiado ou recortado." },
            new AtalhoWord { Categoria = "Copiar e Colar", Teclas = "Ctrl + Shift + V", Acao = "Colar sem formatação", Dica = "Cola o texto copiado sem trazer a formatação original — o texto assume o estilo do destino." },

            // Localizar e Substituir
            new AtalhoWord { Categoria = "Localizar e Substituir", Teclas = "Ctrl + F", Acao = "Localizar palavra", Dica = "Abre a barra de pesquisa para encontrar palavras no documento. Muito útil em documentos longos." },
            new AtalhoWord { Categoria = "Localizar e Substituir", Teclas = "Ctrl + H", Acao = "Localizar e substituir", Dica = "Encontra uma palavra e a substitui por outra — pode substituir todas de uma vez! Exemplo: trocar 'cliente' por 'parceiro' em todo o documento." },
            new AtalhoWord { Categoria = "Localizar e Substituir", Teclas = "Ctrl + G", Acao = "Ir para página específica", Dica = "Pula diretamente para uma página específica do documento — ótimo para documentos longos." },

            // Navegação
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + Home", Acao = "Ir para o início do documento", Dica = "Leva o cursor de volta para o início do documento instantaneamente, sem precisar rolar." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + End", Acao = "Ir para o final do documento", Dica = "Leva o cursor para o final do documento." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + →", Acao = "Avançar uma palavra", Dica = "Move o cursor palavra por palavra para a direita — muito mais rápido que apertar a seta repetidamente." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + ←", Acao = "Voltar uma palavra", Dica = "Move o cursor palavra por palavra para a esquerda." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + Shift + →", Acao = "Selecionar próxima palavra", Dica = "Seleciona a próxima palavra — segure e continue apertando para selecionar mais palavras." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Home", Acao = "Ir para início da linha", Dica = "Move o cursor para o início da linha atual." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "End", Acao = "Ir para fim da linha", Dica = "Move o cursor para o final da linha atual." },
            new AtalhoWord { Categoria = "Navegação", Teclas = "Ctrl + Page Up/Down", Acao = "Ir para página anterior/próxima", Dica = "Navega entre páginas do documento rapidamente." },

            // Tabelas
            new AtalhoWord { Categoria = "Tabelas", Teclas = "Tab", Acao = "Próxima célula da tabela", Dica = "Dentro de uma tabela, Tab move para a próxima célula. Se estiver na última célula, cria uma nova linha." },
            new AtalhoWord { Categoria = "Tabelas", Teclas = "Shift + Tab", Acao = "Célula anterior da tabela", Dica = "Volta para a célula anterior dentro de uma tabela." },
            new AtalhoWord { Categoria = "Tabelas", Teclas = "Alt + Shift + ↑/↓", Acao = "Mover linha da tabela para cima/baixo", Dica = "Reordena linhas de uma tabela sem precisar copiar e colar." },

            // Revisão e Ortografia
            new AtalhoWord { Categoria = "Revisão e Ortografia", Teclas = "F7", Acao = "Verificar ortografia e gramática", Dica = "Abre o corretor ortográfico para revisar todo o documento de uma vez." },
            new AtalhoWord { Categoria = "Revisão e Ortografia", Teclas = "Shift + F7", Acao = "Abrir Dicionário de Sinônimos", Dica = "Abre o dicionário de sinônimos para a palavra selecionada — ótimo para enriquecer o vocabulário." },
            new AtalhoWord { Categoria = "Revisão e Ortografia", Teclas = "Ctrl + Shift + E", Acao = "Ativar rastreamento de alterações", Dica = "Marca todas as mudanças feitas no documento — essencial para revisão colaborativa de textos." },

            // Modos de Visualização
            new AtalhoWord { Categoria = "Visualização", Teclas = "Ctrl + F2", Acao = "Visualização de Impressão", Dica = "Mostra como o documento ficará quando impresso — verifique antes de imprimir para evitar surpresas." },
            new AtalhoWord { Categoria = "Visualização", Teclas = "Ctrl + F1", Acao = "Mostrar/Esconder Faixa de Opções", Dica = "Oculta ou mostra a barra de ferramentas superior — útil para ter mais espaço para editar." },
            new AtalhoWord { Categoria = "Visualização", Teclas = "Alt + F8", Acao = "Abrir Editor de Macros", Dica = "Abre o gerenciador de macros — sequências de ações automatizadas para tarefas repetitivas." },
        };

        // =====================================================================
        // CONTROLES
        // =====================================================================
        private FlowLayoutPanel panelCards;
        private Panel panelDetalhe;
        private Label lblDetTeclas;
        private Label lblDetAcao;
        private Label lblDetDica;
        private TextBox txtBusca;
        private ComboBox comboCategorias;

        public FormDiscoveryWord()
        {
            InitializeComponent();
            ConstruirInterface();
            PopularCards(_atalhos);
        }

        private void ConstruirInterface()
        {
            this.Text = "Atalhos do Microsoft Word — Guia Completo";
            this.Size = new Size(1080, 720);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 9.5f);

            // Cabeçalho
            var panelTopo = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(44, 94, 164), Padding = new Padding(20, 0, 20, 0) };
            panelTopo.Controls.Add(new Label { Text = "⌨️  Atalhos do Microsoft Word", Font = new Font("Segoe UI", 14f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Left, Width = 400, TextAlign = ContentAlignment.MiddleLeft });
            panelTopo.Controls.Add(new Label { Text = $"{_atalhos.Count} atalhos explicados em linguagem simples", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(180, 200, 240), Dock = DockStyle.Right, Width = 360, TextAlign = ContentAlignment.MiddleRight });

            // Barra de filtros
            var panelFiltros = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = Color.White, Padding = new Padding(12, 8, 12, 8) };
            panelFiltros.Paint += (s, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 222, 230)), 0, panelFiltros.Height - 1, panelFiltros.Width, panelFiltros.Height - 1);

            var lblBusca = new Label { Text = "🔍", Font = new Font("Segoe UI", 11f), Location = new Point(12, 12), Size = new Size(28, 30), TextAlign = ContentAlignment.MiddleCenter };

            txtBusca = new TextBox
            {
                Location = new Point(40, 13),
                Size = new Size(280, 28),
                Font = new Font("Segoe UI", 10f),
                BorderStyle = BorderStyle.FixedSingle,
                //PlaceholderText = "Buscar atalho ou ação..."
            };
            txtBusca.TextChanged += (s, e) => Filtrar();

            var lblCat = new Label { Text = "Categoria:", Font = new Font("Segoe UI", 9f), Location = new Point(340, 16), Size = new Size(80, 20), TextAlign = ContentAlignment.MiddleRight };

            comboCategorias = new ComboBox
            {
                Location = new Point(425, 12),
                Size = new Size(220, 28),
                Font = new Font("Segoe UI", 9.5f),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            comboCategorias.Items.Add("Todas as categorias");
            comboCategorias.Items.AddRange(_atalhos.Select(a => a.Categoria).Distinct().ToArray());
            comboCategorias.SelectedIndex = 0;
            comboCategorias.SelectedIndexChanged += (s, e) => Filtrar();

            panelFiltros.Controls.AddRange(new Control[] { lblBusca, txtBusca, lblCat, comboCategorias });

            // Painel detalhe
            panelDetalhe = new Panel { Dock = DockStyle.Right, Width = 320, BackColor = Color.White, Padding = new Padding(15) };
            panelDetalhe.Paint += (s, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 230)), 0, 0, 0, panelDetalhe.Height);

            lblDetTeclas = new Label
            {
                Text = "Selecione um atalho",
                Font = new Font("Consolas", 18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 94, 164),
                Location = new Point(15, 20),
                Size = new Size(290, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(240, 245, 255),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblDetAcao = new Label
            {
                Text = "Clique em qualquer atalho para ver uma explicação detalhada sobre o que ele faz e quando usar.",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(15, 82),
                Size = new Size(290, 70),
                AutoSize = false
            };

            var lblDicaLabel = new Label
            {
                Text = "💡 Dica de uso:",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 94, 164),
                Location = new Point(15, 162),
                AutoSize = true
            };

            lblDetDica = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(70, 80, 100),
                Location = new Point(15, 182),
                Size = new Size(290, 350),
                AutoSize = false
            };

            var btnPraticar = new Button
            {
                Text = "📋  Copiar atalho",
                Font = new Font("Segoe UI", 9.5f),
                BackColor = Color.FromArgb(44, 94, 164),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, 545),
                Size = new Size(290, 38),
                Cursor = Cursors.Hand,
                Name = "btnCopiarAtalho",
                Enabled = false
            };
            btnPraticar.FlatAppearance.BorderSize = 0;
            btnPraticar.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(lblDetTeclas.Text) && lblDetTeclas.Text != "Selecione um atalho")
                {
                    Clipboard.SetText(lblDetTeclas.Text);
                    var t = btnPraticar.Text;
                    btnPraticar.Text = "✔  Copiado!";
                    System.Threading.Tasks.Task.Delay(1500).ContinueWith(_ => this.Invoke((Action)(() => btnPraticar.Text = t)));
                }
            };

            panelDetalhe.Controls.AddRange(new Control[] { lblDetTeclas, lblDetAcao, lblDicaLabel, lblDetDica, btnPraticar });

            // Lista de cards
            panelCards = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, Padding = new Padding(10) };

            this.Controls.Add(panelCards);
            this.Controls.Add(panelDetalhe);
            this.Controls.Add(panelFiltros);
            this.Controls.Add(panelTopo);
        }

        private void Filtrar()
        {
            var busca = txtBusca.Text.ToLower().Trim();
            var catSelecionada = comboCategorias.SelectedItem?.ToString() ?? "Todas as categorias";

            var filtrados = _atalhos.Where(a =>
                (catSelecionada == "Todas as categorias" || a.Categoria == catSelecionada) &&
                (string.IsNullOrEmpty(busca) || a.Teclas.ToLower().Contains(busca) || a.Acao.ToLower().Contains(busca) || a.Dica.ToLower().Contains(busca))
            ).ToList();

            PopularCards(filtrados);
        }

        private void PopularCards(List<AtalhoWord> atalhos)
        {
            panelCards.Controls.Clear();

            if (!atalhos.Any())
            {
                panelCards.Controls.Add(new Label { Text = "Nenhum atalho encontrado para esta busca.", Font = new Font("Segoe UI", 10f), ForeColor = Color.Gray, Size = new Size(500, 40), TextAlign = ContentAlignment.MiddleLeft });
                return;
            }

            string catAtual = null;
            foreach (var atalho in atalhos)
            {
                if (atalho.Categoria != catAtual)
                {
                    catAtual = atalho.Categoria;
                    var lblCat = new Label { Text = catAtual, Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 94, 164), Size = new Size(700, 28), Padding = new Padding(4, 8, 0, 0), AutoSize = false, Margin = new Padding(0, 5, 0, 0) };
                    panelCards.Controls.Add(lblCat);
                }
                panelCards.Controls.Add(CriarCardAtalho(atalho));
            }
        }

        private Panel CriarCardAtalho(AtalhoWord atalho)
        {
            var card = new Panel
            {
                Size = new Size(700, 54),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 5),
                Cursor = Cursors.Hand,
                Tag = atalho
            };
            card.Paint += (s, e) => e.Graphics.DrawRectangle(new Pen(Color.FromArgb(218, 222, 232)), 0, 0, card.Width - 1, card.Height - 1);

            // Badge das teclas
            var badgeTeclas = new Panel { BackColor = Color.FromArgb(44, 94, 164), Location = new Point(10, 10), Size = new Size(130, 32), Cursor = Cursors.Hand };
            badgeTeclas.Controls.Add(new Label { Text = atalho.Teclas, Font = new Font("Consolas", 9.5f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter });

            var lblAcao = new Label { Text = atalho.Acao, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(152, 8), Size = new Size(400, 20), AutoEllipsis = true };
            var lblDica = new Label { Text = atalho.Dica.Length > 80 ? atalho.Dica.Substring(0, 80) + "..." : atalho.Dica, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(152, 28), Size = new Size(400, 18), AutoEllipsis = true };

            card.Controls.AddRange(new Control[] { badgeTeclas, lblAcao, lblDica });

            Action<bool> hover = (h) =>
            {
                card.BackColor = h ? Color.FromArgb(240, 245, 255) : Color.White;
                foreach (Control c in card.Controls) c.BackColor = card.BackColor;
                badgeTeclas.BackColor = h ? Color.FromArgb(30, 70, 140) : Color.FromArgb(44, 94, 164);
            };
            foreach (Control c in card.Controls) { c.MouseEnter += (s, e) => hover(true); c.MouseLeave += (s, e) => hover(false); c.Click += (s, e) => SelecionarAtalho(atalho); }
            card.MouseEnter += (s, e) => hover(true);
            card.MouseLeave += (s, e) => hover(false);
            card.Click += (s, e) => SelecionarAtalho(atalho);

            return card;
        }

        private void SelecionarAtalho(AtalhoWord atalho)
        {
            lblDetTeclas.Text = atalho.Teclas;
            lblDetAcao.Text = atalho.Acao;
            lblDetDica.Text = atalho.Dica;

            var btnCopiar = panelDetalhe.Controls.Find("btnCopiarAtalho", false).FirstOrDefault() as Button;
            if (btnCopiar != null) btnCopiar.Enabled = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1080, 720);
            this.Name = "FormDiscoveryWord";
            this.ResumeLayout(false);
        }
    }
}