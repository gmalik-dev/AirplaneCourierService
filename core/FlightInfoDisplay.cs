public class FlightInfoDisplay
{
    public List<Flight> Flights { get; set; }

    public FlightInfoDisplay(FlightLoader flightLoader)
    {
        Flights = flightLoader.LoadFlightSchedule(); 
    }

    public void DisplayFlightInfo ()
    {
        foreach (var flight in Flights)
        {
           Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
        }
    }
}