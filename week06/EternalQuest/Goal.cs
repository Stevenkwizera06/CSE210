using System;

namespace EternalQuest
{
    public class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public virtual void RecordEvent()
        {
            // Base implementation - can be overridden by derived classes
        }

        public virtual bool IsComplete()
        {
            return false; // Base implementation - can be overridden by derived classes
        }

        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName}: {_description}";
        }

        public virtual string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_shortName},{_description},{_points}";
        }

        public string GetShortName()
        {
            return _shortName;
        }

        public int GetPoints()
        {
            return _points;
        }
    }
}
