namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
        }
        public Book(string title, string author, string isbn, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationDate = publicationDate;
            Loans = new List<Loan>();
        }
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public DateTime PublicationDate { get; private set; }

        public List<Loan> Loans { get; private set; }

    }
}
