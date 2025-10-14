using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        public override string GetActivityName()
        {
            return "Swimming";
        }

        public override double GetDistance()
        {
            // 50 meters per lap, convert to miles
            return _laps * 50.0 / 1000.0 * 0.62;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            return (distance / GetMinutes()) * 60.0;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            if (distance == 0) return 0;
            return GetMinutes() / distance;
        }
    }
}


