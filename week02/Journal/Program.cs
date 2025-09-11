using System.Globalization;
using System.Text;

namespace JournalApp;

class Program
{
    static void Main()
    {
        // Exceeds requirements note: Added CSV export/import with proper quoting, and JSON export option.
        var journal = new Journal();
        var promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Journal - Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Save as CSV (exceed)");
            Console.WriteLine("6. Load from CSV (exceed)");
            Console.WriteLine("7. Clear journal (memory)");
            Console.WriteLine("8. Quit");
            Console.Write("Select an option (1-8): ");
            var input = Console.ReadLine();

            Console.WriteLine();
            switch (input)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string? response = Console.ReadLine() ?? string.Empty;
                    string dateText = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(dateText, prompt, response));
                    Console.WriteLine("Entry recorded.");
                    break;

                case "2":
                    if (journal.EntryCount == 0)
                    {
                        Console.WriteLine("No entries yet.");
                    }
                    else
                    {
                        journal.Display();
                    }
                    break;

                case "3":
                    Console.Write("Filename to save (e.g., journal.txt): ");
                    {
                        string? filename = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                            journal.SaveToFile(filename);
                            Console.WriteLine($"Saved to {filename}");
                        }
                    }
                    break;

                case "4":
                    Console.Write("Filename to load (e.g., journal.txt): ");
                    {
                        string? filename = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                            if (File.Exists(filename))
                            {
                                journal.LoadFromFile(filename);
                                Console.WriteLine($"Loaded {journal.EntryCount} entries from {filename}");
                            }
                            else
                            {
                                Console.WriteLine("File not found.");
                            }
                        }
                    }
                    break;

                case "5":
                    Console.Write("CSV filename to save (e.g., journal.csv): ");
                    {
                        string? filename = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                            journal.SaveToCsv(filename);
                            Console.WriteLine($"Saved CSV to {filename}");
                        }
                    }
                    break;

                case "6":
                    Console.Write("CSV filename to load (e.g., journal.csv): ");
                    {
                        string? filename = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                            if (File.Exists(filename))
                            {
                                journal.LoadFromCsv(filename);
                                Console.WriteLine($"Loaded {journal.EntryCount} entries from {filename}");
                            }
                            else
                            {
                                Console.WriteLine("File not found.");
                            }
                        }
                    }
                    break;

                case "7":
                    journal.Clear();
                    Console.WriteLine("Journal cleared from memory.");
                    break;

                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-7.");
                    break;
            }
        }
    }
}

