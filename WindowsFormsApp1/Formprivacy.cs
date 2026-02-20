using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GuiaDoComputador
{
    public partial class FormPrivacy : Form
    {
        // =====================================================================
        // MODELO DE ITEM DE PRIVACIDADE
        // =====================================================================
        private class PrivacyItem
        {
            public string Icone { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string Categoria { get; set; }
            public Func<bool?> LerEstado { get; set; }
            public Action<bool> AplicarEstado { get; set; }
            public string Aviso { get; set; }
            public string DescricaoLigado { get; set; }
            public string DescricaoDesligado { get; set; }
        }

        private readonly List<PrivacyItem> _itens;
        private FlowLayoutPanel panelCards;
        private Panel panelDetalhe;
        private Label lblDetNome;
        private Label lblDetDescricao;
        private Label lblDetStatus;
        private Label lblDetAviso;
        private Button btnDetAtivar;
        private Button btnDetDesativar;
        private PrivacyItem _itemAtual;

        public FormPrivacy()
        {
            _itens = DefinirItens();
            InitializeComponent();
            ConstruirInterface();
            CarregarItens();
        }

        private List<PrivacyItem> DefinirItens()
        {
            return new List<PrivacyItem>
            {
                // --- Telemetria ---
                new PrivacyItem
                {
                    Categoria = "Telemetria e Dados",
                    Icone = "📡",
                    Titulo = "Telemetria do Windows",
                    Descricao = "O Windows coleta dados de uso e desempenho para enviar à Microsoft. Você pode reduzir o nível de coleta sem comprometer o funcionamento do sistema.",
                    DescricaoLigado = "Nível de telemetria reduzido (básico) — apenas dados essenciais de funcionamento são enviados à Microsoft.",
                    DescricaoDesligado = "Telemetria em nível padrão — dados de uso são enviados à Microsoft para melhorar o Windows.",
                    Aviso = "Reduzir a telemetria não afeta o funcionamento do Windows. O nível mínimo mantém apenas dados de falhas críticas.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", -1);
                            return val != null && (int)val == 0;
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (ligar) =>
                    {
                        var chave = @"SOFTWARE\Policies\Microsoft\Windows\DataCollection";
                        using (var k = Registry.LocalMachine.CreateSubKey(chave))
                            k.SetValue("AllowTelemetry", ligar ? 0 : 1, RegistryValueKind.DWord);
                    }
                },
                new PrivacyItem
                {
                    Categoria = "Telemetria e Dados",
                    Icone = "📍",
                    Titulo = "Serviço de Localização",
                    Descricao = "Permite que aplicativos saibam onde você está. Útil para apps de clima e mapas, mas pode ser uma preocupação de privacidade.",
                    DescricaoLigado = "Localização ATIVADA — aplicativos podem solicitar sua localização geográfica.",
                    DescricaoDesligado = "Localização DESATIVADA — nenhum aplicativo pode acessar sua posição geográfica.",
                    Aviso = "Desativar a localização impede que apps como 'Clima' mostrem sua região automáticamente.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location", "Value", "Allow");
                            return val?.ToString() == "Deny";
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (desativar) =>
                    {
                        var chave = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
                        using (var k = Registry.LocalMachine.CreateSubKey(chave))
                            k.SetValue("Value", desativar ? "Deny" : "Allow", RegistryValueKind.String);
                    }
                },
                new PrivacyItem
                {
                    Categoria = "Telemetria e Dados",
                    Icone = "🎤",
                    Titulo = "Acesso ao Microfone",
                    Descricao = "Controla se aplicativos da Microsoft Store podem usar o microfone do seu computador.",
                    DescricaoLigado = "Microfone desativado para aplicativos — apps não podem gravar áudio.",
                    DescricaoDesligado = "Microfone ativado — aplicativos podem solicitar acesso ao microfone.",
                    Aviso = "Isso afeta apenas apps da loja Windows. Programas instalados manualmente têm controle separado.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone", "Value", "Allow");
                            return val?.ToString() == "Deny";
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (desativar) =>
                    {
                        var chave = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone";
                        using (var k = Registry.LocalMachine.CreateSubKey(chave))
                            k.SetValue("Value", desativar ? "Deny" : "Allow", RegistryValueKind.String);
                    }
                },
                new PrivacyItem
                {
                    Categoria = "Telemetria e Dados",
                    Icone = "📷",
                    Titulo = "Acesso à Câmera",
                    Descricao = "Controla se aplicativos da Microsoft Store podem usar a câmera (webcam) do seu computador.",
                    DescricaoLigado = "Câmera desativada para aplicativos — apps não podem acessar a webcam.",
                    DescricaoDesligado = "Câmera ativada — aplicativos podem solicitar acesso à câmera.",
                    Aviso = "Se você usa videoconferência (Teams, Zoom), essas ferramentas têm permissões próprias e não são afetadas por esta configuração.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam", "Value", "Allow");
                            return val?.ToString() == "Deny";
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (desativar) =>
                    {
                        var chave = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam";
                        using (var k = Registry.LocalMachine.CreateSubKey(chave))
                            k.SetValue("Value", desativar ? "Deny" : "Allow", RegistryValueKind.String);
                    }
                },

                // --- Windows Defender ---
                new PrivacyItem
                {
                    Categoria = "Segurança",
                    Icone = "🛡️",
                    Titulo = "Windows Defender (Proteção em Tempo Real)",
                    Descricao = "O antivírus nativo do Windows — monitora arquivos e programas em tempo real para detectar ameaças. É gratuito e já vem instalado.",
                    DescricaoLigado = "Proteção em tempo real ATIVA — seu computador está sendo monitorado contra vírus e malware.",
                    DescricaoDesligado = "⚠️ Proteção em tempo real DESATIVADA — seu computador está vulnerável a ameaças!",
                    Aviso = "⚠️ Desativar o Windows Defender deixa seu computador sem proteção. Faça isso apenas se tiver outro antivírus instalado.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Real-Time Protection", "DisableRealtimeMonitoring", 0);
                            return (int)(val ?? 0) == 0; // true = ativado (não desativado)
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (ativar) =>
                    {
                        using (var k = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows Defender\Real-Time Protection"))
                            k.SetValue("DisableRealtimeMonitoring", ativar ? 0 : 1, RegistryValueKind.DWord);
                    }
                },

                // --- UAC ---
                new PrivacyItem
                {
                    Categoria = "Segurança",
                    Icone = "🔔",
                    Titulo = "Controle de Conta de Usuário (UAC)",
                    Descricao = "Aquelas janelas que pedem 'Deseja permitir que este aplicativo faça alterações no dispositivo?' — elas protegem seu PC contra mudanças não autorizadas.",
                    DescricaoLigado = "UAC ATIVO — você verá confirmações antes de instalações e mudanças importantes no sistema.",
                    DescricaoDesligado = "UAC DESATIVADO — programas podem fazer alterações no sistema sem pedir sua confirmação. Menos seguro.",
                    Aviso = "Recomendamos manter o UAC ativo. Ele é sua última linha de defesa contra instalações maliciosas.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 1);
                            return (int)(val ?? 1) == 1;
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (ativar) =>
                    {
                        using (var k = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"))
                            k.SetValue("EnableLUA", ativar ? 1 : 0, RegistryValueKind.DWord);
                        MessageBox.Show("Reinicie o computador para aplicar a mudança no UAC.", "Reinicialização necessária", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                },

                // --- Histórico de Atividades ---
                new PrivacyItem
                {
                    Categoria = "Histórico e Privacidade",
                    Icone = "📚",
                    Titulo = "Histórico de Atividades do Windows",
                    Descricao = "O Windows pode registrar quais aplicativos você usou e páginas que visitou para mostrar sugestões na Timeline. Esses dados também podem ser enviados à Microsoft.",
                    DescricaoLigado = "Histórico de atividades DESATIVADO — o Windows não registra nem envia seus dados de uso.",
                    DescricaoDesligado = "Histórico de atividades ATIVO — o Windows registra e pode sincronizar seus dados de uso.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "PublishUserActivities", -1);
                            return val != null && (int)val == 0;
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (desativar) =>
                    {
                        using (var k = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System"))
                        {
                            k.SetValue("PublishUserActivities", desativar ? 0 : 1, RegistryValueKind.DWord);
                            k.SetValue("EnableActivityFeed", desativar ? 0 : 1, RegistryValueKind.DWord);
                        }
                    }
                },
                new PrivacyItem
                {
                    Categoria = "Histórico e Privacidade",
                    Icone = "🎯",
                    Titulo = "Anúncios Personalizados",
                    Descricao = "O Windows atribui um ID de publicidade ao seu computador para personalizar anúncios em aplicativos. Você pode desativar essa personalização.",
                    DescricaoLigado = "ID de publicidade DESATIVADO — anúncios em apps não serão personalizados com base no seu perfil.",
                    DescricaoDesligado = "ID de publicidade ATIVO — seus dados de uso são usados para personalizar anúncios.",
                    LerEstado = () =>
                    {
                        try
                        {
                            var val = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo", "Enabled", 1);
                            return (int)(val ?? 1) == 0;
                        }
                        catch { return null; }
                    },
                    AplicarEstado = (desativar) =>
                    {
                        using (var k = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo"))
                            k.SetValue("Enabled", desativar ? 0 : 1, RegistryValueKind.DWord);
                    }
                },
            };
        }

        private void ConstruirInterface()
        {
            this.Text = "Central de Segurança e Privacidade";
            this.Size = new Size(1020, 700);
            this.MinimumSize = new Size(850, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 9.5f);

            // Cabeçalho
            var panelTopo = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(44, 62, 80), Padding = new Padding(20, 0, 20, 0) };
            panelTopo.Controls.Add(new Label { Text = "🔐  Central de Segurança e Privacidade", Font = new Font("Segoe UI", 14f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Left, Width = 480, TextAlign = ContentAlignment.MiddleLeft });
            panelTopo.Controls.Add(new Label { Text = "Controle o que o Windows pode ver e fazer no seu computador", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(180, 195, 210), Dock = DockStyle.Right, Width = 400, TextAlign = ContentAlignment.MiddleRight });

            // Aviso geral
            var panelAviso = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.FromArgb(255, 243, 205), Padding = new Padding(15, 0, 15, 0) };
            panelAviso.Controls.Add(new Label { Text = "⚠️  Algumas configurações requerem privilégios de administrador. Alterações no registro podem afetar o comportamento do sistema.", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.FromArgb(130, 90, 20), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft });

            // Painel detalhe (direita)
            panelDetalhe = new Panel { Dock = DockStyle.Right, Width = 330, BackColor = Color.White, Padding = new Padding(15) };
            panelDetalhe.Paint += (s, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 230)), 0, 0, 0, panelDetalhe.Height);

            lblDetNome = new Label { Text = "Selecione um item", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(15, 15), Size = new Size(300, 50), AutoSize = false };
            lblDetDescricao = new Label { Text = "Clique em qualquer configuração para ver detalhes, entender o impacto e aplicar a mudança com segurança.", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.FromArgb(90, 100, 120), Location = new Point(15, 75), Size = new Size(300, 120), AutoSize = false };
            lblDetStatus = new Label { Text = "", Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Location = new Point(15, 205), Size = new Size(300, 30), AutoSize = false };
            lblDetAviso = new Label { Text = "", Font = new Font("Segoe UI", 8.5f, FontStyle.Italic), ForeColor = Color.FromArgb(160, 90, 20), Location = new Point(15, 240), Size = new Size(300, 80), AutoSize = false };

            btnDetAtivar = new Button
            {
                Text = "✔  Aplicar / Ativar",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, 330),
                Size = new Size(143, 40),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnDetAtivar.FlatAppearance.BorderSize = 0;
            btnDetAtivar.Click += (s, e) => AplicarConfiguracao(true);

            btnDetDesativar = new Button
            {
                Text = "✖  Desativar",
                Font = new Font("Segoe UI", 10f),
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(167, 330),
                Size = new Size(143, 40),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnDetDesativar.FlatAppearance.BorderSize = 0;
            btnDetDesativar.Click += (s, e) => AplicarConfiguracao(false);

            panelDetalhe.Controls.AddRange(new Control[] { lblDetNome, lblDetDescricao, lblDetStatus, lblDetAviso, btnDetAtivar, btnDetDesativar });

            // Lista de items
            panelCards = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, Padding = new Padding(10) };

            this.Controls.Add(panelCards);
            this.Controls.Add(panelDetalhe);
            this.Controls.Add(panelAviso);
            this.Controls.Add(panelTopo);
        }

        private async void CarregarItens()
        {
            // Agrupar por categoria
            var grupos = _itens.GroupBy(i => i.Categoria).ToList();
            foreach (var grupo in grupos)
            {
                // Label de categoria
                var lblCat = new Label
                {
                    Text = grupo.Key,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(110, 120, 150),
                    Size = new Size(680, 28),
                    Padding = new Padding(5, 8, 0, 0),
                    AutoSize = false
                };
                panelCards.Controls.Add(lblCat);

                foreach (var item in grupo)
                {
                    var estado = await Task.Run(() => { try { return item.LerEstado?.Invoke(); } catch { return null; } });
                    panelCards.Controls.Add(CriarCardItem(item, estado));
                }
            }
        }

        private Panel CriarCardItem(PrivacyItem item, bool? ativo)
        {
            var card = new Panel
            {
                Size = new Size(660, 70),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 8),
                Cursor = Cursors.Hand,
                Tag = item
            };
            card.Paint += (s, e) =>
            {
                var c = s as Panel;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 225, 235)), 0, 0, c.Width - 1, c.Height - 1);
            };

            var lblIco = new Label { Text = item.Icone, Font = new Font("Segoe UI", 15f), Location = new Point(12, 15), Size = new Size(36, 36), TextAlign = ContentAlignment.MiddleCenter };
            var lblNome = new Label { Text = item.Titulo, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(58, 10), Size = new Size(450, 22), AutoEllipsis = true };
            var lblDesc = new Label { Text = item.Descricao.Length > 100 ? item.Descricao.Substring(0, 100) + "..." : item.Descricao, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(58, 32), Size = new Size(450, 28), AutoEllipsis = true };

            // Badge de status
            var statusText = ativo == null ? "?" : (ativo == true ? "Ativo" : "Inativo");
            var statusColor = ativo == null ? Color.Gray : (ativo == true ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43));
            var badgeStatus = new Panel { BackColor = statusColor, Location = new Point(card.Width - 75, 22), Size = new Size(62, 22), Cursor = Cursors.Hand };
            badgeStatus.Controls.Add(new Label { Text = statusText, Font = new Font("Segoe UI", 8f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter });

            card.Controls.AddRange(new Control[] { lblIco, lblNome, lblDesc, badgeStatus });

            Action<bool> hover = (h) =>
            {
                card.BackColor = h ? Color.FromArgb(248, 250, 255) : Color.White;
                foreach (Control c in card.Controls) c.BackColor = card.BackColor;
                badgeStatus.BackColor = statusColor;
            };
            foreach (Control c in card.Controls) { c.MouseEnter += (s, e) => hover(true); c.MouseLeave += (s, e) => hover(false); c.Click += (s, e) => SelecionarItem(item, ativo); }
            card.MouseEnter += (s, e) => hover(true);
            card.MouseLeave += (s, e) => hover(false);
            card.Click += (s, e) => SelecionarItem(item, ativo);

            return card;
        }

        private void SelecionarItem(PrivacyItem item, bool? estado)
        {
            _itemAtual = item;
            lblDetNome.Text = item.Icone + "  " + item.Titulo;
            lblDetDescricao.Text = item.Descricao;

            if (estado == null)
            {
                lblDetStatus.Text = "Status: Não foi possível verificar";
                lblDetStatus.ForeColor = Color.Gray;
            }
            else if (estado == true)
            {
                lblDetStatus.Text = "✔  " + (item.DescricaoLigado ?? "Ativado");
                lblDetStatus.ForeColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblDetStatus.Text = "✖  " + (item.DescricaoDesligado ?? "Desativado");
                lblDetStatus.ForeColor = Color.FromArgb(192, 57, 43);
            }

            lblDetAviso.Text = item.Aviso ?? "";
            btnDetAtivar.Enabled = true;
            btnDetDesativar.Enabled = true;
        }

        private void AplicarConfiguracao(bool ativar)
        {
            if (_itemAtual == null) return;

            var confirmacao = MessageBox.Show(
                $"Deseja {(ativar ? "ATIVAR" : "DESATIVAR")} a configuração:\n\n\"{_itemAtual.Titulo}\"?\n\n" +
                (string.IsNullOrEmpty(_itemAtual.Aviso) ? "" : _itemAtual.Aviso),
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes) return;

            try
            {
                _itemAtual.AplicarEstado?.Invoke(ativar);
                MessageBox.Show("✔  Configuração aplicada com sucesso!\n\nAlgumas mudanças podem requerer reinicialização do Windows para ter efeito completo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarregar lista
                panelCards.Controls.Clear();
                CarregarItens();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("⚠️  Permissão negada.\n\nEsta alteração requer privilégios de administrador.\n\nFeche o programa e execute-o como administrador (botão direito > 'Executar como administrador').", "Sem permissão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar a configuração:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1020, 700);
            this.Name = "FormPrivacy";
            this.ResumeLayout(false);
        }
    }
}