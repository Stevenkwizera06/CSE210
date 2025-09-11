using System;
using System.Collections.Generic;

namespace JournalApp;

public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small win I had today?",
        "What did I learn today?",
        "What am I grateful for today?",
        "What challenged me today and how did I respond?",
        "What is one step I can take tomorrow?"
    };

    private readonly Random _random = new();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}


