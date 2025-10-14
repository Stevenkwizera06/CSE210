using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distanceMiles;

        public Running(DateTime date, int minutes, double distanceMiles) : base(date, minutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override string GetActivityName()
        {
            return "Running";
        }

        public override double GetDistance()
        {
            return _distanceMiles;
        }

        public override double GetSpeed()
        {
            return (_distanceMiles / GetMinutes()) * 60.0;
        }

        public override double GetPace()
        {
            if (_distanceMiles == 0) return 0;
            return GetMinutes() / _distanceMiles;
        }
    }
}


