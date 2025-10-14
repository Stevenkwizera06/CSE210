using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speedMph;

        public Cycling(DateTime date, int minutes, double speedMph) : base(date, minutes)
        {
            _speedMph = speedMph;
        }

        public override string GetActivityName()
        {
            return "Cycling";
        }

        public override double GetDistance()
        {
            return _speedMph * (GetMinutes() / 60.0);
        }

        public override double GetSpeed()
        {
            return _speedMph;
        }

        public override double GetPace()
        {
            if (_speedMph == 0) return 0;
            return 60.0 / _speedMph;
        }
    }
}


