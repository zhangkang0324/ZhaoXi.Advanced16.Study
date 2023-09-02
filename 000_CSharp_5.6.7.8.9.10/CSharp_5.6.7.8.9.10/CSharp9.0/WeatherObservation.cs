namespace CSharp_5._6._7._8._9._10.CSharp9._0
{
    public struct WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }
}
