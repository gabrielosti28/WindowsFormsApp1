using System.Drawing;
using System.Windows.Forms;
using System;

namespace GuiaDoComputador
{
    partial class FormSystemCommands
    {
        private System.ComponentModel.IContainer components = null;

        // Controles principais
        private Panel pnlTopo;
        private TabControl tabCategorias;
        private Panel panelDetalhe;

        // Controles do painel de detalhe
        private Label lblComandoSelecionado;
        private Label lblDescricaoDetalhe;
        private Label lblBeneficio;
        private Label lblImpacto;
        private Label lblQuandoUsar;
        private Label lblComandoBruto;
        private Button btnExecutar;
        private Button btnCopiar;
        private RichTextBox rtbSaida;
        private Label lblStatusExecucao;

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
            this.Text = "⌨️  Central de Comandos Ocultos do Windows  —  Guia do Computador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // =================================================================
            // PAINEL TOPO (Cabeçalho)
            // =================================================================
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Height = 85;
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlTopo.Padding = new System.Windows.Forms.Padding(25, 15, 25, 0);

            var lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "⌨️  Central de Comandos Ocultos";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 15);
            lblTitulo.Size = new System.Drawing.Size(450, 35);

            var lblSubtitulo = new System.Windows.Forms.Label();
            lblSubtitulo.Text = "Ferramentas poderosas do Windows — com explicações em português claro";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(191, 219, 254);
            lblSubtitulo.Location = new System.Drawing.Point(25, 50);
            lblSubtitulo.Size = new System.Drawing.Size(550, 22);

            var lblVersao = new System.Windows.Forms.Label();
            lblVersao.Text = "beta • v1.0";
            lblVersao.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblVersao.ForeColor = System.Drawing.Color.FromArgb(191, 219, 254);
            lblVersao.Location = new System.Drawing.Point(950, 30);
            lblVersao.Size = new System.Drawing.Size(100, 20);
            lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblVersao.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.pnlTopo.Controls.Add(lblTitulo);
            this.pnlTopo.Controls.Add(lblSubtitulo);
            this.pnlTopo.Controls.Add(lblVersao);

            // =================================================================
            // PAINEL DE DETALHES (Lado Direito)
            // =================================================================
            this.panelDetalhe = new System.Windows.Forms.Panel();
            this.panelDetalhe.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetalhe.Width = 380;
            this.panelDetalhe.BackColor = System.Drawing.Color.White;
            this.panelDetalhe.Padding = new System.Windows.Forms.Padding(20);

            // Sombra na borda esquerda
            this.panelDetalhe.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 0, 0, 0)))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, this.panelDetalhe.Height);
                }
            };

            // Título do detalhe
            var lblDetalheTitulo = new System.Windows.Forms.Label();
            lblDetalheTitulo.Text = "🔍  DETALHES DO COMANDO";
            lblDetalheTitulo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblDetalheTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDetalheTitulo.Location = new System.Drawing.Point(20, 20);
            lblDetalheTitulo.Size = new System.Drawing.Size(340, 20);

            // Nome do comando selecionado
            this.lblComandoSelecionado = new System.Windows.Forms.Label();
            this.lblComandoSelecionado.Text = "⌨️  Selecione um comando à esquerda";
            this.lblComandoSelecionado.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblComandoSelecionado.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblComandoSelecionado.Location = new System.Drawing.Point(20, 45);
            this.lblComandoSelecionado.Size = new System.Drawing.Size(340, 50);
            this.lblComandoSelecionado.AutoSize = false;

            // Descrição detalhada
            this.lblDescricaoDetalhe = new System.Windows.Forms.Label();
            this.lblDescricaoDetalhe.Text = "Clique em qualquer comando para ver uma explicação detalhada e executá-lo com segurança.";
            this.lblDescricaoDetalhe.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblDescricaoDetalhe.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDescricaoDetalhe.Location = new System.Drawing.Point(20, 95);
            this.lblDescricaoDetalhe.Size = new System.Drawing.Size(340, 70);
            this.lblDescricaoDetalhe.AutoSize = false;

            // Benefício
            this.lblBeneficio = new System.Windows.Forms.Label();
            this.lblBeneficio.Text = "";
            this.lblBeneficio.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblBeneficio.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBeneficio.Location = new System.Drawing.Point(20, 170);
            this.lblBeneficio.Size = new System.Drawing.Size(340, 20);
            this.lblBeneficio.AutoSize = false;

            // Impacto
            this.lblImpacto = new System.Windows.Forms.Label();
            this.lblImpacto.Text = "";
            this.lblImpacto.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblImpacto.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblImpacto.Location = new System.Drawing.Point(20, 190);
            this.lblImpacto.Size = new System.Drawing.Size(340, 20);
            this.lblImpacto.AutoSize = false;

            // Quando usar
            this.lblQuandoUsar = new System.Windows.Forms.Label();
            this.lblQuandoUsar.Text = "";
            this.lblQuandoUsar.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblQuandoUsar.ForeColor = System.Drawing.Color.FromArgb(147, 51, 234);
            this.lblQuandoUsar.Location = new System.Drawing.Point(20, 210);
            this.lblQuandoUsar.Size = new System.Drawing.Size(340, 20);
            this.lblQuandoUsar.AutoSize = false;

            // Separador
            var separator1 = new System.Windows.Forms.Label();
            separator1.Text = "────────────────";
            separator1.Font = new System.Drawing.Font("Segoe UI", 8f);
            separator1.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            separator1.Location = new System.Drawing.Point(20, 235);
            separator1.Size = new System.Drawing.Size(340, 15);

            // Label "Comando técnico"
            var lblComandoLabel = new System.Windows.Forms.Label();
            lblComandoLabel.Text = "📋  Comando técnico:";
            lblComandoLabel.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblComandoLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblComandoLabel.Location = new System.Drawing.Point(20, 255);
            lblComandoLabel.AutoSize = true;

            // Comando bruto (para copiar)
            this.lblComandoBruto = new System.Windows.Forms.Label();
            this.lblComandoBruto.Text = "—";
            this.lblComandoBruto.Font = new System.Drawing.Font("Consolas", 9f);
            this.lblComandoBruto.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblComandoBruto.Location = new System.Drawing.Point(20, 275);
            this.lblComandoBruto.Size = new System.Drawing.Size(340, 45);
            this.lblComandoBruto.AutoSize = false;
            this.lblComandoBruto.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.lblComandoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComandoBruto.Padding = new System.Windows.Forms.Padding(8);
            this.lblComandoBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Botão Executar
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnExecutar.Text = "▶  Executar Agora";
            this.btnExecutar.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnExecutar.ForeColor = System.Drawing.Color.White;
            this.btnExecutar.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.FlatAppearance.BorderSize = 0;
            this.btnExecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecutar.Location = new System.Drawing.Point(20, 330);
            this.btnExecutar.Size = new System.Drawing.Size(165, 45);
            this.btnExecutar.Enabled = false;
            this.btnExecutar.Click += new System.EventHandler(this.BtnExecutar_Click);

            // Botão Copiar
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnCopiar.Text = "📋  Copiar Comando";
            this.btnCopiar.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnCopiar.ForeColor = System.Drawing.Color.White;
            this.btnCopiar.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopiar.Location = new System.Drawing.Point(195, 330);
            this.btnCopiar.Size = new System.Drawing.Size(165, 45);
            this.btnCopiar.Enabled = false;
            this.btnCopiar.Click += new System.EventHandler(this.BtnCopiar_Click);

            // Status da execução
            this.lblStatusExecucao = new System.Windows.Forms.Label();
            this.lblStatusExecucao.Text = "";
            this.lblStatusExecucao.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblStatusExecucao.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblStatusExecucao.Location = new System.Drawing.Point(20, 385);
            this.lblStatusExecucao.Size = new System.Drawing.Size(340, 20);
            this.lblStatusExecucao.AutoSize = false;

            // Label "Resultado"
            var lblResultado = new System.Windows.Forms.Label();
            lblResultado.Text = "📟  Resultado da execução:";
            lblResultado.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblResultado.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblResultado.Location = new System.Drawing.Point(20, 410);
            lblResultado.AutoSize = true;

            // RichTextBox de saída
            this.rtbSaida = new System.Windows.Forms.RichTextBox();
            this.rtbSaida.Location = new System.Drawing.Point(20, 435);
            this.rtbSaida.Size = new System.Drawing.Size(340, 250);
            this.rtbSaida.Font = new System.Drawing.Font("Consolas", 9f);
            this.rtbSaida.BackColor = System.Drawing.Color.FromArgb(30, 35, 45);
            this.rtbSaida.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.rtbSaida.ReadOnly = true;
            this.rtbSaida.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbSaida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSaida.Text = "▶  Pressione 'Executar Agora' para rodar um comando...";

            // Adicionar controles ao painel de detalhe
            this.panelDetalhe.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDetalheTitulo,
                this.lblComandoSelecionado,
                this.lblDescricaoDetalhe,
                this.lblBeneficio,
                this.lblImpacto,
                this.lblQuandoUsar,
                separator1,
                lblComandoLabel,
                this.lblComandoBruto,
                this.btnExecutar,
                this.btnCopiar,
                this.lblStatusExecucao,
                lblResultado,
                this.rtbSaida
            });

            // =================================================================
            // TAB CONTROL (Categorias à esquerda)
            // =================================================================
            this.tabCategorias = new System.Windows.Forms.TabControl();
            this.tabCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCategorias.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.tabCategorias.Padding = new System.Drawing.Point(15, 8);

            // =================================================================
            // ADICIONAR CONTROLES AO FORMULÁRIO
            // =================================================================
            this.Controls.Add(this.tabCategorias);
            this.Controls.Add(this.panelDetalhe);
            this.Controls.Add(this.pnlTopo);

            // =================================================================
            // CONFIGURAÇÕES FINAIS
            // =================================================================
            this.Name = "FormSystemCommands";
            this.ResumeLayout(false);
        }

        // Método auxiliar para o evento de copiar
        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            if (lblComandoBruto.Text != "—")
            {
                Clipboard.SetText(lblComandoBruto.Text);
                var textoOriginal = btnCopiar.Text;
                btnCopiar.Text = "✔  Copiado!";
                btnCopiar.BackColor = Color.FromArgb(34, 197, 94);

                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, ev) =>
                {
                    btnCopiar.Text = textoOriginal;
                    btnCopiar.BackColor = Color.FromArgb(71, 85, 105);
                    timer.Stop();
                };
                timer.Start();
            }
        }
    }
}