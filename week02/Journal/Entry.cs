using System;

namespace JournalApp;

public class Entry
{
    public string DateText { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string dateText, string prompt, string response)
    {
        DateText = dateText;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"[{DateText}] {Prompt}\n{Response}";
    }
}


