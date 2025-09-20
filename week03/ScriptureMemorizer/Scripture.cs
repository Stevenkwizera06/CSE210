using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a complete scripture with reference and text, managing word hiding functionality.
    /// </summary>
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        /// <summary>
        /// Constructor for a scripture
        /// </summary>
        /// <param name="reference">The scripture reference</param>
        /// <param name="text">The scripture text</param>
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();
            
            // Split the text into words and create Word objects
            string[] wordStrings = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string wordString in wordStrings)
            {
                _words.Add(new Word(wordString));
            }
        }

        /// <summary>
        /// Gets the display text for the entire scripture (reference + text with hidden words)
        /// </summary>
        /// <returns>The formatted scripture display text</returns>
        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();
            string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{referenceText} {scriptureText}";
        }

        /// <summary>
        /// Hides a random number of words (3-5 words) that are not already hidden
        /// </summary>
        public void HideRandomWords()
        {
            // Get all words that are not hidden
            var visibleWords = _words.Where(word => !word.IsHidden).ToList();
            
            if (visibleWords.Count == 0)
                return;

            // Determine how many words to hide (3-5, or all remaining if less than 3)
            int wordsToHide = Math.Min(_random.Next(3, 6), visibleWords.Count);
            
            // Hide random words
            for (int i = 0; i < wordsToHide; i++)
            {
                int randomIndex = _random.Next(visibleWords.Count);
                visibleWords[randomIndex].Hide();
                visibleWords.RemoveAt(randomIndex);
            }
        }

        /// <summary>
        /// Checks if all words in the scripture are hidden
        /// </summary>
        /// <returns>True if all words are hidden, false otherwise</returns>
        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden);
        }

        /// <summary>
        /// Gets the reference of this scripture
        /// </summary>
        public Reference Reference => _reference;

        /// <summary>
        /// Gets the number of words in this scripture
        /// </summary>
        public int WordCount => _words.Count;

        /// <summary>
        /// Gets the number of visible (not hidden) words
        /// </summary>
        public int VisibleWordCount => _words.Count(word => !word.IsHidden);

        /// <summary>
        /// Resets all words to be visible (for testing or restarting)
        /// </summary>
        public void ShowAllWords()
        {
            foreach (var word in _words)
            {
                word.Show();
            }
        }
    }
}
