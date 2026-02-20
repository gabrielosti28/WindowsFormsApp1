using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace GuiaDoComputador
{
    public class InfoRede
    {
        public string Nome { get; set; }
        public string NomeAmigavel { get; set; }
        public string Tipo { get; set; }
        public string TipoEmoji { get; set; }
        public string Status { get; set; }
        public string StatusEmoji { get; set; }
        public string EnderecoIP { get; set; }
        public string MascaraRede { get; set; }
        public string Gateway { get; set; }
        public List<string> ServidoresDNS { get; set; } = new List<string>();
        public string VelocidadeConexao { get; set; }
        public string EnderecoMac { get; set; }
        public string Explicacao { get; set; }
        public string Dica { get; set; }
    }

    public class ResultadoDiagnostico
    {
        public string Titulo { get; set; }
        public string Emoji { get; set; }
        public bool Passou { get; set; }
        public string Resultado { get; set; }
        public string Explicacao { get; set; }
        public string OQueSignifica { get; set; }
        public string OQueFazer { get; set; }
    }

    public class InfoWifi
    {
        public string NomeRede { get; set; }
        public string Senha { get; set; }
        public string TipoSeguranca { get; set; }
        public bool Conectada { get; set; }
    }

    public static class NetworkDiagnosticsService
    {
        // ─── LISTAR ADAPTADORES DE REDE ──────────────────────────────────────

        public static List<InfoRede> ObterAdaptadoresDeRede()
        {
            var lista = new List<InfoRede>();
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Ignora loopback e túneis
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                        ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                        continue;

                    var info = new InfoRede
                    {
                        Nome   = ni.Name,
                        Status = ni.OperationalStatus == OperationalStatus.Up ? "Conectado" : "Desconectado"
                    };
                    info.StatusEmoji = info.Status == "Conectado" ? "🟢" : "🔴";

                    // Tipo
                    switch (ni.NetworkInterfaceType)
                    {
                        case NetworkInterfaceType.Wireless80211:
                            info.Tipo      = "Wi-Fi";
                            info.TipoEmoji = "📶";
                            info.NomeAmigavel = "Wi-Fi";
                            info.Explicacao = "Conexão sem fio. É o jeito mais comum de se conectar à internet em casa, usando ondas de rádio.";
                            break;
                        case NetworkInterfaceType.Ethernet:
                            info.Tipo      = "Cabo de Rede";
                            info.TipoEmoji = "🔌";
                            info.NomeAmigavel = "Rede por Cabo";
                            info.Explicacao = "Conexão com fio. Geralmente mais estável e rápida que o Wi-Fi.";
                            break;
                        case NetworkInterfaceType.Ppp:
                            info.Tipo      = "Discada/VPN";
                            info.TipoEmoji = "📞";
                            info.NomeAmigavel = "Conexão VPN ou Discada";
                            info.Explicacao = "Conexão especial — pode ser uma VPN (rede segura de empresa) ou conexão discada.";
                            break;
                        default:
                            info.Tipo      = "Outro";
                            info.TipoEmoji = "🔗";
                            info.NomeAmigavel = ni.Name;
                            info.Explicacao = "Adaptador de rede virtual ou especial.";
                            break;
                    }

                    // Endereço MAC
                    var mac = ni.GetPhysicalAddress();
                    if (mac != null)
                    {
                        string macStr = BitConverter.ToString(mac.GetAddressBytes()).Replace("-", ":");
                        info.EnderecoMac = macStr == "" ? "N/A" : macStr;
                    }

                    // Velocidade
                    if (ni.Speed > 0)
                    {
                        long mbps = ni.Speed / 1_000_000;
                        info.VelocidadeConexao = mbps >= 1000
                            ? $"{mbps / 1000} Gbps (velocidade ultra rápida)"
                            : $"{mbps} Mbps";
                    }
                    else info.VelocidadeConexao = "Desconhecida";

                    // IPs
                    var ipProps = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            info.EnderecoIP    = ip.Address.ToString();
                            info.MascaraRede   = ip.IPv4Mask?.ToString() ?? "";
                            break;
                        }
                    }
                    foreach (GatewayIPAddressInformation gw in ipProps.GatewayAddresses)
                    {
                        info.Gateway = gw.Address.ToString();
                        break;
                    }
                    foreach (IPAddress dns in ipProps.DnsAddresses)
                    {
                        if (dns.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            info.ServidoresDNS.Add(dns.ToString());
                    }

                    // Dicas
                    if (info.Status == "Conectado")
                        info.Dica = string.IsNullOrEmpty(info.EnderecoIP)
                            ? "⚠️ Conectado mas sem endereço IP. Tente renovar a conexão."
                            : $"✅ Conectado. Seu endereço nesta rede é {info.EnderecoIP}.";
                    else
                        info.Dica = info.Tipo == "Wi-Fi"
                            ? "💡 Wi-Fi desconectado. Verifique se está dentro do alcance e se a senha está correta."
                            : "💡 Sem conexão. Verifique o cabo de rede.";

                    lista.Add(info);
                }
            }
            catch (Exception ex)
            {
                lista.Add(new InfoRede
                {
                    Nome      = "Erro",
                    Explicacao= $"Não foi possível obter informações de rede: {ex.Message}",
                    StatusEmoji = "❌"
                });
            }
            return lista;
        }

        // ─── DIAGNÓSTICO COMPLETO ────────────────────────────────────────────

        public static List<ResultadoDiagnostico> ExecutarDiagnostico()
        {
            var resultados = new List<ResultadoDiagnostico>();

            // 1. Teste de adaptador de rede ativo
            bool temAdaptador = false;
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    temAdaptador = true;
                    break;
                }
            }
            resultados.Add(new ResultadoDiagnostico
            {
                Titulo        = "Conexão de rede ativa",
                Emoji         = "🔌",
                Passou        = temAdaptador,
                Resultado     = temAdaptador ? "✅ Sim — encontrei uma conexão ativa" : "❌ Nenhuma conexão ativa encontrada",
                Explicacao    = "Verifica se há algum cabo de rede conectado ou Wi-Fi ativo.",
                OQueSignifica = temAdaptador ? "Seu computador está fisicamente conectado à rede." : "Seu computador não reconhece nenhuma conexão.",
                OQueFazer     = temAdaptador ? "Nenhuma ação necessária." : "Verifique se o cabo está conectado ou se o Wi-Fi está ligado."
            });

            // 2. Teste de gateway (roteador)
            string gatewayIp = "";
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus != OperationalStatus.Up) continue;
                foreach (var gw in ni.GetIPProperties().GatewayAddresses)
                {
                    if (gw.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        gatewayIp = gw.Address.ToString();
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(gatewayIp)) break;
            }

            bool pingGateway = false;
            if (!string.IsNullOrEmpty(gatewayIp))
            {
                try
                {
                    var ping = new Ping();
                    var reply = ping.Send(gatewayIp, 2000);
                    pingGateway = reply?.Status == IPStatus.Success;
                }
                catch { }
            }
            resultados.Add(new ResultadoDiagnostico
            {
                Titulo        = "Comunicação com o Roteador (Wi-Fi)",
                Emoji         = "📡",
                Passou        = pingGateway,
                Resultado     = pingGateway ? $"✅ Roteador respondendo ({gatewayIp})" : "❌ Roteador não responde",
                Explicacao    = "Testa se o seu computador consegue 'falar' com o roteador (aparelho que distribui a internet).",
                OQueSignifica = pingGateway ? "Seu computador está se comunicando com o roteador corretamente." : "Seu computador não consegue alcançar o roteador.",
                OQueFazer     = pingGateway ? "Comunicação com roteador normal." : "Tente desligar e ligar o roteador. Verifique os cabos e a distância do Wi-Fi."
            });

            // 3. Teste de DNS (resolver nomes de sites)
            bool dnsOk = false;
            try
            {
                var entry = Dns.GetHostEntry("google.com");
                dnsOk = entry.AddressList.Length > 0;
            }
            catch { }
            resultados.Add(new ResultadoDiagnostico
            {
                Titulo        = "Lista de endereços de sites (DNS)",
                Emoji         = "📖",
                Passou        = dnsOk,
                Resultado     = dnsOk ? "✅ Funcionando — conseguiu encontrar o endereço do Google" : "❌ Falhou — não conseguiu resolver endereços de sites",
                Explicacao    = "Testa se o sistema de busca de endereços (que converte 'google.com' no endereço real) está funcionando.",
                OQueSignifica = dnsOk ? "Você consegue acessar sites pelo nome normalmente." : "Sites podem abrir mostrando erros de DNS ou não abrir pelo nome.",
                OQueFazer     = dnsOk ? "DNS funcionando normalmente." : "Tente usar o DNS do Google (8.8.8.8) nas configurações de rede ou reiniciar o roteador."
            });

            // 4. Teste de internet (Google)
            bool internetOk = false;
            long latencia = -1;
            try
            {
                var ping = new Ping();
                var reply = ping.Send("8.8.8.8", 5000);
                if (reply?.Status == IPStatus.Success)
                {
                    internetOk = true;
                    latencia = reply.RoundtripTime;
                }
            }
            catch { }
            string qualidadeLatencia = latencia switch
            {
                < 0   => "Sem resposta",
                < 20  => "Excelente (muito rápida)",
                < 50  => "Boa",
                < 100 => "Razoável",
                < 200 => "Lenta",
                _     => "Muito lenta"
            };
            resultados.Add(new ResultadoDiagnostico
            {
                Titulo        = "Acesso à internet",
                Emoji         = "🌐",
                Passou        = internetOk,
                Resultado     = internetOk ? $"✅ Internet funcionando — resposta em {latencia}ms ({qualidadeLatencia})" : "❌ Sem acesso à internet",
                Explicacao    = "Testa se seu computador consegue alcançar servidores na internet.",
                OQueSignifica = internetOk ? "Sua internet está funcionando." : "O computador está conectado à rede mas sem acesso à internet.",
                OQueFazer     = internetOk ? "Internet funcionando." : "Reinicie o roteador. Se persistir, entre em contato com sua operadora de internet."
            });

            // 5. Velocidade de latência para o usuário
            if (internetOk)
            {
                string dica = latencia < 50
                    ? "Sua internet está rápida — boa para videoconferências, streaming e jogos."
                    : latencia < 100
                    ? "Internet com velocidade média — boa para streaming mas pode ter pequenas falhas em jogos."
                    : "Internet lenta. Pode causar problemas em videoconferências e travamentos em streaming.";

                resultados.Add(new ResultadoDiagnostico
                {
                    Titulo        = "Qualidade da conexão",
                    Emoji         = "⚡",
                    Passou        = latencia < 100,
                    Resultado     = $"Velocidade de resposta: {latencia}ms — {qualidadeLatencia}",
                    Explicacao    = "A latência é o tempo que leva para enviar um pacote de dados e receber resposta — como o eco numa caverna.",
                    OQueSignifica = dica,
                    OQueFazer     = latencia >= 100 ? "Aproxime-se do roteador, reduza o número de dispositivos conectados ou verifique com sua operadora." : "Nenhuma ação necessária."
                });
            }

            return resultados;
        }

        // ─── SENHAS DE WI-FI SALVAS ──────────────────────────────────────────

        public static List<InfoWifi> ObterRedesSalvas()
        {
            var lista = new List<InfoWifi>();
            try
            {
                // Listar perfis
                var procPerfis = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName               = "netsh",
                        Arguments              = "wlan show profiles",
                        RedirectStandardOutput = true,
                        UseShellExecute        = false,
                        CreateNoWindow         = true
                    }
                };
                procPerfis.Start();
                string saidaPerfis = procPerfis.StandardOutput.ReadToEnd();
                procPerfis.WaitForExit(5000);

                // Extrair nomes
                foreach (string linha in saidaPerfis.Split('\n'))
                {
                    if (!linha.Contains(":")) continue;
                    int idx = linha.IndexOf(':');
                    if (idx < 0) continue;
                    string parte = linha.Substring(0, idx).Trim().ToLower();
                    if (!parte.Contains("all user profile") && !parte.Contains("todos os perfis")) continue;
                    string nomeRede = linha.Substring(idx + 1).Trim();
                    if (string.IsNullOrEmpty(nomeRede)) continue;

                    var wifi = new InfoWifi { NomeRede = nomeRede };

                    // Buscar senha
                    try
                    {
                        var procSenha = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName               = "netsh",
                                Arguments              = $"wlan show profile name=\"{nomeRede}\" key=clear",
                                RedirectStandardOutput = true,
                                UseShellExecute        = false,
                                CreateNoWindow         = true
                            }
                        };
                        procSenha.Start();
                        string saidaSenha = procSenha.StandardOutput.ReadToEnd();
                        procSenha.WaitForExit(3000);

                        foreach (string l in saidaSenha.Split('\n'))
                        {
                            string ll = l.ToLower();
                            if (ll.Contains("key content") || ll.Contains("conteúdo da chave"))
                            {
                                int i = l.IndexOf(':');
                                if (i >= 0) wifi.Senha = l.Substring(i + 1).Trim();
                            }
                            if (ll.Contains("authentication") || ll.Contains("autenticação"))
                            {
                                int i = l.IndexOf(':');
                                if (i >= 0) wifi.TipoSeguranca = l.Substring(i + 1).Trim();
                            }
                        }
                        if (string.IsNullOrEmpty(wifi.Senha)) wifi.Senha = "(Sem senha ou protegido)";
                    }
                    catch { wifi.Senha = "(Não foi possível obter)"; }

                    lista.Add(wifi);
                }
            }
            catch (Exception ex)
            {
                lista.Add(new InfoWifi { NomeRede = "Erro: " + ex.Message });
            }
            return lista;
        }

        // ─── DNS ─────────────────────────────────────────────────────────────

        public static List<(string Nome, string IP, string Descricao, string Velocidade)> ObterOpcoesDns()
        {
            return new List<(string, string, string, string)>
            {
                ("DNS Automático (padrão)", "automático",
                 "Usa o servidor de endereços fornecido automaticamente pelo seu roteador. Recomendado para a maioria dos usuários.",
                 "Variável"),
                ("Google DNS", "8.8.8.8 / 8.8.4.4",
                 "Servidor de endereços do Google. Geralmente rápido e confiável. Boa opção se o DNS automático estiver lento.",
                 "Muito rápido"),
                ("Cloudflare DNS", "1.1.1.1 / 1.0.0.1",
                 "Servidor de endereços da Cloudflare. Focado em privacidade — não registra sua atividade. Considerado o mais rápido do mundo.",
                 "Ultra rápido"),
                ("DNS Seguro OpenDNS", "208.67.222.222 / 208.67.220.220",
                 "Bloqueia sites maliciosos e de conteúdo adulto automaticamente. Boa opção para famílias com crianças.",
                 "Rápido"),
            };
        }

        // ─── AUXILIARES ──────────────────────────────────────────────────────

        public static void AbrirConfiguracaoRede() =>
            Process.Start(new ProcessStartInfo("ms-settings:network") { UseShellExecute = true });

        public static void AbrirAdaptadoresRede() =>
            Process.Start(new ProcessStartInfo("ncpa.cpl") { UseShellExecute = true });

        public static (bool Sucesso, string Mensagem) RenovarConexao()
        {
            try
            {
                var psi = new ProcessStartInfo("cmd.exe",
                    "/c ipconfig /release && ipconfig /flushdns && ipconfig /renew")
                {
                    UseShellExecute        = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow         = true,
                    Verb                   = "runas"
                };
                using (var proc = Process.Start(psi))
                {
                    string saida = proc?.StandardOutput.ReadToEnd() ?? "";
                    proc?.WaitForExit(30000);
                    return (true, "✅ Conexão renovada!\n\nO computador pediu um novo endereço de internet para o roteador.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"❌ Erro ao renovar: {ex.Message}\n\nTente como Administrador.");
            }
        }
    }
}