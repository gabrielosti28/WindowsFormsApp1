using System;
using System.Collections.Generic;
using System.Linq;

namespace AppInterno
{
    public class DiscoveryService
    {
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
                    Title = "Recortar",
                    Description = "Recorta (remove e copia) o selecionado",
                    Keys = "Ctrl + X",
                    Category = "Gerais",
                    DetailedExplanation = "Similar ao Ctrl+C, mas REMOVE o original. O item fica guardado temporariamente até você colar.",
                    WhenToUse = "Quando quiser mover algo de um lugar para outro (não duplicar).",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Desfazer",
                    Description = "Desfaz a última ação",
                    Keys = "Ctrl + Z",
                    Category = "Gerais",
                    DetailedExplanation = "Apagou algo sem querer? Ctrl+Z desfaz! Funciona na maioria dos programas. Você pode apertar várias vezes para desfazer múltiplas ações.",
                    WhenToUse = "Sempre que errar ou quiser voltar atrás em algo que fez.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Refazer",
                    Description = "Refaz o que você desfez",
                    Keys = "Ctrl + Y",
                    Category = "Gerais",
                    DetailedExplanation = "Se você desfez algo com Ctrl+Z mas mudou de ideia, Ctrl+Y refaz a ação.",
                    WhenToUse = "Quando desfez demais e quer recuperar.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Selecionar Tudo",
                    Description = "Seleciona todo o conteúdo",
                    Keys = "Ctrl + A",
                    Category = "Gerais",
                    DetailedExplanation = "Seleciona tudo de uma vez: todo texto de um documento, todos arquivos de uma pasta, etc.",
                    WhenToUse = "Quando quiser copiar/mover/deletar tudo de uma vez.",
                    PopularityScore = 4
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
                    Title = "Buscar",
                    Description = "Abre a busca no programa",
                    Keys = "Ctrl + F",
                    Category = "Gerais",
                    DetailedExplanation = "Procura por uma palavra ou frase dentro do documento ou página atual. Muito útil em documentos longos!",
                    WhenToUse = "Quando precisa encontrar algo específico rapidamente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Imprimir",
                    Description = "Abre a janela de impressão",
                    Keys = "Ctrl + P",
                    Category = "Gerais",
                    DetailedExplanation = "Abre as opções de impressão para o documento/página atual.",
                    WhenToUse = "Quando quiser imprimir algo.",
                    PopularityScore = 3
                },

                // ===== WINDOWS - SISTEMA =====
                new KeyboardShortcut
                {
                    Title = "Menu Iniciar",
                    Description = "Abre o Menu Iniciar",
                    Keys = "Win",
                    Category = "Sistema Windows",
                    DetailedExplanation = "A tecla Windows (aquela com o logo do Windows) abre o Menu Iniciar. De lá você pode buscar programas, configurações e arquivos.",
                    WhenToUse = "Para abrir programas, buscar arquivos ou acessar configurações.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Explorador de Arquivos",
                    Description = "Abre o explorador de arquivos",
                    Keys = "Win + E",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre uma nova janela do explorador de arquivos para você navegar pelas pastas e arquivos do computador.",
                    WhenToUse = "Quando precisa procurar arquivos ou pastas.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Busca do Windows",
                    Description = "Abre a busca do Windows",
                    Keys = "Win + S",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre a barra de busca do Windows onde você pode procurar por programas, arquivos, configurações, etc.",
                    WhenToUse = "Quando não sabe onde está algo ou quer abrir um programa rapidamente.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Configurações",
                    Description = "Abre as Configurações do Windows",
                    Keys = "Win + I",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o painel de Configurações onde você pode mudar opções do sistema, instalar/desinstalar programas, mudar a aparência, etc.",
                    WhenToUse = "Para ajustar configurações do computador.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Bloquear Computador",
                    Description = "Bloqueia a tela rapidamente",
                    Keys = "Win + L",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Bloqueia instantaneamente a tela, exigindo senha para voltar. Seus programas continuam rodando.",
                    WhenToUse = "Quando vai se afastar do computador e quer protegê-lo.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Área de Trabalho",
                    Description = "Minimiza tudo e mostra a área de trabalho",
                    Keys = "Win + D",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Minimiza todas as janelas abertas instantaneamente, mostrando a área de trabalho. Pressione novamente para restaurar.",
                    WhenToUse = "Quando tem muitas janelas abertas e quer acessar a área de trabalho rapidamente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Gerenciador de Tarefas",
                    Description = "Abre o Gerenciador de Tarefas",
                    Keys = "Ctrl + Shift + Esc",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Abre o Gerenciador de Tarefas onde você pode ver programas rodando, fechar programas travados e monitorar o desempenho.",
                    WhenToUse = "Quando um programa travou ou quer ver o que está consumindo recursos.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Captura de Tela",
                    Description = "Tira print da tela toda",
                    Keys = "Win + Print Screen",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Tira uma captura de tela e salva automaticamente na pasta 'Imagens > Capturas de Tela'.",
                    WhenToUse = "Quando quer guardar uma imagem do que está na tela.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Captura Parcial",
                    Description = "Ferramenta de captura de tela",
                    Keys = "Win + Shift + S",
                    Category = "Sistema Windows",
                    DetailedExplanation = "Escurece a tela e permite selecionar apenas a parte que quer capturar. A imagem vai para a área de transferência.",
                    WhenToUse = "Quando quer capturar apenas uma parte da tela.",
                    PopularityScore = 5
                },

                // ===== NAVEGAÇÃO =====
                new KeyboardShortcut
                {
                    Title = "Alternar entre Janelas",
                    Description = "Mostra e alterna entre programas abertos",
                    Keys = "Alt + Tab",
                    Category = "Navegação",
                    DetailedExplanation = "Segure Alt e aperte Tab para ver todas as janelas abertas. Continue apertando Tab (mantendo Alt) para navegar entre elas. Solte Alt para abrir a janela selecionada.",
                    WhenToUse = "Para alternar rapidamente entre programas abertos.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Fechar Janela/Programa",
                    Description = "Fecha o programa ou janela atual",
                    Keys = "Alt + F4",
                    Category = "Navegação",
                    DetailedExplanation = "Fecha a janela ativa. Se for a última janela de um programa, fecha o programa inteiro.",
                    WhenToUse = "Para fechar programas rapidamente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Nova Janela",
                    Description = "Abre nova janela do programa",
                    Keys = "Ctrl + N",
                    Category = "Navegação",
                    DetailedExplanation = "Abre uma nova janela do programa atual (funciona em navegadores, explorador de arquivos, etc).",
                    WhenToUse = "Quando quer ter múltiplas janelas do mesmo programa abertas.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Nova Aba",
                    Description = "Abre nova aba no navegador",
                    Keys = "Ctrl + T",
                    Category = "Navegação",
                    DetailedExplanation = "Abre uma nova aba vazia no navegador ou programa com abas.",
                    WhenToUse = "Para abrir múltiplas páginas sem abrir novas janelas.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Fechar Aba",
                    Description = "Fecha a aba atual",
                    Keys = "Ctrl + W",
                    Category = "Navegação",
                    DetailedExplanation = "Fecha a aba atual do navegador ou documento.",
                    WhenToUse = "Para fechar abas rapidamente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Reabrir Aba",
                    Description = "Reabre a última aba fechada",
                    Keys = "Ctrl + Shift + T",
                    Category = "Navegação",
                    DetailedExplanation = "Fechou uma aba sem querer? Isso reabre a última aba que você fechou!",
                    WhenToUse = "Quando fecha uma aba por acidente.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Alternar entre Abas",
                    Description = "Vai para a próxima aba",
                    Keys = "Ctrl + Tab",
                    Category = "Navegação",
                    DetailedExplanation = "Navega entre as abas abertas do navegador ou programa.",
                    WhenToUse = "Para alternar rapidamente entre abas.",
                    PopularityScore = 3
                },

                // ===== PRODUTIVIDADE =====
                new KeyboardShortcut
                {
                    Title = "Janela à Esquerda",
                    Description = "Encaixa janela na metade esquerda",
                    Keys = "Win + Seta Esquerda",
                    Category = "Produtividade",
                    DetailedExplanation = "Encaixa a janela ativa ocupando exatamente metade esquerda da tela. Perfeito para trabalhar com dois programas lado a lado!",
                    WhenToUse = "Quando quer ver dois programas ao mesmo tempo.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Janela à Direita",
                    Description = "Encaixa janela na metade direita",
                    Keys = "Win + Seta Direita",
                    Category = "Produtividade",
                    DetailedExplanation = "Encaixa a janela ativa ocupando exatamente metade direita da tela.",
                    WhenToUse = "Complemento do Win+Seta Esquerda para dividir a tela.",
                    PopularityScore = 5
                },
                new KeyboardShortcut
                {
                    Title = "Maximizar Janela",
                    Description = "Maximiza a janela atual",
                    Keys = "Win + Seta Cima",
                    Category = "Produtividade",
                    DetailedExplanation = "Maximiza a janela ativa para ocupar a tela inteira.",
                    WhenToUse = "Para focar em uma janela apenas.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Minimizar Janela",
                    Description = "Minimiza a janela atual",
                    Keys = "Win + Seta Baixo",
                    Category = "Produtividade",
                    DetailedExplanation = "Minimiza a janela ativa. Se já estiver restaurada, minimiza na barra de tarefas.",
                    WhenToUse = "Para ocultar temporariamente uma janela.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Emoji",
                    Description = "Abre painel de emojis",
                    Keys = "Win + . (ponto)",
                    Category = "Produtividade",
                    DetailedExplanation = "Abre um painel com emojis, kaomojis e símbolos especiais que você pode inserir em qualquer texto! 😊",
                    WhenToUse = "Para adicionar emojis em emails, mensagens, documentos.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Zoom In (Aproximar)",
                    Description = "Aumenta o zoom",
                    Keys = "Ctrl + +",
                    Category = "Produtividade",
                    DetailedExplanation = "Aumenta o tamanho do conteúdo (texto, imagens) na maioria dos programas.",
                    WhenToUse = "Quando o texto está muito pequeno.",
                    PopularityScore = 4
                },
                new KeyboardShortcut
                {
                    Title = "Zoom Out (Afastar)",
                    Description = "Diminui o zoom",
                    Keys = "Ctrl + -",
                    Category = "Produtividade",
                    DetailedExplanation = "Diminui o tamanho do conteúdo.",
                    WhenToUse = "Para ver mais conteúdo de uma vez.",
                    PopularityScore = 3
                },
                new KeyboardShortcut
                {
                    Title = "Zoom Normal",
                    Description = "Reseta o zoom para 100%",
                    Keys = "Ctrl + 0",
                    Category = "Produtividade",
                    DetailedExplanation = "Retorna o zoom para o tamanho padrão (100%).",
                    WhenToUse = "Quando o zoom está bagunçado.",
                    PopularityScore = 3
                }
            };
        }

        public List<WindowsApp> GetWindowsApps()
        {
            return new List<WindowsApp>
            {
                new WindowsApp
                {
                    WhatItDoes = "Tira prints (capturas) da tela e permite desenhar/anotar nelas",
                    AppName = "Captura e Esboço",
                    Category = "Produtividade",
                    HowToOpen = "Win + Shift + S ou busque por 'Captura e Esboço' no Menu Iniciar",
                    DetailedDescription = "Permite capturar a tela toda, uma janela específica ou uma área selecionada. Depois, você pode desenhar, escrever, destacar e salvar ou compartilhar.",
                    KeyFeatures = new List<string>
                    {
                        "Captura de tela inteira, janela ou área personalizada",
                        "Ferramentas de desenho: caneta, marca-texto, borracha",
                        "Régua e transferidor para medições",
                        "Salvar como PNG, JPG ou copiar para área de transferência",
                        "Compartilhar diretamente por email ou apps"
                    },
                    IconEmoji = "✂️",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Edita fotos: corta, ajusta cores, adiciona filtros e efeitos",
                    AppName = "Fotos",
                    Category = "Criatividade",
                    HowToOpen = "Busque 'Fotos' no Menu Iniciar ou abra uma imagem e escolha 'Fotos'",
                    DetailedDescription = "Muito mais que um visualizador! Permite editar fotos, criar vídeos, organizar em álbuns e até fazer montagens.",
                    KeyFeatures = new List<string>
                    {
                        "Ajuste de luz, cor, clareza e vinheta",
                        "Filtros prontos para dar efeitos especiais",
                        "Corte e giro de imagens",
                        "Remover olhos vermelhos",
                        "Criar vídeos com fotos e músicas",
                        "Desenhar e adicionar texto nas fotos"
                    },
                    IconEmoji = "📷",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Grava a tela do computador (ideal para tutoriais e gameplay)",
                    AppName = "Barra de Jogos Xbox (Game Bar)",
                    Category = "Produtividade",
                    HowToOpen = "Win + G (durante um jogo ou programa)",
                    DetailedDescription = "Mesmo que você não jogue, essa ferramenta é MUITO útil! Permite gravar a tela, tirar screenshots, monitorar desempenho e até gravar áudio do microfone.",
                    KeyFeatures = new List<string>
                    {
                        "Gravar vídeo da tela (Win + Alt + R para iniciar/parar)",
                        "Capturar screenshots (Win + Alt + Print Screen)",
                        "Ver desempenho: FPS, uso de CPU, GPU, RAM",
                        "Gravar áudio do sistema e/ou microfone",
                        "Widgets de relógio, desempenho, áudio",
                        "Galeria de capturas integrada"
                    },
                    IconEmoji = "🎮",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Calculadora avançada com conversões e modos científicos",
                    AppName = "Calculadora",
                    Category = "Utilitários",
                    HowToOpen = "Busque 'Calculadora' no Menu Iniciar",
                    DetailedDescription = "Não é só uma calculadora básica! Tem modos científico, programador, cálculo de datas e diversos conversores.",
                    KeyFeatures = new List<string>
                    {
                        "Modo Padrão, Científico e Programador",
                        "Cálculo de datas (diferença entre datas)",
                        "Conversor de: moedas, volume, comprimento, peso, temperatura, energia, área, velocidade, tempo, potência, dados, pressão e ângulo",
                        "Histórico de cálculos",
                        "Memória de valores"
                    },
                    IconEmoji = "🔢",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Organiza tarefas e listas de afazeres com lembretes",
                    AppName = "Microsoft To Do",
                    Category = "Produtividade",
                    HowToOpen = "Busque 'To Do' no Menu Iniciar (pode precisar instalar da Microsoft Store)",
                    DetailedDescription = "Gerenciador de tarefas simples e bonito para organizar seu dia, criar listas e definir lembretes.",
                    KeyFeatures = new List<string>
                    {
                        "Criar listas personalizadas",
                        "Adicionar lembretes e datas de vencimento",
                        "Subdividir tarefas em etapas",
                        "Adicionar notas e anexos",
                        "Lista 'Meu Dia' para focar nas tarefas de hoje",
                        "Sincroniza entre dispositivos (precisa conta Microsoft)"
                    },
                    IconEmoji = "✅",
                    IsPreInstalled = false
                },
                new WindowsApp
                {
                    WhatItDoes = "Cria notas rápidas que ficam sempre visíveis na tela",
                    AppName = "Notas Autoadesivas (Sticky Notes)",
                    Category = "Produtividade",
                    HowToOpen = "Busque 'Notas' ou 'Sticky Notes' no Menu Iniciar",
                    DetailedDescription = "Como post-its digitais! Crie notas coloridas que ficam sempre visíveis na área de trabalho.",
                    KeyFeatures = new List<string>
                    {
                        "Múltiplas notas em cores diferentes",
                        "Formatação de texto: negrito, itálico, sublinhado, riscado",
                        "Criar listas com checkbox",
                        "Sincroniza entre dispositivos",
                        "Buscar texto em todas as notas",
                        "Sempre no topo: notas ficam por cima de outras janelas"
                    },
                    IconEmoji = "📝",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Lê textos em voz alta e lê QR codes/códigos de barras com a câmera",
                    AppName = "Lupa",
                    Category = "Acessibilidade",
                    HowToOpen = "Win + '+' (mais) ou busque 'Lupa' no Menu Iniciar",
                    DetailedExplanation = "Além de ampliar a tela, tem recursos incríveis como leitura de texto em voz alta e leitura de QR codes!",
                    KeyFeatures = new List<string>
                    {
                        "Ampliar qualquer parte da tela",
                        "Leitura de texto em voz alta (aponte e ele lê!)",
                        "Ler QR codes e códigos de barras usando a câmera",
                        "Diferentes modos: tela inteira, lente ou encaixado",
                        "Inverter cores para melhor contraste",
                        "Controlar com teclado ou mouse"
                    },
                    IconEmoji = "🔍",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Grava áudio (útil para gravar reuniões, aulas, ideias)",
                    AppName = "Gravador de Voz",
                    Category = "Utilitários",
                    HowToOpen = "Busque 'Gravador de Voz' no Menu Iniciar",
                    DetailedDescription = "Ferramenta simples para gravar áudio do microfone. Perfeito para reuniões, aulas ou gravar ideias rapidamente.",
                    KeyFeatures = new List<string>
                    {
                        "Gravação de áudio com um clique",
                        "Marcar pontos importantes durante a gravação",
                        "Aparar (cortar) gravações",
                        "Renomear e organizar gravações",
                        "Compartilhar gravações facilmente",
                        "Gravações salvas automaticamente"
                    },
                    IconEmoji = "🎙️",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Transfere arquivos entre seu celular e computador sem fio",
                    AppName = "Aplicativo de Telefone",
                    Category = "Produtividade",
                    HowToOpen = "Busque 'Telefone' no Menu Iniciar",
                    DetailedDescription = "Conecta seu celular Android ao PC para ver notificações, mensagens, fotos e até fazer/receber ligações do computador!",
                    KeyFeatures = new List<string>
                    {
                        "Ver e responder mensagens SMS do PC",
                        "Receber notificações do celular",
                        "Fazer e receber ligações do PC",
                        "Ver e transferir fotos recentes",
                        "Arrastar arquivos entre PC e celular",
                        "Espelhar tela do celular (alguns modelos)"
                    },
                    IconEmoji = "📱",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Visualiza e edita documentos PDF",
                    AppName = "Microsoft Edge (Leitor de PDF)",
                    Category = "Produtividade",
                    HowToOpen = "Abra qualquer PDF (automaticamente abre no Edge)",
                    DetailedDescription = "O navegador Edge é também um excelente leitor de PDF com ferramentas de anotação!",
                    KeyFeatures = new List<string>
                    {
                        "Destacar texto em várias cores",
                        "Adicionar comentários e notas",
                        "Desenhar diretamente no PDF",
                        "Ler em voz alta (narrador integrado)",
                        "Modo de leitura imersivo",
                        "Salvar PDF com as anotações",
                        "Preencher formulários PDF"
                    },
                    IconEmoji = "📄",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Gerencia múltiplas áreas de trabalho virtuais (desktops separados)",
                    AppName = "Modo de Exibição de Tarefas",
                    Category = "Produtividade",
                    HowToOpen = "Win + Tab",
                    DetailedDescription = "Crie áreas de trabalho separadas para organizar janelas por contexto (trabalho, estudos, lazer).",
                    KeyFeatures = new List<string>
                    {
                        "Criar múltiplas áreas de trabalho virtuais",
                        "Mover janelas entre áreas de trabalho",
                        "Ver histórico de atividades (Linha do Tempo)",
                        "Alternar rapidamente entre áreas de trabalho",
                        "Personalizar nome e papel de parede de cada área",
                        "Atalho: Win + Ctrl + D (nova área) e Win + Ctrl + F4 (fechar área)"
                    },
                    IconEmoji = "🖥️",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Monitora e otimiza o desempenho do computador",
                    AppName = "Gerenciador de Tarefas",
                    Category = "Sistema",
                    HowToOpen = "Ctrl + Shift + Esc ou Ctrl + Alt + Del → Gerenciador de Tarefas",
                    DetailedDescription = "Muito mais que fechar programas travados! Monitore desempenho, veja o que está consumindo recursos e gerencie programas que iniciam com o Windows.",
                    KeyFeatures = new List<string>
                    {
                        "Ver uso de CPU, memória, disco e rede em tempo real",
                        "Fechar programas que travaram",
                        "Gerenciar programas de inicialização (acelera boot)",
                        "Ver histórico de desempenho",
                        "Identificar programas que deixam PC lento",
                        "Encerrar processos em segundo plano"
                    },
                    IconEmoji = "📊",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Relógio mundial com alarmes, timer e cronômetro",
                    AppName = "Relógios",
                    Category = "Utilitários",
                    HowToOpen = "Busque 'Relógios' ou 'Alarmes' no Menu Iniciar",
                    DetailedDescription = "Mais que um simples relógio! Tem fuso horários mundiais, alarmes, timer para pomodoro/cozinha e cronômetro.",
                    KeyFeatures = new List<string>
                    {
                        "Relógio mundial: veja hora em diferentes países",
                        "Alarmes: acorda ou lembra de tarefas",
                        "Timer: técnica pomodoro, cozinhar, exercícios",
                        "Cronômetro: medir tempo de atividades",
                        "Alarmes podem tocar sua música favorita",
                        "Notificações mesmo com o PC em segundo plano"
                    },
                    IconEmoji = "⏰",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Prevê o tempo e mostra mapas de clima",
                    AppName = "Clima",
                    Category = "Informação",
                    HowToOpen = "Busque 'Clima' no Menu Iniciar",
                    DetailedDescription = "Previsão do tempo detalhada com mapas de radar, temperatura por hora e alertas de tempo severo.",
                    KeyFeatures = new List<string>
                    {
                        "Previsão para 10 dias",
                        "Temperatura por hora",
                        "Radar de precipitação",
                        "Qualidade do ar",
                        "Alertas de tempo severo",
                        "Múltiplas localizações salvas",
                        "Informações sobre nascer/pôr do sol"
                    },
                    IconEmoji = "🌤️",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Dicionário de sinônimos, definições e traduções",
                    AppName = "Microsoft Edge (Definições)",
                    Category = "Educação",
                    HowToOpen = "No Edge: Selecione uma palavra → Clique direito → 'Pesquisar definições de...'",
                    DetailedDescription = "Recurso escondido do Edge que funciona como dicionário instantâneo!",
                    KeyFeatures = new List<string>
                    {
                        "Definições de palavras",
                        "Sinônimos e antônimos",
                        "Traduções",
                        "Pronúncia (áudio)",
                        "Exemplos de uso",
                        "Funciona offline após carregar uma vez"
                    },
                    IconEmoji = "📖",
                    IsPreInstalled = true
                },
                new WindowsApp
                {
                    WhatItDoes = "Ferramenta avançada para limpar disco e otimizar espaço",
                    AppName = "Limpeza de Disco",
                    Category = "Sistema",
                    HowToOpen = "Busque 'Limpeza de Disco' no Menu Iniciar",
                    DetailedDescription = "Remove arquivos temporários, cache e lixo que acumulam e ocupam espaço no HD/SSD.",
                    KeyFeatures = new List<string>
                    {
                        "Remove arquivos temporários",
                        "Limpa cache do sistema",
                        "Remove instalações antigas do Windows",
                        "Esvazia lixeira",
                        "Libera espaço de downloads antigos",
                        "Pode liberar vários GB de espaço!"
                    },
                    IconEmoji = "🧹",
                    IsPreInstalled = true
                }
            };
        }

        public List<WindowsTip> GetWindowsTips()
        {
            return new List<WindowsTip>
            {
                new WindowsTip
                {
                    Title = "Desfragmentar e Otimizar Unidades",
                    ShortDescription = "Melhora a velocidade de leitura do HD (não necessário para SSD)",
                    Category = "Desempenho",
                    Steps = new List<string>
                    {
                        "Busque 'Desfragmentar' no Menu Iniciar",
                        "Selecione seu HD (geralmente C:)",
                        "Clique em 'Analisar' para ver se precisa",
                        "Se mais de 10% fragmentado, clique 'Otimizar'",
                        "Configure otimização agendada (recomendado semanal)"
                    },
                    WhyUseful = "HDs ficam fragmentados com o tempo, deixando o PC mais lento. A desfragmentação reorganiza os arquivos para acesso mais rápido. ATENÇÃO: SSDs não devem ser desfragmentados, apenas otimizados (o próprio Windows faz isso automaticamente).",
                    IconEmoji = "⚡"
                },
                new WindowsTip
                {
                    Title = "Modo Noturno (Luz Noturna)",
                    ShortDescription = "Reduz luz azul à noite para não atrapalhar o sono",
                    Category = "Bem-Estar",
                    Steps = new List<string>
                    {
                        "Win + A (abrir Central de Ações)",
                        "Clique no botão 'Luz Noturna'",
                        "Para configurar: Win + I → Sistema → Tela",
                        "Ajuste horário e intensidade da luz noturna",
                        "Pode deixar agendado para ativar automaticamente"
                    },
                    WhyUseful = "A luz azul das telas pode dificultar o sono. O modo noturno deixa a tela mais amarelada/alaranjada após o pôr do sol, reduzindo a luz azul e ajudando você a dormir melhor.",
                    IconEmoji = "🌙"
                },
                new WindowsTip
                {
                    Title = "Modo Foco (Não Perturbe)",
                    ShortDescription = "Silencia notificações para trabalhar com concentração",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Win + A (abrir Central de Ações)",
                        "Clique em 'Foco' ou 'Modo Foco'",
                        "Ou Win + I → Sistema → Modo Foco",
                        "Escolha nível: Somente prioridade, Somente alarmes, ou Desativado",
                        "Configure regras automáticas (ex: ativar durante horário de trabalho)"
                    },
                    WhyUseful = "Notificações constantes quebram sua concentração. O Modo Foco bloqueia tudo exceto o que você definir como prioritário, permitindo trabalho focado.",
                    IconEmoji = "🎯"
                },
                new WindowsTip
                {
                    Title = "Copiar Histórico (Área de Transferência)",
                    ShortDescription = "Acessa múltiplos itens copiados recentemente",
                    Category = "Produtividade",
                    Steps = new List<string>
                    {
                        "Pressione Win + V",
                        "Verá histórico de tudo que copiou recentemente",
                        "Clique no item para colar",
                        "Pode fixar itens usados frequentemente",
                        "Para ativar: Win + I → Sistema → Área de transferência"
                    },
                    WhyUseful = "Normalmente só pode colar a última coisa que copiou. Com isso, pode copiar várias coisas e escolher qual colar depois. Economiza MUITO tempo!",
                    IconEmoji = "📋"
                },
                new WindowsTip
                {
                    Title = "Gravação de Problemas",
                    ShortDescription = "Grava sua tela automaticamente para mostrar problemas técnicos",
                    Category = "Suporte",
                    Steps = new List<string>
                    {
                        "Busque 'psr' no Menu Iniciar",
                        "Abra 'Gravador de Passos'",
                        "Clique em 'Iniciar Gravação'",
                        "Reproduza o problema",
                        "Clique em 'Parar Gravação'",
                        "Salve o arquivo ZIP gerado"
                    },
                    WhyUseful = "Quando tem um problema e precisa explicar para o suporte técnico, em vez de tentar descrever, pode gravar automaticamente todos os passos com screenshots. O Windows gera um arquivo com tudo documentado!",
                    IconEmoji = "📹"
                },
                new WindowsTip
                {
                    Title = "Limpador de Armazenamento",
                    ShortDescription = "Remove arquivos desnecessários automaticamente",
                    Category = "Manutenção",
                    Steps = new List<string>
                    {
                        "Win + I → Sistema → Armazenamento",
                        "Ative 'Sensor de Armazenamento'",
                        "Clique em 'Configurar' para ajustar",
                        "Defina frequência (diária, semanal, mensal)",
                        "Configure o que limpar automaticamente"
                    },
                    WhyUseful = "O Windows acumula arquivos temporários, downloads antigos e lixo. O Sensor de Armazenamento limpa tudo automaticamente sem você precisar lembrar, mantendo seu PC rápido.",
                    IconEmoji = "🧽"
                },
                new WindowsTip
                {
                    Title = "Restauração do Sistema",
                    ShortDescription = "Cria pontos de volta caso algo dê errado",
                    Category = "Segurança",
                    Steps = new List<string>
                    {
                        "Busque 'Criar ponto de restauração' no Menu Iniciar",
                        "Selecione seu disco C: e clique 'Configurar'",
                        "Ative a proteção do sistema",
                        "Clique 'Criar' para fazer um ponto de restauração agora",
                        "Dê um nome descritivo (ex: 'Antes de instalar X')"
                    },
                    WhyUseful = "Se algo der errado (vírus, driver problemático, atualização ruim), pode voltar o sistema para um ponto anterior em que estava funcionando. É como um 'Ctrl+Z' para o Windows inteiro!",
                    IconEmoji = "⏮️"
                },
                new WindowsTip
                {
                    Title = "Senha por Imagem",
                    ShortDescription = "Cria senha com gestos em uma foto",
                    Category = "Segurança",
                    Steps = new List<string>
                    {
                        "Win + I → Contas → Opções de entrada",
                        "Clique em 'Senha de Imagem'",
                        "Escolha uma foto pessoal",
                        "Desenhe 3 gestos na imagem (círculos, linhas, pontos)",
                        "Confirme repetindo os gestos"
                    },
                    WhyUseful = "Mais divertido e rápido que digitar senha! Além disso, é difícil de outras pessoas adivinharem porque só você sabe os gestos e onde fez na imagem.",
                    IconEmoji = "🖼️"
                },
                new WindowsTip
                {
                    Title = "Inverter Rolagem do Mouse",
                    ShortDescription = "Faz o scroll funcionar como em celulares/Mac",
                    Category = "Personalização",
                    Steps = new List<string>
                    {
                        "Win + I → Dispositivos → Mouse",
                        "Role até 'Configurações relacionadas'",
                        "Clique em 'Opções adicionais do mouse'",
                        "Aba 'Roda' → Marque 'Inverter direção'",
                        "Ou busque por 'Scroll natural' nas configurações"
                    },
                    WhyUseful = "Se você usa Mac ou está acostumado com celular, pode achar estranho o scroll do Windows. Inverter faz funcionar de forma mais 'natural' - rolar dedo para cima sobe a página (igual celular).",
                    IconEmoji = "🖱️"
                },
                new WindowsTip
                {
                    Title = "Economia de Bateria Avançada",
                    ShortDescription = "Otimiza configurações para notebooks durarem mais",
                    Category = "Energia",
                    Steps = new List<string>
                    {
                        "Win + I → Sistema → Energia e bateria",
                        "Ative 'Economia de bateria'",
                        "Configure para ativar automaticamente abaixo de 20%",
                        "Clique em 'Uso da bateria' para ver o que consome mais",
                        "Ajuste brilho e feche apps que consomem muito"
                    },
                    WhyUseful = "Notebooks têm bateria limitada. Essas configurações reduzem consumo de energia, fazendo a bateria durar horas a mais. Perfeito para trabalhar longe da tomada!",
                    IconEmoji = "🔋"
                }
            };
        }

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