using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.NHibernate.Model
{
    public class Book : Entity
    {
        public string Title { get; }
        public virtual Name AuthorName { get; }

        protected Book()
        {
        }

        private Book(string title, Name authorName)
            : this()
        {
            Title = title;
            AuthorName = authorName;
        }

        public static Result<Book> Create(string title, Name authorName)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<Book>("Title should not be empty");

            title = title.Trim();

            if (title.Length > 500)
                return Result.Failure<Book>("Title is too long");

            return Result.Success(new Book(title, authorName));
        }
    }
}
