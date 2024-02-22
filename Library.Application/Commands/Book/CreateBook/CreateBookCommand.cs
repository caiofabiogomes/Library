using Library.Application.Abstractions;
using MediatR;

namespace Library.Application.Commands.Book.CreateBook
{
    public class CreateBookCommand : IRequest<Result<Unit>>
    {
        public CreateBookCommand(string title, string author, string iSBN, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationDate = publicationDate;
        }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public DateTime PublicationDate { get; private set; }
    }
}
