using System;
using System.Collections.Generic;

namespace AppInterno
{
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

    public class WindowsApp
    {
        public string WhatItDoes { get; set; } // DescriBção do que faz (mostrado primeiro)
        public string AppName { get; set; } // Nome real do app (revelado ao clicar)
        public string Category { get; set; }
        public string HowToOpen { get; set; }
        public string DetailedDescription { get; set; }
        public List<string> KeyFeatures { get; set; }
        public string IconEmoji { get; set; }
        public bool IsPreInstalled { get; set; }
    }

    public class WindowsTip
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public List<string> Steps { get; set; }
        public string WhyUseful { get; set; }
        public string IconEmoji { get; set; }
    }

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