namespace TraversalReservation.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int ıd)
        {
            this.ıd = ıd;
        }

        public int ıd { get; set; }
    }
}
