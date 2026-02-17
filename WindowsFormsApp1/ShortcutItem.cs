namespace AppInterno.Models
{
    public class ShortcutItem
    {
        public string Id { get; set; }
        public string Program { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keys { get; set; }
        public string Category { get; set; }
        public string DetailedExplanation { get; set; }
        public string WhenToUse { get; set; }
        public string PracticalExample { get; set; }
        public int PopularityScore { get; set; }
        public bool RequiresMouse { get; set; }
    }
}