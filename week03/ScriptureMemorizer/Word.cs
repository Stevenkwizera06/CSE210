using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a single word in a scripture with the ability to be shown or hidden.
    /// When hidden, the word is replaced with underscores matching the letter count.
    /// </summary>
    public class Word
    {
        private string _text;
        private bool _isHidden;

        /// <summary>
        /// Constructor for a word
        /// </summary>
        /// <param name="text">The text of the word</param>
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        /// <summary>
        /// Gets the display text for this word (either the actual text or underscores)
        /// </summary>
        /// <returns>The display text</returns>
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            else
            {
                return _text;
            }
        }

        /// <summary>
        /// Hides the word by setting the hidden state to true
        /// </summary>
        public void Hide()
        {
            _isHidden = true;
        }

        /// <summary>
        /// Shows the word by setting the hidden state to false
        /// </summary>
        public void Show()
        {
            _isHidden = false;
        }

        /// <summary>
        /// Gets whether the word is currently hidden
        /// </summary>
        public bool IsHidden => _isHidden;

        /// <summary>
        /// Gets the original text of the word
        /// </summary>
        public string Text => _text;

        /// <summary>
        /// Gets the length of the word
        /// </summary>
        public int Length => _text.Length;
    }
}
