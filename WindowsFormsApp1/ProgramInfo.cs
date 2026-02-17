using System;

namespace AppInterno
{
    /// <summary>
    /// Representa informações sobre um programa/aplicativo
    /// Usado para exibir os cards na tela de seleção
    /// </summary>
    public class ProgramInfo
    {
        /// <summary>
        /// Identificador do programa (ex: "windows", "excel", "word")
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nome de exibição (ex: "Windows", "Excel", "Word")
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Descrição curta (ex: "Atalhos do sistema operacional")
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Emoji/ícone para exibir (ex: "⌨️", "📊", "📝")
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Cor principal do programa (em hexadecimal)
        /// </summary>
        public string ColorHex { get; set; }

        /// <summary>
        /// Total de atalhos disponíveis
        /// </summary>
        public int TotalShortcuts { get; set; }

        /// <summary>
        /// Quantos atalhos estão marcados como favoritos
        /// </summary>
        public int FavoritesCount { get; set; }

        /// <summary>
        /// Se o programa está disponível (ou "Em breve")
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Ordem de exibição (menor = aparece primeiro)
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ProgramInfo()
        {
            IsAvailable = true;
            DisplayOrder = 999;
            FavoritesCount = 0;
        }

        /// <summary>
        /// Retorna informação formatada de atalhos
        /// </summary>
        public string GetShortcutsInfo()
        {
            if (!IsAvailable)
                return "Em breve...";

            if (FavoritesCount > 0)
                return $"{TotalShortcuts} atalhos • ⭐ {FavoritesCount} favoritos";

            return $"{TotalShortcuts} atalhos disponíveis";
        }
    }
}