using Microsoft.Identity.Client;

namespace RelationshipsDemo.API.Core.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //navigation propert
        public Publisher Publisher { get; set; }

        public long PublisherId { get; set; }

        //authoer many books

        public ICollection<Book> Books { get; set; }
    }
}
