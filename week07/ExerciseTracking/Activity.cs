using System;

namespace ExerciseTracking
{
    // Base Activity class
    public abstract class Activity
    {
        private DateTime _date;
        private int _durationMinutes;

        public Activity(DateTime date, int durationMinutes)
        {
            _date = date;
            _durationMinutes = durationMinutes;
        }

        public DateTime Date => _date;
        public int DurationMinutes => _durationMinutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();
            string unit = UseMiles ? "miles" : "km";
            string speedUnit = UseMiles ? "mph" : "kph";
            string paceUnit = UseMiles ? "min per mile" : "min per km";

            return $"{_date:dd MMM yyyy} {GetType().Name} ({_durationMinutes} min) - " +
                   $"Distance: {distance:F1} {unit}, " +
                   $"Speed: {speed:F1} {speedUnit}, " +
                   $"Pace: {pace:F2} {paceUnit}";
        }

        // Choose your unit system (true for miles, false for kilometers)
        protected const bool UseMiles = true;
    }
}