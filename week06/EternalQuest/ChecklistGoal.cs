using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            _amountCompleted++;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName}: {_description} -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public int GetAmountCompleted()
        {
            return _amountCompleted;
        }

        public int GetTarget()
        {
            return _target;
        }
    }
}
