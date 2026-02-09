using System.Collections.Generic;
using System.Linq;
using AppInterno.Models;

namespace AppInterno.Services
{
    /// <summary>
    /// Serviço responsável por fornecer atalhos do Windows
    /// </summary>
    public class WindowsShortcutsService : IShortcutsService
    {
        private List<ShortcutItem> shortcuts;

        public WindowsShortcutsService()
        {
            InitializeShortcuts();
        }

        public List<ShortcutItem> GetAllShortcuts()
        {
            return shortcuts;
        }

        public List<ShortcutItem> SearchShortcuts(string query)
        {
            query = query.ToLower();
            return shortcuts.Where(s =>
                s.Title.ToLower().Contains(query) ||
                s.Description.ToLower().Contains(query) ||
                s.Keys.ToLower().Contains(query) ||
                s.Category.ToLower().Contains(query)
            ).ToList();
        }

        public List<ShortcutItem> GetByCategory(string category)
        {
            return shortcuts.Where(s => s.Category == category).ToList();
        }

        public int GetTotalCount()
        {
            return shortcuts.Count;
        }

        public List<string> GetCategories()
        {
            return shortcuts.Select(s => s.Category).Distinct().OrderBy(c => c).ToList();
        }

        public ProgramInfo GetProgramInfo()
        {
            return new ProgramInfo
            {
                Id = "windows",
                DisplayName = "Windows",
                Description = "Atalhos do sistema operacional",
                Icon = "⌨️",
                ColorHex = "#0078D4",
                TotalShortcuts = GetTotalCount(),
                IsAvailable = true,
                DisplayOrder = 1
            };
        }

        public string GetProgramName()
        {
            return "Windows";
        }

        private void InitializeShortcuts()
        {
            shortcuts = new List<ShortcutItem>
            {
                // ===== GERAIS - MAIS USADOS =====
                new ShortcutItem
                {
                    Id = "windows_copiar",
                    Program = "Windows",
                    Title = "Copiar",
                    Description = "Copia o texto ou arquivo selecionado",
                    Keys = "Ctrl + C",
                    Category = "Gerais",
                    DetailedExplanation = "Quando você seleciona algo (texto, arquivo, imagem) e pressiona Ctrl+C, o Windows guarda uma cópia temporária. Você pode então colar em outro lugar.",
                    WhenToUse = "Use quando quiser duplicar algo sem apagar o original. Por exemplo: copiar um texto de um documento para outro.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_colar",
                    Program = "Windows",
                    Title = "Colar",
                    Description = "Cola o que você copiou anteriormente",
                    Keys = "Ctrl + V",
                    Category = "Gerais",
                    DetailedExplanation = "Depois de copiar algo com Ctrl+C, use Ctrl+V para colar no lugar onde o cursor está posicionado.",
                    WhenToUse = "Sempre que quiser inserir algo que você copiou antes.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_salvar",
                    Program = "Windows",
                    Title = "Salvar",
                    Description = "Salva o arquivo atual",
                    Keys = "Ctrl + S",
                    Category = "Gerais",
                    DetailedExplanation = "Salva suas alterações no arquivo que você está editando. Use sempre para não perder seu trabalho!",
                    WhenToUse = "SEMPRE! Aperte Ctrl+S frequentemente enquanto trabalha.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_recortar",
                    Program = "Windows",
                    Title = "Recortar",
                    Description = "Move o item selecionado (apaga do local original)",
                    Keys = "Ctrl + X",
                    Category = "Gerais",
                    DetailedExplanation = "Diferente do copiar, o recortar REMOVE o item do lugar original. Útil para mover coisas.",
                    WhenToUse = "Quando quer mover algo para outro lugar, não apenas copiar.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_desfazer",
                    Program = "Windows",
                    Title = "Desfazer",
                    Description = "Desfaz a última ação",
                    Keys = "Ctrl + Z",
                    Category = "Gerais",
                    DetailedExplanation = "Volta atrás no que você acabou de fazer. Funciona várias vezes seguidas!",
                    WhenToUse = "Quando errar ou se arrepender de algo que fez.",
                    PopularityScore = 5
                },

                // ===== SISTEMA WINDOWS =====
                new ShortcutItem
                {
                    Id = "windows_alternar_janelas",
                    Program = "Windows",
                    Title = "Alternar entre janelas",
                    Description = "Troca entre programas abertos",
                    Keys = "Alt + Tab",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Mostra miniatura de todos os programas abertos. Mantenha Alt pressionado e aperte Tab para escolher.",
                    WhenToUse = "Para trocar rapidamente entre programas sem usar o mouse.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_area_trabalho",
                    Program = "Windows",
                    Title = "Mostrar Área de Trabalho",
                    Description = "Minimiza tudo e mostra a área de trabalho",
                    Keys = "Win + D",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Esconde todas as janelas instantaneamente. Aperte novamente para trazê-las de volta.",
                    WhenToUse = "Quando precisa acessar algo na área de trabalho rapidamente.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_gerenciador_tarefas",
                    Program = "Windows",
                    Title = "Gerenciador de Tarefas",
                    Description = "Abre o gerenciador de tarefas",
                    Keys = "Ctrl + Shift + Esc",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre direto o gerenciador de tarefas para ver o que está rodando ou fechar programas travados.",
                    WhenToUse = "Quando um programa travar ou quiser ver o que está consumindo recursos.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_explorador_arquivos",
                    Program = "Windows",
                    Title = "Explorador de Arquivos",
                    Description = "Abre o explorador de arquivos",
                    Keys = "Win + E",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o explorador de arquivos diretamente, sem precisar clicar no ícone.",
                    WhenToUse = "Para navegar pelas pastas e arquivos rapidamente.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_pesquisar",
                    Program = "Windows",
                    Title = "Pesquisar",
                    Description = "Abre a pesquisa do Windows",
                    Keys = "Win + S",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre a barra de pesquisa para procurar arquivos, programas ou configurações.",
                    WhenToUse = "Para encontrar rapidamente qualquer coisa no computador.",
                    PopularityScore = 5
                },

                // ===== NAVEGAÇÃO =====
                new ShortcutItem
                {
                    Id = "windows_fechar_janela",
                    Program = "Windows",
                    Title = "Fechar Janela",
                    Description = "Fecha a janela atual",
                    Keys = "Alt + F4",
                    Category = "Navegação",
                    DetailedExplanation = "Fecha o programa que está em foco. Se estiver na área de trabalho, desliga o PC.",
                    WhenToUse = "Para fechar programas rapidamente.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_maximizar",
                    Program = "Windows",
                    Title = "Maximizar Janela",
                    Description = "Maximiza a janela atual",
                    Keys = "Win + Seta Cima",
                    Category = "Navegação",
                    DetailedExplanation = "Faz a janela ocupar a tela inteira.",
                    WhenToUse = "Para trabalhar com a janela em tela cheia.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_minimizar",
                    Program = "Windows",
                    Title = "Minimizar Janela",
                    Description = "Minimiza a janela atual",
                    Keys = "Win + Seta Baixo",
                    Category = "Navegação",
                    DetailedExplanation = "Envia a janela para a barra de tarefas.",
                    WhenToUse = "Para esconder temporariamente sem fechar.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_dividir_esquerda",
                    Program = "Windows",
                    Title = "Janela à Esquerda",
                    Description = "Posiciona janela ocupando metade esquerda da tela",
                    Keys = "Win + Seta Esquerda",
                    Category = "Navegação",
                    DetailedExplanation = "Coloca a janela ocupando exatamente metade da tela no lado esquerdo.",
                    WhenToUse = "Para trabalhar com dois programas lado a lado.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_dividir_direita",
                    Program = "Windows",
                    Title = "Janela à Direita",
                    Description = "Posiciona janela ocupando metade direita da tela",
                    Keys = "Win + Seta Direita",
                    Category = "Navegação",
                    DetailedExplanation = "Coloca a janela ocupando exatamente metade da tela no lado direito.",
                    WhenToUse = "Para trabalhar com dois programas lado a lado.",
                    PopularityScore = 5
                },

                // ===== PRODUTIVIDADE =====
                new ShortcutItem
                {
                    Id = "windows_captura_tela",
                    Program = "Windows",
                    Title = "Captura de Tela",
                    Description = "Ferramenta de captura de tela",
                    Keys = "Win + Shift + S",
                    Category = "Produtividade",
                    DetailedExplanation = "Abre ferramenta para tirar print de uma área específica da tela.",
                    WhenToUse = "Para capturar partes da tela e compartilhar ou salvar.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_bloquear",
                    Program = "Windows",
                    Title = "Bloquear PC",
                    Description = "Bloqueia o computador",
                    Keys = "Win + L",
                    Category = "Produtividade",
                    DetailedExplanation = "Bloqueia instantaneamente o computador, pedindo senha para desbloquear.",
                    WhenToUse = "Quando sair e quiser proteger seus dados.",
                    PopularityScore = 5
                },
                new ShortcutItem
                {
                    Id = "windows_area_transferencia",
                    Program = "Windows",
                    Title = "Histórico da Área de Transferência",
                    Description = "Mostra histórico de itens copiados",
                    Keys = "Win + V",
                    Category = "Produtividade",
                    DetailedExplanation = "Mostra os últimos 25 itens que você copiou. Você pode colar qualquer um deles!",
                    WhenToUse = "Quando precisar colar algo que copiou há alguns passos atrás.",
                    PopularityScore = 4
                },
                new ShortcutItem
                {
                    Id = "windows_emoji",
                    Program = "Windows",
                    Title = "Painel de Emojis",
                    Description = "Abre painel de emojis e símbolos",
                    Keys = "Win + . (ponto)",
                    Category = "Produtividade",
                    DetailedExplanation = "Abre um painel com emojis, kaomojis e símbolos especiais para inserir no texto.",
                    WhenToUse = "Para adicionar emojis em mensagens ou documentos.",
                    PopularityScore = 3
                },
                new ShortcutItem
                {
                    Id = "windows_renomear",
                    Program = "Windows",
                    Title = "Renomear Arquivo",
                    Description = "Renomeia o arquivo selecionado",
                    Keys = "F2",
                    Category = "Produtividade",
                    DetailedExplanation = "Com um arquivo selecionado, aperte F2 para editar o nome diretamente.",
                    WhenToUse = "Para renomear arquivos rapidamente no explorador.",
                    PopularityScore = 4
                }
            };
        }
    }
}