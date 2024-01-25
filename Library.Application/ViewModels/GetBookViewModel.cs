using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class GetBookViewModel
    {
        public GetBookViewModel(int id, string title, string author, string isbn, DateTime publicationDate, List<LoansViewModel> loans)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationDate = publicationDate;
            Loans = loans;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public DateTime PublicationDate { get; private set; }
        public List<LoansViewModel> Loans { get; private set; }
    }
}
