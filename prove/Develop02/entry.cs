namespace JournalApp
{
    class Entry
    {
        public string Date { get; }
        public string Prompt { get; }
        public string Response { get; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }

        public string ToCsv()
        {
            return $"{Date}~|~{Prompt}~|~{Response}";
        }

        public static Entry FromCsv(string csvLine)
        {
            string[] parts = csvLine.Split(new[] { "~|~" }, StringSplitOptions.None);
            return new Entry(parts[0], parts[1], parts[2]);
        }
    }
}
