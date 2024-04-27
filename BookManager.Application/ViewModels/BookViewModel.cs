using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, int yearPublished)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublished = yearPublished;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public int YearPublished { get; private set; }
    }
}
