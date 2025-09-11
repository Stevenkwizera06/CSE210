using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JournalApp;

public class Journal
{
    private const string Separator = "~|~"; // Unlikely to appear in text
    private readonly List<Entry> _entries = new();

    public int EntryCount => _entries.Count;

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Clear()
    {
        _entries.Clear();
    }

    public void Display()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry {i + 1}:");
            Console.WriteLine(_entries[i]);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using var output = new StreamWriter(filename, false, Encoding.UTF8);
        foreach (var entry in _entries)
        {
            // date ~|~ prompt ~|~ response
            output.WriteLine(string.Join(Separator, new[] { entry.DateText, entry.Prompt, entry.Response }));
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        if (!File.Exists(filename)) return;
        var lines = File.ReadAllLines(filename, Encoding.UTF8);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(Separator);
            if (parts.Length >= 3)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }

    // Exceed: CSV support with proper quoting
    public void SaveToCsv(string filename)
    {
        using var output = new StreamWriter(filename, false, Encoding.UTF8);
        output.WriteLine("Date,Prompt,Response");
        foreach (var e in _entries)
        {
            output.WriteLine(string.Join(',', new[] { CsvEscape(e.DateText), CsvEscape(e.Prompt), CsvEscape(e.Response) }));
        }
    }

    public void LoadFromCsv(string filename)
    {
        _entries.Clear();
        using var reader = new StreamReader(filename, Encoding.UTF8);
        string? header = reader.ReadLine();
        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;
            var fields = ParseCsvLine(line);
            if (fields.Count >= 3)
            {
                _entries.Add(new Entry(fields[0], fields[1], fields[2]));
            }
        }
    }

    private static string CsvEscape(string text)
    {
        bool mustQuote = text.Contains('"') || text.Contains(',') || text.Contains('\n') || text.Contains('\r');
        string escaped = text.Replace("\"", "\"\"");
        return mustQuote ? $"\"{escaped}\"" : escaped;
    }

    private static List<string> ParseCsvLine(string line)
    {
        var fields = new List<string>();
        var sb = new StringBuilder();
        bool inQuotes = false;
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            else
            {
                if (c == ',')
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else
                {
                    sb.Append(c);
                }
            }
        }
        fields.Add(sb.ToString());
        return fields;
    }
}


