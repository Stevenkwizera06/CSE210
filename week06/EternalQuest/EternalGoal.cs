using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override void RecordEvent()
        {
            // Eternal goals are never complete, just award points
        }

        public override bool IsComplete()
        {
            return false; // Eternal goals are never complete
        }

        public override string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_shortName},{_description},{_points}";
        }
    }
}
