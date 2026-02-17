namespace WindowsFormsApp1
{
    partial class FormDesempenho
    {
        /// <summary>
        /// Variavel de designer necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estao sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessario descartar os recursos gerenciados; caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo gerado pelo Windows Form Designer

        /// <summary>
        /// Metodo necessario para suporte ao Designer - nao modifique 
        /// o conteudo deste metodo com o editor de codigo.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMemoria = new System.Windows.Forms.TabPage();
            this.listViewMemoria = new System.Windows.Forms.ListView();
            this.columnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMemoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExplicacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabProcessos = new System.Windows.Forms.TabPage();
            this.listViewProcessos = new System.Windows.Forms.ListView();
            this.columnProcesso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMemoriaProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDisco = new System.Windows.Forms.TabPage();
            this.listViewDisco = new System.Windows.Forms.ListView();
            this.columnPasta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTamanho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOQue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabInicializacao = new System.Windows.Forms.TabPage();
            this.listViewInicializacao = new System.Windows.Forms.ListView();
            this.columnPrograma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnImpacto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExplicacaoInit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.labelResumo = new System.Windows.Forms.Label();
            this.panelResumo = new System.Windows.Forms.Panel();
            this.progressBarDisco = new System.Windows.Forms.ProgressBar();
            this.progressBarMemoria = new System.Windows.Forms.ProgressBar();
            this.labelDiscoUsado = new System.Windows.Forms.Label();
            this.labelDiscoTotal = new System.Windows.Forms.Label();
            this.labelMemoriaUsada = new System.Windows.Forms.Label();
            this.labelMemoriaTotal = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelDica = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabMemoria.SuspendLayout();
            this.tabProcessos.SuspendLayout();
            this.tabDisco.SuspendLayout();
            this.tabInicializacao.SuspendLayout();
            this.panelResumo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMemoria);
            this.tabControl1.Controls.Add(this.tabProcessos);
            this.tabControl1.Controls.Add(this.tabDisco);
            this.tabControl1.Controls.Add(this.tabInicializacao);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 160);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMemoria
            // 
            this.tabMemoria.Controls.Add(this.listViewMemoria);
            this.tabMemoria.Location = new System.Drawing.Point(4, 25);
            this.tabMemoria.Name = "tabMemoria";
            this.tabMemoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabMemoria.Size = new System.Drawing.Size(1152, 449);
            this.tabMemoria.TabIndex = 0;
            this.tabMemoria.Text = "Memoria RAM (O que esta usando agora)";
            this.tabMemoria.UseVisualStyleBackColor = true;
            // 
            // listViewMemoria
            // 
            this.listViewMemoria.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNome,
            this.columnMemoria,
            this.columnExplicacao});
            this.listViewMemoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMemoria.FullRowSelect = true;
            this.listViewMemoria.GridLines = true;
            this.listViewMemoria.HideSelection = false;
            this.listViewMemoria.Location = new System.Drawing.Point(3, 3);
            this.listViewMemoria.Name = "listViewMemoria";
            this.listViewMemoria.Size = new System.Drawing.Size(1146, 443);
            this.listViewMemoria.TabIndex = 0;
            this.listViewMemoria.UseCompatibleStateImageBehavior = false;
            this.listViewMemoria.View = System.Windows.Forms.View.Details;
            // 
            // columnNome
            // 
            this.columnNome.Text = "Nome do Programa";
            this.columnNome.Width = 250;
            // 
            // columnMemoria
            // 
            this.columnMemoria.Text = "Memoria Usada";
            this.columnMemoria.Width = 150;
            // 
            // columnExplicacao
            // 
            this.columnExplicacao.Text = "O que e isso? (Explicacao Simples)";
            this.columnExplicacao.Width = 700;
            // 
            // tabProcessos
            // 
            this.tabProcessos.Controls.Add(this.listViewProcessos);
            this.tabProcessos.Location = new System.Drawing.Point(4, 25);
            this.tabProcessos.Name = "tabProcessos";
            this.tabProcessos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessos.Size = new System.Drawing.Size(1152, 449);
            this.tabProcessos.TabIndex = 1;
            this.tabProcessos.Text = "Programas Rodando (O que esta deixando lento)";
            this.tabProcessos.UseVisualStyleBackColor = true;
            // 
            // listViewProcessos
            // 
            this.listViewProcessos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnProcesso,
            this.columnCPU,
            this.columnMemoriaProc,
            this.columnDescricao});
            this.listViewProcessos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcessos.FullRowSelect = true;
            this.listViewProcessos.GridLines = true;
            this.listViewProcessos.HideSelection = false;
            this.listViewProcessos.Location = new System.Drawing.Point(3, 3);
            this.listViewProcessos.Name = "listViewProcessos";
            this.listViewProcessos.Size = new System.Drawing.Size(1146, 443);
            this.listViewProcessos.TabIndex = 0;
            this.listViewProcessos.UseCompatibleStateImageBehavior = false;
            this.listViewProcessos.View = System.Windows.Forms.View.Details;
            // 
            // columnProcesso
            // 
            this.columnProcesso.Text = "Nome do Programa";
            this.columnProcesso.Width = 250;
            // 
            // columnCPU
            // 
            this.columnCPU.Text = "Uso do Processador";
            this.columnCPU.Width = 150;
            // 
            // columnMemoriaProc
            // 
            this.columnMemoriaProc.Text = "Memoria";
            this.columnMemoriaProc.Width = 120;
            // 
            // columnDescricao
            // 
            this.columnDescricao.Text = "O que faz? (Explicacao)";
            this.columnDescricao.Width = 600;
            // 
            // tabDisco
            // 
            this.tabDisco.Controls.Add(this.listViewDisco);
            this.tabDisco.Location = new System.Drawing.Point(4, 25);
            this.tabDisco.Name = "tabDisco";
            this.tabDisco.Size = new System.Drawing.Size(1152, 449);
            this.tabDisco.TabIndex = 2;
            this.tabDisco.Text = "Espaco no HD/SSD (O que ocupa lugar)";
            this.tabDisco.UseVisualStyleBackColor = true;
            // 
            // listViewDisco
            // 
            this.listViewDisco.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPasta,
            this.columnTamanho,
            this.columnOQue});
            this.listViewDisco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDisco.FullRowSelect = true;
            this.listViewDisco.GridLines = true;
            this.listViewDisco.HideSelection = false;
            this.listViewDisco.Location = new System.Drawing.Point(0, 0);
            this.listViewDisco.Name = "listViewDisco";
            this.listViewDisco.Size = new System.Drawing.Size(1152, 449);
            this.listViewDisco.TabIndex = 0;
            this.listViewDisco.UseCompatibleStateImageBehavior = false;
            this.listViewDisco.View = System.Windows.Forms.View.Details;
            // 
            // columnPasta
            // 
            this.columnPasta.Text = "Local/Pasta";
            this.columnPasta.Width = 300;
            // 
            // columnTamanho
            // 
            this.columnTamanho.Text = "Tamanho";
            this.columnTamanho.Width = 150;
            // 
            // columnOQue
            // 
            this.columnOQue.Text = "O que tem aqui?";
            this.columnOQue.Width = 650;
            // 
            // tabInicializacao
            // 
            this.tabInicializacao.Controls.Add(this.listViewInicializacao);
            this.tabInicializacao.Location = new System.Drawing.Point(4, 25);
            this.tabInicializacao.Name = "tabInicializacao";
            this.tabInicializacao.Size = new System.Drawing.Size(1152, 449);
            this.tabInicializacao.TabIndex = 3;
            this.tabInicializacao.Text = "Programas que Iniciam Sozinhos";
            this.tabInicializacao.UseVisualStyleBackColor = true;
            // 
            // listViewInicializacao
            // 
            this.listViewInicializacao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPrograma,
            this.columnImpacto,
            this.columnExplicacaoInit});
            this.listViewInicializacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInicializacao.FullRowSelect = true;
            this.listViewInicializacao.GridLines = true;
            this.listViewInicializacao.HideSelection = false;
            this.listViewInicializacao.Location = new System.Drawing.Point(0, 0);
            this.listViewInicializacao.Name = "listViewInicializacao";
            this.listViewInicializacao.Size = new System.Drawing.Size(1152, 449);
            this.listViewInicializacao.TabIndex = 0;
            this.listViewInicializacao.UseCompatibleStateImageBehavior = false;
            this.listViewInicializacao.View = System.Windows.Forms.View.Details;
            // 
            // columnPrograma
            // 
            this.columnPrograma.Text = "Programa";
            this.columnPrograma.Width = 250;
            // 
            // columnImpacto
            // 
            this.columnImpacto.Text = "Impacto na Inicializacao";
            this.columnImpacto.Width = 180;
            // 
            // columnExplicacaoInit
            // 
            this.columnExplicacaoInit.Text = "O que e e para que serve?";
            this.columnExplicacaoInit.Width = 650;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(982, 644);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(190, 45);
            this.btnAtualizar.TabIndex = 1;
            this.btnAtualizar.Text = "Atualizar Dados";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // labelResumo
            // 
            this.labelResumo.AutoSize = true;
            this.labelResumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResumo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelResumo.Location = new System.Drawing.Point(12, 9);
            this.labelResumo.Name = "labelResumo";
            this.labelResumo.Size = new System.Drawing.Size(389, 26);
            this.labelResumo.TabIndex = 2;
            this.labelResumo.Text = "Resumo do Seu Computador Agora";
            // 
            // panelResumo
            // 
            this.panelResumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelResumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelResumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResumo.Controls.Add(this.progressBarDisco);
            this.panelResumo.Controls.Add(this.progressBarMemoria);
            this.panelResumo.Controls.Add(this.labelDiscoUsado);
            this.panelResumo.Controls.Add(this.labelDiscoTotal);
            this.panelResumo.Controls.Add(this.labelMemoriaUsada);
            this.panelResumo.Controls.Add(this.labelMemoriaTotal);
            this.panelResumo.Location = new System.Drawing.Point(12, 38);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(1160, 100);
            this.panelResumo.TabIndex = 3;
            // 
            // progressBarDisco
            // 
            this.progressBarDisco.Location = new System.Drawing.Point(593, 58);
            this.progressBarDisco.Name = "progressBarDisco";
            this.progressBarDisco.Size = new System.Drawing.Size(550, 30);
            this.progressBarDisco.TabIndex = 5;
            // 
            // progressBarMemoria
            // 
            this.progressBarMemoria.Location = new System.Drawing.Point(13, 58);
            this.progressBarMemoria.Name = "progressBarMemoria";
            this.progressBarMemoria.Size = new System.Drawing.Size(550, 30);
            this.progressBarMemoria.TabIndex = 4;
            // 
            // labelDiscoUsado
            // 
            this.labelDiscoUsado.AutoSize = true;
            this.labelDiscoUsado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiscoUsado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDiscoUsado.Location = new System.Drawing.Point(590, 33);
            this.labelDiscoUsado.Name = "labelDiscoUsado";
            this.labelDiscoUsado.Size = new System.Drawing.Size(105, 15);
            this.labelDiscoUsado.TabIndex = 3;
            this.labelDiscoUsado.Text = "Usado: 0 GB (0%)";
            // 
            // labelDiscoTotal
            // 
            this.labelDiscoTotal.AutoSize = true;
            this.labelDiscoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiscoTotal.Location = new System.Drawing.Point(590, 10);
            this.labelDiscoTotal.Name = "labelDiscoTotal";
            this.labelDiscoTotal.Size = new System.Drawing.Size(252, 18);
            this.labelDiscoTotal.TabIndex = 2;
            this.labelDiscoTotal.Text = "Espaco no Disco: 0 GB de 0 GB";
            // 
            // labelMemoriaUsada
            // 
            this.labelMemoriaUsada.AutoSize = true;
            this.labelMemoriaUsada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemoriaUsada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMemoriaUsada.Location = new System.Drawing.Point(10, 33);
            this.labelMemoriaUsada.Name = "labelMemoriaUsada";
            this.labelMemoriaUsada.Size = new System.Drawing.Size(146, 15);
            this.labelMemoriaUsada.TabIndex = 1;
            this.labelMemoriaUsada.Text = "Em uso agora: 0 GB (0%)";
            // 
            // labelMemoriaTotal
            // 
            this.labelMemoriaTotal.AutoSize = true;
            this.labelMemoriaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemoriaTotal.Location = new System.Drawing.Point(10, 10);
            this.labelMemoriaTotal.Name = "labelMemoriaTotal";
            this.labelMemoriaTotal.Size = new System.Drawing.Size(272, 18);
            this.labelMemoriaTotal.TabIndex = 0;
            this.labelMemoriaTotal.Text = "Memoria RAM Total: 0 GB de 0 GB";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelDica
            // 
            this.labelDica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDica.AutoSize = true;
            this.labelDica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDica.Location = new System.Drawing.Point(14, 660);
            this.labelDica.Name = "labelDica";
            this.labelDica.Size = new System.Drawing.Size(462, 15);
            this.labelDica.TabIndex = 4;
            this.labelDica.Text = "Dica: Clique em qualquer linha para ver mais detalhes. Atualiza a cada 2 segundos" +
    ".";
            // 
            // FormDesempenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 701);
            this.Controls.Add(this.labelDica);
            this.Controls.Add(this.panelResumo);
            this.Controls.Add(this.labelResumo);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1200, 740);
            this.Name = "FormDesempenho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entenda Seu Computador - Simplificador para Leigos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMemoria.ResumeLayout(false);
            this.tabProcessos.ResumeLayout(false);
            this.tabDisco.ResumeLayout(false);
            this.tabInicializacao.ResumeLayout(false);
            this.panelResumo.ResumeLayout(false);
            this.panelResumo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMemoria;
        private System.Windows.Forms.TabPage tabProcessos;
        private System.Windows.Forms.TabPage tabDisco;
        private System.Windows.Forms.TabPage tabInicializacao;
        private System.Windows.Forms.ListView listViewMemoria;
        private System.Windows.Forms.ColumnHeader columnNome;
        private System.Windows.Forms.ColumnHeader columnMemoria;
        private System.Windows.Forms.ColumnHeader columnExplicacao;
        private System.Windows.Forms.ListView listViewProcessos;
        private System.Windows.Forms.ColumnHeader columnProcesso;
        private System.Windows.Forms.ColumnHeader columnCPU;
        private System.Windows.Forms.ColumnHeader columnMemoriaProc;
        private System.Windows.Forms.ColumnHeader columnDescricao;
        private System.Windows.Forms.ListView listViewDisco;
        private System.Windows.Forms.ColumnHeader columnPasta;
        private System.Windows.Forms.ColumnHeader columnTamanho;
        private System.Windows.Forms.ColumnHeader columnOQue;
        private System.Windows.Forms.ListView listViewInicializacao;
        private System.Windows.Forms.ColumnHeader columnPrograma;
        private System.Windows.Forms.ColumnHeader columnImpacto;
        private System.Windows.Forms.ColumnHeader columnExplicacaoInit;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label labelResumo;
        private System.Windows.Forms.Panel panelResumo;
        private System.Windows.Forms.Label labelMemoriaTotal;
        private System.Windows.Forms.Label labelMemoriaUsada;
        private System.Windows.Forms.Label labelDiscoTotal;
        private System.Windows.Forms.Label labelDiscoUsado;
        private System.Windows.Forms.ProgressBar progressBarMemoria;
        private System.Windows.Forms.ProgressBar progressBarDisco;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelDica;
    }
}