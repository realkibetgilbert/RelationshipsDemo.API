namespace RelationshipsDemo.API.Core.Models
{
    public class Publisher
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //navigatoon

        public Author Author { get; set; }

        public long AuthorId { get;set; }


        public ICollection<BookPublisher> BookPublishers { get; set; }

    }
}
