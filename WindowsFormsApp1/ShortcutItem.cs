using System;

namespace AppInterno.Models
{
    /// <summary>
    /// Modelo base que representa um atalho de teclado
    /// Usado por todos os programas (Windows, Excel, Word, etc)
    /// </summary>
    public class ShortcutItem
    {
        /// <summary>
        /// Identificador único do atalho (ex: "windows_copiar", "excel_soma")
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Programa ao qual pertence (ex: "Windows", "Excel", "Word")
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Título do atalho (ex: "Copiar", "Colar", "Soma Automática")
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição curta do que o atalho faz
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Teclas do atalho (ex: "Ctrl + C", "Alt + =")
        /// </summary>
        public string Keys { get; set; }

        /// <summary>
        /// Categoria do atalho (ex: "Edição", "Navegação", "Formatação")
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Explicação detalhada de como usar
        /// </summary>
        public string DetailedExplanation { get; set; }

        /// <summary>
        /// Quando usar este atalho (dica de uso)
        /// </summary>
        public string WhenToUse { get; set; }

        /// <summary>
        /// Exemplo prático de uso (especialmente útil para Excel)
        /// </summary>
        public string PracticalExample { get; set; }

        /// <summary>
        /// Ação com mouse necessária (para Excel principalmente)
        /// </summary>
        public string MouseAction { get; set; }

        /// <summary>
        /// Score de popularidade (1-5 estrelas)
        /// </summary>
        public int PopularityScore { get; set; }

        /// <summary>
        /// Se requer uso do mouse além do teclado
        /// </summary>
        public bool RequiresMouse { get; set; }

        /// <summary>
        /// Se está marcado como favorito pelo usuário
        /// </summary>
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Última vez que foi visualizado
        /// </summary>
        public DateTime? LastViewed { get; set; }

        /// <summary>
        /// Quantas vezes foi visualizado
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ShortcutItem()
        {
            ViewCount = 0;
            IsFavorite = false;
            RequiresMouse = false;
            PopularityScore = 3;
        }

        /// <summary>
        /// Registra uma visualização deste atalho
        /// </summary>
        public void RegisterView()
        {
            ViewCount++;
            LastViewed = DateTime.Now;
        }

        /// <summary>
        /// Retorna string formatada com estrelas baseado na popularidade
        /// </summary>
        public string GetStarsDisplay()
        {
            return new string('⭐', PopularityScore);
        }
    }
}