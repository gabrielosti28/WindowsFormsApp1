using System;
using System.Collections.Generic;
using System.Linq;

namespace AppInterno
{
    public class DiscoveryService
    {
        // Método para atalhos do Windows
        public List<KeyboardShortcut> GetKeyboardShortcuts()
        {
            return new List<KeyboardShortcut>
            {
                // ===== GERAIS - MAIS USADOS =====
                new KeyboardShortcut
                {
                    Title = "Copiar",
                    Description = "Copia o texto ou arquivo selecionado",
                    Keys = "Ctrl + C",
                    Category = "Gerais",
                    DetailedExplanation = "Quando você seleciona algo (texto, arquivo, imagem) e pressiona Ctrl+C, o Windows guarda uma cópia temporária. Você pode então colar em outro lugar.",
                    WhenToUse = "Use quando quiser duplicar algo sem apagar o original. Por exemplo: copiar um texto de um documento para outro.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Colar",
                    Description = "Cola o que você copiou anteriormente",
                    Keys = "Ctrl + V",
                    Category = "Gerais",
                    DetailedExplanation = "Depois de copiar algo com Ctrl+C, use Ctrl+V para colar no lugar onde o cursor está posicionado.",
                    WhenToUse = "Sempre que quiser inserir algo que você copiou antes.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Salvar",
                    Description = "Salva o arquivo atual",
                    Keys = "Ctrl + S",
                    Category = "Gerais",
                    DetailedExplanation = "Salva suas alterações no arquivo que você está editando. Use sempre para não perder seu trabalho!",
                    WhenToUse = "SEMPRE! Aperte Ctrl+S frequentemente enquanto trabalha.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Recortar",
                    Description = "Move o item selecionado (apaga do local original)",
                    Keys = "Ctrl + X",
                    Category = "Gerais",
                    DetailedExplanation = "Diferente do copiar, o recortar REMOVE o item do lugar original. Útil para mover coisas.",
                    WhenToUse = "Quando quer mover algo para outro lugar, não apenas copiar.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Desfazer",
                    Description = "Desfaz a última ação",
                    Keys = "Ctrl + Z",
                    Category = "Gerais",
                    DetailedExplanation = "Volta atrás no que você acabou de fazer. Funciona várias vezes seguidas!",
                    WhenToUse = "Quando errar ou se arrepender de algo que fez.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Refazer",
                    Description = "Refaz o que você desfez",
                    Keys = "Ctrl + Y",
                    Category = "Gerais",
                    DetailedExplanation = "Se você desfez demais e quer voltar.",
                    WhenToUse = "Quando desfez algo mas mudou de ideia.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Selecionar Tudo",
                    Description = "Seleciona todo o conteúdo",
                    Keys = "Ctrl + A",
                    Category = "Gerais",
                    DetailedExplanation = "Seleciona tudo no documento ou pasta atual.",
                    WhenToUse = "Para copiar ou mover tudo de uma vez.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Imprimir",
                    Description = "Abre a janela de impressão",
                    Keys = "Ctrl + P",
                    Category = "Gerais",
                    DetailedExplanation = "Abre as opções de impressão do documento ou página atual.",
                    WhenToUse = "Quando quiser imprimir algo.",
                    PopularityScore = 4
                },

                // ===== SISTEMA WINDOWS =====
                new KeyboardShortcut
                {
                    Title = "Alternar entre janelas",
                    Description = "Troca entre programas abertos",
                    Keys = "Alt + Tab",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Mostra miniatura de todos os programas abertos. Mantenha Alt pressionado e aperte Tab para escolher.",
                    WhenToUse = "Para trocar rapidamente entre programas sem usar o mouse.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Mostrar Área de Trabalho",
                    Description = "Minimiza tudo e mostra a área de trabalho",
                    Keys = "Win + D",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Esconde todas as janelas instantaneamente. Aperte novamente para trazê-las de volta.",
                    WhenToUse = "Quando precisa acessar algo na área de trabalho rapidamente.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Gerenciador de Tarefas",
                    Description = "Abre o gerenciador de tarefas",
                    Keys = "Ctrl + Shift + Esc",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre direto o gerenciador de tarefas para ver o que está rodando ou fechar programas travados.",
                    WhenToUse = "Quando um programa travar ou quiser ver o que está consumindo recursos.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Explorador de Arquivos",
                    Description = "Abre o explorador de arquivos",
                    Keys = "Win + E",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o explorador de arquivos diretamente, sem precisar clicar no ícone.",
                    WhenToUse = "Para navegar pelas pastas e arquivos rapidamente.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Pesquisar",
                    Description = "Abre a pesquisa do Windows",
                    Keys = "Win + S",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre a barra de pesquisa para procurar arquivos, programas ou configurações.",
                    WhenToUse = "Para encontrar rapidamente qualquer coisa no computador.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Configurações",
                    Description = "Abre as Configurações do Windows",
                    Keys = "Win + I",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o painel de configurações do Windows 10/11.",
                    WhenToUse = "Para mudar configurações do sistema.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Menu Iniciar",
                    Description = "Abre o Menu Iniciar",
                    Keys = "Win",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o menu iniciar. Você pode começar a digitar imediatamente para buscar.",
                    WhenToUse = "Para abrir programas rapidamente.",
                    PopularityScore = 5
                },

                // ===== NAVEGAÇÃO =====
                new KeyboardShortcut
                {
                    Title = "Fechar Janela",
                    Description = "Fecha a janela atual",
                    Keys = "Alt + F4",
                    Category = "Navegação",
                    DetailedExplanation = "Fecha o programa que está em foco. Se estiver na área de trabalho, desliga o PC.",
                    WhenToUse = "Para fechar programas rapidamente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Maximizar Janela",
                    Description = "Maximiza a janela atual",
                    Keys = "Win + Seta Cima",
                    Category = "Navegação",
                    DetailedExplanation = "Faz a janela ocupar a tela inteira.",
                    WhenToUse = "Para trabalhar com a janela em tela cheia.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Minimizar Janela",
                    Description = "Minimiza a janela atual",
                    Keys = "Win + Seta Baixo",
                    Category = "Navegação",
                    DetailedExplanation = "Envia a janela para a barra de tarefas.",
                    WhenToUse = "Para esconder temporariamente sem fechar.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Janela à Esquerda",
                    Description = "Posiciona janela ocupando metade esquerda da tela",
                    Keys = "Win + Seta Esquerda",
                    Category = "Navegação",
                    DetailedExplanation = "Coloca a janela ocupando exatamente metade da tela no lado esquerdo.",
                    WhenToUse = "Para trabalhar com dois programas lado a lado.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Janela à Direita",
                    Description = "Posiciona janela ocupando metade direita da tela",
                    Keys = "Win + Seta Direita",
                    Category = "Navegação",
                    DetailedExplanation = "Coloca a janela ocupando exatamente metade da tela no lado direito.",
                    WhenToUse = "Para trabalhar com dois programas lado a lado.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Nova Aba",
                    Description = "Abre nova aba (navegadores/explorador)",
                    Keys = "Ctrl + T",
                    Category = "Navegação",
                    DetailedExplanation = "Abre uma nova aba no navegador ou explorador de arquivos.",
                    WhenToUse = "Para abrir múltiplas páginas ou pastas.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Fechar Aba",
                    Description = "Fecha a aba atual",
                    Keys = "Ctrl + W",
                    Category = "Navegação",
                    DetailedExplanation = "Fecha a aba atual do navegador ou explorador.",
                    WhenToUse = "Para fechar abas rapidamente.",
                    PopularityScore = 5
                },

                // ===== PRODUTIVIDADE =====
                new KeyboardShortcut
                {
                    Title = "Captura de Tela",
                    Description = "Ferramenta de captura de tela",
                    Keys = "Win + Shift + S",
                    Category = "Produtividade",
                    DetailedExplanation = "Abre ferramenta para tirar print de uma área específica da tela.",
                    WhenToUse = "Para capturar partes da tela e compartilhar ou salvar.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Bloquear PC",
                    Description = "Bloqueia o computador",
                    Keys = "Win + L",
                    Category = "Produtividade",
                    DetailedExplanation = "Bloqueia instantaneamente o computador, pedindo senha para desbloquear.",
                    WhenToUse = "Quando sair e quiser proteger seus dados.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Histórico da Área de Transferência",
                    Description = "Mostra histórico de itens copiados",
                    Keys = "Win + V",
                    Category = "Produtividade",
                    DetailedExplanation = "Mostra os últimos 25 itens que você copiou. Você pode colar qualquer um deles!",
                    WhenToUse = "Quando precisar colar algo que copiou há alguns passos atrás.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Painel de Emojis",
                    Description = "Abre painel de emojis e símbolos",
                    Keys = "Win + . (ponto)",
                    Category = "Produtividade",
                    DetailedExplanation = "Abre um painel com emojis, kaomojis e símbolos especiais para inserir no texto.",
                    WhenToUse = "Para adicionar emojis em mensagens ou documentos.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Renomear Arquivo",
                    Description = "Renomeia o arquivo selecionado",
                    Keys = "F2",
                    Category = "Produtividade",
                    DetailedExplanation = "Com um arquivo selecionado, aperte F2 para editar o nome diretamente.",
                    WhenToUse = "Para renomear arquivos rapidamente no explorador.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Deletar Arquivo",
                    Description = "Move arquivo para lixeira",
                    Keys = "Delete",
                    Category = "Produtividade",
                    DetailedExplanation = "Deleta o arquivo selecionado enviando para a lixeira.",
                    WhenToUse = "Para remover arquivos que não precisa mais.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Deletar Permanentemente",
                    Description = "Deleta sem enviar para lixeira",
                    Keys = "Shift + Delete",
                    Category = "Produtividade",
                    DetailedExplanation = "Deleta o arquivo PERMANENTEMENTE, sem passar pela lixeira. Cuidado!",
                    WhenToUse = "Apenas quando tiver certeza absoluta que não precisa do arquivo.",
                    PopularityScore = 3
                }
            };
        }

        // ATALHOS DO EXCEL - COMPLETO
        public List<ExcelShortcut> GetExcelShortcuts()
        {
            return new List<ExcelShortcut>
            {
                // ===== NAVEGAÇÃO BÁSICA =====
                new ExcelShortcut
                {
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
                new ExcelShortcut
                {
                    Title = "Mover para célula à esquerda",
                    Description = "Volta para a célula anterior (esquerda)",
                    Keys = "Shift + Tab",
                    Category = "Navegação Básica",
                    DetailedExplanation = "Se você apertou Tab demais e passou da célula que queria, use Shift+Tab para voltar.",
                    WhenToUse = "Para corrigir algo na célula anterior sem usar o mouse.",
                    PracticalExample = "Preencheu B1 mas esqueceu de algo em A1? Shift+Tab volta para A1.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
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
                new ExcelShortcut
                {
                    Title = "Ir para primeira célula da planilha",
                    Description = "Volta para A1 (início)",
                    Keys = "Ctrl + Home",
                    Category = "Navegação Básica",
                    DetailedExplanation = "Não importa onde você está na planilha, isso te leva de volta para o início (célula A1).",
                    WhenToUse = "Quando se perdeu na planilha e quer voltar pro começo.",
                    PracticalExample = "Está lá na célula Z500? Ctrl+Home volta para A1 instantaneamente.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ir para última célula com dados",
                    Description = "Pula para o fim dos seus dados",
                    Keys = "Ctrl + End",
                    Category = "Navegação Básica",
                    DetailedExplanation = "Vai para a última célula que tem algum dado (canto inferior direito da sua área de trabalho).",
                    WhenToUse = "Para ver rapidamente até onde vai sua planilha.",
                    PracticalExample = "Quer saber se tem dados além da linha 100? Ctrl+End mostra.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },

                // ===== NAVEGAÇÃO RÁPIDA =====
                new ExcelShortcut
                {
                    Title = "Pular para próxima célula com dados (direita)",
                    Description = "Pula células vazias indo para direita",
                    Keys = "Ctrl + →",
                    Category = "Navegação Rápida",
                    DetailedExplanation = "Vai pulando de um grupo de dados para outro. Se tem células vazias no meio, ele pula tudo e vai direto para o próximo dado.",
                    WhenToUse = "Para navegar rapidamente em planilhas grandes sem ficar apertando seta várias vezes.",
                    PracticalExample = "Tem dados em A:E, depois células vazias, depois dados em J:M? Ctrl+→ pula de E direto para J.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Pular para próxima célula com dados (esquerda)",
                    Description = "Pula células vazias indo para esquerda",
                    Keys = "Ctrl + ←",
                    Category = "Navegação Rápida",
                    DetailedExplanation = "Mesma lógica do Ctrl+→, mas voltando (esquerda).",
                    WhenToUse = "Para voltar rapidamente entre grupos de dados.",
                    PracticalExample = "Está em M1 e quer voltar para E1? Ctrl+← faz isso instantaneamente.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Pular para próxima célula com dados (baixo)",
                    Description = "Pula células vazias indo para baixo",
                    Keys = "Ctrl + ↓",
                    Category = "Navegação Rápida",
                    DetailedExplanation = "Desce pulando células vazias até encontrar a próxima com dados.",
                    WhenToUse = "Para ir rapidamente para o final de uma lista ou coluna.",
                    PracticalExample = "Tem 1000 linhas de produtos? Ctrl+↓ vai direto para a última linha com dados.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Pular para próxima célula com dados (cima)",
                    Description = "Pula células vazias indo para cima",
                    Keys = "Ctrl + ↑",
                    Category = "Navegação Rápida",
                    DetailedExplanation = "Sobe pulando células vazias.",
                    WhenToUse = "Para voltar rapidamente ao topo de uma coluna.",
                    PracticalExample = "Está na linha 1000 e quer voltar pro cabeçalho? Ctrl+↑.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },

                // ===== SELEÇÃO =====
                new ExcelShortcut
                {
                    Title = "Selecionar coluna inteira",
                    Description = "Seleciona toda a coluna onde você está",
                    Keys = "Ctrl + Espaço",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona a coluna inteira de cima até embaixo (todas as 1.048.576 linhas!).",
                    WhenToUse = "Quando quer formatar, deletar ou copiar uma coluna inteira.",
                    PracticalExample = "Quer deixar toda coluna B em negrito? Ctrl+Espaço e depois Ctrl+B.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Selecionar linha inteira",
                    Description = "Seleciona toda a linha onde você está",
                    Keys = "Shift + Espaço",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona a linha inteira da esquerda até a direita (todas as 16.384 colunas!).",
                    WhenToUse = "Para deletar, copiar ou formatar uma linha completa.",
                    PracticalExample = "Quer deletar a linha 5 inteira? Vá para qualquer célula da linha 5, Shift+Espaço, depois Delete.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Selecionar tudo",
                    Description = "Seleciona todas as células da planilha",
                    Keys = "Ctrl + A (ou Ctrl + T)",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona absolutamente TUDO na planilha atual. Use com cuidado!",
                    WhenToUse = "Quando quer aplicar formatação em toda a planilha ou copiar tudo.",
                    PracticalExample = "Quer mudar a fonte de toda planilha? Ctrl+A e depois escolha a fonte.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Expandir seleção",
                    Description = "Segure Shift e use setas para selecionar mais células",
                    Keys = "Shift + Setas",
                    Category = "Seleção",
                    DetailedExplanation = "Mantém Shift apertado e usa as setas para ir selecionando célula por célula.",
                    WhenToUse = "Para selecionar um range específico de células.",
                    PracticalExample = "Quer selecionar A1:A10? Clique A1, Shift+↓ (9 vezes) ou Shift+Ctrl+↓.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Selecionar até o fim dos dados",
                    Description = "Seleciona do ponto atual até o fim",
                    Keys = "Ctrl + Shift + End",
                    Category = "Seleção",
                    DetailedExplanation = "Seleciona desde onde você está até a última célula com dados da planilha.",
                    WhenToUse = "Para selecionar grande quantidade de dados de uma vez.",
                    PracticalExample = "Está em A1 e quer selecionar tudo até Z1000? Ctrl+Shift+End.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Selecionar bloco de dados atual",
                    Description = "Seleciona todos os dados ao redor da célula",
                    Keys = "Ctrl + Shift + * (asterisco)",
                    Category = "Seleção",
                    DetailedExplanation = "Detecta automaticamente onde começam e terminam seus dados e seleciona tudo.",
                    WhenToUse = "Para selecionar uma tabela completa rapidamente.",
                    PracticalExample = "Tem uma tabela de vendas? Clique em qualquer célula dela e Ctrl+Shift+* seleciona tudo.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },

                // ===== EDIÇÃO =====
                new ExcelShortcut
                {
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
                new ExcelShortcut
                {
                    Title = "Copiar célula de cima",
                    Description = "Copia o valor da célula acima",
                    Keys = "Ctrl + D",
                    Category = "Edição",
                    DetailedExplanation = "Copia o conteúdo da célula de cima para a célula atual (D = Down, descer o valor).",
                    WhenToUse = "Para repetir valores rapidamente em uma coluna.",
                    PracticalExample = "A1 tem 'Brasil'. Quer preencher A2:A10 com 'Brasil'? Selecione A1:A10 e Ctrl+D.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Copiar célula da esquerda",
                    Description = "Copia o valor da célula à esquerda",
                    Keys = "Ctrl + R",
                    Category = "Edição",
                    DetailedExplanation = "Copia o conteúdo da célula da esquerda para a atual (R = Right, ir para direita).",
                    WhenToUse = "Para repetir valores rapidamente em uma linha.",
                    PracticalExample = "A1 tem '100'. Quer preencher B1:E1 com '100'? Selecione A1:E1 e Ctrl+R.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Deletar conteúdo da célula",
                    Description = "Apaga o que está na célula",
                    Keys = "Delete",
                    Category = "Edição",
                    DetailedExplanation = "Apaga o conteúdo mas mantém a formatação (cores, bordas, etc).",
                    WhenToUse = "Para limpar dados mas manter a formatação.",
                    PracticalExample = "Célula está azul e com borda, mas quer apagar só o número? Delete.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
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
                new ExcelShortcut
                {
                    Title = "Refazer",
                    Description = "Refaz o que você desfez",
                    Keys = "Ctrl + Y",
                    Category = "Edição",
                    DetailedExplanation = "Se você desfez demais e quer voltar.",
                    WhenToUse = "Quando desfez algo mas mudou de ideia.",
                    PracticalExample = "Deu Ctrl+Z 3 vezes mas só queria 2? Ctrl+Y desfaz um 'desfazer'.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Inserir data atual",
                    Description = "Coloca a data de hoje automaticamente",
                    Keys = "Ctrl + ;",
                    Category = "Edição",
                    DetailedExplanation = "Insere a data atual no formato que seu Windows está configurado.",
                    WhenToUse = "Para marcar quando algo foi feito ou atualizado.",
                    PracticalExample = "Quer registrar 'Última atualização'? Ctrl+; insere a data de hoje.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Inserir hora atual",
                    Description = "Coloca a hora de agora automaticamente",
                    Keys = "Ctrl + Shift + ;",
                    Category = "Edição",
                    DetailedExplanation = "Insere a hora atual (HH:MM).",
                    WhenToUse = "Para registrar horários de forma rápida.",
                    PracticalExample = "Controlando entrada/saída de funcionários? Ctrl+Shift+; registra a hora.",
                    PopularityScore = 3,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Adicionar comentário",
                    Description = "Abre janela para adicionar nota na célula",
                    Keys = "Shift + F2",
                    Category = "Edição",
                    DetailedExplanation = "Permite adicionar uma anotação/comentário que aparece quando passa o mouse sobre a célula.",
                    WhenToUse = "Para deixar observações ou explicações sem poluir a planilha.",
                    PracticalExample = "Número estranho? Shift+F2 e explica 'Este valor está alto por causa do feriado'.",
                    PopularityScore = 3,
                    RequiresMouse = false
                },

                // ===== FORMATAÇÃO =====
                new ExcelShortcut
                {
                    Title = "Negrito",
                    Description = "Deixa o texto em negrito",
                    Keys = "Ctrl + B (ou Ctrl + N)",
                    Category = "Formatação",
                    DetailedExplanation = "Deixa o texto mais forte/destacado. Funciona como liga/desliga.",
                    WhenToUse = "Para destacar cabeçalhos ou valores importantes.",
                    PracticalExample = "Linha de totais? Selecione e Ctrl+B para destacar.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Itálico",
                    Description = "Deixa o texto em itálico (inclinado)",
                    Keys = "Ctrl + I",
                    Category = "Formatação",
                    DetailedExplanation = "Inclina o texto. Também funciona como liga/desliga.",
                    WhenToUse = "Para dar ênfase sutil ou indicar observações.",
                    PracticalExample = "Notas de rodapé ou comentários podem ficar em itálico.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Sublinhado",
                    Description = "Sublinha o texto",
                    Keys = "Ctrl + U (ou Ctrl + S)",
                    Category = "Formatação",
                    DetailedExplanation = "Coloca uma linha embaixo do texto.",
                    WhenToUse = "Para destacar títulos ou valores críticos.",
                    PracticalExample = "Total final? Ctrl+U para sublinhar e chamar atenção.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Abrir formatação de células",
                    Description = "Abre a janela completa de formatação",
                    Keys = "Ctrl + 1",
                    Category = "Formatação",
                    DetailedExplanation = "Abre a janela onde você pode mudar tudo: número, fonte, bordas, preenchimento, etc.",
                    WhenToUse = "Quando precisa fazer formatações mais complexas.",
                    PracticalExample = "Quer mudar para moeda brasileira? Ctrl+1, aba Número, escolhe Moeda.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Formato de moeda",
                    Description = "Formata como dinheiro (R$)",
                    Keys = "Ctrl + Shift + $",
                    Category = "Formatação",
                    DetailedExplanation = "Transforma o número em formato de moeda com símbolo e 2 casas decimais.",
                    WhenToUse = "Para valores em dinheiro.",
                    PracticalExample = "Digitou '1500'? Vira 'R$ 1.500,00' com Ctrl+Shift+$.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Formato de porcentagem",
                    Description = "Formata como porcentagem (%)",
                    Keys = "Ctrl + Shift + %",
                    Category = "Formatação",
                    DetailedExplanation = "Multiplica o número por 100 e adiciona o símbolo %.",
                    WhenToUse = "Para exibir valores percentuais.",
                    PracticalExample = "Digitou '0.15'? Vira '15%' com Ctrl+Shift+%.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Formato de data",
                    Description = "Formata como data (DD/MM/AAAA)",
                    Keys = "Ctrl + Shift + #",
                    Category = "Formatação",
                    DetailedExplanation = "Transforma o número em formato de data.",
                    WhenToUse = "Para exibir datas corretamente.",
                    PracticalExample = "Célula mostra '45678'? Ctrl+Shift+# mostra a data correspondente.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Copiar formatação",
                    Description = "Copia a formatação de uma célula para outra",
                    Keys = "Clique na célula origem → Ctrl + C → Clique destino → Ctrl + Alt + V → F → Enter",
                    MouseAction = "Ou use o botão 'Pincel de Formatação' clicando na célula origem",
                    Category = "Formatação",
                    DetailedExplanation = "Copia apenas a formatação (cores, bordas, fonte) sem copiar o conteúdo.",
                    WhenToUse = "Quando quer que outra célula fique igual visualmente.",
                    PracticalExample = "A1 está azul com borda? Copie a formatação para B1 ficar igual.",
                    PopularityScore = 4,
                    RequiresMouse = true
                },

                // ===== FÓRMULAS =====
                new ExcelShortcut
                {
                    Title = "Iniciar fórmula",
                    Description = "Começa a digitar uma fórmula",
                    Keys = "= (sinal de igual)",
                    Category = "Fórmulas",
                    DetailedExplanation = "Toda fórmula no Excel SEMPRE começa com =. Sem o =, Excel acha que é só texto.",
                    WhenToUse = "Sempre que quiser fazer qualquer cálculo.",
                    PracticalExample = "Quer somar A1+B1? Digite: =A1+B1",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
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
                new ExcelShortcut
                {
                    Title = "Mostrar/ocultar fórmulas",
                    Description = "Alterna entre ver valores ou fórmulas",
                    Keys = "Ctrl + ` (acento grave)",
                    Category = "Fórmulas",
                    DetailedExplanation = "Mostra as fórmulas em vez dos resultados. Útil para conferir ou aprender.",
                    WhenToUse = "Para auditar planilhas ou ver como os cálculos foram feitos.",
                    PracticalExample = "Pegou planilha de outra pessoa? Ctrl+` mostra todas as fórmulas.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Inserir função",
                    Description = "Abre assistente de funções",
                    Keys = "Shift + F3",
                    Category = "Fórmulas",
                    DetailedExplanation = "Abre uma janela que te ajuda a escolher e preencher funções do Excel.",
                    WhenToUse = "Quando não lembra exatamente como usar uma função.",
                    PracticalExample = "Quer usar SE mas não lembra a ordem? Shift+F3 te guia.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Fixar referência ($)",
                    Description = "Adiciona $ para fixar linha/coluna",
                    Keys = "F4 (com cursor na referência)",
                    Category = "Fórmulas",
                    DetailedExplanation = "Quando você copia fórmulas, o $ impede que a referência mude. F4 alterna entre $A$1, A$1, $A1 e A1.",
                    WhenToUse = "Para manter sempre a mesma célula em fórmulas copiadas.",
                    PracticalExample = "Fórmula =A1*B1, cursor em B1, aperte F4 até virar =A1*$B$1. Agora ao copiar, B1 nunca muda!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Calcular agora",
                    Description = "Recalcula todas as fórmulas",
                    Keys = "F9",
                    Category = "Fórmulas",
                    DetailedExplanation = "Força o Excel a recalcular todas as fórmulas da planilha.",
                    WhenToUse = "Quando mudou dados mas fórmulas não atualizaram.",
                    PracticalExample = "Alterou A1 mas B1 (que tem =A1*2) não mudou? F9 força atualizar.",
                    PopularityScore = 3,
                    RequiresMouse = false
                },

                // ===== LINHAS E COLUNAS =====
                new ExcelShortcut
                {
                    Title = "Inserir linha",
                    Description = "Adiciona nova linha acima da atual",
                    Keys = "Ctrl + Shift + + (mais) - com linha selecionada",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "Insere uma linha em branco acima da linha selecionada, empurrando as demais para baixo.",
                    WhenToUse = "Quando esqueceu de adicionar dados e precisa de uma linha no meio.",
                    PracticalExample = "Esqueceu um produto entre linha 5 e 6? Clique na linha 6, Ctrl+Shift++, nova linha aparece!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Inserir coluna",
                    Description = "Adiciona nova coluna à esquerda",
                    Keys = "Ctrl + Shift + + (mais) - com coluna selecionada",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "Insere uma coluna em branco à esquerda da coluna selecionada.",
                    WhenToUse = "Quando precisa adicionar mais dados entre colunas existentes.",
                    PracticalExample = "Esqueceu coluna 'Email' entre Nome e Telefone? Selecione coluna Telefone, Ctrl+Shift++.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Deletar linha/coluna",
                    Description = "Remove linha ou coluna selecionada",
                    Keys = "Ctrl + - (menos)",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "Deleta a linha ou coluna inteira que está selecionada.",
                    WhenToUse = "Para remover linhas/colunas desnecessárias.",
                    PracticalExample = "Produto duplicado na linha 8? Selecione linha 8, Ctrl+-.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ocultar linhas",
                    Description = "Esconde as linhas selecionadas",
                    Keys = "Ctrl + 9",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "As linhas ficam escondidas mas não são deletadas. Podem ser reexibidas depois.",
                    WhenToUse = "Para focar em dados importantes sem deletar nada.",
                    PracticalExample = "Linhas 10-50 são detalhes que não precisa ver agora? Selecione e Ctrl+9.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ocultar colunas",
                    Description = "Esconde as colunas selecionadas",
                    Keys = "Ctrl + 0",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "As colunas ficam escondidas mas não são deletadas.",
                    WhenToUse = "Para limpar a visualização temporariamente.",
                    PracticalExample = "Colunas F-Z são cálculos internos? Ctrl+0 para esconder.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ajustar largura da coluna",
                    Description = "Ajusta automaticamente para caber o conteúdo",
                    Keys = "Alt + H + O + I",
                    MouseAction = "Ou duplo-clique na borda entre colunas (no cabeçalho)",
                    Category = "Linhas e Colunas",
                    DetailedExplanation = "Faz a coluna ficar exatamente do tamanho necessário para mostrar todo o conteúdo.",
                    WhenToUse = "Quando o texto está cortado (aparece ####).",
                    PracticalExample = "Coluna B mostra ####? Duplo-clique na borda entre B e C no cabeçalho.",
                    PopularityScore = 5,
                    RequiresMouse = true
                },

                // ===== PLANILHAS (ABAS) =====
                new ExcelShortcut
                {
                    Title = "Nova planilha",
                    Description = "Cria nova aba/planilha",
                    Keys = "Shift + F11",
                    Category = "Planilhas",
                    DetailedExplanation = "Adiciona uma nova aba (Plan4, Plan5...) no mesmo arquivo.",
                    WhenToUse = "Quando precisa separar dados em abas diferentes.",
                    PracticalExample = "Quer aba separada para cada mês? Shift+F11 cria novas abas.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ir para próxima planilha",
                    Description = "Vai para a aba da direita",
                    Keys = "Ctrl + Page Down",
                    Category = "Planilhas",
                    DetailedExplanation = "Navega entre as abas sem usar o mouse.",
                    WhenToUse = "Para alternar entre planilhas rapidamente.",
                    PracticalExample = "Está em Janeiro e quer ir para Fevereiro? Ctrl+Page Down.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Voltar para planilha anterior",
                    Description = "Vai para a aba da esquerda",
                    Keys = "Ctrl + Page Up",
                    Category = "Planilhas",
                    DetailedExplanation = "Volta para a aba anterior.",
                    WhenToUse = "Para voltar entre abas.",
                    PracticalExample = "Foi longe demais? Ctrl+Page Up volta.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },

                // ===== BUSCA E FILTROS =====
                new ExcelShortcut
                {
                    Title = "Localizar",
                    Description = "Busca por texto na planilha",
                    Keys = "Ctrl + L (ou Ctrl + F)",
                    Category = "Busca e Filtros",
                    DetailedExplanation = "Abre janela para procurar qualquer texto na planilha.",
                    WhenToUse = "Para encontrar dados específicos rapidamente.",
                    PracticalExample = "Tem 1000 produtos e quer achar 'Notebook'? Ctrl+L e busque.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Substituir",
                    Description = "Busca e substitui texto",
                    Keys = "Ctrl + U (ou Ctrl + H)",
                    Category = "Busca e Filtros",
                    DetailedExplanation = "Encontra um texto e troca por outro em toda planilha.",
                    WhenToUse = "Para fazer mudanças em massa.",
                    PracticalExample = "Empresa mudou nome de 'ABC' para 'XYZ'? Ctrl+U substitui todos de uma vez.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ativar filtro",
                    Description = "Liga/desliga os filtros automáticos",
                    Keys = "Ctrl + Shift + L",
                    Category = "Busca e Filtros",
                    DetailedExplanation = "Adiciona setinhas nos cabeçalhos para filtrar dados.",
                    WhenToUse = "Para visualizar apenas partes específicas dos dados.",
                    PracticalExample = "Quer ver só vendas acima de R$1000? Ctrl+Shift+L ativa filtros, clique na setinha e filtre.",
                    PopularityScore = 5,
                    RequiresMouse = false
                },

                // ===== OUTROS ÚTEIS =====
                new ExcelShortcut
                {
                    Title = "Salvar",
                    Description = "Salva o arquivo",
                    Keys = "Ctrl + B (ou Ctrl + S)",
                    Category = "Arquivo",
                    DetailedExplanation = "Salva suas alterações. SEMPRE use isso frequentemente!",
                    WhenToUse = "A cada mudança importante. Crie o hábito!",
                    PracticalExample = "Terminou de digitar dados? Ctrl+B. Fez cálculos? Ctrl+B. SEMPRE!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Salvar Como",
                    Description = "Salva com outro nome ou local",
                    Keys = "F12",
                    Category = "Arquivo",
                    DetailedExplanation = "Permite salvar uma cópia com nome diferente ou em outro lugar.",
                    WhenToUse = "Para criar versões ou backups.",
                    PracticalExample = "Quer versão 'Vendas_Final_v2'? F12 e salve com novo nome.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Imprimir",
                    Description = "Abre visualização de impressão",
                    Keys = "Ctrl + P",
                    Category = "Arquivo",
                    DetailedExplanation = "Mostra como ficará impresso e permite configurar impressão.",
                    WhenToUse = "Antes de imprimir para ver se está tudo ok.",
                    PracticalExample = "Vai imprimir relatório? Ctrl+P para conferir antes.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Novo arquivo",
                    Description = "Cria nova pasta de trabalho",
                    Keys = "Ctrl + O (ou Ctrl + N)",
                    Category = "Arquivo",
                    DetailedExplanation = "Abre um Excel novinho em branco.",
                    WhenToUse = "Para começar trabalho novo sem mexer no atual.",
                    PracticalExample = "Precisa de planilha separada para novo projeto? Ctrl+O.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Fechar arquivo",
                    Description = "Fecha a planilha atual",
                    Keys = "Ctrl + W (ou Ctrl + F4)",
                    Category = "Arquivo",
                    DetailedExplanation = "Fecha o arquivo atual mas mantém Excel aberto.",
                    WhenToUse = "Para fechar sem sair do programa.",
                    PracticalExample = "Terminou este arquivo mas vai trabalhar em outro? Ctrl+W fecha este.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Ir para célula específica",
                    Description = "Pula diretamente para qualquer célula",
                    Keys = "Ctrl + G (ou F5)",
                    Category = "Navegação",
                    DetailedExplanation = "Abre janela onde você digita qual célula quer ir (tipo: Z5000).",
                    WhenToUse = "Para ir direto a uma célula específica sem rolar.",
                    PracticalExample = "Alguém falou 'olha a célula AC500'? Ctrl+G, digite AC500, Enter.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Verificar ortografia",
                    Description = "Verifica erros de português",
                    Keys = "F7",
                    Category = "Revisão",
                    DetailedExplanation = "Igual ao Word - verifica se tem palavras escritas errado.",
                    WhenToUse = "Antes de entregar planilha importante.",
                    PracticalExample = "Relatório para chefe? F7 para garantir que não tem erro de digitação.",
                    PopularityScore = 3,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Criar gráfico",
                    Description = "Cria gráfico dos dados selecionados",
                    Keys = "Alt + F1 (gráfico embutido) ou F11 (nova aba)",
                    Category = "Gráficos",
                    DetailedExplanation = "F11 cria gráfico em aba separada. Alt+F1 cria na mesma planilha.",
                    WhenToUse = "Para visualizar dados graficamente.",
                    PracticalExample = "Selecionou vendas por mês? F11 cria gráfico automaticamente!",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Repetir última ação",
                    Description = "Repete o último comando",
                    Keys = "Ctrl + Y (ou F4)",
                    Category = "Produtividade",
                    DetailedExplanation = "Repete a última coisa que você fez. Muito útil para ações repetitivas!",
                    WhenToUse = "Para fazer a mesma coisa várias vezes sem refazer todos os passos.",
                    PracticalExample = "Pintou A1 de amarelo? Clique B1, F4. Clique C1, F4. Vai pintando!",
                    PopularityScore = 5,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Preencher série",
                    Description = "Continua sequência automaticamente",
                    Keys = "Selecione células + Ctrl + D/R (ou arraste com mouse)",
                    MouseAction = "Selecione célula com valor, arraste pela alça (quadradinho no canto) para baixo ou lado",
                    Category = "Preenchimento",
                    DetailedExplanation = "Excel detecta padrões (1,2,3 ou Jan,Fev,Mar) e continua automaticamente!",
                    WhenToUse = "Para criar sequências ou listas sem digitar tudo.",
                    PracticalExample = "Digite 'Segunda' em A1, arraste a alça para baixo. Excel completa Terça, Quarta...",
                    PopularityScore = 5,
                    RequiresMouse = true
                },
                new ExcelShortcut
                {
                    Title = "Quebra de linha na célula",
                    Description = "Pula linha dentro da mesma célula",
                    Keys = "Alt + Enter",
                    Category = "Edição",
                    DetailedExplanation = "Cria nova linha DENTRO da célula, sem ir para célula de baixo.",
                    WhenToUse = "Para texto com múltiplas linhas em uma célula.",
                    PracticalExample = "Quer endereço em 3 linhas na mesma célula? Digite linha1, Alt+Enter, linha2, Alt+Enter, linha3.",
                    PopularityScore = 4,
                    RequiresMouse = false
                },
                new ExcelShortcut
                {
                    Title = "Colar especial",
                    Description = "Opções avançadas de colagem",
                    Keys = "Ctrl + Alt + V",
                    Category = "Edição",
                    DetailedExplanation = "Permite colar só valores, só formatação, fazer operações matemáticas, transpor, etc.",
                    WhenToUse = "Quando quer colar de forma específica, não normal.",
                    PracticalExample = "Copiou fórmula mas quer só resultado? Ctrl+C na origem, Ctrl+Alt+V no destino, escolha 'Valores'.",
                    PopularityScore = 5,
                    RequiresMouse = false
                }
            };
        }

        // Apps Nativos do Windows
        public List<WindowsApp> GetWindowsApps()
        {
            return new List<WindowsApp>
            {
                // ===== PRODUTIVIDADE =====
                new WindowsApp
                {
                    WhatItDoes = "Gerencia suas tarefas e lista de afazeres",
                    AppName = "Microsoft To Do",
                    Category = "Produtividade",
                    HowToOpen = "Procure por 'To Do' no Menu Iniciar ou Microsoft Store",
                    DetailedDescription = "Aplicativo para criar listas de tarefas, definir lembretes e organizar seu dia. Sincroniza entre seus dispositivos.",
                    KeyFeatures = new List<string>
                    {
                        "Crie listas de tarefas organizadas",
                        "Defina lembretes e prazos",
                        "Organize por categorias (Meu Dia, Importante, Planejado)",
                        "Sincroniza com sua conta Microsoft",
                        "Compartilhe listas com outras pessoas"
                    },
                    IconEmoji = "✅",
                    IsPreInstalled = false
                },
                new WindowsApp
                {
                    WhatItDoes = "Bloco de notas simples para textos",
                    AppName = "Bloco de Notas (Notepad)",
                    Category = "Produtividade",
                    HowToOpen = "Procure por 'Bloco de Notas' ou 'Notepad' no Menu Iniciar",
                    DetailedDescription = "Editor de texto mais simples do Windows. Ótimo para anotações rápidas e edição de arquivos de texto puro (.txt).",
                    KeyFeatures = new List<string>
                    {
                        "Extremamente leve e rápido",
                        "Abre instantaneamente",
                        "Ideal para código e arquivos de configuração",
                        "Não adiciona formatação ao texto"
                    },
                    IconEmoji = "📝",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Calculadora com múltiplos modos",
                    AppName = "Calculadora",
                    Category = "Produtividade",
                    HowToOpen = "Procure por 'Calculadora' no Menu Iniciar",
                    DetailedDescription = "Calculadora completa com modo padrão, científico, programador e conversor de unidades.",
                    KeyFeatures = new List<string>
                    {
                        "Modo padrão para cálculos simples",
                        "Modo científico para matemática avançada",
                        "Conversor de unidades (comprimento, peso, temperatura, etc)",
                        "Calculadora de datas",
                        "Histórico de cálculos"
                    },
                    IconEmoji = "🔢",
                    IsPreInstalled = true
                },

                // ===== MULTIMÍDIA =====
                new WindowsApp
                {
                    WhatItDoes = "Toca músicas e vídeos",
                    AppName = "Groove Música / Filmes e TV",
                    Category = "Multimídia",
                    HowToOpen = "Procure por 'Groove' ou 'Filmes e TV' no Menu Iniciar",
                    DetailedDescription = "Player de mídia nativo do Windows para reproduzir músicas e vídeos.",
                    KeyFeatures = new List<string>
                    {
                        "Reproduz MP3, MP4, MKV e outros formatos",
                        "Cria playlists de música",
                        "Interface limpa e moderna",
                        "Suporta legendas"
                    },
                    IconEmoji = "🎵",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Visualiza e edita fotos",
                    AppName = "Fotos",
                    Category = "Multimídia",
                    HowToOpen = "Clique com botão direito em uma imagem → Abrir com → Fotos",
                    DetailedDescription = "Aplicativo para ver, organizar e fazer edições básicas em fotos.",
                    KeyFeatures = new List<string>
                    {
                        "Visualize fotos em alta qualidade",
                        "Edições básicas (cortar, girar, filtros)",
                        "Crie álbuns e apresentações",
                        "Organize por data e local",
                        "Faça pequenos vídeos com suas fotos"
                    },
                    IconEmoji = "📷",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Editor de vídeo simples",
                    AppName = "Editor de Vídeo (Video Editor)",
                    Category = "Multimídia",
                    HowToOpen = "Abra o app 'Fotos' → Menu → Editor de Vídeo",
                    DetailedDescription = "Ferramenta gratuita para editar vídeos de forma simples, cortar clipes, adicionar música e texto.",
                    KeyFeatures = new List<string>
                    {
                        "Corte e una vídeos",
                        "Adicione música de fundo",
                        "Insira texto e títulos",
                        "Aplique efeitos 3D",
                        "Controle velocidade (câmera lenta/rápida)"
                    },
                    IconEmoji = "🎬",
                    IsPreInstalled = true
                },

                // ===== UTILITÁRIOS =====
                new WindowsApp
                {
                    WhatItDoes = "Abre e lê arquivos PDF",
                    AppName = "Microsoft Edge (leitor PDF)",
                    Category = "Utilitários",
                    HowToOpen = "Clique duas vezes em um PDF ou abra pelo Edge",
                    DetailedDescription = "O Edge funciona como leitor de PDF nativo, sem precisar instalar nada extra.",
                    KeyFeatures = new List<string>
                    {
                        "Abre PDFs instantaneamente",
                        "Faça anotações e marcações",
                        "Preencha formulários PDF",
                        "Modo de leitura confortável",
                        "Salve páginas como PDF"
                    },
                    IconEmoji = "📄",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Captura trechos da tela",
                    AppName = "Ferramenta de Captura",
                    Category = "Utilitários",
                    HowToOpen = "Win + Shift + S ou procure 'Snipping Tool'",
                    DetailedDescription = "Tire prints de áreas específicas da tela e salve ou compartilhe.",
                    KeyFeatures = new List<string>
                    {
                        "Capture área retangular",
                        "Capture janela específica",
                        "Capture tela inteira",
                        "Desenhe sobre a captura",
                        "Compartilhe diretamente"
                    },
                    IconEmoji = "✂️",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Compacta e descompacta arquivos ZIP",
                    AppName = "Compactador de Arquivos Nativo",
                    Category = "Utilitários",
                    HowToOpen = "Clique direito em arquivo/pasta → Enviar para → Pasta compactada",
                    DetailedDescription = "O Windows tem suporte nativo para arquivos ZIP sem precisar instalar WinRAR ou outros.",
                    KeyFeatures = new List<string>
                    {
                        "Comprima arquivos para economizar espaço",
                        "Envie vários arquivos em um só",
                        "Abra arquivos ZIP sem programas extras",
                        "Proteja com senha"
                    },
                    IconEmoji = "🗜️",
                    IsPreInstalled = true
                },

                // ===== SEGURANÇA =====
                new WindowsApp
                {
                    WhatItDoes = "Protege contra vírus e ameaças",
                    AppName = "Windows Security (Defender)",
                    Category = "Segurança",
                    HowToOpen = "Procure por 'Windows Security' ou 'Segurança do Windows' no Menu Iniciar",
                    DetailedDescription = "Antivírus gratuito e integrado do Windows. Protege contra vírus, malware e outras ameaças.",
                    KeyFeatures = new List<string>
                    {
                        "Proteção em tempo real",
                        "Verificações agendadas",
                        "Firewall integrado",
                        "Proteção contra ransomware",
                        "Atualizações automáticas"
                    },
                    IconEmoji = "🛡️",
                    IsPreInstalled = true
                },

                // ===== ACESSIBILIDADE =====
                new WindowsApp
                {
                    WhatItDoes = "Lê o texto da tela em voz alta",
                    AppName = "Narrator (Narrador)",
                    Category = "Acessibilidade",
                    HowToOpen = "Win + Ctrl + Enter ou procure 'Narrador' no Menu Iniciar",
                    DetailedDescription = "Leitor de tela que lê em voz alta o que aparece na tela. Útil para pessoas com deficiência visual.",
                    KeyFeatures = new List<string>
                    {
                        "Lê textos, botões e menus",
                        "Navega por aplicativos",
                        "Ajustável (velocidade, voz)",
                        "Funciona em português"
                    },
                    IconEmoji = "🔊",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Aumenta partes da tela como uma lupa",
                    AppName = "Lupa (Magnifier)",
                    Category = "Acessibilidade",
                    HowToOpen = "Win + + (mais) ou procure 'Lupa' no Menu Iniciar",
                    DetailedDescription = "Amplia partes da tela para facilitar a leitura. Útil para pessoas com baixa visão.",
                    KeyFeatures = new List<string>
                    {
                        "Aumenta até 1600%",
                        "Três modos de visualização",
                        "Segue o cursor do mouse",
                        "Atalhos rápidos (Win + mais/menos)"
                    },
                    IconEmoji = "🔍",
                    IsPreInstalled = true
                }
            };
        }

        // Dicas e Truques do Windows
        public List<WindowsTip> GetWindowsTips()
        {
            return new List<WindowsTip>
            {
                // ===== PRODUTIVIDADE =====
                new WindowsTip
                {
                    Title = "Área de Trabalho Virtual",
                    ShortDescription = "Use múltiplas áreas de trabalho para organizar suas janelas",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Aperte Win + Tab",
                        "Clique em 'Nova Área de Trabalho' no topo",
                        "Alterne entre elas com Ctrl + Win + Seta Esquerda/Direita",
                        "Arraste janelas entre as áreas de trabalho"
                    },
                    WhyUseful = "Perfeito para separar trabalho de lazer, ou diferentes projetos. Por exemplo: uma área para estudos, outra para entretenimento.",
                    IconEmoji = "🖥️"
                },
                new WindowsTip
                {
                    Title = "Modo Noturno (Night Light)",
                    ShortDescription = "Reduza luz azul à noite para dormir melhor",
                    Category = "Personalização",
                    Steps = new List<string>
                    {
                        "Vá em Configurações (Win + I)",
                        "Sistema → Tela",
                        "Ative 'Luz Noturna'",
                        "Clique em 'Configurações de luz noturna'",
                        "Agende para ativar automaticamente ao anoitecer"
                    },
                    WhyUseful = "A luz azul da tela atrapalha o sono. Este modo deixa a tela mais amarelada à noite, ajudando você a dormir melhor.",
                    IconEmoji = "🌙"
                },
                new WindowsTip
                {
                    Title = "Clipboard com Histórico",
                    ShortDescription = "Acesse múltiplos itens copiados recentemente",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Vá em Configurações → Sistema → Área de Transferência",
                        "Ative 'Histórico da área de transferência'",
                        "Agora aperte Win + V para ver tudo que você copiou",
                        "Clique em qualquer item para colar"
                    },
                    WhyUseful = "Não perca mais o que copiou antes! O Windows guarda até 25 itens copiados. Muito útil quando está copiando várias coisas.",
                    IconEmoji = "📋"
                },
                new WindowsTip
                {
                    Title = "Desfragmentar o Disco",
                    ShortDescription = "Otimize o HD para melhor desempenho",
                    Category = "Manutenção",
                    Steps = new List<string>
                    {
                        "Procure 'Desfragmentar' no Menu Iniciar",
                        "Selecione o disco (normalmente C:)",
                        "Clique em 'Otimizar'",
                        "Configure para otimizar automaticamente"
                    },
                    WhyUseful = "HDs (não SSDs) ficam fragmentados com o tempo, deixando o PC lento. Desfragmentar reorganiza os arquivos e melhora a velocidade. OBS: NÃO faça em SSDs!",
                    IconEmoji = "🔧"
                },
                new WindowsTip
                {
                    Title = "Limpeza de Disco",
                    ShortDescription = "Libere espaço deletando arquivos temporários",
                    Category = "Manutenção",
                    Steps = new List<string>
                    {
                        "Procure 'Limpeza de Disco' no Menu Iniciar",
                        "Selecione o disco C:",
                        "Marque 'Arquivos temporários', 'Lixeira', 'Downloads'",
                        "Clique em 'Limpar arquivos do sistema' para mais opções",
                        "Clique OK"
                    },
                    WhyUseful = "O Windows acumula arquivos temporários que ocupam gigabytes. Esta ferramenta remove tudo isso com segurança, liberando espaço.",
                    IconEmoji = "🗑️"
                },

                // ===== PERSONALIZAÇÃO =====
                new WindowsTip
                {
                    Title = "Modo Escuro (Dark Mode)",
                    ShortDescription = "Deixe o Windows com tema escuro",
                    Category = "Personalização",
                    Steps = new List<string>
                    {
                        "Configurações (Win + I)",
                        "Personalização → Cores",
                        "Em 'Escolher seu modo', selecione 'Escuro'",
                        "Ou escolha 'Personalizado' para ter modo escuro nos apps e claro no Windows"
                    },
                    WhyUseful = "Cansa menos a vista, economiza bateria em telas OLED, e muita gente acha mais bonito!",
                    IconEmoji = "🌑"
                },
                new WindowsTip
                {
                    Title = "Mostrar Extensão de Arquivos",
                    ShortDescription = "Veja o tipo real dos arquivos (.jpg, .exe, .txt)",
                    Category = "Personalização",
                    Steps = new List<string>
                    {
                        "Abra o Explorador de Arquivos",
                        "Clique na aba 'Exibir'",
                        "Marque 'Extensões de nomes de arquivos'"
                    },
                    WhyUseful = "SEGURANÇA! Vírus podem se disfarçar mudando ícones. Ver a extensão te protege de clicar em 'foto.jpg' que na verdade é 'foto.jpg.exe' (vírus).",
                    IconEmoji = "👁️"
                },
                new WindowsTip
                {
                    Title = "Desativar Apps de Inicialização",
                    ShortDescription = "Faça o PC ligar mais rápido",
                    Category = "Manutenção",
                    Steps = new List<string>
                    {
                        "Ctrl + Shift + Esc (Gerenciador de Tarefas)",
                        "Vá na aba 'Inicializar'",
                        "Clique direito nos apps que não precisa → 'Desabilitar'",
                        "NÃO desabilite Windows Security ou drivers"
                    },
                    WhyUseful = "Muitos programas se configuram para abrir sozinhos ao ligar o PC. Isso deixa a inicialização MUITO lenta. Desabilite o que não usa!",
                    IconEmoji = "⚡"
                },

                // ===== SEGURANÇA =====
                new WindowsTip
                {
                    Title = "Criar Ponto de Restauração",
                    ShortDescription = "Crie backup para voltar se algo der errado",
                    Category = "Segurança",
                    Steps = new List<string>
                    {
                        "Procure 'Criar ponto de restauração'",
                        "Clique em 'Criar'",
                        "Dê um nome (ex: 'Antes de instalar programa X')",
                        "Aguarde criar"
                    },
                    WhyUseful = "Se instalar algo que bagunce o PC, você pode voltar no tempo para quando estava funcionando!",
                    IconEmoji = "💾"
                },
                new WindowsTip
                {
                    Title = "Windows Update",
                    ShortDescription = "Mantenha o Windows sempre atualizado",
                    Category = "Segurança",
                    Steps = new List<string>
                    {
                        "Configurações → Windows Update",
                        "Clique em 'Verificar atualizações'",
                        "Instale tudo que aparecer",
                        "Reinicie se pedir"
                    },
                    WhyUseful = "Atualizações corrigem falhas de segurança e bugs. Um Windows desatualizado pode ser invadido facilmente!",
                    IconEmoji = "🔄"
                },

                // ===== ORGANIZAÇÃO =====
                new WindowsTip
                {
                    Title = "Fixar Pastas no Acesso Rápido",
                    ShortDescription = "Acesse suas pastas favoritas rapidamente",
                    Category = "Organização",
                    Steps = new List<string>
                    {
                        "Abra o Explorador de Arquivos",
                        "Navegue até uma pasta que usa muito",
                        "Clique direito nela",
                        "Escolha 'Fixar no Acesso Rápido'",
                        "Ela aparecerá sempre na barra lateral"
                    },
                    WhyUseful = "Pare de navegar 10 pastas para chegar onde precisa. Fixe e clique direto!",
                    IconEmoji = "📌"
                },
                new WindowsTip
                {
                    Title = "Atalhos para Programas na Barra de Tarefas",
                    ShortDescription = "Abra programas com Win + Número",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Fixe seus programas favoritos na barra de tarefas",
                        "O primeiro programa é Win + 1",
                        "O segundo é Win + 2",
                        "E assim por diante até Win + 9"
                    },
                    WhyUseful = "Abra programas instantaneamente sem procurar! Organize os mais usados nos primeiros números.",
                    IconEmoji = "⌨️"
                },
                new WindowsTip
                {
                    Title = "Pesquisa Rápida de Arquivos",
                    ShortDescription = "Encontre qualquer arquivo em segundos",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Aperte Win + S",
                        "Digite parte do nome do arquivo",
                        "Use filtros (tipo, data, tamanho) se precisar",
                        "Clique no arquivo para abrir ou clique direito para mais opções"
                    },
                    WhyUseful = "Não perca tempo procurando manualmente. A pesquisa do Windows é muito rápida se você souber usar!",
                    IconEmoji = "🔍"
                }
            };
        }

        // Métodos de busca
        public List<KeyboardShortcut> SearchShortcuts(string query)
        {
            var allShortcuts = GetKeyboardShortcuts();
            query = query.ToLower();

            return allShortcuts.Where(s =>
                s.Title.ToLower().Contains(query) ||
                s.Description.ToLower().Contains(query) ||
                s.Keys.ToLower().Contains(query) ||
                s.Category.ToLower().Contains(query)
            ).ToList();
        }

        public List<ExcelShortcut> SearchExcelShortcuts(string query)
        {
            var allShortcuts = GetExcelShortcuts();
            query = query.ToLower();

            return allShortcuts.Where(s =>
                s.Title.ToLower().Contains(query) ||
                s.Description.ToLower().Contains(query) ||
                s.Keys.ToLower().Contains(query) ||
                s.Category.ToLower().Contains(query) ||
                (s.MouseAction != null && s.MouseAction.ToLower().Contains(query))
            ).ToList();
        }

        public List<WindowsApp> SearchApps(string query)
        {
            var allApps = GetWindowsApps();
            query = query.ToLower();

            return allApps.Where(a =>
                a.WhatItDoes.ToLower().Contains(query) ||
                a.AppName.ToLower().Contains(query) ||
                a.Category.ToLower().Contains(query)
            ).ToList();
        }

        public List<WindowsTip> SearchTips(string query)
        {
            var allTips = GetWindowsTips();
            query = query.ToLower();

            return allTips.Where(t =>
                t.Title.ToLower().Contains(query) ||
                t.ShortDescription.ToLower().Contains(query) ||
                t.Category.ToLower().Contains(query)
            ).ToList();
        }
    }
}