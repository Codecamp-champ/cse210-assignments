using System;

namespace ExerciseTracking
{
    // Running class
    public class Running : Activity
    {
        private double _distance;

        public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / DurationMinutes) * 60.0;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return distance > 0 ? DurationMinutes / distance : 0;
        }
    }
}