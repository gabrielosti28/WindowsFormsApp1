// ============================================================
//  FormMenuPrincipal.cs  —  Menu Principal (LÓGICA DO CÓDIGO)
//  NÃO ALTERE ESTE ARQUIVO PELO DESIGNER
// ============================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace AppInterno
{
    public partial class FormMenuPrincipal : Form
    {
        // ────────────────────────────────────────────────────────────────────
        // MODELO
        // ────────────────────────────────────────────────────────────────────
        private class Modulo
        {
            public string Icone, Titulo, Descricao, Tag;
            public Color Cor;
        }

        private readonly List<Modulo> _todos = new List<Modulo>
        {
            new Modulo { Icone="🖥", Titulo="Peças do Computador",     Descricao="Processador, memória, GPU e todos os componentes de hardware do seu PC.",        Tag="hardware",    Cor = Color.FromArgb(82, 130, 255) },
            new Modulo { Icone="📊", Titulo="Desempenho do Sistema",   Descricao="Monitore CPU, RAM, disco e processos em tempo real.",                            Tag="desempenho",  Cor = Color.FromArgb(255, 180, 50)  },
            new Modulo { Icone="🔌", Titulo="Drivers do Sistema",      Descricao="Verifique e atualize os drivers de todos os dispositivos instalados.",           Tag="drivers",     Cor = Color.FromArgb(82, 130, 255)  },
            new Modulo { Icone="⚙",  Titulo="Serviços do Windows",     Descricao="Gerencie o que roda em segundo plano — inicie, pare ou reinicie serviços.",      Tag="servicos",    Cor = Color.FromArgb(50, 200, 150)  },
            new Modulo { Icone="🧹", Titulo="Manutenção e Limpeza",    Descricao="Check-up completo, limpeza de arquivos temporários e otimização do boot.",       Tag="manutencao",  Cor = Color.FromArgb(50, 200, 150)  },
            new Modulo { Icone="🔐", Titulo="Privacidade e Segurança", Descricao="Controle telemetria, microfone, câmera, UAC e permissões de aplicativos.",       Tag="privacidade", Cor = Color.FromArgb(240, 100, 80)  },
            new Modulo { Icone="📋", Titulo="Central de Eventos",      Descricao="Entenda erros, logins, desligamentos e avisos do sistema em português claro.",   Tag="eventos",     Cor = Color.FromArgb(255, 180, 50)  },
            new Modulo { Icone="🎛",  Titulo="Painel de Controle",     Descricao="Configure tela, energia, rede, usuários e inicialização de forma simplificada.", Tag="painel",      Cor = Color.FromArgb(200, 130, 255) },
            new Modulo { Icone="⌨",  Titulo="Atalhos de Teclado",     Descricao="Guia completo de atalhos do Windows, Excel e Word com explicações práticas.",     Tag="atalhos",     Cor = Color.FromArgb(200, 130, 255) },
            new Modulo { Icone="📱", Titulo="Apps Nativos do Windows", Descricao="Descubra programas úteis que já vêm instalados e prontos para usar.",            Tag="apps",        Cor = Color.FromArgb(200, 130, 255) },
            new Modulo { Icone="💡", Titulo="Dicas e Truques",         Descricao="Aprenda truques avançados do Windows com guia passo a passo.",                   Tag="dicas",       Cor = Color.FromArgb(60, 190, 230)  },
            new Modulo { Icone="💻", Titulo="Comandos Ocultos",        Descricao="Execute ferramentas poderosas do Windows com explicações claras e segurança.",    Tag="comandos",    Cor = Color.FromArgb(60, 190, 230)  },
        };

        // ────────────────────────────────────────────────────────────────────
        // CONSTRUTOR
        // ────────────────────────────────────────────────────────────────────
        public FormMenuPrincipal()
        {
            InitializeComponent();
            // FIX: usar evento Load via override em vez de lambda anônima
        }

        // FIX: substituir o Load via lambda por override — mais seguro e sem referências nulas
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarDados();
        }

        // ────────────────────────────────────────────────────────────────────
        // DETECÇÃO DO WINDOWS
        // ────────────────────────────────────────────────────────────────────
        private static string ObterNomeWindows()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(
                    "SELECT Caption FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string caption = obj["Caption"]?.ToString() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(caption))
                            return caption.Replace("Microsoft ", "").Trim();
                    }
                }
            }
            catch { /* Fallback seguro abaixo */ }

            return "Windows";
        }

        // ────────────────────────────────────────────────────────────────────
        // CARREGAR DADOS DO SISTEMA
        // ────────────────────────────────────────────────────────────────────
        private void CarregarDados()
        {
            string os = ObterNomeWindows();
            string usuario = Environment.UserName;
            string maquina = Environment.MachineName;

            // FIX: usar diretamente os controles do Designer (sem campos duplicados _grid/_busca)
            lblOSValor.Text = os.Length > 20 ? os.Substring(0, 19) + "…" : os;
            lblUsuarioValor.Text = usuario.Length > 14 ? usuario.Substring(0, 13) + "…" : usuario;
            lblMaquinaValor.Text = maquina.Length > 14 ? maquina.Substring(0, 13) + "…" : maquina;

            // Renderizar todos os cards inicialmente
            RenderCards(_todos);
        }

        // ────────────────────────────────────────────────────────────────────
        // CARDS
        // ────────────────────────────────────────────────────────────────────
        private void RenderCards(IEnumerable<Modulo> lista)
        {
            // FIX: usar gridCards do Designer em vez de campo _grid nunca inicializado
            gridCards.SuspendLayout();
            gridCards.Controls.Clear();

            foreach (var m in lista)
                gridCards.Controls.Add(CriarCard(m));

            gridCards.ResumeLayout();
        }

        private Panel CriarCard(Modulo m)
        {
            const int W = 265, H = 152;

            var card = new Panel
            {
                Size = new Size(W, H),
                BackColor = Color.FromArgb(22, 26, 40),
                Margin = new Padding(0, 0, 10, 10),
                Cursor = Cursors.Hand,
            };

            var topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 3,
                BackColor = m.Cor,
            };

            var lblIco = new Label
            {
                Text = m.Icone,
                Font = new Font("Segoe UI Emoji", 20f),
                ForeColor = m.Cor,
                AutoSize = true,
                Location = new Point(14, 14),
            };

            var lblTit = new Label
            {
                Text = m.Titulo,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 225, 240),
                AutoSize = false,
                Size = new Size(W - 20, 36),
                Location = new Point(14, 60),
            };

            var lblDesc = new Label
            {
                Text = m.Descricao,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(130, 140, 170),
                AutoSize = false,
                Size = new Size(W - 20, 46),
                Location = new Point(14, 96),
            };

            var lblSeta = new Label
            {
                Text = "→",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = m.Cor,
                AutoSize = true,
                Location = new Point(W - 28, H - 24),
            };

            // Borda do card desenhada via Paint
            card.Paint += (s, e) =>
            {
                using (var p = new Pen(Color.FromArgb(40, 46, 68)))
                    e.Graphics.DrawRectangle(p, 0, 0, card.Width - 1, card.Height - 1);
            };

            card.Controls.AddRange(new Control[] { topBar, lblIco, lblTit, lblDesc, lblSeta });

            // Efeito hover
            Action<bool> hover = h =>
            {
                card.BackColor = h ? Color.FromArgb(30, 36, 55) : Color.FromArgb(22, 26, 40);
                topBar.Height = h ? 4 : 3;
                lblSeta.Left = h ? W - 22 : W - 28;
                card.Invalidate();
            };

            // FIX: aplicar eventos em todos os filhos para evitar "buracos" no hover
            foreach (Control c in card.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.Click += (s, e) => AbrirModulo(m);
                c.MouseEnter += (s, e) => hover(true);
                c.MouseLeave += (s, e) => hover(false);
            }

            card.Click += (s, e) => AbrirModulo(m);
            card.MouseEnter += (s, e) => hover(true);
            card.MouseLeave += (s, e) => hover(false);

            return card;
        }

        // ────────────────────────────────────────────────────────────────────
        // FILTRO DE BUSCA
        // ────────────────────────────────────────────────────────────────────
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            // FIX: usar txtBusca do Designer em vez de campo _busca nunca inicializado
            string texto = txtBusca.Text;

            if (string.IsNullOrWhiteSpace(texto))
            {
                RenderCards(_todos);
                return;
            }

            string t = texto.ToLowerInvariant();

            RenderCards(_todos.FindAll(m =>
                m.Titulo.ToLowerInvariant().Contains(t) ||
                m.Descricao.ToLowerInvariant().Contains(t) ||
                m.Tag.ToLowerInvariant().Contains(t)));        // FIX: busca também pela tag
        }

        // ────────────────────────────────────────────────────────────────────
        // ABRIR MÓDULO
        // ────────────────────────────────────────────────────────────────────
        private void AbrirModulo(Modulo m)
        {
            Form form = null;
            try
            {
                switch (m.Tag)
                {
                    case "hardware": form = new FormHardware(); break;
                    case "desempenho": form = new WindowsFormsApp1.FormDesempenho(); break;
                    case "drivers": form = new FormDrivers(); break;
                    case "servicos": form = new GuiaDoComputador.FormWindowsServices(); break;
                    case "manutencao": form = new GuiaDoComputador.FormMaintenance(); break;
                    case "privacidade": form = new GuiaDoComputador.FormPrivacy(); break;
                    case "eventos": form = new GuiaDoComputador.FormEvents(); break;
                    case "painel": form = new GuiaDoComputador.FormControlPanel(); break;
                    case "atalhos": form = new FormSelecaoAtalhos(); break;
                    case "apps": form = new FormAppsNativos(); break;
                    case "dicas": form = new FormDicasTruques(); break;
                    case "comandos": form = new GuiaDoComputador.FormSystemCommands(); break;

                    default:
                        MessageBox.Show(
                            $"O módulo \"{m.Titulo}\" ainda não está disponível.",
                            "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }

                // FIX: ShowDialog dentro do using — garante Dispose mesmo em exceção
                using (form)
                    form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // FIX: mostrar stack-trace resumida em modo Debug para facilitar diagnóstico
                string detalhe = System.Diagnostics.Debugger.IsAttached
                    ? $"\n\nDetalhe técnico:\n{ex}"
                    : string.Empty;

                MessageBox.Show(
                    $"Não foi possível abrir o módulo \"{m.Titulo}\".\n{ex.Message}{detalhe}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Garante que form seja descartado mesmo se ShowDialog lançar exceção fora do using
                // (o using já cobre isso, mas fica como salvaguarda)
            }
        }

        // ────────────────────────────────────────────────────────────────────
        // BOTÃO SAIR
        // ────────────────────────────────────────────────────────────────────
        private void btnSair_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Deseja realmente sair do Guia do Computador?",
                "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
                Application.Exit();
        }

        // ────────────────────────────────────────────────────────────────────
        // EVENTOS DE PINTURA
        // ────────────────────────────────────────────────────────────────────
        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Círculo de fundo do ícone
            using (var b = new SolidBrush(Color.FromArgb(40, 82, 130, 255)))
                g.FillEllipse(b, 14, 18, 50, 50);
            using (var p = new Pen(Color.FromArgb(82, 130, 255), 1.5f))
                g.DrawEllipse(p, 14, 18, 50, 50);

            // Ícone laptop
            using (var f = new Font("Segoe UI Emoji", 19f))
            using (var b = new SolidBrush(Color.FromArgb(82, 130, 255)))
                g.DrawString("💻", f, b, new PointF(17, 20));

            // Texto do logo
            using (var f = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(220, 225, 240)))
                g.DrawString("Guia do Computador", f, b, new PointF(72, 28));

            using (var f = new Font("Segoe UI", 7.5f))
            using (var b = new SolidBrush(Color.FromArgb(130, 140, 170)))
                g.DrawString("v1.0  •  Profissional", f, b, new PointF(73, 48));

            // Linha separadora
            using (var p = new Pen(Color.FromArgb(40, 46, 68)))
                g.DrawLine(p, 12, 88, 218, 88);
        }

        private void pnlSys_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Linha separadora no topo
            using (var p = new Pen(Color.FromArgb(40, 46, 68)))
                g.DrawLine(p, 12, 0, 218, 0);

            // Label "SISTEMA"
            using (var f = new Font("Segoe UI", 7f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(82, 130, 255)))
                g.DrawString("SISTEMA", f, b, 12, 10);
        }

        private void boxBusca_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(Color.FromArgb(40, 46, 68)))
                e.Graphics.DrawRectangle(p, 0, 0, 269, 32);
        }
    }
}