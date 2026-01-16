namespace TraversalReservation.CQRS.Result.DestinationResult
{
    public class GetDestinationByIDQueryResult
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayAndNight { get; set; }
        public decimal Price { get; set; }
    }
}
