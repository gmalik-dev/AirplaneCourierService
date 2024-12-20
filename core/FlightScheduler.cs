using System.Text.Json;

public class FlightScheduler
{
    public List<Flight> Flights { get; set; }
   
    public Dictionary<string, Dictionary<string, string>> ordersData = [];

    public FlightScheduler(FlightLoader flightLoader)
    {
        Flights = flightLoader.LoadFlightSchedule(); 
    }

    public void ScheduleOrders(string jsonFilePath)
    {
        var ordersJson = File.ReadAllText(jsonFilePath);
#pragma warning disable CS8601 // Possible null reference assignment.
        ordersData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(ordersJson);
#pragma warning restore CS8601 // Possible null reference assignment.
        if (ordersData == null)
        {
            Console.WriteLine("Deserialization failed. The dictionary is null.");
        }
        else
        {
            int boxesLoaded = 0;
            var orderAssignments = new Dictionary<string, Flight>();

            foreach (var flight in Flights)
            {
                boxesLoaded = 0; 

                foreach (var order in ordersData)
                {
                    var orderDestination = order.Value["destination"];
                    var orderId = order.Key;
                    if (boxesLoaded < 20 && orderDestination == flight.ArrivalCity && !orderAssignments.ContainsKey(orderId))
                    {
                        orderAssignments[orderId] = flight;
                        boxesLoaded++;
                    }
                }
            }

            foreach (var order in ordersData)
            {
                var orderId = order.Key;
                Flight assignedFlight = null;

                if (orderAssignments.ContainsKey(orderId))
                {
                    assignedFlight = orderAssignments[orderId];
                    Console.WriteLine($"order: {orderId}, flightNumber: {assignedFlight.FlightNumber}, departure: {assignedFlight.DepartureCity}, arrival: {assignedFlight.ArrivalCity}, day: {assignedFlight.Day}");
                }
                else
                {
                    Console.WriteLine($"order: {orderId}, flightNumber: not scheduled");
                }
            }
        }
    }

}
