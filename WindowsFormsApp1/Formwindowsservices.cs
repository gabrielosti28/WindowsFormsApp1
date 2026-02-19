using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormWindowsServices : Form
    {
        private List<ServicoDoWindows> _todosServicos = new List<ServicoDoWindows>();
        private ServicoDoWindows _selecionado = null;

        // Cores do tema
        private readonly Color CorFundo = Color.FromArgb(245, 247, 250);
        private readonly Color CorPainel = Color.White;
        private readonly Color CorDestaque = Color.FromArgb(41, 128, 185);
        private readonly Color CorVerde = Color.FromArgb(39, 174, 96);
        private readonly Color CorVermelho = Color.FromArgb(192, 57, 43);
        private readonly Color CorAmarelo = Color.FromArgb(243, 156, 18);
        private readonly Color CorTexto = Color.FromArgb(44, 62, 80);
        private readonly Color CorTextoCinza = Color.FromArgb(127, 140, 141);

        public FormWindowsServices()
        {
            InitializeComponent();
        }

        private void FormWindowsServices_Load(object sender, EventArgs e)
        {
            CarregarServicos();
            // Verificar ação rápida de impressora
            VerificarAcoesRapidas();
        }

        private void CarregarServicos()
        {
            lblStatus.Text = "⏳ Carregando serviços...";
            lblStatus.ForeColor = CorAmarelo;
            Application.DoEvents();

            _todosServicos = WindowsServicesService.ObterServicos();

            cmbCategoria.Items.Clear();
            foreach (var cat in WindowsServicesService.ObterCategorias())
                cmbCategoria.Items.Add(cat);
            cmbCategoria.SelectedIndex = 0;

            AplicarFiltro();
            lblStatus.Text = $"✅ {_todosServicos.Count} serviços carregados.";
            lblStatus.ForeColor = CorVerde;
        }

        private void AplicarFiltro()
        {
            string termoBusca = txtBusca.Text.Trim().ToLower();
            string catSel = cmbCategoria.SelectedItem?.ToString() ?? "Todos";
            string filtroStatus = cmbStatus.SelectedItem?.ToString() ?? "Todos";

            var filtrado = _todosServicos.AsEnumerable();

            if (catSel != "Todos")
                filtrado = filtrado.Where(s => s.Categoria == catSel);

            if (!string.IsNullOrEmpty(termoBusca))
                filtrado = filtrado.Where(s =>
                    s.NomeAmigavel.ToLower().Contains(termoBusca) ||
                    s.NomeTecnico.ToLower().Contains(termoBusca) ||
                    (s.ParaQueServe?.ToLower().Contains(termoBusca) ?? false));

            if (filtroStatus == "Funcionando") filtrado = filtrado.Where(s => s.StatusAtual == "Funcionando");
            if (filtroStatus == "Desligado") filtrado = filtrado.Where(s => s.StatusAtual == "Desligado");
            if (filtroStatus == "Importantes") filtrado = filtrado.Where(s => s.EhCritico);
            if (filtroStatus == "Pode Desligar") filtrado = filtrado.Where(s => s.PodeSerDesligado);

            PreencherLista(filtrado.ToList());
        }

        private void PreencherLista(List<ServicoDoWindows> servicos)
        {
            lvServicos.BeginUpdate();
            lvServicos.Items.Clear();

            foreach (var s in servicos)
            {
                var item = new ListViewItem($"{s.Emoji} {s.NomeAmigavel}");
                item.SubItems.Add(s.StatusEmoji + " " + s.StatusAtual);
                item.SubItems.Add(s.Categoria ?? "");
                item.SubItems.Add(s.TipoDeInicio ?? "");
                item.Tag = s;

                // Cor de fundo por status
                if (s.EhCritico && s.StatusAtual == "Desligado")
                    item.BackColor = Color.FromArgb(254, 235, 233);
                else if (s.NomeTecnico.Equals("RemoteRegistry", StringComparison.OrdinalIgnoreCase) && s.StatusAtual == "Funcionando")
                    item.BackColor = Color.FromArgb(255, 248, 220);
                else if (s.StatusAtual == "Funcionando")
                    item.BackColor = Color.FromArgb(235, 252, 243);
                else
                    item.BackColor = Color.FromArgb(248, 248, 248);

                lvServicos.Items.Add(item);
            }

            lvServicos.EndUpdate();
            lblContagem.Text = $"{servicos.Count} serviços";
        }

        private void lvServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvServicos.SelectedItems.Count == 0) { LimparDetalhes(); return; }
            _selecionado = lvServicos.SelectedItems[0].Tag as ServicoDoWindows;
            if (_selecionado == null) return;
            MostrarDetalhes(_selecionado);
        }

        private void MostrarDetalhes(ServicoDoWindows s)
        {
            lblNomeServico.Text = $"{s.Emoji} {s.NomeAmigavel}";
            lblNomeTecnico.Text = $"Nome interno: {s.NomeTecnico}";

            // Status
            lblStatusServico.Text = $"{s.StatusEmoji} {s.StatusAtual}";
            lblStatusServico.ForeColor = s.StatusAtual == "Funcionando" ? CorVerde : CorVermelho;

            // Tipo de início
            lblTipoInicio.Text = $"🔁 {s.TipoDeInicio}";

            // Explicações
            txtOQueEste.Text = s.OQueEste ?? "";
            txtParaQueServe.Text = s.ParaQueServe ?? "";
            txtSeDesligar.Text = s.OQueAconteceSeDesligar ?? "";
            lblRecomendacao.Text = s.Recomendacao ?? "";

            // Ação rápida
            if (!string.IsNullOrEmpty(s.AcaoRapida))
            {
                btnAcaoRapida.Text = s.AcaoRapida;
                btnAcaoRapida.Visible = true;
            }
            else btnAcaoRapida.Visible = false;

            // Botões de controle
            btnIniciar.Enabled = s.StatusAtual == "Desligado";
            btnParar.Enabled = s.StatusAtual == "Funcionando" && !s.EhCritico;
            btnReiniciar.Enabled = s.StatusAtual == "Funcionando";

            // Aviso de crítico
            if (s.EhCritico)
            {
                lblAvisoCritico.Text = "⚠️ Este é um serviço importante do Windows. Alterar pode afetar o funcionamento do computador.";
                lblAvisoCritico.Visible = true;
                btnParar.Enabled = false;
            }
            else lblAvisoCritico.Visible = false;
        }

        private void LimparDetalhes()
        {
            lblNomeServico.Text = "Selecione um serviço para ver detalhes";
            lblNomeTecnico.Text = "";
            lblStatusServico.Text = "";
            txtOQueEste.Text = "";
            txtParaQueServe.Text = "";
            txtSeDesligar.Text = "";
            lblRecomendacao.Text = "";
            btnIniciar.Enabled = false;
            btnParar.Enabled = false;
            btnReiniciar.Enabled = false;
            btnAcaoRapida.Visible = false;
            lblAvisoCritico.Visible = false;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;
            if (!ConfirmarAcao($"Reiniciar o serviço\n\n\"{_selecionado.NomeAmigavel}\"?\n\nIsso é útil quando o serviço está com problema. O serviço será parado e iniciado novamente.")) return;

            ExecutarComFeedback(() =>
            {
                var (ok, msg) = WindowsServicesService.ReiniciarServico(_selecionado.NomeTecnico);
                return (ok, msg);
            }, "Reiniciando...");
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;
            if (!ConfirmarAcao($"Desligar o serviço\n\n\"{_selecionado.NomeAmigavel}\"?\n\n⚠️ O que acontece se desligar:\n{_selecionado.OQueAconteceSeDesligar}")) return;

            ExecutarComFeedback(() =>
            {
                var (ok, msg) = WindowsServicesService.PararServico(_selecionado.NomeTecnico);
                return (ok, msg);
            }, "Desligando...");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;
            ExecutarComFeedback(() =>
            {
                var (ok, msg) = WindowsServicesService.IniciarServico(_selecionado.NomeTecnico);
                return (ok, msg);
            }, "Iniciando...");
        }

        private void btnAcaoRapida_Click(object sender, EventArgs e)
        {
            // Ação rápida da impressora
            if (_selecionado?.NomeTecnico == "Spooler")
            {
                if (!ConfirmarAcao("Corrigir a impressora?\n\nVou reiniciar o serviço de fila de impressão. Isso resolve a maioria dos casos de impressora travada.\n\nQualquer impressão em andamento será cancelada.")) return;
                ExecutarComFeedback(() =>
                {
                    var (ok, msg) = WindowsServicesService.ReiniciarServico("Spooler");
                    return (ok, ok ? "✅ Fila de impressão reiniciada!\n\nTente imprimir novamente. Se ainda não funcionar, verifique se a impressora está ligada e conectada." : msg);
                }, "Corrigindo impressora...");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _selecionado = null;
            LimparDetalhes();
            CarregarServicos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltro();
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltro();
        private void txtBusca_TextChanged(object sender, EventArgs e) => AplicarFiltro();

        private void VerificarAcoesRapidas()
        {
            // Verificar se a impressora está travada
            var spooler = _todosServicos.FirstOrDefault(s =>
                s.NomeTecnico.Equals("Spooler", StringComparison.OrdinalIgnoreCase));
            if (spooler != null && !string.IsNullOrEmpty(spooler.AcaoRapida))
            {
                pnlAvisoImpressora.Visible = true;
                lblAvisoImpressora.Text = "🖨️ Dica: Se sua impressora está travada, selecione 'Fila de Impressão' na lista e clique em Reiniciar para corrigir.";
            }
        }

        private bool ConfirmarAcao(string mensagem) =>
            MessageBox.Show(mensagem, "Confirmar Ação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;

        private void ExecutarComFeedback(Func<(bool, string)> acao, string mensagemAguardo)
        {
            lblStatus.Text = $"⏳ {mensagemAguardo}";
            lblStatus.ForeColor = CorAmarelo;
            btnReiniciar.Enabled = btnParar.Enabled = btnIniciar.Enabled = false;
            Application.DoEvents();
            try
            {
                var (ok, msg) = acao();
                lblStatus.Text = ok ? "✅ Concluído" : "❌ Erro";
                lblStatus.ForeColor = ok ? CorVerde : CorVermelho;
                MessageBox.Show(msg, ok ? "✅ Sucesso" : "❌ Erro",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                // Atualiza o item na lista
                if (_selecionado != null)
                {
                    var atualizado = WindowsServicesService.ObterServicos()
                        .FirstOrDefault(s => s.NomeTecnico == _selecionado.NomeTecnico);
                    if (atualizado != null)
                    {
                        _selecionado = atualizado;
                        MostrarDetalhes(_selecionado);
                        // Atualiza item na listview
                        foreach (ListViewItem item in lvServicos.Items)
                            if ((item.Tag as ServicoDoWindows)?.NomeTecnico == atualizado.NomeTecnico)
                            {
                                item.SubItems[1].Text = atualizado.StatusEmoji + " " + atualizado.StatusAtual;
                                item.Tag = atualizado;
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Erro";
                lblStatus.ForeColor = CorVermelho;
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}