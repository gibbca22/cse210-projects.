using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Journal
    {
        private List<Entry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        public void WriteNewEntry()
        {
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            string prompt = prompts[index];
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            entries.Add(new Entry(date, prompt, response));
        }

        public void DisplayJournal()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveJournalToFile()
        {
            Console.Write("Enter filename to save to: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToCsv());
                }
            }
        }

        public void LoadJournalFromFile()
        {
            Console.Write("Enter filename to load from: ");
            string filename = Console.ReadLine();
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    entries.Add(Entry.FromCsv(line));
                }
            }
        }
    }
}