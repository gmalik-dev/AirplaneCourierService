class Program
{
    static void Main(string[] args)
    {
        
        var flightLoader = new FlightLoader();
        var flightInfoDisplay = new FlightInfoDisplay(flightLoader);
        var flightScheduler = new FlightScheduler(flightLoader);
        string jsonFilePath = "data/AssignmentOrders.json"; 

        // Display the flight schedule
        Console.WriteLine("Flight Schedule:");
        flightInfoDisplay.DisplayFlightInfo();

         // Display the Scheduled orders
        Console.WriteLine("\nScheduled Orders:");
        flightScheduler.ScheduleOrders(jsonFilePath);
    }
}