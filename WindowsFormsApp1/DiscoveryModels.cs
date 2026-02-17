using System;
using System.Collections.Generic;

namespace AppInterno
{
    /// <summary>
    /// Modelo para atalhos de teclado do Windows
    /// NOTA: ShortcutItem.cs é o modelo unificado preferido
    /// Este é mantido para compatibilidade legacy
    /// </summary>
    public class KeyboardShortcut
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keys { get; set; }
        public string Category { get; set; }
        public string DetailedExplanation { get; set; }
        public string WhenToUse { get; set; }
        public int PopularityScore { get; set; } // 1-5
    }

    /// <summary>
    /// Modelo para aplicativos nativos do Windows
    /// </summary>
    public class WindowsApp
    {
        public string WhatItDoes { get; set; } // Descrição do que faz (mostrado primeiro)
        public string AppName { get; set; } // Nome real do app (revelado ao clicar)
        public string Category { get; set; }
        public string HowToOpen { get; set; }
        public string DetailedDescription { get; set; }
        public List<string> KeyFeatures { get; set; }
        public string IconEmoji { get; set; }
        public bool IsPreInstalled { get; set; }
    }

    /// <summary>
    /// Modelo para dicas e truques do Windows
    /// </summary>
    public class WindowsTip
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public List<string> Steps { get; set; }
        public string WhyUseful { get; set; }
        public string IconEmoji { get; set; }
    }

    /// <summary>
    /// Modelo para atalhos do Excel
    /// NOTA: ShortcutItem.cs é o modelo unificado preferido
    /// Este é mantido para compatibilidade legacy
    /// </summary>
    public class ExcelShortcut
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keys { get; set; }
        public string MouseAction { get; set; } // Para ações com mouse
        public string Category { get; set; }
        public string DetailedExplanation { get; set; }
        public string WhenToUse { get; set; }
        public string PracticalExample { get; set; }
        public int PopularityScore { get; set; } // 1-5
        public bool RequiresMouse { get; set; } // Se precisa de mouse além do teclado
    }
}