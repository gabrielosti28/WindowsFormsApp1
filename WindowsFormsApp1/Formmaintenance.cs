using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormMaintenance : Form
    {
        private ProgramaInicializacao progSelecionado = null;

        public FormMaintenance()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            // Evento do botão de check-up
            btnCheckup.Click += async (s, e) =>
            {
                btnCheckup.Enabled = false;
                MostrarProgresso("🔍 Analisando seu computador...");
                pnlCheckupResultados.Controls.Clear();

                await Task.Run(() =>
                {
                    var resultado = MaintenanceService.ExecutarCheckup();
                    this.Invoke((Action)(() =>
                    {
                        pnlCheckupResultados.Controls.Add(CriarPainelCheckup(resultado));
                        OcultarProgresso("✅ Check-up concluído!");
                        btnCheckup.Enabled = true;
                    }));
                });
            };

            // Evento do botão analisar lixo
            btnAnalisarLixo.Click += async (s, e) =>
            {
                btnAnalisarLixo.Enabled = btnLimparLixo.Enabled = false;
                MostrarProgresso("🔍 Analisando arquivos desnecessários...");
                pnlLixoResultados.Controls.Clear();

                await Task.Run(() =>
                {
                    var lixo = MaintenanceService.AnalisarLixo();
                    this.Invoke((Action)(() =>
                    {
                        long totalBytes = 0;
                        int y = 10;

                        foreach (var item in lixo)
                        {
                            totalBytes += item.BytesLiberados;
                            var card = CriarCardItemLixo(item, y);
                            pnlLixoResultados.Controls.Add(card);
                            y += 45;
                        }

                        var cardTotal = CriarCardTotalLixo(totalBytes, y);
                        pnlLixoResultados.Controls.Add(cardTotal);

                        btnAnalisarLixo.Enabled = true;
                        btnLimparLixo.Enabled = totalBytes > 0;
                        OcultarProgresso("✅ Análise concluída!");
                    }));
                });
            };

            // Evento do botão limpar lixo
            btnLimparLixo.Click += async (s, e) =>
            {
                if (MessageBox.Show(
                    "🧹 Apagar arquivos desnecessários?\n\n" +
                    "Isso é 100% seguro! Serão apagados apenas:\n" +
                    "• Arquivos temporários da internet\n" +
                    "• Cache do sistema\n" +
                    "• Conteúdo da Lixeira\n\n" +
                    "Seus documentos, fotos e programas não serão afetados.",
                    "Confirmar limpeza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

                btnAnalisarLixo.Enabled = btnLimparLixo.Enabled = false;
                MostrarProgresso("🧹 Limpando arquivos...");
                pnlLixoResultados.Controls.Clear();

                await Task.Run(() =>
                {
                    var resultados = MaintenanceService.ExecutarLimpeza(
                        new Progress<string>(msg => this.Invoke((Action)(() => lblStatus.Text = msg))));

                    long total = resultados.Sum(r => r.BytesLiberados);
                    this.Invoke((Action)(() =>
                    {
                        int y = 10;
                        foreach (var r in resultados)
                        {
                            var card = CriarCardResultadoLimpeza(r, y);
                            pnlLixoResultados.Controls.Add(card);
                            y += 45;
                        }

                        var cardTotal = CriarCardTotalLimpeza(total, y);
                        pnlLixoResultados.Controls.Add(cardTotal);

                        btnAnalisarLixo.Enabled = true;
                        OcultarProgresso($"✅ {MaintenanceService.FormatarBytes(total)} liberados!");
                    }));
                });
            };

            // Evento do botão carregar programas de inicialização
            btnCarregarInicializacao.Click += (s, e) => CarregarListaInicializacao();

            // Evento de seleção na lista de inicialização
            lvInicializacao.SelectedIndexChanged += (s, e) =>
            {
                if (lvInicializacao.SelectedItems.Count == 0)
                {
                    btnDesativarInicializacao.Enabled = false;
                    return;
                }

                progSelecionado = lvInicializacao.SelectedItems[0].Tag as ProgramaInicializacao;
                if (progSelecionado == null) return;

                lblDetalheProgramaNome.Text = progSelecionado.Nome;
                lblDetalheProgramaDesc.Text = progSelecionado.Descricao;
                lblDetalheProgramaRec.Text = progSelecionado.Recomendacao;
                btnDesativarInicializacao.Enabled = true;
            };

            // Evento do botão desativar programa
            btnDesativarInicializacao.Click += (s, e) =>
            {
                if (progSelecionado == null) return;

                if (MessageBox.Show(
                    $"❓ Desativar '{progSelecionado.Nome}' da inicialização?\n\n" +
                    $"{progSelecionado.Recomendacao}\n\n" +
                    "O programa continua instalado e funcionando — só não vai mais abrir sozinho quando o Windows ligar.",
                    "Confirmar desativação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

                var (ok, msg) = MaintenanceService.DesativarProgramaInicializacao(progSelecionado);

                MessageBox.Show(msg,
                    ok ? "✅ Sucesso!" : "❌ Atenção",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (ok) CarregarListaInicializacao();
            };

            // Evento do botão analisar discos
            btnAnalisarDiscos.Click += (s, e) =>
            {
                MostrarProgresso("💾 Analisando discos...");
                pnlDiscosResultados.Controls.Clear();

                var discos = MaintenanceService.AnalisarDiscos();
                int y = 0;

                foreach (var d in discos)
                {
                    var card = CriarCardDisco(d, y);
                    pnlDiscosResultados.Controls.Add(card);
                    y += 115;
                }

                OcultarProgresso($"✅ {discos.Count} disco(s) analisado(s).");
            };
        }

        private void CarregarListaInicializacao()
        {
            MostrarProgresso("🔄 Carregando programas de inicialização...");
            lvInicializacao.Items.Clear();

            var progs = MaintenanceService.ObterProgramasInicializacao();

            foreach (var p in progs)
            {
                var item = new ListViewItem(p.Nome);
                item.SubItems.Add(p.Ativo ? "✅ Ativo" : "⚪ Inativo");
                item.SubItems.Add(p.ImpactoEmoji + " " + p.ImpactoNaInicializacao);
                item.SubItems.Add(p.Fabricante);
                item.SubItems.Add(p.Origem);
                item.Tag = p;

                item.BackColor = p.ImpactoEmoji == "🟢" ? Color.FromArgb(240, 255, 240) :
                                 p.ImpactoEmoji == "🟡" ? Color.FromArgb(255, 255, 225) :
                                 Color.FromArgb(255, 240, 240);

                lvInicializacao.Items.Add(item);
            }

            OcultarProgresso($"✅ {progs.Count} programa(s) na inicialização.");
        }

        private Panel CriarPainelCheckup(ResultadoManutencao resultado)
        {
            var pnl = new Panel
            {
                Width = 860,
                Height = 400,
                AutoScroll = true,
                BackColor = Color.White
            };

            int y = 20;

            var pnlPontuacao = CriarCardPontuacao(resultado, y);
            pnl.Controls.Add(pnlPontuacao);
            y += 100;

            var pbPontuacao = new ProgressBar
            {
                Location = new Point(20, y),
                Width = 820,
                Height = 20,
                Minimum = 0,
                Maximum = 100,
                Value = resultado.Pontuacao,
                Style = ProgressBarStyle.Continuous
            };
            pnl.Controls.Add(pbPontuacao);
            y += 40;

            if (resultado.ProblemasEncontrados.Any())
            {
                var lblProblemas = new Label
                {
                    Text = "📋 O que encontramos:",
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Location = new Point(20, y),
                    AutoSize = true
                };
                pnl.Controls.Add(lblProblemas);
                y += 30;

                foreach (var prob in resultado.ProblemasEncontrados)
                {
                    var lblItem = new Label
                    {
                        Text = "• " + prob,
                        Font = new Font("Segoe UI", 9.5f),
                        ForeColor = prob.Contains("✅") ? Color.FromArgb(22, 163, 74) : Color.FromArgb(71, 85, 105),
                        Location = new Point(40, y),
                        Size = new Size(800, 25)
                    };
                    pnl.Controls.Add(lblItem);
                    y += 28;
                }
            }

            if (resultado.Recomendacoes.Any())
            {
                var lblRecomendacoes = new Label
                {
                    Text = "💡 Recomendações:",
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Location = new Point(20, y),
                    AutoSize = true
                };
                pnl.Controls.Add(lblRecomendacoes);
                y += 30;

                foreach (var rec in resultado.Recomendacoes)
                {
                    var pnlRec = new Panel
                    {
                        Location = new Point(20, y),
                        Size = new Size(820, 35),
                        BackColor = Color.FromArgb(239, 246, 255)
                    };

                    pnlRec.Controls.Add(new Label
                    {
                        Text = "→ " + rec,
                        Font = new Font("Segoe UI", 9.5f),
                        ForeColor = Color.FromArgb(37, 99, 235),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(10, 0, 0, 0)
                    });

                    pnl.Controls.Add(pnlRec);
                    y += 40;
                }
            }

            pnl.Height = y + 30;
            return pnl;
        }

        private Panel CriarCardPontuacao(ResultadoManutencao resultado, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(820, 80),
                BackColor = Color.FromArgb(249, 250, 255)
            };

            var corPontuacao = ObterCorPontuacao(resultado.Pontuacao);

            var lblPontos = new Label
            {
                Text = resultado.Pontuacao.ToString(),
                Font = new Font("Segoe UI", 36f, FontStyle.Bold),
                ForeColor = corPontuacao,
                Location = new Point(20, 10),
                AutoSize = true
            };

            var lblDe100 = new Label
            {
                Text = "/100",
                Font = new Font("Segoe UI", 14f),
                ForeColor = Color.FromArgb(156, 163, 175),
                Location = new Point(85, 28),
                AutoSize = true
            };

            var lblClassificacao = new Label
            {
                Text = $"{resultado.Emoji}  {resultado.Classificacao}",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = corPontuacao,
                Location = new Point(140, 18),
                AutoSize = true
            };

            var lblResumo = new Label
            {
                Text = resultado.Resumo,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(140, 48),
                AutoSize = true
            };

            pnl.Controls.AddRange(new Control[] { lblPontos, lblDe100, lblClassificacao, lblResumo });
            return pnl;
        }

        // *** CORRIGIDO: era ItemLixo, agora é ResultadoLimpeza ***
        private Panel CriarCardItemLixo(ResultadoLimpeza item, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(820, 40),
                BackColor = Color.FromArgb(248, 250, 252)
            };

            var corTamanho = item.BytesLiberados > 100_000_000 ? Color.FromArgb(234, 88, 12) :
                             item.BytesLiberados > 10_000_000 ? Color.FromArgb(37, 99, 235) :
                             Color.FromArgb(75, 85, 99);

            pnl.Controls.Add(new Label
            {
                Text = $"{item.Emoji}  {item.Nome}",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(15, 10),
                AutoSize = true
            });

            pnl.Controls.Add(new Label
            {
                Text = item.TamanhoFormatado,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = corTamanho,
                Location = new Point(700, 10),
                AutoSize = true
            });

            return pnl;
        }

        private Panel CriarCardTotalLixo(long totalBytes, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(820, 45),
                BackColor = Color.FromArgb(219, 234, 254)
            };

            pnl.Controls.Add(new Label
            {
                Text = $"📦  Total que pode ser liberado:  {MaintenanceService.FormatarBytes(totalBytes)}",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(29, 78, 216),
                Location = new Point(15, 10),
                AutoSize = true
            });

            return pnl;
        }

        private Panel CriarCardResultadoLimpeza(ResultadoLimpeza r, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(820, 40),
                BackColor = r.Sucesso ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242)
            };

            pnl.Controls.Add(new Label
            {
                Text = $"{r.Emoji}  {r.Nome}: {r.Mensagem.Split('\n')[0]}",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(15, 10),
                Size = new Size(790, 22)
            });

            return pnl;
        }

        private Panel CriarCardTotalLimpeza(long total, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(820, 45),
                BackColor = Color.FromArgb(220, 252, 231)
            };

            pnl.Controls.Add(new Label
            {
                Text = $"🎉  Limpeza concluída!  {MaintenanceService.FormatarBytes(total)} liberados!",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 163, 74),
                Location = new Point(15, 10),
                AutoSize = true
            });

            return pnl;
        }

        private Panel CriarCardDisco(InfoDisco d, int y)
        {
            var card = new Panel
            {
                Location = new Point(20, y),
                Size = new Size(860, 105),
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            var corUso = ObterCorPorcentagem(d.PorcentagemUso);

            card.Controls.Add(new Label
            {
                Text = $"💾  {d.Letra}  —  {d.Nome}",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(15, 12),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"{d.SaudeEmoji}  {d.SaudeStatus}",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = corUso,
                Location = new Point(650, 14),
                AutoSize = true
            });

            var pnlBarra = new Panel
            {
                Location = new Point(15, 42),
                Size = new Size(740, 20),
                BackColor = Color.FromArgb(229, 231, 235)
            };

            int larguraUsada = (int)(740 * d.PorcentagemUso / 100);
            pnlBarra.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(larguraUsada, 20),
                BackColor = corUso
            });
            card.Controls.Add(pnlBarra);

            card.Controls.Add(new Label
            {
                Text = $"📊  Usado: {MaintenanceService.FormatarBytes(d.EspacoUsadoBytes)}  de  {MaintenanceService.FormatarBytes(d.EspacoTotalBytes)}  ({d.PorcentagemUso:0}%)",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location = new Point(15, 70),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = d.Alerta,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = corUso,
                Location = new Point(15, 88),
                AutoSize = true
            });

            return card;
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
            Application.DoEvents();
        }

        private Color ObterCorPontuacao(int pontuacao)
        {
            if (pontuacao >= 85) return Color.FromArgb(22, 163, 74);
            if (pontuacao >= 70) return Color.FromArgb(37, 99, 235);
            if (pontuacao >= 50) return Color.FromArgb(234, 88, 12);
            return Color.FromArgb(220, 38, 38);
        }

        private Color ObterCorPorcentagem(double pct)
        {
            if (pct >= 95) return Color.FromArgb(220, 38, 38);
            if (pct >= 85) return Color.FromArgb(234, 88, 12);
            if (pct >= 70) return Color.FromArgb(234, 179, 8);
            return Color.FromArgb(22, 163, 74);
        }
    }
}