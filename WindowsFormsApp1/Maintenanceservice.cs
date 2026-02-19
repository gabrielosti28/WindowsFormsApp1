using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GuiaDoComputador
{
    public class ResultadoLimpeza
    {
        public string Nome { get; set; }
        public string Emoji { get; set; }
        public long BytesLiberados { get; set; }
        public string TamanhoFormatado { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }

    public class ProgramaInicializacao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public string Caminho { get; set; }
        public bool Ativo { get; set; }
        public string ImpactoNaInicializacao { get; set; }
        public string ImpactoEmoji { get; set; }
        public string Recomendacao { get; set; }
        public string Origem { get; set; } // HKCU ou HKLM
        public string ChaveRegistro { get; set; }
    }

    public class InfoDisco
    {
        public string Letra { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public long EspacoTotalBytes { get; set; }
        public long EspacoLivreBytes { get; set; }
        public long EspacoUsadoBytes { get; set; }
        public double PorcentagemUso { get; set; }
        public string SaudeStatus { get; set; }
        public string SaudeEmoji { get; set; }
        public string Alerta { get; set; }
    }

    public class ResultadoManutencao
    {
        public int Pontuacao { get; set; }               // 0-100
        public string Classificacao { get; set; }
        public string Emoji { get; set; }
        public List<string> ProblemasEncontrados { get; set; } = new List<string>();
        public List<string> Recomendacoes { get; set; } = new List<string>();
        public string Resumo { get; set; }
    }

    public static class MaintenanceService
    {
        // ─── LIMPEZA DE ARQUIVOS ──────────────────────────────────────────────

        public static List<ResultadoLimpeza> AnalisarLixo()
        {
            var resultado = new List<ResultadoLimpeza>();

            // Arquivos temporários do Windows
            resultado.Add(AnalisarPasta(
                Path.GetTempPath(),
                "Arquivos Temporários do Windows",
                "🗑️",
                "Sobras de instalações, downloads e programas que já não são mais necessários."));

            // Arquivos temporários do usuário
            string tempUser = Environment.GetEnvironmentVariable("TEMP") ?? "";
            if (!string.IsNullOrEmpty(tempUser) && tempUser != Path.GetTempPath())
                resultado.Add(AnalisarPasta(tempUser, "Temporários do Usuário", "🗑️",
                    "Arquivos temporários criados pelos seus programas."));

            // Pasta Prefetch
            string prefetch = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");
            if (Directory.Exists(prefetch))
                resultado.Add(AnalisarPasta(prefetch, "Cache de Inicialização", "⚡",
                    "Arquivos antigos de agilização de abertura de programas."));

            // Cache de miniaturas
            string thumbCache = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Microsoft\Windows\Explorer");
            if (Directory.Exists(thumbCache))
                resultado.Add(AnalisarPasta(thumbCache, "Cache de Miniaturas de Imagens", "🖼️",
                    "Miniaturas de imagens e pastas que o Windows guardou para mostrar mais rápido."));

            // Cache do Windows Update
            string winUpdateCache = @"C:\Windows\SoftwareDistribution\Download";
            if (Directory.Exists(winUpdateCache))
                resultado.Add(AnalisarPasta(winUpdateCache, "Arquivos Antigos de Atualização", "🔄",
                    "Arquivos de atualizações do Windows que já foram instaladas e não são mais necessários."));

            // Lixeira
            resultado.Add(AnalisarLixeira());

            return resultado;
        }

        private static ResultadoLimpeza AnalisarPasta(string caminho, string nome, string emoji, string descricao)
        {
            var r = new ResultadoLimpeza { Nome = nome, Emoji = emoji };
            try
            {
                long total = 0;
                var dir = new DirectoryInfo(caminho);
                if (dir.Exists)
                    foreach (var f in dir.GetFiles("*", SearchOption.AllDirectories))
                        try { total += f.Length; } catch { }

                r.BytesLiberados = total;
                r.TamanhoFormatado = FormatarBytes(total);
                r.Sucesso = true;
                r.Mensagem = $"{descricao}\nTamanho encontrado: {r.TamanhoFormatado}";
            }
            catch (Exception ex)
            {
                r.Sucesso = false;
                r.Mensagem = $"Não foi possível analisar: {ex.Message}";
            }
            return r;
        }

        private static ResultadoLimpeza AnalisarLixeira()
        {
            var r = new ResultadoLimpeza { Nome = "Lixeira", Emoji = "🗑️" };
            try
            {
                long total = 0;
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (!drive.IsReady) continue;
                    string lixeira = Path.Combine(drive.Name, "$RECYCLE.BIN");
                    if (Directory.Exists(lixeira))
                        foreach (var f in new DirectoryInfo(lixeira).GetFiles("*", SearchOption.AllDirectories))
                            try { total += f.Length; } catch { }
                }
                r.BytesLiberados = total;
                r.TamanhoFormatado = FormatarBytes(total);
                r.Sucesso = true;
                r.Mensagem = total == 0
                    ? "Sua Lixeira já está vazia."
                    : $"Sua Lixeira contém {r.TamanhoFormatado} de arquivos apagados que ainda ocupam espaço.";
            }
            catch (Exception ex)
            {
                r.Sucesso = false;
                r.Mensagem = $"Não foi possível acessar a Lixeira: {ex.Message}";
            }
            return r;
        }

        public static List<ResultadoLimpeza> ExecutarLimpeza(IProgress<string> progresso = null)
        {
            var resultado = new List<ResultadoLimpeza>();
            var pastas = new[]
            {
                (Path.GetTempPath(), "Arquivos Temporários", "🗑️"),
                (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch"), "Cache de Inicialização", "⚡"),
            };

            foreach (var (caminho, nome, emoji) in pastas)
            {
                progresso?.Report($"Limpando: {nome}...");
                var r = LimparPasta(caminho, nome, emoji);
                resultado.Add(r);
            }

            progresso?.Report("Verificando Lixeira...");
            resultado.Add(LimparLixeira());

            return resultado;
        }

        private static ResultadoLimpeza LimparPasta(string caminho, string nome, string emoji)
        {
            var r = new ResultadoLimpeza { Nome = nome, Emoji = emoji };
            long liberado = 0;
            int erros = 0;
            try
            {
                var dir = new DirectoryInfo(caminho);
                if (!dir.Exists) { r.Sucesso = true; r.Mensagem = "Pasta não encontrada."; return r; }

                foreach (var f in dir.GetFiles("*", SearchOption.TopDirectoryOnly))
                    try { liberado += f.Length; f.Delete(); } catch { erros++; }
                foreach (var d in dir.GetDirectories())
                    try { d.Delete(true); } catch { erros++; }

                r.BytesLiberados = liberado;
                r.TamanhoFormatado = FormatarBytes(liberado);
                r.Sucesso = true;
                r.Mensagem = erros == 0
                    ? $"✅ Limpeza concluída! {r.TamanhoFormatado} liberados."
                    : $"✅ Limpeza parcial. {r.TamanhoFormatado} liberados ({erros} arquivo(s) em uso foram ignorados).";
            }
            catch (Exception ex)
            {
                r.Sucesso = false;
                r.Mensagem = $"❌ Erro: {ex.Message}";
            }
            return r;
        }

        private static ResultadoLimpeza LimparLixeira()
        {
            var r = new ResultadoLimpeza { Nome = "Lixeira", Emoji = "🗑️" };
            try
            {
                long total = 0;
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (!drive.IsReady) continue;
                    string lixeira = Path.Combine(drive.Name, "$RECYCLE.BIN");
                    if (!Directory.Exists(lixeira)) continue;
                    foreach (var f in new DirectoryInfo(lixeira).GetFiles("*", SearchOption.AllDirectories))
                        try { total += f.Length; f.Delete(); } catch { }
                    foreach (var d in new DirectoryInfo(lixeira).GetDirectories())
                        try { d.Delete(true); } catch { }
                }
                r.BytesLiberados = total;
                r.TamanhoFormatado = FormatarBytes(total);
                r.Sucesso = true;
                r.Mensagem = total == 0
                    ? "✅ Lixeira já estava vazia."
                    : $"✅ Lixeira esvaziada! {r.TamanhoFormatado} liberados.";
            }
            catch (Exception ex)
            {
                r.Sucesso = false;
                r.Mensagem = $"❌ Erro ao esvaziar Lixeira: {ex.Message}";
            }
            return r;
        }

        // ─── PROGRAMAS DE INICIALIZAÇÃO ───────────────────────────────────────

        public static List<ProgramaInicializacao> ObterProgramasInicializacao()
        {
            var lista = new List<ProgramaInicializacao>();
            LerRegistroInicializacao(lista, Registry.CurrentUser,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Usuário Atual");
            LerRegistroInicializacao(lista, Registry.LocalMachine,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Todos os Usuários");
            LerRegistroInicializacao(lista, Registry.CurrentUser,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", "Usuário Atual (única vez)");
            return lista;
        }

        private static void LerRegistroInicializacao(
            List<ProgramaInicializacao> lista, RegistryKey raiz, string caminho, string origem)
        {
            try
            {
                using (var chave = raiz.OpenSubKey(caminho, false))
                {
                    if (chave == null) return;
                    foreach (string nome in chave.GetValueNames())
                    {
                        string valor = chave.GetValue(nome)?.ToString() ?? "";
                        var prog = new ProgramaInicializacao
                        {
                            Nome = nome,
                            Caminho = valor,
                            Ativo = true,
                            Origem = origem,
                            ChaveRegistro = caminho
                        };
                        ClassificarProgramaInicializacao(prog);
                        lista.Add(prog);
                    }
                }
            }
            catch { /* sem permissão — ignora */ }
        }

        private static void ClassificarProgramaInicializacao(ProgramaInicializacao prog)
        {
            string nome = prog.Nome.ToLower();
            string path = prog.Caminho.ToLower();

            // Classifica impacto
            if (path.Contains("microsoft") || path.Contains("windows") ||
                nome.Contains("security") || nome.Contains("antivirus"))
            {
                prog.ImpactoNaInicializacao = "Baixo — Parte do Windows";
                prog.ImpactoEmoji = "🟢";
                prog.Recomendacao = "✅ Este programa faz parte do Windows ou é importante para segurança. Mantenha ativo.";
            }
            else if (nome.Contains("update") || nome.Contains("updater") || nome.Contains("atualiz"))
            {
                prog.ImpactoNaInicializacao = "Médio — Atualizador automático";
                prog.ImpactoEmoji = "🟡";
                prog.Recomendacao = "💡 Atualizadores automáticos podem ser desativados — você ainda consegue atualizar manualmente abrindo o programa.";
            }
            else if (nome.Contains("discord") || nome.Contains("steam") || nome.Contains("spotify") ||
                     nome.Contains("teams") || nome.Contains("zoom") || nome.Contains("skype") ||
                     nome.Contains("slack") || nome.Contains("dropbox") || nome.Contains("onedrive") ||
                     nome.Contains("googledrive") || nome.Contains("whatsapp"))
            {
                prog.ImpactoNaInicializacao = "Médio — Aplicativo de comunicação ou nuvem";
                prog.ImpactoEmoji = "🟡";
                prog.Recomendacao = "💡 Abre automaticamente com o Windows. Se não usa constantemente, pode desativar para o computador iniciar mais rápido.";
            }
            else
            {
                prog.ImpactoNaInicializacao = "Verificar — Programa de terceiro";
                prog.ImpactoEmoji = "⚪";
                prog.Recomendacao = "❓ Programa desconhecido. Pesquise o nome antes de desativar para entender o que é.";
            }

            // Fabricante simplificado
            if (path.Contains("microsoft")) prog.Fabricante = "Microsoft";
            else if (path.Contains("google")) prog.Fabricante = "Google";
            else if (path.Contains("adobe")) prog.Fabricante = "Adobe";
            else if (path.Contains("apple")) prog.Fabricante = "Apple";
            else if (path.Contains("nvidia")) prog.Fabricante = "NVIDIA";
            else if (path.Contains("intel")) prog.Fabricante = "Intel";
            else if (path.Contains("amd") || path.Contains("realtek")) prog.Fabricante = "Fabricante de hardware";
            else prog.Fabricante = "Desconhecido";

            prog.Descricao = $"Abre automaticamente quando o Windows inicia. Caminho: {prog.Caminho}";
        }

        public static (bool Sucesso, string Mensagem) DesativarProgramaInicializacao(
            ProgramaInicializacao prog)
        {
            try
            {
                var raiz = prog.Origem.Contains("Todos") ? Registry.LocalMachine : Registry.CurrentUser;
                using (var chave = raiz.OpenSubKey(prog.ChaveRegistro, true))
                {
                    if (chave == null)
                        return (false, "Não foi possível acessar o registro. Tente como Administrador.");
                    chave.DeleteValue(prog.Nome, false);
                    return (true, $"✅ '{prog.Nome}' foi removido da inicialização.\n\nO programa ainda funciona normalmente — só não vai mais abrir sozinho quando o Windows ligar.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Erro: {ex.Message}");
            }
        }

        // ─── INFORMAÇÕES DE DISCO ─────────────────────────────────────────────

        public static List<InfoDisco> AnalisarDiscos()
        {
            var lista = new List<InfoDisco>();
            try
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (!drive.IsReady) continue;
                    var info = new InfoDisco
                    {
                        Letra = drive.Name,
                        Nome = string.IsNullOrEmpty(drive.VolumeLabel) ? $"Disco {drive.Name}" : drive.VolumeLabel,
                        Tipo = drive.DriveType switch
                        {
                            DriveType.Fixed => "Disco Interno",
                            DriveType.Removable => "Pen Drive / Cartão",
                            DriveType.Network => "Disco de Rede",
                            DriveType.CDRom => "CD/DVD",
                            _ => "Outro"
                        },
                        EspacoTotalBytes = drive.TotalSize,
                        EspacoLivreBytes = drive.AvailableFreeSpace,
                        EspacoUsadoBytes = drive.TotalSize - drive.AvailableFreeSpace
                    };
                    info.PorcentagemUso = info.EspacoTotalBytes > 0
                        ? (double)info.EspacoUsadoBytes / info.EspacoTotalBytes * 100 : 0;

                    if (info.PorcentagemUso >= 95)
                    {
                        info.SaudeStatus = "Crítico — Quase cheio!";
                        info.SaudeEmoji = "🔴";
                        info.Alerta = $"⚠️ ATENÇÃO! Seu disco {info.Letra} está com {info.PorcentagemUso:0}% cheio. O computador pode ficar muito lento ou travar. Apague arquivos ou mova-os para outro lugar urgentemente.";
                    }
                    else if (info.PorcentagemUso >= 85)
                    {
                        info.SaudeStatus = "Atenção — Ficando cheio";
                        info.SaudeEmoji = "🟠";
                        info.Alerta = $"💡 Seu disco {info.Letra} está com {info.PorcentagemUso:0}% ocupado. Considere fazer uma limpeza em breve.";
                    }
                    else if (info.PorcentagemUso >= 70)
                    {
                        info.SaudeStatus = "Bom — Com espaço";
                        info.SaudeEmoji = "🟡";
                        info.Alerta = $"✅ Disco {info.Letra} com {FormatarBytes(info.EspacoLivreBytes)} livres.";
                    }
                    else
                    {
                        info.SaudeStatus = "Ótimo — Bastante espaço livre";
                        info.SaudeEmoji = "🟢";
                        info.Alerta = $"✅ Disco {info.Letra} com bastante espaço: {FormatarBytes(info.EspacoLivreBytes)} livres.";
                    }

                    lista.Add(info);
                }
            }
            catch (Exception ex)
            {
                lista.Add(new InfoDisco { Nome = "Erro ao ler discos: " + ex.Message, SaudeEmoji = "❌" });
            }
            return lista;
        }

        // ─── CHECK-UP GERAL ───────────────────────────────────────────────────

        public static ResultadoManutencao ExecutarCheckup()
        {
            var resultado = new ResultadoManutencao();
            int pontos = 100;

            // Verifica discos
            foreach (var disco in AnalisarDiscos())
            {
                if (disco.PorcentagemUso >= 95) { pontos -= 25; resultado.ProblemasEncontrados.Add($"🔴 Disco {disco.Letra} está quase cheio ({disco.PorcentagemUso:0}%)!"); resultado.Recomendacoes.Add($"Faça uma limpeza urgente no disco {disco.Letra}."); }
                else if (disco.PorcentagemUso >= 85) { pontos -= 10; resultado.ProblemasEncontrados.Add($"🟠 Disco {disco.Letra} está ficando cheio ({disco.PorcentagemUso:0}%)."); resultado.Recomendacoes.Add($"Considere limpar o disco {disco.Letra} em breve."); }
            }

            // Verifica arquivos temporários
            long totalTemp = 0;
            foreach (var lixo in AnalisarLixo()) totalTemp += lixo.BytesLiberados;
            if (totalTemp > 5L * 1024 * 1024 * 1024) { pontos -= 15; resultado.ProblemasEncontrados.Add($"🟠 Mais de {FormatarBytes(totalTemp)} de arquivos desnecessários encontrados."); resultado.Recomendacoes.Add("Execute a limpeza de arquivos temporários."); }
            else if (totalTemp > 1L * 1024 * 1024 * 1024) { pontos -= 5; resultado.ProblemasEncontrados.Add($"💡 {FormatarBytes(totalTemp)} de arquivos temporários podem ser apagados."); resultado.Recomendacoes.Add("Uma limpeza de arquivos temporários seria benéfica."); }

            // Verifica programas de inicialização
            var progs = ObterProgramasInicializacao();
            if (progs.Count > 15) { pontos -= 10; resultado.ProblemasEncontrados.Add($"🟠 {progs.Count} programas abrem com o Windows — pode estar deixando o computador mais lento para ligar."); resultado.Recomendacoes.Add("Revise os programas que abrem com o Windows e desative os desnecessários."); }
            else if (progs.Count > 8) { pontos -= 5; resultado.ProblemasEncontrados.Add($"💡 {progs.Count} programas abrem com o Windows."); resultado.Recomendacoes.Add("Verifique se todos os programas que abrem com o Windows são necessários."); }

            // Memória RAM via WMI
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT FreePhysicalMemory, TotalVisibleMemorySize FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        long total = Convert.ToInt64(obj["TotalVisibleMemorySize"]) * 1024;
                        long livre = Convert.ToInt64(obj["FreePhysicalMemory"]) * 1024;
                        double pct = (double)(total - livre) / total * 100;
                        if (pct > 90) { pontos -= 15; resultado.ProblemasEncontrados.Add($"🔴 Memória quase esgotada! {pct:0}% em uso."); resultado.Recomendacoes.Add("Feche programas desnecessários ou considere ampliar a memória."); }
                        else if (pct > 80) { pontos -= 8; resultado.ProblemasEncontrados.Add($"🟠 Memória com {pct:0}% em uso — computador pode estar lento."); resultado.Recomendacoes.Add("Feche alguns programas abertos para liberar memória."); }
                    }
                }
            }
            catch { /* continua sem memória */ }

            // Pontuação final
            pontos = Math.Max(0, pontos);
            resultado.Pontuacao = pontos;

            if (pontos >= 85) { resultado.Classificacao = "Ótimo estado!"; resultado.Emoji = "🌟"; resultado.Resumo = "Seu computador está em ótimas condições. Parabéns pela manutenção!"; }
            else if (pontos >= 70) { resultado.Classificacao = "Bom estado"; resultado.Emoji = "✅"; resultado.Resumo = "Seu computador está bem, mas há algumas coisas que podem ser melhoradas."; }
            else if (pontos >= 50) { resultado.Classificacao = "Precisa de atenção"; resultado.Emoji = "⚠️"; resultado.Resumo = "Seu computador precisa de manutenção. Siga as recomendações abaixo."; }
            else { resultado.Classificacao = "Precisa de cuidados!"; resultado.Emoji = "🔴"; resultado.Resumo = "Seu computador precisa de atenção urgente. Resolva os problemas indicados."; }

            if (resultado.ProblemasEncontrados.Count == 0)
                resultado.ProblemasEncontrados.Add("✅ Nenhum problema encontrado!");

            return resultado;
        }

        // ─── AUXILIARES ───────────────────────────────────────────────────────

        public static string FormatarBytes(long bytes)
        {
            if (bytes <= 0) return "0 bytes";
            if (bytes < 1024) return $"{bytes} bytes";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:0.#} KB";
            if (bytes < 1024L * 1024 * 1024) return $"{bytes / (1024.0 * 1024):0.#} MB";
            return $"{bytes / (1024.0 * 1024 * 1024):0.##} GB";
        }

        public static void AbrirLimpezaDeDisco()
        {
            try { Process.Start("cleanmgr.exe"); }
            catch { }
        }

        public static void AbrirGerenciadorDeTarefas()
        {
            try { Process.Start("taskmgr.exe"); }
            catch { }
        }
    }
}