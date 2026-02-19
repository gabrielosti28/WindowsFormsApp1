using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public class FormMaintenance : Form
    {
        // Cores
        private readonly Color CorFundo = Color.FromArgb(245, 247, 250);
        private readonly Color CorBranco = Color.White;
        private readonly Color CorAzul = Color.FromArgb(41, 128, 185);
        private readonly Color CorVerde = Color.FromArgb(39, 174, 96);
        private readonly Color CorVermelho = Color.FromArgb(192, 57, 43);
        private readonly Color CorAmarelo = Color.FromArgb(243, 156, 18);
        private readonly Color CorLaranja = Color.FromArgb(230, 126, 34);
        private readonly Color CorTexto = Color.FromArgb(44, 62, 80);

        private TabControl tabMain;
        private Label lblStatus;
        private ProgressBar pbProgresso;

        public FormMaintenance()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "🔧 Manutenção do Computador";
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = CorFundo;
            this.Font = new Font("Segoe UI", 9f);

            // Topo
            var pnlTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(39, 174, 96)
            };
            pnlTopo.Controls.Add(new Label
            {
                Text = "🔧 Manutenção do Computador",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 8),
                AutoSize = true
            });
            pnlTopo.Controls.Add(new Label
            {
                Text = "Faça um check-up, limpe arquivos desnecessários e deixe o computador mais rápido",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(200, 240, 210),
                Location = new Point(17, 42),
                AutoSize = true
            });

            // Barra de status/progresso
            var pnlRodape = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 36,
                BackColor = Color.FromArgb(236, 240, 241),
                Padding = new Padding(10, 4, 10, 4)
            };
            lblStatus = new Label
            {
                Dock = DockStyle.Left,
                Width = 500,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = CorAzul,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Pronto."
            };
            pbProgresso = new ProgressBar
            {
                Dock = DockStyle.Right,
                Width = 250,
                Style = ProgressBarStyle.Marquee,
                Visible = false,
                Height = 18
            };
            pnlRodape.Controls.Add(lblStatus);
            pnlRodape.Controls.Add(pbProgresso);

            // Abas
            tabMain = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f),
                Padding = new Point(12, 6)
            };

            tabMain.TabPages.Add(CriarAbaCheckup());
            tabMain.TabPages.Add(CriarAbaLimpeza());
            tabMain.TabPages.Add(CriarAbaInicializacao());
            tabMain.TabPages.Add(CriarAbaDiscos());

            this.Controls.Add(tabMain);
            this.Controls.Add(pnlTopo);
            this.Controls.Add(pnlRodape);
        }

        // ═══════════════════════════════════════════════════════════════
        // ABA 1: CHECK-UP GERAL
        // ═══════════════════════════════════════════════════════════════
        private TabPage CriarAbaCheckup()
        {
            var tab = new TabPage("🏥 Check-up Geral") { BackColor = CorFundo, Padding = new Padding(10) };

            var pnlScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };

            // Botão de executar
            var btnCheckup = CriarBotaoGrande("🔍 Fazer Check-up do Computador Agora",
                "Verificar tudo e receber um relatório completo com pontuação", CorAzul, 10, 10, 600);
            btnCheckup.Click += async (s, e) =>
            {
                btnCheckup.Enabled = false;
                MostrarProgresso("Analisando seu computador...");
                pnlScroll.Controls.Clear();
                pnlScroll.Controls.Add(btnCheckup);
                await Task.Run(() =>
                {
                    var resultado = MaintenanceService.ExecutarCheckup();
                    this.Invoke((Action)(() =>
                    {
                        pnlScroll.Controls.Add(CriarPainelCheckup(resultado, 100));
                        OcultarProgresso("✅ Check-up concluído!");
                        btnCheckup.Enabled = true;
                    }));
                });
            };

            pnlScroll.Controls.Add(btnCheckup);
            tab.Controls.Add(pnlScroll);
            return tab;
        }

        private Panel CriarPainelCheckup(ResultadoManutencao resultado, int y)
        {
            var pnl = new Panel { Location = new Point(10, y), Width = 900, AutoSize = true };
            int py = 0;

            // Pontuação
            var pnlNota = new Panel
            {
                Location = new Point(0, py),
                Size = new Size(880, 90),
                BackColor = CorBranco
            };
            pnlNota.Paint += (s, e) => DesenhaBordaArredondada(e.Graphics, pnlNota.ClientRectangle, 8, CorAzul);

            var lblPontos = new Label
            {
                Text = resultado.Pontuacao.ToString(),
                Font = new Font("Segoe UI", 36f, FontStyle.Bold),
                ForeColor = ObterCorPontuacao(resultado.Pontuacao),
                Location = new Point(20, 10),
                AutoSize = true
            };
            var lblDe100 = new Label
            {
                Text = "/100",
                Font = new Font("Segoe UI", 14f),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(85, 30),
                AutoSize = true
            };
            var lblClassif = new Label
            {
                Text = $"{resultado.Emoji} {resultado.Classificacao}",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = ObterCorPontuacao(resultado.Pontuacao),
                Location = new Point(140, 20),
                AutoSize = true
            };
            var lblResumo = new Label
            {
                Text = resultado.Resumo,
                Font = new Font("Segoe UI", 9f),
                ForeColor = CorTexto,
                Location = new Point(140, 50),
                AutoSize = true
            };
            pnlNota.Controls.AddRange(new Control[] { lblPontos, lblDe100, lblClassif, lblResumo });
            py += 100;

            // Barra de progresso visual
            var pb = new ProgressBar
            {
                Location = new Point(0, py),
                Width = 880,
                Height = 20,
                Minimum = 0,
                Maximum = 100,
                Value = resultado.Pontuacao,
                Style = ProgressBarStyle.Continuous
            };
            py += 28;

            // Problemas
            if (resultado.ProblemasEncontrados.Any())
            {
                var lblProb = new Label
                {
                    Text = "📋 O que foi encontrado:",
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = CorTexto,
                    Location = new Point(0, py),
                    AutoSize = true
                };
                py += 26;

                foreach (var prob in resultado.ProblemasEncontrados)
                {
                    var lblItem = new Label
                    {
                        Text = prob,
                        Font = new Font("Segoe UI", 9f),
                        ForeColor = prob.Contains("✅") ? CorVerde : CorTexto,
                        Location = new Point(10, py),
                        Size = new Size(860, 22)
                    };
                    py += 24;
                    pnl.Controls.Add(lblItem);
                }
                pnl.Controls.Add(lblProb);
            }

            // Recomendações
            if (resultado.Recomendacoes.Any())
            {
                var lblRec = new Label
                {
                    Text = "💡 O que fazer:",
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = CorTexto,
                    Location = new Point(0, py),
                    AutoSize = true
                };
                py += 26;

                foreach (var rec in resultado.Recomendacoes)
                {
                    var pnlRec = new Panel
                    {
                        Location = new Point(0, py),
                        Size = new Size(880, 32),
                        BackColor = Color.FromArgb(232, 246, 255)
                    };
                    pnlRec.Controls.Add(new Label
                    {
                        Text = "→ " + rec,
                        Font = new Font("Segoe UI", 9f),
                        ForeColor = CorAzul,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(10, 0, 0, 0)
                    });
                    py += 36;
                    pnl.Controls.Add(pnlRec);
                }
                pnl.Controls.Add(lblRec);
            }

            pnl.Controls.AddRange(new Control[] { pnlNota, pb });
            pnl.Height = py + 20;
            return pnl;
        }

        // ═══════════════════════════════════════════════════════════════
        // ABA 2: LIMPEZA
        // ═══════════════════════════════════════════════════════════════
        private TabPage CriarAbaLimpeza()
        {
            var tab = new TabPage("🧹 Limpar Arquivos") { BackColor = CorFundo, Padding = new Padding(10) };
            var pnl = new Panel { Dock = DockStyle.Fill, AutoScroll = true };

            var lblExplica = new Label
            {
                Text = "Com o tempo, o computador acumula arquivos desnecessários — como uma gaveta que vai enchendo de papéis velhos.\n" +
                            "A limpeza abaixo é completamente segura: remove apenas arquivos que o Windows não precisa mais.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = CorTexto,
                Location = new Point(10, 10),
                Size = new Size(880, 50)
            };

            var pnlAnalise = new Panel { Location = new Point(10, 68), Width = 880, Height = 280, BackColor = CorBranco };
            var lblAnaliseTitulo = new Label
            {
                Text = "📊 Analisar quanto espaço pode ser liberado",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = CorTexto,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var pnlResultados = new Panel { Location = new Point(0, 40), Width = 880, Height = 220, AutoScroll = true };

            var btnAnalisar = CriarBotaoGrande("🔍 Analisar Arquivos Desnecessários",
                "Verificar quanto espaço pode ser liberado (sem apagar nada ainda)", CorAzul, 10, 10, 400);

            var btnLimpar = CriarBotaoGrande("🧹 Apagar Arquivos Desnecessários",
                "Apagar todos os arquivos encontrados e liberar espaço", CorVerde, 430, 10, 400);
            btnLimpar.Enabled = false;

            btnAnalisar.Click += async (s, e) =>
            {
                btnAnalisar.Enabled = btnLimpar.Enabled = false;
                MostrarProgresso("Analisando arquivos...");
                pnlResultados.Controls.Clear();

                await Task.Run(() =>
                {
                    var lixo = MaintenanceService.AnalisarLixo();
                    this.Invoke((Action)(() =>
                    {
                        int ry = 10; long totalBytes = 0;
                        foreach (var item in lixo)
                        {
                            totalBytes += item.BytesLiberados;
                            var pItem = new Panel { Location = new Point(10, ry), Size = new Size(840, 36), BackColor = Color.FromArgb(248, 250, 252) };
                            pItem.Controls.Add(new Label { Text = $"{item.Emoji} {item.Nome}", Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = CorTexto, Location = new Point(8, 8), AutoSize = true });
                            pItem.Controls.Add(new Label { Text = item.TamanhoFormatado, Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = item.BytesLiberados > 100_000_000 ? CorLaranja : CorAzul, Location = new Point(700, 8), AutoSize = true });
                            pnlResultados.Controls.Add(pItem);
                            ry += 40;
                        }
                        var pTotal = new Panel { Location = new Point(10, ry), Size = new Size(840, 40), BackColor = Color.FromArgb(232, 246, 255) };
                        pTotal.Controls.Add(new Label { Text = $"📦 Total que pode ser liberado: {MaintenanceService.FormatarBytes(totalBytes)}", Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = CorAzul, Location = new Point(10, 10), AutoSize = true });
                        pnlResultados.Controls.Add(pTotal);

                        btnAnalisar.Enabled = true;
                        btnLimpar.Enabled = totalBytes > 0;
                        OcultarProgresso("✅ Análise concluída!");
                    }));
                });
            };

            btnLimpar.Click += async (s, e) =>
            {
                if (MessageBox.Show("Apagar todos os arquivos desnecessários encontrados?\n\nIsso é seguro — apenas arquivos temporários e o conteúdo da Lixeira serão apagados. Seus documentos, fotos e programas não são afetados.",
                    "Confirmar Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                btnAnalisar.Enabled = btnLimpar.Enabled = false;
                MostrarProgresso("Limpando...");

                await Task.Run(() =>
                {
                    var resultados = MaintenanceService.ExecutarLimpeza(
                        new Progress<string>(msg => this.Invoke((Action)(() => lblStatus.Text = msg))));

                    long total = resultados.Sum(r => r.BytesLiberados);
                    this.Invoke((Action)(() =>
                    {
                        pnlResultados.Controls.Clear();
                        int ry = 10;
                        foreach (var r in resultados)
                        {
                            var pItem = new Panel { Location = new Point(10, ry), Size = new Size(840, 36), BackColor = r.Sucesso ? Color.FromArgb(232, 250, 240) : Color.FromArgb(254, 235, 233) };
                            pItem.Controls.Add(new Label { Text = $"{r.Emoji} {r.Nome}: {r.Mensagem.Split('\n')[0]}", Font = new Font("Segoe UI", 9f), ForeColor = CorTexto, Location = new Point(8, 8), Size = new Size(800, 22) });
                            pnlResultados.Controls.Add(pItem);
                            ry += 40;
                        }
                        var pTotal = new Panel { Location = new Point(10, ry), Size = new Size(840, 40), BackColor = Color.FromArgb(232, 250, 240) };
                        pTotal.Controls.Add(new Label { Text = $"🎉 Limpeza concluída! {MaintenanceService.FormatarBytes(total)} liberados no total!", Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = CorVerde, Location = new Point(10, 10), AutoSize = true });
                        pnlResultados.Controls.Add(pTotal);
                        btnAnalisar.Enabled = true;
                        btnLimpar.Enabled = false;
                        OcultarProgresso($"✅ {MaintenanceService.FormatarBytes(total)} liberados!");
                    }));
                });
            };

            pnlAnalise.Controls.AddRange(new Control[] { lblAnaliseTitulo, btnAnalisar, btnLimpar, pnlResultados });
            pnl.Controls.AddRange(new Control[] { lblExplica, pnlAnalise });
            tab.Controls.Add(pnl);
            return tab;
        }

        // ═══════════════════════════════════════════════════════════════
        // ABA 3: INICIALIZAÇÃO
        // ═══════════════════════════════════════════════════════════════
        private TabPage CriarAbaInicializacao()
        {
            var tab = new TabPage("🚀 Velocidade ao Ligar") { BackColor = CorFundo };
            var pnl = new Panel { Dock = DockStyle.Fill };

            var lblExplica = new Label
            {
                Text = "📖 Esses são os programas que abrem automaticamente toda vez que você liga o computador.\n" +
                            "Quanto mais programas, mais demora para o Windows estar pronto para usar. Desative os que não precisa.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = CorTexto,
                Location = new Point(10, 10),
                Size = new Size(940, 50)
            };

            var lvInicio = new ListView
            {
                Location = new Point(10, 68),
                Size = new Size(720, 540),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 9f),
                BackColor = CorBranco
            };
            lvInicio.Columns.Add("Programa", 240);
            lvInicio.Columns.Add("Situação", 90);
            lvInicio.Columns.Add("Impacto", 170);
            lvInicio.Columns.Add("Fabricante", 130);
            lvInicio.Columns.Add("Origem", 80);

            var pnlDetalhesInicio = new Panel
            {
                Location = new Point(745, 68),
                Size = new Size(220, 300),
                BackColor = CorBranco,
                Padding = new Padding(10)
            };

            var lblDetTitle = new Label
            {
                Text = "Selecione um programa para ver detalhes",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = CorTexto,
                Location = new Point(10, 10),
                Size = new Size(200, 60),
                AutoSize = false
            };

            var lblDetDesc = new Label
            {
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = CorTexto,
                Location = new Point(10, 80),
                Size = new Size(200, 80),
                AutoSize = false
            };

            var lblDetRec = new Label
            {
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = CorVerde,
                Location = new Point(10, 170),
                Size = new Size(200, 80),
                AutoSize = false
            };

            var btnDesativarInicio = new Button
            {
                Text = "🚫 Remover da Inicialização",
                Location = new Point(10, 260),
                Size = new Size(200, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = CorVermelho,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnDesativarInicio.FlatAppearance.BorderSize = 0;

            pnlDetalhesInicio.Controls.AddRange(new Control[] { lblDetTitle, lblDetDesc, lblDetRec, btnDesativarInicio });

            ProgramaInicializacao progSelecionado = null;

            lvInicio.SelectedIndexChanged += (s, e) =>
            {
                if (lvInicio.SelectedItems.Count == 0) { btnDesativarInicio.Enabled = false; return; }
                progSelecionado = lvInicio.SelectedItems[0].Tag as ProgramaInicializacao;
                if (progSelecionado == null) return;
                lblDetTitle.Text = progSelecionado.Nome;
                lblDetDesc.Text = progSelecionado.Descricao;
                lblDetRec.Text = progSelecionado.Recomendacao;
                btnDesativarInicio.Enabled = true;
            };

            btnDesativarInicio.Click += (s, e) =>
            {
                if (progSelecionado == null) return;
                if (MessageBox.Show($"Remover '{progSelecionado.Nome}' da inicialização?\n\n{progSelecionado.Recomendacao}\n\nO programa continua funcionando normalmente — só não vai mais abrir sozinho quando o Windows ligar.",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                var (ok, msg) = MaintenanceService.DesativarProgramaInicializacao(progSelecionado);
                MessageBox.Show(msg, ok ? "✅ Pronto!" : "❌ Erro", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (ok) CarregarListaInicializacao(lvInicio);
            };

            // Botão carregar
            var btnCarregar = CriarBotaoGrande("🔄 Carregar Programas da Inicialização", "", CorAzul, 10, 10, 350);
            btnCarregar.Height = 36;
            btnCarregar.Click += (s, e) => CarregarListaInicializacao(lvInicio);

            pnl.Controls.AddRange(new Control[] { lblExplica, btnCarregar, lvInicio, pnlDetalhesInicio });
            tab.Controls.Add(pnl);
            return tab;
        }

        private void CarregarListaInicializacao(ListView lv)
        {
            MostrarProgresso("Carregando programas de inicialização...");
            lv.Items.Clear();
            var progs = MaintenanceService.ObterProgramasInicializacao();
            foreach (var p in progs)
            {
                var item = new ListViewItem(p.Nome);
                item.SubItems.Add(p.Ativo ? "✅ Ativo" : "🔴 Inativo");
                item.SubItems.Add(p.ImpactoEmoji + " " + p.ImpactoNaInicializacao);
                item.SubItems.Add(p.Fabricante);
                item.SubItems.Add(p.Origem);
                item.Tag = p;
                item.BackColor = p.ImpactoEmoji == "🟢" ? Color.FromArgb(235, 252, 243) :
                                 p.ImpactoEmoji == "🟡" ? Color.FromArgb(255, 253, 231) :
                                 Color.FromArgb(248, 248, 248);
                lv.Items.Add(item);
            }
            OcultarProgresso($"✅ {progs.Count} programas na inicialização.");
        }

        // ═══════════════════════════════════════════════════════════════
        // ABA 4: DISCOS
        // ═══════════════════════════════════════════════════════════════
        private TabPage CriarAbaDiscos()
        {
            var tab = new TabPage("💾 Meus Discos") { BackColor = CorFundo };
            var pnl = new Panel { Dock = DockStyle.Fill, AutoScroll = true };

            var btnAnalisarDiscos = CriarBotaoGrande("💾 Verificar Espaço nos Discos", "", CorAzul, 10, 10, 300);
            btnAnalisarDiscos.Height = 36;

            var pnlDiscos = new Panel { Location = new Point(10, 60), Width = 920, Height = 600, AutoScroll = true };

            btnAnalisarDiscos.Click += (s, e) =>
            {
                pnlDiscos.Controls.Clear();
                var discos = MaintenanceService.AnalisarDiscos();
                int dy = 0;
                foreach (var d in discos)
                {
                    var card = CriarCardDisco(d, dy);
                    pnlDiscos.Controls.Add(card);
                    dy += 120;
                }
                OcultarProgresso($"✅ {discos.Count} disco(s) analisado(s).");
            };

            pnl.Controls.AddRange(new Control[] { btnAnalisarDiscos, pnlDiscos });
            tab.Controls.Add(pnl);
            return tab;
        }

        private Panel CriarCardDisco(InfoDisco d, int y)
        {
            var card = new Panel
            {
                Location = new Point(0, y),
                Size = new Size(900, 105),
                BackColor = CorBranco,
                Padding = new Padding(15)
            };

            card.Controls.Add(new Label
            {
                Text = $"💾 {d.Letra} — {d.Nome} ({d.Tipo})",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = CorTexto,
                Location = new Point(15, 10),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = $"{d.SaudeEmoji} {d.SaudeStatus}",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = ObterCorPorcentagem(d.PorcentagemUso),
                Location = new Point(500, 10),
                AutoSize = true
            });

            // Barra de uso
            var pnlBarra = new Panel { Location = new Point(15, 38), Size = new Size(780, 18), BackColor = Color.FromArgb(220, 225, 230) };
            int larguraUsada = (int)(780 * d.PorcentagemUso / 100);
            pnlBarra.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(larguraUsada, 18),
                BackColor = ObterCorPorcentagem(d.PorcentagemUso)
            });
            card.Controls.Add(pnlBarra);

            card.Controls.Add(new Label
            {
                Text = $"Usado: {MaintenanceService.FormatarBytes(d.EspacoUsadoBytes)} de {MaintenanceService.FormatarBytes(d.EspacoTotalBytes)} ({d.PorcentagemUso:0}%)   |   Livre: {MaintenanceService.FormatarBytes(d.EspacoLivreBytes)}",
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = CorTexto,
                Location = new Point(15, 62),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = d.Alerta,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = ObterCorPorcentagem(d.PorcentagemUso),
                Location = new Point(15, 82),
                AutoSize = true
            });

            return card;
        }

        // ═══════════════════════════════════════════════════════════════
        // AUXILIARES
        // ═══════════════════════════════════════════════════════════════

        private Button CriarBotaoGrande(string texto, string subtexto, Color cor, int x, int y, int largura)
        {
            var btn = new Button
            {
                Location = new Point(x, y),
                Size = new Size(largura, 50),
                FlatStyle = FlatStyle.Flat,
                BackColor = cor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Text = string.IsNullOrEmpty(subtexto) ? texto : texto + "\n" + subtexto,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void MostrarProgresso(string msg)
        {
            lblStatus.Text = msg;
            pbProgresso.Visible = true;
            Application.DoEvents();
        }

        private void OcultarProgresso(string msg)
        {
            pbProgresso.Visible = false;
            lblStatus.Text = msg;
            lblStatus.ForeColor = CorVerde;
        }

        private Color ObterCorPontuacao(int pontuacao) =>
            pontuacao >= 85 ? CorVerde :
            pontuacao >= 70 ? CorAzul :
            pontuacao >= 50 ? CorAmarelo :
            CorVermelho;

        private Color ObterCorPorcentagem(double pct) =>
            pct >= 95 ? CorVermelho :
            pct >= 85 ? CorLaranja :
            pct >= 70 ? CorAmarelo :
            CorVerde;

        private void DesenhaBordaArredondada(System.Drawing.Graphics g, Rectangle rect, int raio, Color cor)
        {
            using (var pen = new System.Drawing.Pen(cor, 2))
            {
                // Apenas borda simples — evita dependências de GraphicsPath
                g.DrawRectangle(pen, rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
            }
        }
    }
}