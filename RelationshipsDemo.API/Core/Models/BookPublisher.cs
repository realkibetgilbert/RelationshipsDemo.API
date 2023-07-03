namespace RelationshipsDemo.API.Core.Models
{
    public class BookPublisher
    {
        public Book Book { get; set; }

        public long BookId { get; set; }    

        public Publisher Publisher { get; set; }

        public long PublisherId { get; set;}
    }
}
