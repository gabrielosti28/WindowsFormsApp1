using System;

namespace AppInterno
{
    public class DriverInfo
    {
        public string DeviceName { get; set; }
        public string Category { get; set; }
        public string DriverVersion { get; set; }
        public string DriverProvider { get; set; }
        public DateTime? DriverDate { get; set; }
        public string Status { get; set; } // OK, Atenção, Problema, Desatualizado
        public string StatusDescription { get; set; }
        public bool IsSigned { get; set; }
        public string UpdateUrl { get; set; }
        public string Recommendation { get; set; }
        public int DaysOld { get; set; }
        public string FriendlyExplanation { get; set; }
        public DriverPriority Priority { get; set; }
    }

    public enum DriverPriority
    {
        Critical,    // GPU, Chipset, Storage
        Important,   // Network, Audio
        Normal       // Outros
    }

    public class DriverAnalysisResult
    {
        public int TotalDrivers { get; set; }
        public int DriversOK { get; set; }
        public int DriversOutdated { get; set; }
        public int DriversWithProblems { get; set; }
        public int DriversMissing { get; set; }
        public string OverallHealth { get; set; } // Excelente, Bom, Precisa Atenção, Crítico
        public string HealthDescription { get; set; }
        public System.Drawing.Color HealthColor { get; set; }
    }
}