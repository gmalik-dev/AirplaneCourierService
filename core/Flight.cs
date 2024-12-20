public class Flight : IFlight
{
    public int FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public int Day { get; set; }

    public Flight(int flightNumber, string departureCity, string arrivalCity, int day)
    {
        FlightNumber = flightNumber;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        Day = day;
    }
}
