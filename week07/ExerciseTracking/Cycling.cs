using System;

namespace ExerciseTracking
{
    // Cycling class
    public class Cycling : Activity
    {
        private double _speed; // Speed in mph or kph

        public Cycling(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * DurationMinutes) / 60.0;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return distance > 0 ? DurationMinutes / distance : 0;
        }
    }
}