using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormEvents : Form
    {
        // =====================================================================
        // MODELOS
        // =====================================================================
        private class EventoTraduzido
        {
            public string Icone { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string DetalhesTecnicos { get; set; }
            public DateTime DataHora { get; set; }
            public string Categoria { get; set; }
            public EventLogEntryType Tipo { get; set; }
            public string Fonte { get; set; }
            public int EventId { get; set; }
        }

        // =====================================================================
        // ESTADO
        // =====================================================================
        private List<EventoTraduzido> _todosEventos = new List<EventoTraduzido>();
        private string _categoriaAtiva = "Todos";

        public FormEvents()
        {
           
            CarregarEventos();
        }

        private async void CarregarEventos()
        {
            panelCarregando.BringToFront();
            panelCarregando.Visible = true;

            _todosEventos = await Task.Run(() => LerEventos());

            panelCarregando.Visible = false;
            ExibirEventos("Todos");
        }

        private List<EventoTraduzido> LerEventos()
        {
            var lista = new List<EventoTraduzido>();

            lista.AddRange(LerLog("System", 150));
            lista.AddRange(LerLog("Application", 100));
            lista.AddRange(LerEventosLogin());

            lista = lista.OrderByDescending(e => e.DataHora).ToList();
            return lista;
        }

        private List<EventoTraduzido> LerLog(string logNome, int maxItens)
        {
            var lista = new List<EventoTraduzido>();
            try
            {
                using (var log = new EventLog(logNome))
                {
                    var entries = log.Entries.Cast<EventLogEntry>()
                        .Where(e => e.EntryType == EventLogEntryType.Error || e.EntryType == EventLogEntryType.Warning)
                        .OrderByDescending(e => e.TimeGenerated)
                        .Take(maxItens);

                    foreach (var entry in entries)
                    {
                        lista.Add(TraduzirEvento(entry, logNome));
                    }
                }
            }
            catch { /* sem acesso ao log */ }
            return lista;
        }

        private List<EventoTraduzido> LerEventosLogin()
        {
            var lista = new List<EventoTraduzido>();
            try
            {
                using (var log = new EventLog("Security"))
                {
                    var logins = log.Entries.Cast<EventLogEntry>()
                        .Where(e => e.InstanceId == 4624 || e.InstanceId == 4634 || e.InstanceId == 4647 || e.InstanceId == 6006 || e.InstanceId == 41)
                        .OrderByDescending(e => e.TimeGenerated)
                        .Take(100);

                    foreach (var entry in logins)
                    {
                        lista.Add(TraduzirEventoSeguranca(entry));
                    }
                }
            }
            catch { /* sem acesso ao log de segurança */ }
            return lista;
        }

        private EventoTraduzido TraduzirEvento(EventLogEntry entry, string logNome)
        {
            var ev = new EventoTraduzido
            {
                DataHora = entry.TimeGenerated,
                Tipo = entry.EntryType,
                Fonte = entry.Source,
                EventId = (int)(entry.InstanceId & 0xFFFF),
                DetalhesTecnicos = $"Fonte: {entry.Source} | ID: {entry.InstanceId} | Log: {logNome}"
            };

            var fonte = entry.Source?.ToLower() ?? "";

            if (fonte.Contains("disk") || fonte.Contains("ntfs"))
            {
                ev.Categoria = "Erros Críticos"; ev.Icone = "💾";
                ev.Titulo = "Problema com o disco rígido";
                ev.Descricao = "O Windows detectou um problema no seu disco rígido ou SSD. Isso pode indicar que seu disco está começando a falhar. Recomendamos fazer backup imediatamente e verificar o disco.";
            }
            else if (fonte.Contains("kernel-power") || fonte.Contains("eventlog"))
            {
                ev.Categoria = "Desligamentos"; ev.Icone = "⚡";
                ev.Titulo = "Desligamento inesperado";
                ev.Descricao = "O computador foi desligado de forma anormal — possivelmente por queda de energia, superaquecimento, ou travamento grave (tela azul). Se isso acontece com frequência, pode indicar problema de hardware.";
            }
            else if (fonte.Contains("winlogon") || fonte.Contains("user") || fonte.Contains("session"))
            {
                ev.Categoria = "Logins"; ev.Icone = "👤";
                ev.Titulo = "Atividade de usuário";
                ev.Descricao = "Evento relacionado ao login ou logout de um usuário no sistema.";
            }
            else if (fonte.Contains("msiinstaller") || fonte.Contains("application"))
            {
                ev.Categoria = "Instalações"; ev.Icone = "📦";
                ev.Titulo = "Instalação ou desinstalação de programa";
                ev.Descricao = $"O programa '{entry.Source}' foi instalado, atualizado ou desinstalado no seu computador.";
            }
            else if (entry.EntryType == EventLogEntryType.Error)
            {
                ev.Categoria = "Erros Críticos"; ev.Icone = "❌";
                ev.Titulo = $"Erro: {entry.Source}";
                ev.Descricao = TraduzirMensagemGenerica(entry.Message, entry.Source);
            }
            else
            {
                ev.Categoria = "Avisos"; ev.Icone = "⚠️";
                ev.Titulo = $"Aviso: {entry.Source}";
                ev.Descricao = TraduzirMensagemGenerica(entry.Message, entry.Source);
            }

            return ev;
        }

        private string TraduzirMensagemGenerica(string mensagem, string fonte)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                return $"O componente '{fonte}' registrou um evento no sistema. Para mais detalhes, consulte o Visualizador de Eventos do Windows.";

            var resumo = mensagem.Length > 200 ? mensagem.Substring(0, 200) + "..." : mensagem;
            return $"O Windows registrou uma ocorrência no componente '{fonte}'.\n\n" +
                   $"Mensagem técnica:\n{resumo}\n\n" +
                   $"Este tipo de aviso é geralmente inofensivo se ocorrer esporadicamente. Se for frequente, pode indicar um problema que merece atenção.";
        }

        private EventoTraduzido TraduzirEventoSeguranca(EventLogEntry entry)
        {
            var id = (int)(entry.InstanceId & 0xFFFF);

            if (id == 4624)
                return new EventoTraduzido { Categoria = "Logins", Icone = "🔓", Titulo = "Login realizado com sucesso", Descricao = "Um usuário fez login no computador com sucesso. Verifique a data e hora — se não foi você, pode indicar acesso não autorizado.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 4634 || id == 4647)
                return new EventoTraduzido { Categoria = "Logins", Icone = "🔒", Titulo = "Logout realizado", Descricao = "Um usuário saiu da sessão do Windows (logout ou bloqueio de tela).", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 6006)
                return new EventoTraduzido { Categoria = "Desligamentos", Icone = "🔌", Titulo = "Desligamento normal do sistema", Descricao = "O Windows foi desligado normalmente através do menu Iniciar > Desligar.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
            if (id == 41)
                return new EventoTraduzido { Categoria = "Desligamentos", Icone = "⚡", Titulo = "Desligamento inesperado (Kernel Power)", Descricao = "O computador foi desligado sem passar pelo processo normal de encerramento. Causas comuns: queda de energia, pressão acidental do botão de desligar, ou travamento grave (tela azul). Se frequente, verifique a fonte de alimentação e o sistema de refrigeração.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };

            return new EventoTraduzido { Categoria = "Logins", Icone = "🛡️", Titulo = $"Evento de segurança (ID {id})", Descricao = "Evento de segurança registrado pelo Windows.", DataHora = entry.TimeGenerated, Tipo = entry.EntryType, Fonte = entry.Source, EventId = id };
        }

        private void FiltroBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var categoria = btn.Tag as string;

            foreach (Control c in panelFiltros.Controls)
            {
                if (c is Button b)
                {
                    b.BackColor = Color.FromArgb(240, 245, 255);
                    b.ForeColor = Color.FromArgb(60, 70, 90);
                }
            }
            btn.BackColor = Color.FromArgb(79, 70, 229);
            btn.ForeColor = Color.White;

            _categoriaAtiva = categoria;
            ExibirEventos(categoria);
        }

        private void ExibirEventos(string categoria)
        {
            panelCards.Controls.Clear();

            var filtrados = categoria == "Todos"
                ? _todosEventos
                : _todosEventos.Where(e => e.Categoria == categoria).ToList();

            lblCount.Text = $"{filtrados.Count} eventos encontrados";

            if (filtrados.Count == 0)
            {
                var panelVazio = new Panel { Size = new Size(600, 200), BackColor = Color.Transparent };
                var lblVazio = new Label
                {
                    Text = "✨  Nenhum evento encontrado nesta categoria\n\n" +
                           "Boa notícia! Seu computador está funcionando perfeitamente.",
                    Font = new Font("Segoe UI", 12f),
                    ForeColor = Color.FromArgb(39, 174, 96),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                panelVazio.Controls.Add(lblVazio);
                panelCards.Controls.Add(panelVazio);
                return;
            }

            foreach (var ev in filtrados.Take(200))
            {
                panelCards.Controls.Add(CriarCardEvento(ev));
            }
        }

        private Panel CriarCardEvento(EventoTraduzido ev)
        {
            var card = new Panel
            {
                Size = new Size(645, 70),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Hand,
                Tag = ev
            };

            var corCategoria = ev.Categoria == "Erros Críticos" ? Color.FromArgb(239, 68, 68) :
                               ev.Categoria == "Avisos" ? Color.FromArgb(245, 158, 11) :
                               ev.Categoria == "Logins" ? Color.FromArgb(59, 130, 246) :
                               ev.Categoria == "Instalações" ? Color.FromArgb(16, 185, 129) :
                               ev.Categoria == "Desligamentos" ? Color.FromArgb(139, 92, 246) :
                               Color.FromArgb(107, 114, 128);

            var lblIco = new Label
            {
                Text = ev.Icone,
                Font = new Font("Segoe UI", 16f),
                Location = new Point(15, 10),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTit = new Label
            {
                Text = ev.Titulo,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(65, 12),
                Size = new Size(380, 20),
                AutoEllipsis = true
            };

            var lblDat = new Label
            {
                Text = ev.DataHora.ToString("dd/MM/yyyy • HH:mm") + "  |  " + ev.Categoria,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(65, 35),
                Size = new Size(380, 18)
            };

            var panelCor = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(4, 70),
                BackColor = corCategoria
            };

            card.Controls.AddRange(new Control[] { panelCor, lblIco, lblTit, lblDat });

            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(249, 250, 255);
                card.Refresh();
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.Refresh();
            };
            card.Click += (s, e) => MostrarDetalhe(ev);

            return card;
        }

        private void MostrarDetalhe(EventoTraduzido ev)
        {
            lblDetalheNome.Text = ev.Icone + "  " + ev.Titulo;
            lblDetalheData.Text = ev.DataHora.ToString("dddd, dd 'de' MMMM 'de' yyyy • HH:mm:ss");

            var descricaoCompleta = ev.Descricao;

            if (!string.IsNullOrEmpty(ev.DetalhesTecnicos))
            {
                descricaoCompleta += $"\n\n🔍 **Para os curiosos:**\n{ev.DetalhesTecnicos}";
            }

            descricaoCompleta += "\n\n💡 **Dica:** A maioria dos eventos do sistema é normal e não requer ação. " +
                                 "Fique atento apenas se o mesmo erro aparecer muitas vezes.";

            rtbDetalheDescricao.Text = descricaoCompleta;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 720);
            this.Name = "FormEvents";
            this.ResumeLayout(false);
        }
    }
}