using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        protected Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        protected int GetMinutes()
        {
            return _minutes;
        }

        public abstract string GetActivityName();
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            string dateStr = _date.ToString("dd MMM yyyy");
            return $"{dateStr} {GetActivityName()} ({_minutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
        }
    }
}


