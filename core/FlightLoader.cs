public class FlightLoader
{
    public List<Flight> LoadFlightSchedule()
    {
        var flights = new List<Flight>();

        flights.Add(new Flight(1, "YUL", "YYZ", 1));
        flights.Add(new Flight(2, "YUL", "YYC", 1));
        flights.Add(new Flight(3, "YUL", "YVR", 1));
        flights.Add(new Flight(4, "YUL", "YYZ", 2));
        flights.Add(new Flight(5, "YUL", "YYC", 2));
        flights.Add(new Flight(6, "YUL", "YVR", 2));

        return flights;
    }
}