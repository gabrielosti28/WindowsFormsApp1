using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuCounter;
        private Dictionary<string, PerformanceCounter> processCounters = new Dictionary<string, PerformanceCounter>();

        public Form1()
        {
            InitializeComponent();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
            MessageBox.Show("Dados atualizados com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AtualizarResumo();
        }

        private void CarregarDados()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                AtualizarResumo();
                CarregarMemoria();
                CarregarProcessos();
                CarregarDisco();
                CarregarInicializacao();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AtualizarResumo()
        {
            try
            {
                // Memoria
                var memoriaInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
                ulong memoriaTotal = memoriaInfo.TotalPhysicalMemory / (1024 * 1024 * 1024);
                ulong memoriaDisponivel = memoriaInfo.AvailablePhysicalMemory / (1024 * 1024 * 1024);
                ulong memoriaUsada = memoriaTotal - memoriaDisponivel;
                double percentualMemoria = (double)memoriaUsada / memoriaTotal * 100;

                labelMemoriaTotal.Text = string.Format("Memoria RAM Total: {0} GB de {1} GB", memoriaUsada, memoriaTotal);
                labelMemoriaUsada.Text = string.Format("Em uso agora: {0} GB ({1:F1}%)", memoriaUsada, percentualMemoria);
                progressBarMemoria.Value = Math.Min((int)percentualMemoria, 100);

                // Disco
                DriveInfo driveC = new DriveInfo("C");
                long discoTotal = driveC.TotalSize / (1024 * 1024 * 1024);
                long discoLivre = driveC.AvailableFreeSpace / (1024 * 1024 * 1024);
                long discoUsado = discoTotal - discoLivre;
                double percentualDisco = (double)discoUsado / discoTotal * 100;

                labelDiscoTotal.Text = string.Format("Espaco no Disco: {0} GB de {1} GB", discoUsado, discoTotal);
                labelDiscoUsado.Text = string.Format("Usado: {0} GB ({1:F1}%)", discoUsado, percentualDisco);
                progressBarDisco.Value = Math.Min((int)percentualDisco, 100);

                // Cores do progresso
                if (percentualMemoria > 80)
                    progressBarMemoria.ForeColor = Color.Red;
                else if (percentualMemoria > 60)
                    progressBarMemoria.ForeColor = Color.Orange;
                else
                    progressBarMemoria.ForeColor = Color.Green;

                if (percentualDisco > 80)
                    progressBarDisco.ForeColor = Color.Red;
                else if (percentualDisco > 60)
                    progressBarDisco.ForeColor = Color.Orange;
                else
                    progressBarDisco.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro ao atualizar resumo: " + ex.Message);
            }
        }

        private void CarregarMemoria()
        {
            listViewMemoria.Items.Clear();

            try
            {
                var processos = Process.GetProcesses()
                    .Where(p => p.WorkingSet64 > 10 * 1024 * 1024) // Maior que 10 MB
                    .OrderByDescending(p => p.WorkingSet64)
                    .Take(50);

                foreach (var processo in processos)
                {
                    try
                    {
                        long memoriaBytes = processo.WorkingSet64;
                        string memoriaFormatada = FormatarBytes(memoriaBytes);
                        string explicacao = ObterExplicacaoProcesso(processo.ProcessName);

                        ListViewItem item = new ListViewItem(processo.ProcessName);
                        item.SubItems.Add(memoriaFormatada);
                        item.SubItems.Add(explicacao);

                        // Cor baseada no uso
                        if (memoriaBytes > 500 * 1024 * 1024) // > 500 MB
                            item.BackColor = Color.LightCoral;
                        else if (memoriaBytes > 200 * 1024 * 1024) // > 200 MB
                            item.BackColor = Color.LightYellow;

                        listViewMemoria.Items.Add(item);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void CarregarProcessos()
        {
            listViewProcessos.Items.Clear();

            try
            {
                var processos = Process.GetProcesses()
                    .OrderByDescending(p => p.WorkingSet64)
                    .Take(50);

                foreach (var processo in processos)
                {
                    try
                    {
                        string memoriaFormatada = FormatarBytes(processo.WorkingSet64);
                        string cpuUso = "Calculando...";
                        string explicacao = ObterExplicacaoProcesso(processo.ProcessName);

                        ListViewItem item = new ListViewItem(processo.ProcessName);
                        item.SubItems.Add(cpuUso);
                        item.SubItems.Add(memoriaFormatada);
                        item.SubItems.Add(explicacao);

                        listViewProcessos.Items.Add(item);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void CarregarDisco()
        {
            listViewDisco.Items.Clear();

            try
            {
                string[] pastasPrincipais = new[]
                {
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                };

                foreach (string pasta in pastasPrincipais)
                {
                    try
                    {
                        if (Directory.Exists(pasta))
                        {
                            long tamanho = CalcularTamanhoPasta(pasta);
                            string tamanhoFormatado = FormatarBytes(tamanho);
                            string explicacao = ObterExplicacaoPasta(pasta);

                            ListViewItem item = new ListViewItem(pasta);
                            item.SubItems.Add(tamanhoFormatado);
                            item.SubItems.Add(explicacao);

                            if (tamanho > 5L * 1024 * 1024 * 1024) // > 5 GB
                                item.BackColor = Color.LightCoral;
                            else if (tamanho > 1L * 1024 * 1024 * 1024) // > 1 GB
                                item.BackColor = Color.LightYellow;

                            listViewDisco.Items.Add(item);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void CarregarInicializacao()
        {
            listViewInicializacao.Items.Clear();

            try
            {
                // Chaves do Registro
                string[] chavesRegistro = new[]
                {
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce"
                };

                foreach (string caminhoChave in chavesRegistro)
                {
                    try
                    {
                        using (RegistryKey chave = Registry.LocalMachine.OpenSubKey(caminhoChave))
                        {
                            if (chave != null)
                            {
                                foreach (string nomeval in chave.GetValueNames())
                                {
                                    string programa = Path.GetFileNameWithoutExtension(nomeval);
                                    string explicacao = ObterExplicacaoProcesso(programa);
                                    string impacto = "Medio";

                                    ListViewItem item = new ListViewItem(programa);
                                    item.SubItems.Add(impacto);
                                    item.SubItems.Add(explicacao);
                                    item.BackColor = Color.LightYellow;

                                    listViewInicializacao.Items.Add(item);
                                }
                            }
                        }
                    }
                    catch { }
                }

                // Pasta de inicializacao do usuario
                string pastaStartup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                if (Directory.Exists(pastaStartup))
                {
                    foreach (string arquivo in Directory.GetFiles(pastaStartup))
                    {
                        string programa = Path.GetFileNameWithoutExtension(arquivo);
                        string explicacao = "Programa configurado para iniciar automaticamente quando voce liga o computador.";

                        ListViewItem item = new ListViewItem(programa);
                        item.SubItems.Add("Baixo");
                        item.SubItems.Add(explicacao);

                        listViewInicializacao.Items.Add(item);
                    }
                }
            }
            catch { }
        }

        private long CalcularTamanhoPasta(string pasta)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(pasta);
                return dir.EnumerateFiles("*", SearchOption.AllDirectories)
                    .Sum(file => file.Length);
            }
            catch
            {
                return 0;
            }
        }

        private string FormatarBytes(long bytes)
        {
            string[] sufixos = { "B", "KB", "MB", "GB", "TB" };
            int contador = 0;
            decimal numero = bytes;

            while (Math.Round(numero / 1024) >= 1)
            {
                numero /= 1024;
                contador++;
            }

            return string.Format("{0:n2} {1}", numero, sufixos[contador]);
        }

        private string ObterExplicacaoProcesso(string nomeProcesso)
        {
            var explicacoes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Processos do Windows
                {"svchost", "Gerenciador de Servicos do Windows - Programa que roda varios servicos importantes do sistema operacional ao mesmo tempo. E normal ter varios deles rodando."},
                {"explorer", "Explorador de Arquivos - O programa que mostra suas pastas, arquivos e a area de trabalho. Sem ele voce nao ve nada na tela."},
                {"dwm", "Gerenciador de Janelas - Responsavel por desenhar as janelas bonitas na tela, com transparencia e efeitos visuais."},
                {"System", "Sistema Principal - O cerebro do Windows. Ele gerencia tudo que acontece no computador."},
                {"RuntimeBroker", "Corretor de Tempo de Execucao - Verifica as permissoes dos aplicativos da Windows Store, garantindo que eles nao facam coisas que nao devem."},
                {"SearchIndexer", "Indexador de Pesquisa - Cata e organiza seus arquivos para que voce possa encontra-los rapido quando pesquisar no Windows."},
                {"csrss", "Subsistema Cliente-Servidor - Parte essencial do Windows que cuida de criar e gerenciar janelas e processos."},
                {"lsass", "Servico de Autenticacao Local - Cuida da seguranca, senhas e verifica se voce tem permissao para fazer as coisas."},
                {"winlogon", "Processo de Login - Cuida da tela de login quando voce liga o computador ou troca de usuario."},
                {"services", "Controlador de Servicos - Gerencia todos os servicos que ficam rodando em segundo plano no Windows."},
                {"spoolsv", "Servico de Impressao - Gerencia a fila de impressao quando voce manda imprimir algo."},
                {"taskhostw", "Host de Tarefas - Executa tarefas agendadas do Windows, como atualizacoes automaticas."},
                {"fontdrvhost", "Host de Driver de Fonte - Gerencia as fontes (letras) que aparecem na tela."},
                {"ctfmon", "Monitor de Servicos de Texto - Ajuda com os metodos de entrada de texto, como teclados em outros idiomas."},
                {"audiodg", "Motor de Graficos de Audio - Processa e gerencia todo o som do computador."},
                {"WmiPrvSE", "Provedor WMI - Fornece informacoes sobre o hardware e software do computador para outros programas."},
                {"MsMpEng", "Windows Defender - O antivirus gratuito do Windows que protege seu computador de virus e ameacas."},
                {"SearchApp", "Aplicativo de Pesquisa - A barra de pesquisa do Windows 10/11 onde voce procura programas e arquivos."},
                {"StartMenuExperienceHost", "Menu Iniciar - O menu que abre quando voce clica no botao Iniciar do Windows."},
                {"ShellExperienceHost", "Experiencia do Shell - Cuida de elementos da interface como o calendario, notificacoes e configuracoes rapidas."},
                {"sihost", "Host de Interface do Shell - Gerencia a interacao entre voce e o Windows, como icones e menus."},
                {"TextInputHost", "Host de Entrada de Texto - Gerencia o teclado virtual e sugestoes de texto."},
                {"ApplicationFrameHost", "Host de Quadro de Aplicativo - Permite que aplicativos da Windows Store rodem dentro de janelas."},
                {"smartscreen", "SmartScreen - Protege voce de sites e downloads perigosos, avisando sobre possiveis ameacas."},
                
                // Navegadores
                {"chrome", "Google Chrome - Navegador de internet do Google. Cada aba aberta usa memoria separadamente."},
                {"firefox", "Mozilla Firefox - Navegador de internet conhecido por privacidade e personalizacao."},
                {"msedge", "Microsoft Edge - Navegador de internet da Microsoft, vem instalado no Windows."},
                {"opera", "Opera - Navegador de internet com VPN gratis integrada e bloqueador de anuncios."},
                {"brave", "Brave - Navegador focado em privacidade que bloqueia rastreadores e anuncios."},
                
                // Programas comuns
                {"Steam", "Steam - Plataforma de jogos digitais. Mesmo fechado, fica rodando no segundo plano se voce nao desativar."},
                {"Discord", "Discord - Aplicativo de conversa por voz e texto, muito usado por gamers."},
                {"Spotify", "Spotify - Aplicativo de musica por streaming."},
                {"OneDrive", "OneDrive - Servico de armazenamento na nuvem da Microsoft. Sincroniza seus arquivos com a internet."},
                {"Dropbox", "Dropbox - Servico de armazenamento na nuvem para guardar e compartilhar arquivos online."},
                {"GoogleDrive", "Google Drive - Armazena seus arquivos na nuvem do Google."},
                {"Teams", "Microsoft Teams - Programa de reunioes e chat corporativo da Microsoft."},
                {"Zoom", "Zoom - Aplicativo de videoconferencias e reunioes online."},
                {"Skype", "Skype - Programa de chamadas de video e mensagens da Microsoft."},
                {"WhatsApp", "WhatsApp Desktop - Versao do WhatsApp para computador."},
                {"Telegram", "Telegram - Aplicativo de mensagens focado em velocidade e seguranca."},
                
                // Jogos e launchers
                {"EpicGamesLauncher", "Epic Games - Loja de jogos digitais, distribuidora de Fortnite e outros jogos gratuitos."},
                {"Battle.net", "Battle.net - Plataforma de jogos da Blizzard (World of Warcraft, Overwatch, etc)."},
                {"Origin", "Origin - Loja de jogos da EA (FIFA, The Sims, Battlefield, etc)."},
                
                // Antivirus
                {"avast", "Avast Antivirus - Programa que protege seu computador contra virus e malware."},
                {"avg", "AVG Antivirus - Programa de protecao contra virus e ameacas."},
                {"Norton", "Norton Antivirus - Software de seguranca que protege contra virus e hackers."},
                {"McAfee", "McAfee Antivirus - Programa de seguranca da McAfee."},
                
                // Adobe
                {"Photoshop", "Adobe Photoshop - Editor profissional de imagens e fotos."},
                {"Illustrator", "Adobe Illustrator - Programa para criar ilustracoes e designs vetoriais."},
                {"Premiere", "Adobe Premiere - Editor profissional de videos."},
                
                // Office
                {"WINWORD", "Microsoft Word - Editor de textos do pacote Office."},
                {"EXCEL", "Microsoft Excel - Programa de planilhas do Office."},
                {"POWERPNT", "Microsoft PowerPoint - Programa para criar apresentacoes de slides."},
                {"OUTLOOK", "Microsoft Outlook - Gerenciador de emails e agenda da Microsoft."},
            };

            if (explicacoes.TryGetValue(nomeProcesso, out string explicacao))
            {
                return explicacao;
            }

            // Verifica se e um processo do sistema
            if (nomeProcesso.ToLower().Contains("windows") || nomeProcesso.ToLower().Contains("microsoft"))
            {
                return "Processo do sistema Windows - Faz parte do funcionamento normal do seu computador.";
            }

            return "Programa instalado no seu computador. Se voce nao reconhece, pode ser um aplicativo que veio junto com outro programa que voce instalou.";
        }

        private string ObterExplicacaoPasta(string caminhoPasta)
        {
            string nomePasta = Path.GetFileName(caminhoPasta);

            var explicacoes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"Program Files", "Pasta onde ficam instalados os programas principais do seu computador (versao 64 bits)."},
                {"Program Files (x86)", "Pasta com programas antigos ou de 32 bits. Mesmo em computadores modernos, alguns programas ainda usam esta pasta."},
                {"Windows", "Pasta principal do sistema Windows. Contem todos os arquivos que fazem o Windows funcionar. Nao mexa aqui!"},
                {"Users", "Pasta com todas as contas de usuario do computador. Seus documentos, downloads e configuracoes ficam aqui."},
                {"Documents", "Seus documentos pessoais - textos, planilhas, PDFs e outros arquivos que voce cria ou salva."},
                {"Downloads", "Tudo que voce baixa da internet vem para ca. E bom limpar de vez em quando!"},
                {"Pictures", "Suas fotos e imagens. Pode ocupar muito espaco se voce tira muitas fotos."},
                {"Videos", "Videos que voce baixou ou gravou. Videos ocupam MUITO espaco!"},
                {"Music", "Suas musicas e arquivos de audio."},
                {"Desktop", "Tudo que fica na sua area de trabalho. Evite deixar muitos arquivos aqui, pode deixar o PC lento."},
                {"AppData", "Dados de configuracao dos seus aplicativos. Cada programa guarda suas preferencias aqui."},
                {"Local", "Dados locais dos aplicativos - caches, arquivos temporarios e configuracoes."},
                {"Temp", "Arquivos temporarios. Podem ser apagados com seguranca para liberar espaco."},
            };

            foreach (var kvp in explicacoes)
            {
                if (caminhoPasta.ToLower().Contains(kvp.Key.ToLower()))
                {
                    return kvp.Value;
                }
            }

            return "Pasta com arquivos e configuracoes de programas instalados no seu computador.";
        }
    }
}