using System.Collections.Generic;
using System.Linq;
using AppInterno.Models;

namespace AppInterno.Services
{
    /// <summary>
    /// Serviço responsável por fornecer atalhos do Excel
    /// </summary>
    public class ExcelShortcutsService : IShortcutsService
    {
        private List<ShortcutItem> shortcuts;

        public ExcelShortcutsService()
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
                Id = "excel",
                DisplayName = "Excel",
                Description = "Atalhos para planilhas",
                Icon = "📊",
                ColorHex = "#217346",
                TotalShortcuts = GetTotalCount(),
                IsAvailable = true,
                DisplayOrder = 2
            };
        }

        public string GetProgramName()
        {
            return "Excel";
        }

        private void InitializeShortcuts()
        {
            // Pegando os atalhos do Excel que já existem no seu DiscoveryService
            // Vou pegar os principais (por limite de espaço, mas você pode adicionar todos)
            shortcuts = new List<ShortcutItem>
            {
                new ShortcutItem
                {
                    Id = "excel_tab",
                    Program = "Excel",
                    Title = "Mover para célula à direita",
                    Description = "Vai para a próxima célula à direita",
                    Keys = "Tab",
                    Category = "Navegação Básica",
                    DetailedExplanation = "Ao invés de clicar com o mouse, apenas aperte Tab para ir para a célula da direita. Muito mais rápido!",
                    WhenToUse = "Quando estiver preenchendo uma linha de dados e quiser ir para a próxima coluna.",
                    PracticalExample = "Digitou o nome na coluna A? Aperte Tab e digite o sobrenome na coluna B.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_enter",
                    Program = "Excel",
                    Title = "Mover para baixo",
                    Description = "Vai para a célula abaixo",
                    Keys = "Enter",
                    Category = "Navegação Básica",
                    DetailedExplanation = "Depois de digitar algo, aperte Enter para confirmar e ir para a célula de baixo automaticamente.",
                    WhenToUse = "Quando estiver preenchendo uma coluna de cima para baixo.",
                    PracticalExample = "Digitando lista de produtos? Digite o primeiro, Enter, digite o segundo, Enter...",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_c",
                    Program = "Excel",
                    Title = "Copiar",
                    Description = "Copia as células selecionadas",
                    Keys = "Ctrl + C",
                    Category = "Edição",
                    DetailedExplanation = "Copia o conteúdo das células selecionadas para a área de transferência.",
                    WhenToUse = "Para duplicar dados de uma célula para outra.",
                    PracticalExample = "Copiou uma fórmula de A1? Cole em B1, B2, B3 quantas vezes quiser!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_v",
                    Program = "Excel",
                    Title = "Colar",
                    Description = "Cola o conteúdo copiado",
                    Keys = "Ctrl + V",
                    Category = "Edição",
                    DetailedExplanation = "Cola o que você copiou anteriormente.",
                    WhenToUse = "Depois de copiar células ou fórmulas.",
                    PracticalExample = "Copiou valores de janeiro? Cole em fevereiro, março...",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_z",
                    Program = "Excel",
                    Title = "Desfazer",
                    Description = "Desfaz a última ação",
                    Keys = "Ctrl + Z",
                    Category = "Edição",
                    DetailedExplanation = "Volta atrás no que você fez. Pode usar várias vezes seguidas.",
                    WhenToUse = "Quando errar ou se arrepender de algo que fez.",
                    PracticalExample = "Deletou dados sem querer? Ctrl+Z recupera!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_alt_igual",
                    Program = "Excel",
                    Title = "Soma automática",
                    Description = "Cria fórmula SOMA automaticamente",
                    Keys = "Alt + =",
                    Category = "Fórmulas",
                    DetailedExplanation = "Excel detecta os números acima ou à esquerda e cria uma fórmula SOMA automaticamente!",
                    WhenToUse = "Para somar rapidamente sem digitar a fórmula.",
                    PracticalExample = "Tem números de A1:A10? Vá para A11 e aperte Alt+=. Excel cria =SOMA(A1:A10) sozinho!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_space",
                    Program = "Excel",
                    Title = "Selecionar coluna inteira",
                    Description = "Seleciona toda a coluna onde você está",
                    Keys = "Ctrl + Espaço",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona a coluna inteira de cima até embaixo.",
                    WhenToUse = "Quando quer formatar, deletar ou copiar uma coluna inteira.",
                    PracticalExample = "Quer deixar toda coluna B em negrito? Ctrl+Espaço e depois Ctrl+B.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_shift_space",
                    Program = "Excel",
                    Title = "Selecionar linha inteira",
                    Description = "Seleciona toda a linha onde você está",
                    Keys = "Shift + Espaço",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona a linha inteira da esquerda até a direita.",
                    WhenToUse = "Para deletar, copiar ou formatar uma linha completa.",
                    PracticalExample = "Quer deletar a linha 5 inteira? Vá para qualquer célula da linha 5, Shift+Espaço, depois Delete.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_f2",
                    Program = "Excel",
                    Title = "Editar célula (modo edição)",
                    Description = "Permite editar o conteúdo da célula",
                    Keys = "F2",
                    Category = "Edição",
                    DetailedExplanation = "Entra no modo de edição sem apagar o que já está na célula. Você pode mover o cursor e editar o texto.",
                    WhenToUse = "Quando quer editar apenas parte do texto, não substituir tudo.",
                    PracticalExample = "Célula tem 'João Silva' mas você quer mudar para 'João Santos'? F2, apaga 'Silva', digita 'Santos'.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ShortcutItem
                {
                    Id = "excel_ctrl_1",
                    Program = "Excel",
                    Title = "Abrir formatação de células",
                    Description = "Abre a janela completa de formatação",
                    Keys = "Ctrl + 1",
                    Category = "Formatação",
                    DetailedExplanation = "Abre a janela onde você pode mudar tudo: número, fonte, bordas, preenchimento, etc.",
                    WhenToUse = "Quando precisa fazer formatações mais complexas.",
                    PracticalExample = "Quer mudar para moeda brasileira? Ctrl+1, aba Número, escolhe Moeda.",
                    PopularityScore = 5,
                    RequiresMouse = false
                }
            };
        }
    }
}