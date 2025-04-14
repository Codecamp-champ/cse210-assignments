using System;

namespace ExerciseTracking
{
    // Swimming class
    public class Swimming : Activity
    {
        private int _laps;
        private const double _lapDistanceMeters = 50.0;

        public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            double distanceKm = _laps * _lapDistanceMeters / 1000.0;
            return UseMiles ? distanceKm * 0.62 : distanceKm;
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