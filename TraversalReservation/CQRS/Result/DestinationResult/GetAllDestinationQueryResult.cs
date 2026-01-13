namespace TraversalReservation.CQRS.Result.DestinationResult
{
    public class GetAllDestinationQueryResult
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayAndNight { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
