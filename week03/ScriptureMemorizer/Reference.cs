using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture reference that can handle both single verses and verse ranges.
    /// Examples: "John 3:16" or "Proverbs 3:5-6"
    /// </summary>
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;
        private bool _isRange;

        /// <summary>
        /// Constructor for a single verse reference (e.g., "John 3:16")
        /// </summary>
        /// <param name="book">The book name</param>
        /// <param name="chapter">The chapter number</param>
        /// <param name="verse">The verse number</param>
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
            _isRange = false;
        }

        /// <summary>
        /// Constructor for a verse range reference (e.g., "Proverbs 3:5-6")
        /// </summary>
        /// <param name="book">The book name</param>
        /// <param name="chapter">The chapter number</param>
        /// <param name="startVerse">The starting verse number</param>
        /// <param name="endVerse">The ending verse number</param>
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
            _isRange = true;
        }

        /// <summary>
        /// Gets the formatted reference string
        /// </summary>
        /// <returns>A formatted reference string</returns>
        public string GetDisplayText()
        {
            if (_isRange)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }

        /// <summary>
        /// Gets the book name
        /// </summary>
        public string Book => _book;

        /// <summary>
        /// Gets the chapter number
        /// </summary>
        public int Chapter => _chapter;

        /// <summary>
        /// Gets the start verse number
        /// </summary>
        public int StartVerse => _startVerse;

        /// <summary>
        /// Gets the end verse number
        /// </summary>
        public int EndVerse => _endVerse;

        /// <summary>
        /// Gets whether this is a verse range
        /// </summary>
        public bool IsRange => _isRange;
    }
}
