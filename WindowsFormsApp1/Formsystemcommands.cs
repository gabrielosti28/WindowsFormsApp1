using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiaDoComputador
{
    public partial class FormSystemCommands : Form
    {
        // =====================================================================
        // MODELO DE COMANDO
        // =====================================================================
        private class CommandItem
        {
            public string Nome { get; set; }
            public string Comando { get; set; }
            public string Descricao { get; set; }
            public string Categoria { get; set; }
            public bool UsaCmd { get; set; }
            public bool RequereAdmin { get; set; }
            public string Icone { get; set; }
            public string Beneficio { get; set; }
            public string Impacto { get; set; }
            public string QuandoUsar { get; set; }
        }

        private readonly List<CommandItem> _comandos;
        private CommandItem _comandoAtual;

        public FormSystemCommands()
        {
            _comandos = DefinirComandos();
            InitializeComponent();
        }

        private List<CommandItem> DefinirComandos()
        {
            return new List<CommandItem>
            {
                // --- Menu Executar (Win+R) ---
                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Configuração de Inicialização",
                    Comando = "msconfig",
                    Descricao = "Controla o que roda quando o PC liga — programas, serviços e opções de boot. Ótimo para diagnosticar lentidão na inicialização.",
                    Beneficio = "Identifica programas que atrasam a inicialização",
                    Impacto = "✅ Permite otimizar o tempo de boot",
                    QuandoUsar = "Quando o computador demora muito para iniciar",
                    Icone = "⚙️"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Gerenciador de Dispositivos",
                    Comando = "devmgmt.msc",
                    Descricao = "Lista todas as peças físicas do computador (placa de vídeo, som, rede). Aqui você vê se algum componente está com problema (ícone amarelo).",
                    Beneficio = "Visualiza e gerencia drivers de hardware",
                    Impacto = "✅ Permite atualizar ou resolver problemas de drivers",
                    QuandoUsar = "Quando um dispositivo não funciona (som, vídeo, Wi-Fi)",
                    Icone = "🔌"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Gerenciador de Discos",
                    Comando = "diskmgmt.msc",
                    Descricao = "Mostra todos os HDs e SSDs conectados, suas partições e espaço livre. Usado para formatar, particionar ou verificar discos.",
                    Beneficio = "Gerencia partições e espaço em disco",
                    Impacto = "✅ Permite criar, formatar ou redimensionar partições",
                    QuandoUsar = "Para criar novas partições ou verificar discos",
                    Icone = "💾"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Limpeza de Disco",
                    Comando = "cleanmgr",
                    Descricao = "Ferramenta oficial do Windows para remover arquivos temporários, cache e lixo que ocupa espaço sem necessidade.",
                    Beneficio = "Libera espaço em disco de forma segura",
                    Impacto = "✅ Remove apenas arquivos desnecessários",
                    QuandoUsar = "Quando o disco está ficando cheio",
                    Icone = "🧹"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Monitor de Recursos",
                    Comando = "resmon",
                    Descricao = "Versão avançada do Gerenciador de Tarefas — mostra exatamente quem está usando CPU, memória, disco e rede em tempo real.",
                    Beneficio = "Diagnóstico detalhado de desempenho",
                    Impacto = "✅ Identifica processos que consomem muitos recursos",
                    QuandoUsar = "Quando o PC está lento sem motivo aparente",
                    Icone = "📊"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Monitor de Desempenho",
                    Comando = "perfmon",
                    Descricao = "Gráficos detalhados do desempenho do sistema ao longo do tempo. Ótimo para identificar gargalos e lentidão.",
                    Beneficio = "Análise histórica de desempenho",
                    Impacto = "✅ Ajuda a identificar tendências de lentidão",
                    QuandoUsar = "Para análise aprofundada de desempenho",
                    Icone = "📈"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Visualizador de Eventos",
                    Comando = "eventvwr",
                    Descricao = "Histórico de tudo que aconteceu no seu PC — erros, avisos, logins. É como o \"diário\" do Windows.",
                    Beneficio = "Entende erros e problemas do sistema",
                    Impacto = "✅ Diagnostica causas de travamentos",
                    QuandoUsar = "Quando ocorrem erros ou travamentos frequentes",
                    Icone = "📋"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Gerenciador de Usuários",
                    Comando = "netplwiz",
                    Descricao = "Controla quem tem acesso ao computador, senhas e permissões de cada conta de usuário.",
                    Beneficio = "Gerencia contas e permissões de usuários",
                    Impacto = "✅ Configura logins automáticos ou controla acessos",
                    QuandoUsar = "Para configurar login automático ou gerenciar usuários",
                    Icone = "👤"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Políticas do Sistema",
                    Comando = "gpedit.msc",
                    Descricao = "Configurações avançadas de segurança e comportamento do Windows. Requer cuidado — alterações afetam todo o sistema.",
                    RequereAdmin = true,
                    Beneficio = "Controle avançado de configurações do Windows",
                    Impacto = "⚠️ Pode afetar o comportamento do sistema",
                    QuandoUsar = "Apenas para usuários avançados",
                    Icone = "🔐"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Editor do Registro",
                    Comando = "regedit",
                    Descricao = "O \"DNA\" do Windows — guarda todas as configurações do sistema. Extremamente poderoso, mas altere somente se souber o que está fazendo.",
                    RequereAdmin = true,
                    Beneficio = "Acesso a configurações profundas do sistema",
                    Impacto = "⚠️ Pode danificar o Windows se usado incorretamente",
                    QuandoUsar = "Sob orientação técnica ou tutorial confiável",
                    Icone = "⚠️"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Informações do Sistema",
                    Comando = "msinfo32",
                    Descricao = "Relatório completo do hardware e software instalado — útil para suporte técnico e diagnósticos.",
                    Beneficio = "Resumo completo do computador",
                    Impacto = "✅ Útil para suporte técnico",
                    QuandoUsar = "Antes de pedir ajuda técnica ou comprar peças",
                    Icone = "ℹ️"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Configurações de IP",
                    Comando = "ncpa.cpl",
                    Descricao = "Acesso direto às configurações de adaptadores de rede (Wi-Fi e cabo). Útil para configurar IP fixo ou DNS.",
                    Beneficio = "Configurações avançadas de rede",
                    Impacto = "✅ Permite ajustar IP, DNS e conexões",
                    QuandoUsar = "Para configurar IP fixo ou resolver problemas de rede",
                    Icone = "🌐"
                },

                new CommandItem
                {
                    Categoria = "⚡  Executar (Win+R)",
                    Nome = "Serviços do Windows",
                    Comando = "services.msc",
                    Descricao = "Lista todos os serviços rodando em segundo plano. Permite iniciar, parar ou desabilitar cada um.",
                    Beneficio = "Controla o que roda em segundo plano",
                    Impacto = "✅ Pode melhorar desempenho ao desativar serviços desnecessários",
                    QuandoUsar = "Para otimizar serviços em segundo plano",
                    Icone = "🔧"
                },

                // --- Comandos CMD ---
                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Verificar Arquivos do Windows",
                    Comando = "sfc /scannow",
                    Descricao = "Verifica e corrige automaticamente arquivos corrompidos do Windows. Rode quando o PC estiver com comportamento estranho. Pode demorar 10-15 min.",
                    UsaCmd = true,
                    RequereAdmin = true,
                    Beneficio = "Corrige arquivos corrompidos do sistema",
                    Impacto = "✅ Pode resolver travamentos e erros",
                    QuandoUsar = "Quando o Windows apresenta erros ou comportamento estranho",
                    Icone = "🛡️"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Reparar o Windows (DISM)",
                    Comando = "DISM /Online /Cleanup-Image /RestoreHealth",
                    Descricao = "Reparo mais profundo do Windows — verifica e restaura a imagem do sistema operacional. Use junto com o SFC quando houver erros persistentes.",
                    UsaCmd = true,
                    RequereAdmin = true,
                    Beneficio = "Repara a imagem do Windows",
                    Impacto = "✅ Corrige problemas que o SFC não resolve",
                    QuandoUsar = "Quando o SFC não corrige os erros",
                    Icone = "🔨"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Informações de Rede",
                    Comando = "ipconfig /all",
                    Descricao = "Mostra todas as informações de rede: IP, DNS, gateway, MAC address. Essencial para diagnóstico de problemas de internet.",
                    UsaCmd = true,
                    Beneficio = "Diagnóstico completo de rede",
                    Impacto = "✅ Ajuda a resolver problemas de conexão",
                    QuandoUsar = "Quando a internet não funciona ou está lenta",
                    Icone = "📡"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Renovar Conexão de Rede",
                    Comando = "ipconfig /release && ipconfig /renew",
                    Descricao = "Libera e renova o endereço IP — resolve muitos problemas de conexão sem precisar reiniciar o computador.",
                    UsaCmd = true,
                    RequereAdmin = true,
                    Beneficio = "Renova configurações de rede",
                    Impacto = "✅ Resolve problemas de IP conflitante",
                    QuandoUsar = "Quando a internet para de funcionar de repente",
                    Icone = "🔄"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Limpar Cache DNS",
                    Comando = "ipconfig /flushdns",
                    Descricao = "Limpa a lista telefônica de internet do Windows. Resolve problemas de sites que não abrem mesmo com internet funcionando.",
                    UsaCmd = true,
                    RequereAdmin = true,
                    Beneficio = "Limpa registros DNS obsoletos",
                    Impacto = "✅ Resolve problemas de acesso a sites",
                    QuandoUsar = "Quando sites não abrem, mas a internet funciona",
                    Icone = "🧽"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Verificar Disco (C:)",
                    Comando = "chkdsk C: /f /r",
                    Descricao = "Verifica o disco principal em busca de erros e setores danificados. Precisa reiniciar para executar no disco do sistema.",
                    UsaCmd = true,
                    RequereAdmin = true,
                    Beneficio = "Detecta e corrige erros no disco",
                    Impacto = "✅ Previne perda de dados em discos com problemas",
                    QuandoUsar = "Quando o disco apresenta erros ou lentidão",
                    Icone = "🔍"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Conexões de Internet Ativas",
                    Comando = "netstat -an",
                    Descricao = "Mostra todas as conexões de internet abertas no momento — útil para detectar programas se comunicando com a internet.",
                    UsaCmd = true,
                    Beneficio = "Visualiza conexões ativas do computador",
                    Impacto = "✅ Identifica programas se comunicando pela internet",
                    QuandoUsar = "Para verificar se há conexões suspeitas",
                    Icone = "🕸️"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Relatório de Bateria",
                    Comando = "powercfg /batteryreport /output \"%USERPROFILE%\\Desktop\\relatorio_bateria.html\"",
                    Descricao = "Gera um relatório completo da bateria em HTML na sua área de trabalho, mostrando capacidade atual vs original e histórico de uso.",
                    UsaCmd = true,
                    Beneficio = "Analisa a saúde da bateria do notebook",
                    Impacto = "✅ Mostra se a bateria precisa ser trocada",
                    QuandoUsar = "Para verificar o desgaste da bateria",
                    Icone = "🔋"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Informações Completas do Sistema",
                    Comando = "systeminfo",
                    Descricao = "Exibe detalhes completos do sistema: Windows, hardware, hotfixes instalados, configurações de rede — tudo em um só lugar.",
                    UsaCmd = true,
                    Beneficio = "Resumo completo do computador",
                    Impacto = "✅ Útil para diagnóstico e suporte técnico",
                    QuandoUsar = "Para obter informações detalhadas do sistema",
                    Icone = "🖥️"
                },

                new CommandItem
                {
                    Categoria = "🖥️  Comandos CMD",
                    Nome = "Teste de Conectividade (Ping)",
                    Comando = "ping google.com -n 4",
                    Descricao = "Testa se o computador consegue se comunicar com a internet. Se falhar, o problema está na sua conexão ou no DNS.",
                    UsaCmd = true,
                    Beneficio = "Testa conectividade com a internet",
                    Impacto = "✅ Diagnostica problemas de rede rapidamente",
                    QuandoUsar = "Quando suspeitar que a internet caiu",
                    Icone = "🏓"
                },
            };
        }

        private void PopularCategorias()
        {
            var grupos = new Dictionary<string, List<CommandItem>>();
            foreach (var cmd in _comandos)
            {
                if (!grupos.ContainsKey(cmd.Categoria))
                    grupos[cmd.Categoria] = new List<CommandItem>();
                grupos[cmd.Categoria].Add(cmd);
            }

            foreach (var kvp in grupos)
            {
                var tab = new TabPage(kvp.Key);
                tab.BackColor = Color.FromArgb(248, 250, 252);
                tab.Padding = new Padding(10);

                var flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoScroll = true,
                    Padding = new Padding(10, 5, 10, 5)
                };

                foreach (var cmd in kvp.Value)
                {
                    var card = CriarCardComando(cmd);
                    flowPanel.Controls.Add(card);
                }

                tab.Controls.Add(flowPanel);
                tabCategorias.TabPages.Add(tab);
            }
        }

        private Panel CriarCardComando(CommandItem cmd)
        {
            var card = new Panel
            {
                Size = new Size(540, 80),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Hand,
                Tag = cmd
            };

            // Borda e efeito de elevação
            card.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }

                // Barra lateral colorida por categoria
                using (var brush = new SolidBrush(ObterCorCategoria(cmd.Categoria)))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 4, card.Height);
                }
            };

            // Ícone
            var lblIcone = new Label
            {
                Text = cmd.Icone,
                Font = new Font("Segoe UI", 18f),
                Location = new Point(12, 12),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Nome do comando
            var lblNome = new Label
            {
                Text = cmd.Nome,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(60, 10),
                Size = new Size(340, 22),
                AutoEllipsis = true
            };

            // Descrição resumida
            var lblDesc = new Label
            {
                Text = cmd.Descricao.Length > 90 ? cmd.Descricao.Substring(0, 90) + "..." : cmd.Descricao,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(60, 32),
                Size = new Size(340, 35)
            };

            // Badge de Admin (se necessário)
            if (cmd.RequereAdmin)
            {
                var badgeAdmin = new Panel
                {
                    BackColor = Color.FromArgb(220, 38, 38),
                    Location = new Point(card.Width - 80, 25),
                    Size = new Size(65, 22)
                };

                var lblAdmin = new Label
                {
                    Text = "ADMIN",
                    Font = new Font("Segoe UI", 7f, FontStyle.Bold),
                    ForeColor = Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                badgeAdmin.Controls.Add(lblAdmin);
                card.Controls.Add(badgeAdmin);
            }

            card.Controls.AddRange(new Control[] { lblIcone, lblNome, lblDesc });

            // Eventos de hover
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(239, 246, 255);
                card.Refresh();
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.Refresh();
            };
            card.Click += (s, e) => SelecionarComando(cmd);

            // Propagar clique para todos os controles
            foreach (Control c in card.Controls)
            {
                c.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(239, 246, 255);
                c.MouseLeave += (s, e) => card.BackColor = Color.White;
                c.Click += (s, e) => SelecionarComando(cmd);
            }

            return card;
        }

        private Color ObterCorCategoria(string categoria)
        {
            if (categoria.Contains("Executar")) return Color.FromArgb(59, 130, 246);      // Azul
            if (categoria.Contains("CMD")) return Color.FromArgb(147, 51, 234);          // Roxo
            return Color.FromArgb(107, 114, 128);                                         // Cinza
        }

        private void SelecionarComando(CommandItem cmd)
        {
            _comandoAtual = cmd;

            lblComandoSelecionado.Text = $"{cmd.Icone}  {cmd.Nome}";
            lblDescricaoDetalhe.Text = cmd.Descricao;
            lblComandoBruto.Text = cmd.Comando;

            // Informações educativas
            lblBeneficio.Text = $"✨ {cmd.Beneficio}";
            lblImpacto.Text = $"⚡ {cmd.Impacto}";
            lblQuandoUsar.Text = $"📌 {cmd.QuandoUsar}";

            btnExecutar.Enabled = true;
            btnCopiar.Enabled = true;
            lblStatusExecucao.Text = "";
            rtbSaida.Text = "▶  Pressione 'Executar Agora' para rodar este comando.\n\nA saída será mostrada aqui.";

            if (cmd.RequereAdmin)
            {
                btnExecutar.BackColor = Color.FromArgb(220, 38, 38);
                lblStatusExecucao.Text = "⚠️  Requer privilégios de Administrador";
                lblStatusExecucao.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                btnExecutar.BackColor = Color.FromArgb(34, 197, 94);
                lblStatusExecucao.Text = "";
            }
        }

        private async void BtnExecutar_Click(object sender, EventArgs e)
        {
            if (_comandoAtual == null) return;

            btnExecutar.Enabled = false;
            btnExecutar.Text = "⏳  Executando...";
            rtbSaida.Text = "";
            lblStatusExecucao.Text = "Executando comando...";

            try
            {
                if (_comandoAtual.UsaCmd)
                {
                    var resultado = await Task.Run(() => ExecutarCmd(_comandoAtual.Comando, _comandoAtual.RequereAdmin));
                    rtbSaida.Text = resultado;
                    rtbSaida.ForeColor = Color.FromArgb(220, 255, 220);
                    lblStatusExecucao.Text = "✅  Comando executado com sucesso!";
                    lblStatusExecucao.ForeColor = Color.FromArgb(34, 197, 94);
                }
                else
                {
                    var psi = new ProcessStartInfo(_comandoAtual.Comando)
                    {
                        UseShellExecute = true,
                        Verb = _comandoAtual.RequereAdmin ? "runas" : ""
                    };
                    Process.Start(psi);

                    rtbSaida.Text = $"✅  Programa aberto com sucesso!\n\nO Windows abriu: {_comandoAtual.Nome}\n\n" +
                                     $"💡 Dica: Você pode encontrar esta ferramenta no menu Iniciar também.";
                    rtbSaida.ForeColor = Color.FromArgb(220, 255, 220);
                    lblStatusExecucao.Text = "✅  Aberto com sucesso!";
                    lblStatusExecucao.ForeColor = Color.FromArgb(34, 197, 94);
                }
            }
            catch (Exception ex)
            {
                rtbSaida.ForeColor = Color.FromArgb(255, 200, 200);

                if (ex.Message.Contains("cancel") || ex.Message.Contains("denied"))
                {
                    rtbSaida.Text = "⚠️  Operação cancelada ou permissão negada.\n\n" +
                                    "Você clicou em 'Não' na janela de confirmação, ou não tem permissão de administrador.\n\n" +
                                    "Para executar comandos que exigem Admin:\n" +
                                    "1. Feche o programa\n" +
                                    "2. Clique com botão direito no atalho\n" +
                                    "3. Escolha 'Executar como administrador'";
                }
                else
                {
                    rtbSaida.Text = $"❌  Erro ao executar: {ex.Message}";
                }

                lblStatusExecucao.Text = "❌  Erro na execução";
                lblStatusExecucao.ForeColor = Color.FromArgb(220, 38, 38);
            }
            finally
            {
                btnExecutar.Enabled = true;
                btnExecutar.Text = "▶  Executar Agora";
                btnExecutar.BackColor = _comandoAtual.RequereAdmin ? Color.FromArgb(220, 38, 38) : Color.FromArgb(34, 197, 94);
            }
        }

        private string ExecutarCmd(string comando, bool admin)
        {
            try
            {
                var psi = new ProcessStartInfo("cmd.exe", $"/C {comando}")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = System.Text.Encoding.UTF8,
                    StandardErrorEncoding = System.Text.Encoding.UTF8
                };

                if (admin)
                {
                    psi.UseShellExecute = true;
                    psi.RedirectStandardOutput = false;
                    psi.RedirectStandardError = false;
                    psi.Verb = "runas";
                    psi.WindowStyle = ProcessWindowStyle.Normal;

                    var proc = Process.Start(psi);
                    proc?.WaitForExit(60000);

                    return "🔐  Comando enviado ao terminal de administrador.\n\n" +
                           "Uma janela de CMD se abriu para executar o comando com privilégios elevados.\n" +
                           "Acompanhe a execução na janela que abriu.";
                }

                var procNormal = Process.Start(psi);
                var saida = procNormal.StandardOutput.ReadToEnd();
                var erro = procNormal.StandardError.ReadToEnd();
                procNormal.WaitForExit(60000);

                var resultado = "";
                if (!string.IsNullOrWhiteSpace(saida))
                    resultado += saida;
                if (!string.IsNullOrWhiteSpace(erro))
                    resultado += $"\n\n⚠️  Avisos/Erros:\n{erro}";

                return string.IsNullOrWhiteSpace(resultado)
                    ? "✅  Comando executado (sem saída para mostrar)."
                    : resultado.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao executar CMD: {ex.Message}");
            }
        }
    }
}